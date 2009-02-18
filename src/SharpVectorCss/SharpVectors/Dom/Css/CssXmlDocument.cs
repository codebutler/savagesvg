using System;
using System.Collections;
using System.Xml;
using System.Net;
using SharpVectors.Dom.Stylesheets;

using SharpVectors.Dom;
using SharpVectors.Xml;

namespace SharpVectors.Dom.Css
{
	/// <summary>
	/// A XmlDocument with CSS support
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>80</completed>
	public class CssXmlDocument : Document, IDocumentCss, IViewCss
	{
	
	
		CssStyleSheet userAgentStyleSheet;
		CssStyleSheet userStyleSheet;
	
		#region Public constructors
		/// <summary>
		/// Initializes a new instance of CssXmlDocument
		/// </summary>
		public CssXmlDocument() : base()
		{
			setupNodeChangeListeners();

		//	SharpVectors.Net.ExtendedHttpWebRequest.Register();
		//	SharpVectors.Net.DataWebRequest.Register();
		}

		/// <summary>
		/// Initializes a new instance of CssXmlDocument
		/// </summary>
		/// <param name="nt">The name table to use</param>
		public CssXmlDocument(XmlNameTable nt) : base(nt)
		{
			setupNodeChangeListeners();

		//	SharpVectors.Net.ExtendedHttpWebRequest.Register();
		//	SharpVectors.Net.DataWebRequest.Register();
		}
		#endregion

		#region Public properties
		private bool _static = false;
		public bool Static
		{
			get{return _static;}
			set{_static = value;}
		}

		public MediaList Media
		{
			get
			{
				return _currentMedia;
			}
			set
			{
				_currentMedia = value;

			}
		}

		private CssPropertyProfile _cssPropertyProfile = new CssPropertyProfile();
		public CssPropertyProfile CssPropertyProfile
		{
			get
			{
				return _cssPropertyProfile;
			}
			set
			{
				_cssPropertyProfile = value;
			}
		}

		public string Url
		{
			get
			{
				return BaseURI;
			}
		}

		private StyleSheetList _StyleSheets = null;
		/// <summary>
		/// All the stylesheets associated with this document
		/// </summary>
		public IStyleSheetList StyleSheets
		{
			get
			{
				if(_StyleSheets == null)
				{
					_StyleSheets = new StyleSheetList(this);
				}
				return _StyleSheets;
			}
		}
		#endregion

		#region Private and internal fields
		internal ArrayList styleElements = new ArrayList();
		internal MediaList _currentMedia = new MediaList("all");
	
	
		public CssStyleSheet UserAgentStyleSheet {
			get {
				return userAgentStyleSheet;
			}
		}
		
		public CssStyleSheet UserStyleSheet {
			get {
				return userStyleSheet;
			}
		}
		
		
		#endregion

		#region Public methods
		public override XmlElement CreateElement(string prefix, string localName, string ns)
		{
			return new CssXmlElement(prefix, localName, ns, this);
		}

		/// <summary>
		/// Loads a XML document, compare to XmlDocument.Load()
		/// </summary>
		/// <param name="filename"></param>
		public override void Load(string filename)
		{
			bool oldStatic = Static;
			Static = true;

			// remove any hash (won't work for local files)
			int hashStart = filename.IndexOf("#");
			if(hashStart>-1)
			{
				filename = filename.Substring(0, hashStart);
			}
			base.Load(filename);	

			Static = oldStatic;
		}

		public override void LoadXml(string xml)
		{
			bool oldStatic = Static;
			Static = true;

			base.LoadXml(xml);		

			Static = oldStatic;
		}

    //JR added in
    public override void Load(XmlReader reader)
    {
      bool oldStatic = _static;
      _static = true;
      base.Load(reader);		
      _static = oldStatic;
    }
    
    /// <summary>
		/// Adds a element type to be used as style elements (e.g. as in the HTML style element)
		/// </summary>
		/// <param name="ns">The namespace URI of the element</param>
		/// <param name="localName">The local-name of the element</param>
		public void AddStyleElement(string ns, string localName)
		{
			styleElements.Add(new string[]{ns, localName});
		}

		/// <summary>
		/// Sets the user agent stylesheet for this document
		/// </summary>
		/// <param name="href">The URI to the stylesheet</param>
		public void SetUserAgentStyleSheet(string href)
		{
			userAgentStyleSheet = new CssStyleSheet(null, href, String.Empty, String.Empty, null, CssStyleSheetType.UserAgent);
		}

		/// <summary>
		/// Sets the user stylesheet for this document
		/// </summary>
		/// <param name="href">The URI to the stylesheet</param>
		public void SetUserStyleSheet(string href)
		{
			userStyleSheet = new CssStyleSheet(null, href, String.Empty, String.Empty, null, CssStyleSheetType.User);
		}

	//	public void AddStyleSheet(string href)
	//	{
	//		
	//		UserStyleSheet = new CssStyleSheet(null, href, String.Empty, String.Empty, null, CssStyleSheetType.User);
	//	}

		#endregion

		#region Implementation of IDocumentCss
		/// <summary>
		/// This method is used to retrieve the override style declaration for a specified element and a specified pseudo-element.
		/// </summary>
		/// <param name="elt">The element whose style is to be modified. This parameter cannot be null.</param>
		/// <param name="pseudoElt">The pseudo-element or null if none.</param>
		/// <returns>The override style declaration.</returns>
		public SharpVectors.Dom.Css.ICssStyleDeclaration GetOverrideStyle(System.Xml.XmlElement elt, string pseudoElt)
		{
			throw new NotImplementedException("CssXmlDocument.GetOverrideStyle()");
		}
		
		#endregion

		#region Implementation of IViewCss
		/// <summary>
		/// This method is used to get the computed style as it is defined in [CSS2].
		/// </summary>
		/// <param name="elt">The element whose style is to be computed. This parameter cannot be null.</param>
		/// <param name="pseudoElt">The pseudo-element or null if none.</param>
		/// <returns>The computed style. The CSSStyleDeclaration is read-only and contains only absolute values.</returns>
		public SharpVectors.Dom.Css.ICssStyleDeclaration GetComputedStyle(System.Xml.XmlElement elt, string pseudoElt)
		{
			if(elt == null) throw new NullReferenceException();
			else if(!(elt is CssXmlElement)) throw new DomException(DomExceptionType.SyntaxErr, "element must of type CssXmlElement");
			else
			{
				return ((CssXmlElement)elt).GetComputedStyle(pseudoElt);
			}
		}
		#endregion

		#region Update handling
		private void setupNodeChangeListeners()
		{
			XmlNodeChangedEventHandler handler = new XmlNodeChangedEventHandler(NodeChangedEvent);

			NodeChanged += handler;
			NodeInserted += handler;
			//NodeRemoving += handler;
			NodeRemoved += handler;
		}

		public void NodeChangedEvent(Object src, XmlNodeChangedEventArgs args)
		{
			if(!Static)
			{
				#region Attribute updates
        // xmlns:xml is auto-inserted whenever a selectNode is performed, we don't want those events
				if(args.Node is XmlText && args.NewParent is XmlAttribute && args.NewParent.Name != "xmlns:xml")
				{
					XmlAttribute attr = args.NewParent as XmlAttribute;
					CssXmlElement elm = attr.OwnerElement as CssXmlElement;
					if(elm != null)
					{
						elm.AttributeChange(attr, args);
					}
				}
				else if(args.Node is XmlAttribute && args.Node.Name != "xmlns:xml")
				{
					// the cause of the change is a XmlAttribute => happens during inserting or removing
					CssXmlElement oldElm = args.OldParent as CssXmlElement;
					if(oldElm != null) oldElm.AttributeChange(args.Node, args);

					CssXmlElement newElm = args.NewParent as CssXmlElement;
					if(newElm != null) newElm.AttributeChange(args.Node, args);
				}
				#endregion

				#region OnElementChange				
        if(args.Node is XmlText && args.NewParent is XmlElement) 
        {
          CssXmlElement element = (CssXmlElement)args.NewParent;
          element.ElementChange(src, args);
        } 
        else if(args.Node is CssXmlElement)
				{
          if(args.Action == XmlNodeChangedAction.Insert || args.Action == XmlNodeChangedAction.Change)
          {
            // Changes to a child XML node may affect the sibling offsets (for example in tspan)
            // By calling the parent's OnElementChange, invalidation will propogate back to Node
            CssXmlElement newParent = (CssXmlElement)args.NewParent;
            newParent.ElementChange(src, args);
          }          

          if (args.Action == XmlNodeChangedAction.Remove) 
          {
            // Removing a child XML node may affect the sibling offsets (for example in tspan)
            CssXmlElement oldParent = (CssXmlElement)args.OldParent;
            oldParent.ElementChange(src, args);      
          }
				}
				#endregion

			}
		}
		#endregion

		public WebResponse GetResource(Uri absoluteUri)
		{
			WebRequest request = WebRequest.Create(absoluteUri);
			WebResponse response = request.GetResponse();

			return response;
		}
	}
}
