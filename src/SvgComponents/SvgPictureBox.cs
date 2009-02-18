using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;

using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;
using System.Reflection;
using System.Text;
using System.Security;
using System.Security.Permissions;

using SharpVectors.Dom.Events;
using SharpVectors.Dom.Svg;
using SharpVectors.Xml;
using SharpVectors.Renderer.Gdi;
using SharpVectors.Renderer;
using SharpVectors.Dom.Svg.Rendering;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Scripting;
using SharpVectors.Collections;
using SharpVectors.Net;

using System.Threading;

[assembly: AllowPartiallyTrustedCallers]  

namespace SvgComponents
{
  public class SvgPictureBox : System.Windows.Forms.Control
  {
    private static readonly string UserAgentCssFileName = "useragent.css";
    private static readonly string UserCssFileName = "user.css";

    private GdiRenderer renderer;

    #region Constructors
    public SvgPictureBox()
    {
      InitializeComponent();

      SetStyle(ControlStyles.UserPaint, true);
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.DoubleBuffer, true);

      scriptEngineByMimeType = new TypeDictionary();
      SetMimeTypeEngineType("application/ecmascript", typeof(JScriptEngine));
      
      renderer = new GdiRenderer();
      renderer.OnRender = new RenderEvent(this.OnRender);
      window = new SvgWindow(this, renderer);
    }
    #endregion

    #region Events
    public void OnRender(RectangleF updatedRect) 
    {
      if (surface != null) 
      {
        if (updatedRect == RectangleF.Empty) 
          Draw(surface);        
        else  
          Draw(surface, updatedRect);
      }
      else 
      {
        surface = CreateGraphics();
        if (updatedRect == RectangleF.Empty) 
          Draw(surface);        
        else  
          Draw(surface, updatedRect);
        surface.Dispose();
        surface = null;
      }

      // Collect the rendering regions for later updates
      SvgDocument doc = (window.Document as SvgDocument);
      SvgElement root = (doc.RootElement as SvgElement);
      //root.CacheRenderingRegion(renderer);
    }

    private int lastX = -1;
    private int lastY = -1;
    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (lastX == e.X && lastY == e.Y) return;
      lastX = e.X;
      lastY = e.Y;
      renderer.OnMouseEvent("mousemove", e);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      renderer.OnMouseEvent("mousedown", e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      renderer.OnMouseEvent("mouseup", e);
    }
    #endregion

    #region Private fields
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components = null;
    private SvgWindow window;
    private bool autoSize = false;
    private bool loaded = false;

    //private Thread renderThread;
    #endregion

    #region Public properties
    /// <summary>
    /// Source URL for the Svg Content
    /// </summary>
    [Category("Data")]
    [DefaultValue("")]
    [Description("The URL of the document currently being display in this SvgPictureBox")]
    public string SourceURL
    {
      get
      {
        return window.Src;
      }
      set
      {
        Load(value);
      }
    }

    /// <summary>
    /// Return current SvgWindow used by this control
    /// </summary>
    [Category("Data")]
    [DefaultValue("")]
    [Description("The Window Interface connected to the SvgPictureBox")]
    public ISvgWindow Window
    {
      get
      {
        return window;
      }
    }

    /// <summary>
    /// Forces the component to autosize to fit the svg
    /// </summary>
    public bool AutoSize 
    {
      get 
      {
        return autoSize;
      }
      set 
      {
        autoSize = value;
      }
    }
    #endregion

    #region Public methods
    public void Load(string value) 
    {
#if RELEASE
		    try
			  {
#endif
        
      // Worry about clearing the graphics nodes map...
      renderer.ClearMap();
      System.GC.Collect();
      System.Threading.Thread.Sleep(1);

      if(value != null && value.Length > 0)
      {
        // Load the source
        window.Src = value;
        // Initialize the style sheets
        SetupStyleSheets();
        // Execute all script elements
        UnloadEngines();
        InitializeEvents();        
        ExecuteScripts();
        //JR
        if (autoSize) 
        {
          ISvgSvgElement svgEl = window.Document.RootElement;          
          this.Width = (int)svgEl.Width.BaseVal.Value;
          this.Height = (int)svgEl.Height.BaseVal.Value;
        }
        renderer.InvalidRect = RectangleF.Empty;
        Render();
        loaded = true;
      }
      
#if RELEASE
        }
			  catch(Exception e)
		  	{
			  	MessageBox.Show("An error occured while loading the document.\n" + e.Message);
		    }
#endif
    }
    
    public void LoadXml(string xml) 
    {
#if RELEASE
		  try
			{
#endif
      // Worry about clearing the graphics nodes map...
      renderer.ClearMap();
      System.GC.Collect();
      System.Threading.Thread.Sleep(1);

      if(xml != null && xml.Length > 0)
      {
        if(xml != null && xml.Length > 0)
        {
          SvgDocument doc = window.CreateEmptySvgDocument();
          doc.LoadXml(xml);
          window.Document = doc;
          SetupStyleSheets();
          //JR
          if (autoSize) 
          {
            ISvgRect r = window.Document.RootElement.GetBBox();
            this.Width = (int)r.Width;
            this.Height = (int)r.Height;
          }
          Render();
          loaded = true;
        }
      }
#if RELEASE
			}
			catch(Exception e)
			{
				MessageBox.Show("An error occured while loading the document.\n" + e.Message);
		  }
#endif
    }

    public void Render() 
    {
      if ( this.window != null ) 
      {
        renderAndInvalidate();
      }
    }

    public void Update(RectangleF rect) 
    {
      if ( this.window != null ) 
      {
        updateAndInvalidate(rect);
      }
    }

    public void CacheRenderingRegions() 
    {
      // Collect the rendering regions for later updates
      System.Threading.Thread.Sleep(1);
      SvgDocument doc = (window.Document as SvgDocument);
      SvgElement root = (doc.RootElement as SvgElement);
      root.CacheRenderingRegion(renderer);
    }

    private Graphics surface;
    public Graphics Surface 
    {
      get { return surface; }
      set { surface = value; }
    }
       
    public RectangleF InvalidRect 
    {
      get { return renderer.InvalidRect; }
    }
              
    /// <summary>
    /// Create an empty SvgDocument and GdiRenderer for this control.  The empty SvgDocument is returned.  This method is needed only in situations where the library user needs to create an SVG DOM tree outside of the usual window Src setting mechanism.
    /// </summary>
    public SvgDocument CreateEmptySvgDocument()
    {
      SvgDocument svgDocument = window.CreateEmptySvgDocument();
      SetupStyleSheets();

      return svgDocument;
    }
    #endregion
		
    #region Protected methods
    private void renderAndInvalidate()
    {
#if RELEASE
			try
			{
#endif
      renderer.Render(window.Document as SvgDocument);

#if RELEASE	
			}
			catch(Exception e)
			{
				MessageBox.Show("An exception occured while rendering: " + e.Message);
			}
#endif
    }

    private void updateAndInvalidate(RectangleF rect)
    {
      renderer.InvalidateRect(rect);
      renderAndInvalidate();
    }

    public void DrawTo(IntPtr hdc) 
    {
      if ( !this.DesignMode )
      {
        if ( window != null )
        {
          GraphicsWrapper gw = GraphicsWrapper.FromHdc(hdc, true);
          GdiRenderer r = ((GdiRenderer)window.Renderer);
          gw.Clear(r.BackColor);
          r.GraphicsWrapper = gw;
          window.Renderer.Render((SvgDocument)window.Document);
          r.GraphicsWrapper = null;
          gw.Dispose();
        }
      }
    }

    public void Draw(Graphics gr)
    {
      if ( !this.DesignMode ) 
      {
        if ( window != null )
        {
          Bitmap rasterImage = ((GdiRenderer) window.Renderer).RasterImage;

          if ( rasterImage != null )
          {
            gr.DrawImage(rasterImage, 0, 0, rasterImage.Width, rasterImage.Height);
          }
        }
      }
    }

    public void Draw(Graphics gr, int offsetX, int offsetY)
    {
      if ( !this.DesignMode ) 
      {
        if ( window != null )
        {
          Bitmap rasterImage = ((GdiRenderer) window.Renderer).RasterImage;

          if ( rasterImage != null )
          {
            gr.DrawImage(rasterImage, offsetX, offsetY, rasterImage.Width, rasterImage.Height);
          }
        }
      }
    }

    public void Draw(Graphics gr, RectangleF rect)
    {
       if ( !this.DesignMode ) 
      {
        if ( window != null )
        {
          Bitmap rasterImage = ((GdiRenderer) window.Renderer).RasterImage;

          if ( rasterImage != null )
          {
            gr.DrawImage(rasterImage, rect, rect, GraphicsUnit.Pixel);
          }
        }
      }
    }

    protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
    {
      if (surface != null) 
      {
        Draw(surface);
      }
      else
        Draw(e.Graphics);
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);	
      if (loaded) 
      {
        // Worry about clearing the graphics nodes map...
        System.GC.Collect();
        System.Threading.Thread.Sleep(1);

        (window as SvgWindow).Resize(this.Width, this.Height);
        renderAndInvalidate();
      }
    }

    /// <summary>
    /// Loads the default user and agent stylesheets into the current SvgDocument
    /// </summary>
    protected virtual void SetupStyleSheets()
    {
      CssXmlDocument cssDocument = (CssXmlDocument) window.Document;
      string appRootPath = SharpVectors.ApplicationContext.ExecutableDirectory.FullName;
      FileInfo userAgentCssPath = new FileInfo(appRootPath + "\\" + UserAgentCssFileName);
      FileInfo userCssPath = new FileInfo(appRootPath + "\\" + UserCssFileName);
					
      if(userAgentCssPath.Exists)
      {
        cssDocument.SetUserAgentStyleSheet((new Uri("file:/" + userAgentCssPath.FullName)).AbsoluteUri);
      }

      if(userCssPath.Exists)
      {
        cssDocument.SetUserStyleSheet((new Uri("file:/" + userCssPath.FullName)).AbsoluteUri);
      }
    }
    #endregion

    #region Scripting Methods and Properties
    private TypeDictionary scriptEngineByMimeType;
    private Hashtable scriptEngines = new Hashtable();
    
    public void SetMimeTypeEngineType(string mimeType, Type engineType)
    {
      scriptEngineByMimeType[mimeType] = engineType;
    }

    public ScriptEngine GetScriptEngineByMimeType(string mimeType) 
    {
      ScriptEngine engine = null;

      if (mimeType == "") 
        mimeType = ((ISvgWindow)window).Document.RootElement.GetAttribute("contentScriptType");

      if (mimeType == "" || mimeType == "text/ecmascript" || mimeType == "text/javascript" || mimeType == "application/javascript") 
        mimeType = "application/ecmascript";

      if (!scriptEngines.Contains(mimeType))
      {
        object[] args = new object[] { (window as ISvgWindow) };
        engine = (ScriptEngine)scriptEngineByMimeType.CreateInstance(mimeType, args);
        scriptEngines.Add(mimeType,engine);
        engine.Initialise();
      }
                    
      if (engine == null)
        engine = (ScriptEngine) scriptEngines[mimeType];

      return engine;
    }


    /// <summary>
    /// Clears the existing script engine list from any previously running instances
    /// </summary>
    private void UnloadEngines() 
    {
      // Dispose of all running engines from previous document instances
      foreach (string mimeType in scriptEngines.Keys) 
      {
        ScriptEngine engine = (ScriptEngine)scriptEngines[mimeType];
        engine.Close();
        engine = null;
      }
      // Clear the list
      scriptEngines.Clear();
      ClosureEventMonitor.Clear();
      ScriptTimerMonitor.Reset();
    }

    /// <summary>
    /// Add event listeners for on* events within the document
    /// </summary>
    private void InitializeEvents() 
    {
      SvgDocument document = (SvgDocument)window.Document;
      document.NamespaceManager.AddNamespace("svg", "http://www.w3.org/2000/svg");
        
      XmlNodeList nodes = document.SelectNodes(@"//*[namespace-uri()='http://www.w3.org/2000/svg']
                                                   [local-name()='svg' or
                                                    local-name()='g' or
                                                    local-name()='defs' or
                                                    local-name()='symbol' or
                                                    local-name()='use' or
                                                    local-name()='switch' or
                                                    local-name()='image' or
                                                    local-name()='path' or
                                                    local-name()='rect' or
                                                    local-name()='circle' or
                                                    local-name()='ellipse' or
                                                    local-name()='line' or
                                                    local-name()='polyline' or
                                                    local-name()='polygon' or
                                                    local-name()='text' or
                                                    local-name()='tref' or
                                                    local-name()='tspan' or
                                                    local-name()='textPath' or
                                                    local-name()='altGlyph' or
                                                    local-name()='a' or
                                                    local-name()='foreignObject']
                                                /@*[name()='onfocusin' or
                                                    name()='onfocusout' or
                                                    name()='onactivate' or
                                                    name()='onclick' or
                                                    name()='onmousedown' or
                                                    name()='onmouseup' or
                                                    name()='onmouseover' or
                                                    name()='onmousemove' or
                                                    name()='onmouseout' or
                                                    name()='onload']", document.NamespaceManager);
        
      foreach (XmlNode node in nodes) 
      {
        IAttribute att = (IAttribute)node;
        IEventTarget targ = (IEventTarget)att.OwnerElement;
        ScriptEventMonitor mon = new ScriptEventMonitor((VsaScriptEngine)GetScriptEngineByMimeType(""), att, window);
        string eventName = null;
        switch (att.Name) 
        {
          case "onfocusin":
            eventName = "focusin";
            break;
          case "onfocusout":
            eventName = "focusout";
            break;
          case "onactivate":
            eventName = "activate";
            break;
          case "onclick":
            eventName = "click";
            break;
          case "onmousedown":
            eventName = "mousedown";
            break;
          case "onmouseup":
            eventName = "mouseup";
            break;
          case "onmouseover":
            eventName = "mouseover";
            break;
          case "onmousemove":
            eventName = "mousemove";
            break;
          case "onmouseout":
            eventName = "mouseout";
            break;
          case "onload":
            eventName = "SVGLoad";
            break;
        }
        targ.AddEventListener(eventName, new EventListener(mon.EventHandler), false);
      }        
    }

    /// <summary>
    /// Collect the text in all script elements, build engine and execute. 
    /// </summary>
    private void ExecuteScripts()
    {
      Hashtable codeByMimeType = new Hashtable();
      StringBuilder codeBuilder;
      SvgDocument document = (SvgDocument)window.Document;

      XmlNodeList scripts = document.GetElementsByTagName("script", SvgDocument.SvgNamespace);
      StringBuilder code = new StringBuilder();

      foreach ( XmlElement script in scripts )
      {
        string type = script.GetAttribute("type");

        if ( GetScriptEngineByMimeType(type) != null )
        {
          // make sure we have a StringBuilder for this MIME type
          if ( !codeByMimeType.Contains(type) )
            codeByMimeType[type] = new StringBuilder();

          // grab this MIME type's codeBuilder
          codeBuilder = (StringBuilder) codeByMimeType[type];

          if ( script.HasChildNodes )
          {
            // process each child that is text node or a CDATA section
            foreach ( XmlNode node in script.ChildNodes )
            {
              if ( node.NodeType == XmlNodeType.CDATA || node.NodeType == XmlNodeType.Text )
              {
                codeBuilder.Append(node.Value);
              }
            }
          }
          
          if (script.HasAttribute("href", "http://www.w3.org/1999/xlink")) 
          {
            string href = script.GetAttribute("href", "http://www.w3.org/1999/xlink");
            Uri baseUri = new Uri(((XmlDocument)((ISvgWindow)window).Document).BaseURI);
            Uri hUri = new Uri(baseUri, href);
            ExtendedHttpWebRequestCreator creator = new ExtendedHttpWebRequestCreator();            
            ExtendedHttpWebRequest request = (ExtendedHttpWebRequest)creator.Create(hUri);
            ExtendedHttpWebResponse response = (ExtendedHttpWebResponse)request.GetResponse();
            Stream rs = response.GetResponseStream();
            StreamReader sr = new StreamReader(rs);
            codeBuilder.Append(sr.ReadToEnd());
            rs.Close();            
          }
        }
      }

      // execute code for all script engines
      foreach ( string mimeType in codeByMimeType.Keys )
      {
        codeBuilder = (StringBuilder) codeByMimeType[mimeType];

        if ( codeBuilder.Length > 0 )
        {
          ScriptEngine engine = GetScriptEngineByMimeType(mimeType);
          engine.Execute( codeBuilder.ToString() );
        }
      }

      // load the root element
      ((ISvgWindow)window).Document.RootElement.DispatchEvent(new Event("SVGLoad", false, true));
    }

    #endregion


    #region Component Designer generated code
    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.Name = "SvgPictureBox";
    }
		
    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    protected override void Dispose( bool disposing )
    {
      renderer.Dispose();
      
      if( disposing )
      {
        if(components != null)
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    #endregion

  }
}

