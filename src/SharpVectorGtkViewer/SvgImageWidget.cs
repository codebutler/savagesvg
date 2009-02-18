using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using SharpVectors;
using SharpVectors.Collections;
using SharpVectors.Scripting;
using SharpVectors.Renderer.Gdi;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;
using Gtk;

public class SvgImageWidget : DrawingArea
{
	private static readonly string userAgentCssFileName = "useragent.css";
	private static readonly string userCssFileName = "user.css";

	private int lastX = -1;
	private int lastY = -1;

	private GdiRenderer renderer; // I think i'd rather use window.Renderer...
	//private Graphics surface;

	//private TypeDictionary scriptEngineByMimeType;
	//private Hashtable scriptEngines = new Hashtable();

	private SvgWindow window;

	private bool loaded = false;

	public SvgImageWidget ()
	{
		//scriptEngineByMimeType = new TypeDictionary();
		//SetMimeTypeEngineType("application/ecmascript", 
		//typeof(JScriptEngine));

	
		this.Events = this.Events | 
			Gdk.EventMask.ButtonPressMask |
			Gdk.EventMask.ButtonReleaseMask |
			Gdk.EventMask.PointerMotionMask |
			Gdk.EventMask.EnterNotifyMask |
			Gdk.EventMask.LeaveNotifyMask |
			Gdk.EventMask.ScrollMask;


		this.CanFocus = true;
		
		renderer = new GdiRenderer();
		renderer.OnRender += OnRender;
		
		window = new SvgWindow(this.Allocation.Width, 
		                       this.Allocation.Height,
		                       renderer);
	}

	public void OnRender(RectangleF updatedRect)
	{
		using (Graphics graphics = Gtk.DotNet.Graphics.FromDrawable (this.GdkWindow)) {
			Bitmap rasterImage = ((GdiRenderer)window.Renderer).RasterImage;

			if (rasterImage != null) {
				if (updatedRect == RectangleF.Empty) {
					graphics.DrawImage (rasterImage, 0, 0, 
					                    rasterImage.Width, 
					                    rasterImage.Height);
				} else {
					graphics.DrawImage (rasterImage, 
					                    updatedRect.X, 
					                    updatedRect.Y,
					                    updatedRect.Width, 
					                    updatedRect.Height);
				}
			}
		}
	}
	
	protected override bool OnMotionNotifyEvent (Gdk.EventMotion evnt)
	{
		base.OnMotionNotifyEvent (evnt);
		
		if (lastX == evnt.X && lastY == evnt.Y) {
			return true;
		}

		lastX = (int)evnt.X;
		lastY = (int)evnt.Y;

		renderer.OnMouseEvent("mousemove", (int)evnt.X, (int)evnt.Y);

		return true;
	}

	protected override bool OnButtonPressEvent (Gdk.EventButton evnt)
	{
		base.OnButtonPressEvent(evnt);

		renderer.OnMouseEvent("mousedown", (int)evnt.X, (int)evnt.Y);

		return true;
	}

	protected override bool OnButtonReleaseEvent (Gdk.EventButton evnt)
	{
		base.OnButtonReleaseEvent (evnt);

		renderer.OnMouseEvent("mouseup", (int)evnt.X, (int)evnt.Y);

		return true;
	}

	protected override bool OnExposeEvent (Gdk.EventExpose evnt)
	{
		// XXX: What's this supposed to do??
		// window.Renderer.InvalidateRect(new RectangleF(evnt.Area.X, evnt.Area.Y, evnt.Area.Width, evnt.Area.Height));
		
		if (window.Document != null) {
			window.Renderer.Render((SvgDocument)window.Document);	
		}
		
		return true;
	}


	protected override void OnSizeAllocated (Gdk.Rectangle allocation)
	{
		base.OnSizeAllocated(allocation);

		(window as SvgWindow).Resize(this.Allocation.Width,
		                             this.Allocation.Height);

		this.QueueDraw();
	}

	public string SourceURL {
		get {
			return window.Src;
		}
		set {
			Load(value);
		}
	}


	public ISvgWindow Window {
		get {
			return window;
		}
	}

	public void Load (string value)
	{
		try {
			if (value != null && value.Length > 0) {
				window.Src = value;
				
				//(window.Document as CssXmlDocument).SetUserAgentStyleSheet((new Uri("file://home/eric/Desktop/circle.css")).AbsoluteUri);
				//(window.Document as CssXmlDocument).StyleSheets.Add (new CssStyleSheet(
				
				renderer.InvalidRect = RectangleF.Empty;
				loaded = true;
				this.QueueDraw();
			}
		} catch (Exception ex) {
			ShowErrorDialog (String.Format("An error occured while loading the document.\n{0}", ex));
		}
	}

/*
	public void LoadXml (string xml)
	{
		try {
			if (xml != null && xml.Length > 0) {
				SvgDocument document = window.CreateEmptySvgDocument();
				document.LoadXml(xml);
				window.Document = document;
				SetupStyleSheets();
				loaded = true;
				this.QueueDraw();
			}
		} catch (Exception ex) {
			ShowErrorDialog(String.Format("An error occured while loading the document.\n{0}", ex));
		}
	}
*/

/*
	public void CacheRenderingRegions ()
	{
		// Collect the rendering retgions for later updates
		System.Threading.Thread.Sleep(1);
		SvgDocument document = (SvgDocument)window.Document;
		SvgElement root = (SvgElement)document.RootElement;
		root.CacheRenderingRegion(renderer);
	}
*/

	/*
	public RectangleF InvalidRect {
		get {
			return renderer.InvalidRect;
		}
	}
	*/


	/*
	private void SetupStyleSheets ()
	{
		CssXmlDocument cssDocument = (CssXmlDocument)window.Document;
		string appRootPath = SharpVectors.ApplicationContext.ExecutableDirectory.FullName;
		FileInfo userAgentCssPath = new FileInfo(System.IO.Path.Combine(appRootPath, userAgentCssFileName));
		FileInfo userCssPath = new FileInfo(System.IO.Path.Combine(appRootPath, userCssFileName));

		if (userAgentCssPath.Exists) {
			cssDocument.SetUserAgentStyleSheet(new Uri("file://" + userAgentCssPath.FullName).AbsoluteUri);;
		}

		if (userCssPath.Exists) {
			cssDocument.SetUserAgentStyleSheet(new Uri("file://" + userCssPath.FullName).AbsoluteUri);
		}
	}

	public void SetmimeTypeEngineType (string mimeType, Type engineType)
	{
		scriptEngineByMimeType[mimeType] = engineType;
	}
	
	public ScriptEngine GetScriptEngineByMimeType (string mimeType)
	{
		ScriptEngine engine = null;

		if (mimeType == "") {
			mimeType = ((ISvgWindow)window).Document.RootElement.GetAttribute("contentScriptType");
		}

		if (mimeType == "" || mimeType == "text/ecmascript" || mimeType == "text/javascript" || mimeType == "application/javascript") {
			mimeType = "application/ecmascript";
		}

		if (scriptEngines.Contains(mimeType) == false) {
			object[] args = new object[] { ((ISvgWindow)window) };
			engine = (ScriptEngine)scriptEngineByMimeType.CreateInstance(mimeType, args);
			scriptEngines.Add(mimeType,engine);
			engine.Initialise();
		}

		if (engine == null) {
			engine = (ScriptEngine)scriptEngines[mimeType];
		}

		return engine;
	}

	private void UnloadEngines ()
	{
		// Dispose of all running engines from previous document instances
		foreach (string mimeType in scriptEngines.Keys) {
			ScriptEngine engine = (ScriptEngine)scriptEngines[mimeType];
			engine.Close();
			engine = null;
		}

		// Clear the list
		scriptEngines.Clear();
	//XXX	CloseEventMonitor.Clear();
		ScriptTimerMonitor.Reset();
	}

	private void InitializeEvents ()
	{
	//XXX:	throw new NotImplementedException();
	}
	*/
	
	private void ShowErrorDialog (string error)
	{
		Console.WriteLine (error);
		MessageDialog dialog = new MessageDialog (null, 
		                                          DialogFlags.DestroyWithParent, 
		                                          MessageType.Error,
		                                          ButtonsType.Close, 
		                                          error);
		dialog.Show(); 
		dialog.Run();
		dialog.Destroy();
	}
}
