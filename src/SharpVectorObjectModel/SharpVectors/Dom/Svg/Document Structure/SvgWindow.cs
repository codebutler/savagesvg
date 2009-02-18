using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;

using SharpVectors.Collections;
using SharpVectors.Dom.Svg.Rendering;
using SharpVectors.Dom.Events;
using SharpVectors.Xml;

namespace SharpVectors.Dom.Svg
{
  public class SvgWindow : ISvgWindow
  {
    #region Contructors
    [Obsolete("This constructor is obsolete and will be removed in future versions.")]
    public SvgWindow(long innerWidth, long innerHeight)
    {
      this.innerWidth = innerWidth;
      this.innerHeight = innerHeight;
    }

    public SvgWindow(long innerWidth, long innerHeight, ISvgRenderer renderer)
    {
      this.renderer = renderer;
      if(this.renderer != null)
      {
        this.renderer.Window = this;
      }

      this.innerWidth = innerWidth;
      this.innerHeight = innerHeight;
    }

    public SvgWindow(SvgWindow parentWindow, long innerWidth, long innerHeight) : this(innerWidth, innerHeight, parentWindow.Renderer)
    {
      this.parentWindow = parentWindow;
    }
/*
    public SvgWindow(Control control, ISvgRenderer renderer)
    {
      if ( control == null )
      {
        throw new NullReferenceException( "control cannot be null" );
      }
      else
      {
        this.control = control;
        this.renderer = renderer;
        this.renderer.Window = this;
      }
    }*/
    #endregion
        
    #region Private fields
   // private Control control = null;
    private Hashtable referencedWindows = new Hashtable();
    private Hashtable referencedFiles = new Hashtable();
    #endregion

    #region Public properties
    private SvgWindow parentWindow = null;
    public SvgWindow ParentWindow
    {
      get
      {
        return parentWindow;
      }
    }

    private ISvgRenderer renderer;
    public ISvgRenderer Renderer
    {
      get { return renderer; }
      set { renderer = value; }
    }
    #endregion

    #region Public methods
    /// <summary>
    /// Create and assign an empty SvgDocument to this window.  This is needed only in situations where the library user needs to create an SVG DOM tree outside of the usual LoadSvgDocument mechanism.
    /// </summary>
    public SvgDocument CreateEmptySvgDocument()
    {
      return document = new SvgDocument(this);
    }
    #endregion

    #region Implementation of ISvgWindow
    private long innerWidth;
    public long InnerWidth
    {
      get
      {
        /*if(control != null)
        {
          return control.Width;
        }
        else
        {*/
          return innerWidth;
        /*}*/
      }
      set
      {
        this.innerWidth = value;
      }
    }

    private long innerHeight;
    public long InnerHeight
    {
      get
      {
       /* if(control != null)
        {
          return control.Height;
        }
        else
        {*/
          return innerHeight;
        /*}*/
      }
      set
      {
        this.innerHeight = value;
      }
    }

    public XmlDocumentFragment ParseXML(string source, XmlDocument document)
    {
      XmlDocumentFragment frag = document.CreateDocumentFragment();
      frag.InnerXml = source;
      return frag;
    }

    public string PrintNode(System.Xml.XmlNode node)
    {
      return node.OuterXml;
    }

    public SharpVectors.Dom.Stylesheets.IStyleSheet DefaultStyleSheet
    {
      get
      {
        return null;
      }
    }

    private SvgDocument document;
    public ISvgDocument Document
    {
      get
      {
        return document;
      }
      set
      {
        document = (SvgDocument)value;
      }
    }

    public void Alert(string message)
    {
      //XXX: This needs to be changed!!! MessageBox.Show(message);
   	Console.WriteLine ("TODO: Alert(): " +message);
    }

    public string Src
    {
      get
      {
        return (document != null) ? document.Url : String.Empty;
      }
      set
      {
       // Uri uri = new Uri(new Uri(Environment.CurrentDirectory), value);
       Uri uri = new Uri(value);

        document = new SvgDocument(this);
        document.Load(uri.AbsoluteUri);
      }
    }

    /// <summary>
    /// This is expected to be called by the host
    /// </summary>
    /// <param name="width">The new width of the control</param>
    /// <param name="height">The new height of the control</param>
    public void Resize(int innerWidth, int innerHeight) 
    {
      this.innerWidth = innerWidth;
      this.innerHeight = innerHeight;
      if (Document != null && Document.RootElement != null)
        (Document.RootElement as SvgSvgElement).Resize();
    }
    #endregion
  }
}
