// Define this to enable the dispatching of load events.  The implementation
// of load events requires that a complete implementation of SvgDocument.Load
// be supplied rather than relying on the base XmlDocument.Load behaviour.
// This is required because I know of no way to hook into the key stages of
// XML document creation in order to throw events at the right times during
// the load process.
//#define ENABLE_LOAD_EVENTS

using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;

using SharpVectors.Collections;
using SharpVectors.Dom.Css;
using SharpVectors.Xml;

using SharpVectors.Dom.Svg.Rendering;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The root object in the document object hierarchy of an Svg document.
	/// </summary>
	/// <remarks>
	/// <p>
	/// When an 'svg'  element is embedded inline as a component of a
	/// document from another namespace, such as when an 'svg' element is
	/// embedded inline within an XHTML document
	/// [<a href="http://www.w3.org/TR/SVG/refs.html#ref-XHTML">XHTML</a>],
	/// then an
	/// <see cref="ISvgDocument">ISvgDocument</see> object will not exist;
	/// instead, the root object in the
	/// document object hierarchy will be a Document object of a different
	/// type, such as an HTMLDocument object.
	/// </p>
	/// <p>
	/// However, an <see cref="ISvgDocument">ISvgDocument</see> object will
	/// indeed exist when the root
	/// element of the XML document hierarchy is an 'svg' element, such as
	/// when viewing a stand-alone SVG file (i.e., a file with MIME type
	/// "image/svg+xml"). In this case, the
	/// <see cref="ISvgDocument">ISvgDocument</see> object will be the
	/// root object of the document object model hierarchy.
	/// </p>
	/// <p>
	/// In the case where an SVG document is embedded by reference, such as
	/// when an XHTML document has an 'object' element whose href attribute
	/// references an SVG document (i.e., a document whose MIME type is
	/// "image/svg+xml" and whose root element is thus an 'svg' element),
	/// there will exist two distinct DOM hierarchies. The first DOM hierarchy
	/// will be for the referencing document (e.g., an XHTML document). The
	/// second DOM hierarchy will be for the referenced SVG document. In this
	/// second DOM hierarchy, the root object of the document object model
	/// hierarchy is an <see cref="ISvgDocument">ISvgDocument</see> object.
	/// </p>
	/// <p>
	/// The <see cref="ISvgDocument">ISvgDocument</see> interface contains a
	/// similar list of attributes and
	/// methods to the HTMLDocument interface described in the
	/// <a href="http://www.w3.org/TR/REC-DOM-Level-1/level-one-html.html">Document
	/// Object Model (HTML) Level 1</a> chapter of the
	/// [<a href="http://www.w3.org/TR/SVG/refs.html#ref-DOM1">DOM1</a>] specification.
	/// </p>
	/// </remarks>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>60</completed>
	public class SvgDocument : CssXmlDocument, ISvgDocument
	{
		#region Fields
		
		private SvgWindow window;
		private TypeDictionary nodeByTagName = new TypeDictionary();
		
		#endregion
		
		#region Constructors
		
		public SvgDocument(SvgWindow window)
		{
			this.window = window;
			this.window.Document = this;
			
			// set up CSS properties
			AddStyleElement(SvgDocument.SvgNamespace, "style");
			CssPropertyProfile = CssPropertyProfile.SvgProfile;
			
			//this.XmlResolver = new CachingXmlUrlResolver();
			
			// build tagName to type dictionary
			buildTypeDictionary();
 		}
		
		#endregion
		
		#region NamespaceManager
		
		private XmlNamespaceManager namespaceManager;
		
		public XmlNamespaceManager NamespaceManager
		{
			get
			{
				if(namespaceManager == null)
				{
					// Setup namespace manager and add default namespaces
					namespaceManager = new XmlNamespaceManager(this.NameTable);
					namespaceManager.AddNamespace(String.Empty, SvgDocument.SvgNamespace); 
					namespaceManager.AddNamespace("svg", SvgDocument.SvgNamespace); 
					namespaceManager.AddNamespace("xlink", SvgDocument.XLinkNamespace);
				}
				
				return namespaceManager;
			}
		}
		
		#endregion
		
		#region Type handling and creation of elements
		
		/// <summary>
		/// buildTypeDictionary
		/// </summary>
		protected virtual void buildTypeDictionary()
		{
			SetTagNameNodeType(SvgNamespace, "a",              typeof(SvgTransformableElement));
			SetTagNameNodeType(SvgNamespace, "circle",         typeof(SvgCircleElement));
			SetTagNameNodeType(SvgNamespace, "clipPath",       typeof(SvgClipPathElement));
			SetTagNameNodeType(SvgNamespace, "defs",           typeof(SvgDefsElement));
			SetTagNameNodeType(SvgNamespace, "desc",           typeof(SvgDescElement));
			SetTagNameNodeType(SvgNamespace, "ellipse",        typeof(SvgEllipseElement));
			SetTagNameNodeType(SvgNamespace, "g",              typeof(SvgGElement));
			SetTagNameNodeType(SvgNamespace, "image",          typeof(SvgImageElement));
			SetTagNameNodeType(SvgNamespace, "line",           typeof(SvgLineElement));
			SetTagNameNodeType(SvgNamespace, "linearGradient", typeof(SvgLinearGradientElement));
			SetTagNameNodeType(SvgNamespace, "marker",         typeof(SvgMarkerElement));
			SetTagNameNodeType(SvgNamespace, "mask",           typeof(SvgMaskElement));
			SetTagNameNodeType(SvgNamespace, "metadata",       typeof(SvgMetadataElement));
			SetTagNameNodeType(SvgNamespace, "rect",           typeof(SvgRectElement));
			SetTagNameNodeType(SvgNamespace, "path",           typeof(SvgPathElement));
			SetTagNameNodeType(SvgNamespace, "pattern",        typeof(SvgPatternElement));
			SetTagNameNodeType(SvgNamespace, "polyline",       typeof(SvgPolylineElement));
			SetTagNameNodeType(SvgNamespace, "polygon",        typeof(SvgPolygonElement));
			SetTagNameNodeType(SvgNamespace, "radialGradient", typeof(SvgRadialGradientElement));
			SetTagNameNodeType(SvgNamespace, "script",         typeof(SvgScriptElement));
			SetTagNameNodeType(SvgNamespace, "stop",           typeof(SvgStopElement));
			SetTagNameNodeType(SvgNamespace, "svg",            typeof(SvgSvgElement));
			SetTagNameNodeType(SvgNamespace, "switch",         typeof(SvgSwitchElement));
			SetTagNameNodeType(SvgNamespace, "symbol",         typeof(SvgSymbolElement));
			SetTagNameNodeType(SvgNamespace, "text",           typeof(SvgTextElement));
			SetTagNameNodeType(SvgNamespace, "title",          typeof(SvgTitleElement));
			SetTagNameNodeType(SvgNamespace, "tref",           typeof(SvgTRefElement));
			SetTagNameNodeType(SvgNamespace, "tspan",          typeof(SvgTSpanElement));
			SetTagNameNodeType(SvgNamespace, "use",            typeof(SvgUseElement));
		}
		
		public void SetTagNameNodeType(string prefix, string localName, Type type) 
		{
			nodeByTagName[prefix + ":" + localName] = type;
		}
		
		public override XmlElement CreateElement(string prefix, string localName, string ns)
		{
			string name = ns + ":" + localName;
			XmlElement result;
			
			if ( nodeByTagName.ContainsKey(name) )
			{
				Type type = nodeByTagName[name];
				object[] args = new object[] { prefix, localName, ns, this };
				
				result = (XmlElement) nodeByTagName.CreateInstance(
					name, args, BindingFlags.Instance | BindingFlags.NonPublic);
			}
			else if(ns == SvgNamespace)
			{
				result = new SvgElement(prefix, localName, ns, this);
			}
			else
			{
				result = base.CreateElement(prefix, localName, ns);
			}
			
			return result;
		}
		
		#endregion
		
		#region Static properties
		
		public static string SvgNamespace = "http://www.w3.org/2000/svg";
		
		public static string XLinkNamespace = "http://www.w3.org/1999/xlink";
		
		#endregion
		
		#region Support collections
		
		private string[] supportedFeatures = new string[]
			{
				"org.w3c.svg.static",
				"http://www.w3.org/TR/Svg11/feature#Shape",
				"http://www.w3.org/TR/Svg11/feature#BasicText",
				"http://www.w3.org/TR/Svg11/feature#OpacityAttribute"
			};
		
		private string[] supportedExtensions = new string[] {};
		
		public override bool Supports(
			string feature,
			string version)
		{
			foreach(string supportedFeature in supportedFeatures)
			{
				if(supportedFeature == feature)
				{
					return true;
				}
			}
			
			foreach(string supportedExtension in supportedExtensions)
			{
				if(supportedExtension == feature)
				{
					return true;
				}
			}
			
			return base.Supports(feature, version);
		}
		
		#endregion
		
		#region Overrides of Load()
		
		private void prepareXmlResolver(
			XmlReader reader)
		{
      // TODO: 1.2 has removed the DTD, can we do this safely?
      if (reader != null && reader is XmlValidatingReader)
      {
        XmlValidatingReader valReader = (XmlValidatingReader)reader;				
        valReader.ValidationType = ValidationType.None;
      }
      return;

      /*LocalDtdXmlUrlResolver localDtdXmlUrlResolver = new LocalDtdXmlUrlResolver();
      localDtdXmlUrlResolver.AddDtd("http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd", @"dtd\svg10.dtd");
			localDtdXmlUrlResolver.AddDtd("http://www.w3.org/TR/SVG/DTD/svg10.dtd", @"dtd\svg10.dtd");
			localDtdXmlUrlResolver.AddDtd("http://www.w3.org/Graphics/SVG/1.1/DTD/svg11-tiny.dtd", @"dtd\svg11-tiny.dtd");
			localDtdXmlUrlResolver.AddDtd("http://www.w3.org/Graphics/SVG/1.1/DTD/svg11-basic.dtd", @"dtd\svg11-basic.dtd");
			localDtdXmlUrlResolver.AddDtd("http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd", @"dtd\svg11.dtd");
			
			if (reader != null && reader is XmlValidatingReader)
			{
				XmlValidatingReader valReader = (XmlValidatingReader)reader;
				
				valReader.ValidationType = ValidationType.None;
				valReader.XmlResolver = localDtdXmlUrlResolver;
			}
			
			this.XmlResolver = localDtdXmlUrlResolver;*/
		}
		
		/// <overloads>
		/// Loads an XML document.Loads the specified XML data.
		/// <blockquote>
		/// <b>Note</b>   The Load method always preserves significant white
		/// space. The PreserveWhitespace property determines whether or not
		/// white space is preserved. The default is false, whites space is
		/// not preserved.
		/// </blockquote>
		/// </overloads>
		/// <summary>
		/// Loads the XML document from the specified URL.
		/// </summary>
		/// <param name="url">
		/// URL for the file containing the XML document to load.
		/// </param>
		public override void Load(string url)
		{
		
			System.Net.WebClient client = new System.Net.WebClient ();
			byte[] data = client.DownloadData(url);
			
			base.LoadXml (System.Text.Encoding.UTF8.GetString(data));
			
			/*
			Console.WriteLine ("1");
			XmlTextReader reader = new XmlTextReader(url);
			Console.WriteLine ("2");
			XmlValidatingReader vr = new XmlValidatingReader(reader);
			prepareXmlResolver(vr);
			LoadAndFire(vr);
			reader.Close();
			Console.WriteLine ("3");
			*/
		}
		
		/// <summary>
		/// Loads the XML document from the specified stream but with the
		/// specified base URL
		/// </summary>
		/// <param name="url">
		/// Base URL for the stream from which the XML document is loaded.
		/// </param>
		/// <param name="stream">
		/// The stream containing the XML document to load.
		/// </param>
		public void Load(
			string url,
			Stream stream)
		{
			XmlValidatingReader vr = new XmlValidatingReader(
				new XmlTextReader(url, stream));
			prepareXmlResolver(vr);
			LoadAndFire(vr);
		}
		
		/// <summary>
		/// Loads the XML document from the specified
		/// <see cref="XmlReader">XmlReader</see>.
		/// </summary>
		/// <param name="reader">
		/// The <see cref="XmlReader">XmlReader</see> used to feed the XML
		/// data into the document.
		/// </param>
		public override void Load(
			XmlReader reader)
		{
			prepareXmlResolver(reader);
			LoadAndFire(reader);
		}
		
		/// <summary>
		/// Loads the XML document from the specified
		/// <see cref="TextReader">TextReader</see>.
		/// </summary>
		/// <param name="reader"></param>
		public override void Load(
			TextReader reader)
		{
			XmlValidatingReader vr = new XmlValidatingReader(
				new XmlTextReader(reader));
			prepareXmlResolver(vr);
			LoadAndFire(vr);
		}
		
		/// <summary>
		/// Loads the XML document from the specified stream.
		/// </summary>
		/// <param name="stream">
		/// The stream containing the XML document to load.
		/// </param>
		public override void Load(
			Stream stream)
		{
			prepareXmlResolver(null);
			Load("", stream);
		}
		
		/// <summary>
		/// Loads the specified XML data and fires load events.
		/// </summary>
		/// <param name="reader">
		/// The <see cref="XmlReader">XmlReader</see> describing the document
		/// to be loaded.
		/// </param>
		private void LoadAndFire(
			XmlReader reader)
		{
#if !ENABLE_LOAD_EVENTS
			base.Load(reader);
#else
			RemoveAll();
			base.Load(new XmlTextReader(reader.BaseURI,
				new MemoryStream(System.Text.Encoding.UTF8.GetBytes(
				"<?xml version=\"1.0\"?><xmldoc/>"))));
			RemoveAll();
			XmlNode currentNode = this;
			// Read each node in the tree.
			while (reader.Read())
			{
				Console.WriteLine (reader.NodeType);
				switch (reader.NodeType)
				{
					case XmlNodeType.Element:
						XmlElement xmlElement = CreateElement(
							reader.Prefix, reader.LocalName, reader.NamespaceURI);
						currentNode.AppendChild(xmlElement);
						
						if (!reader.IsEmptyElement)
						{
							currentNode = xmlElement;
						}
						
						while (reader.MoveToNextAttribute())
						{
							XmlAttribute xmlAttribute = CreateAttribute(
								reader.Prefix, reader.LocalName, reader.NamespaceURI);
							xmlAttribute.Value = reader.Value;
							xmlElement.SetAttributeNode(xmlAttribute);
						}
						
						break;
					case XmlNodeType.Text:
						currentNode.AppendChild(CreateTextNode(reader.Value));
						break;
					case XmlNodeType.CDATA:
						currentNode.AppendChild(CreateCDataSection(reader.Value));
						break;
					case XmlNodeType.ProcessingInstruction:
						currentNode.AppendChild(CreateProcessingInstruction(
							reader.Name, reader.Value));
						break;
					case XmlNodeType.Comment:
						currentNode.AppendChild(CreateComment(reader.Value));
						break;
					case XmlNodeType.Document:
						currentNode = this;
						break;
					case XmlNodeType.Whitespace:
						if (PreserveWhitespace)
						{
							currentNode.AppendChild(CreateWhitespace(reader.Value));
						}
						break;
					case XmlNodeType.SignificantWhitespace:
						currentNode.AppendChild(CreateSignificantWhitespace(reader.Value));
						break;
					case XmlNodeType.EndElement:
						currentNode = currentNode.ParentNode;
						break;
					case XmlNodeType.Attribute:
						currentNode.AppendChild(CreateAttribute(
							reader.Prefix, reader.LocalName, reader.NamespaceURI));
						break;
					case XmlNodeType.EntityReference:
						currentNode.AppendChild(this.CreateEntityReference(reader.Value));
						break;
					case XmlNodeType.XmlDeclaration:
						XmlDeclaration xmlDeclaration = CreateXmlDeclaration(
							"1.0", String.Empty, String.Empty);
						xmlDeclaration.Value = reader.Value;
						currentNode.AppendChild(xmlDeclaration);
						break;
					case XmlNodeType.DocumentType:
						currentNode.AppendChild(CreateDocumentType(
							reader.Name, reader["PUBLIC"], reader["SYSTEM"], reader.Value));
						break;
				}
			}
			
			reader.Close();
#endif//ENABLE_LOAD_EVENTS
		}
		
		#endregion
		
		#region Resource handling
		
		public XmlNode GetNodeByUri(Uri absoluteUri)
		{
			return GetNodeByUri(absoluteUri.AbsoluteUri);
		}
		
		public XmlNode GetNodeByUri(string absoluteUrl)
		{
			absoluteUrl = absoluteUrl.Trim();
			if(absoluteUrl.StartsWith("#"))
			{
        return GetElementById(absoluteUrl.Substring(1));
			}
			else
			{
				Uri docUri = ResolveUri("");
				Uri absoluteUri = new Uri(absoluteUrl);
				
				string fragment = absoluteUri.Fragment;
				
				if(fragment.Length == 0)
				{
					// no fragment => return entire document
					if(docUri.AbsolutePath == absoluteUri.AbsolutePath)
					{
						return this;
					}
					else
					{
						SvgDocument doc = new SvgDocument((SvgWindow)Window);
						
						XmlTextReader xtr = new XmlTextReader(absoluteUri.AbsolutePath, GetResource(absoluteUri).GetResponseStream() );
						XmlValidatingReader vr = new XmlValidatingReader(xtr);
						vr.ValidationType = ValidationType.None;
						doc.Load(vr);
						return doc;
					}
				}
				else
				{
					// got a fragment => return XmlElement
					string noFragment = absoluteUri.AbsoluteUri.Replace(fragment, "");
					SvgDocument doc = (SvgDocument)GetNodeByUri(new Uri(noFragment, true));
					return doc.GetElementById(fragment.Substring(1));
				}
			}
		}
		
		public Uri ResolveUri(string uri)
		{
			string baseUri = BaseURI;
			if(baseUri.Length == 0)
			{
				baseUri = "file:///" + SharpVectors.ApplicationContext.ExecutableDirectory.FullName.Replace('\\', '/');
			}
			
			return new Uri(new Uri(baseUri), uri);
		}
		
		#endregion
		
		#region Implementation of ISvgDocument
		
		/// <summary>
		/// The title of the document which is the text content of the first child title element of the 'svg' root element.
		/// </summary>
		public string Title
		{
			get
			{
				string result = "";
				
				XmlNode node = SelectSingleNode("/svg:svg/svg:title[text()!='']", NamespaceManager);
				
				if(node != null)
				{
					node.Normalize();
					// NOTE: should probably use spec-defined whitespace
					result = Regex.Replace(node.InnerText, @"\s\s+", " ");
				}
				
				return result;
			}
		}
		
		/// <summary>
		/// Returns the URI of the page that linked to this page. The value is an empty string if the user navigated to the page directly (not through a link, but, for example, via a bookmark).
		/// </summary>
		public string Referrer
		{
			get
			{
				return String.Empty;
			}
		}
		
		/// <summary>
		/// The domain name of the server that served the document, or a null string if the server cannot be identified by a domain name.
		/// </summary>
		public string Domain
		{
			get
			{
				if(Url.Length == 0 || 
					Url.StartsWith(Uri.UriSchemeFile))
				{
					return null;
				}
				else
				{
					return new Uri(Url).Host;
				}
			}
		}
		
		/// <summary>
		/// The root 'svg' element in the document hierarchy
		/// </summary>
		public ISvgSvgElement RootElement
		{
			get
			{
				return DocumentElement as ISvgSvgElement;
			}
		}
		
    internal Hashtable collectedIds = null;

		public override XmlElement GetElementById(string elementId)
		{
      // TODO: handle element and attribute updates globally to watch for id changes.
      if (collectedIds == null) 
      {
        collectedIds = new Hashtable();
        // TODO: handle xml:id, handle duplicate ids?
        XmlNodeList ids = this.SelectNodes("//*/@id");        
        foreach (XmlAttribute node in ids) 
        {
          try 
          {
            collectedIds.Add(node.Value, node.OwnerElement);            
          } 
          catch (Exception) 
          {
            // Duplicate ID... what to do?
          }
        }
      }

      // Find the item
      object res = collectedIds[elementId];

      if (res == null)
        return null;
      else
        return (Element)res;
		}
		
		#endregion
		
		#region Implementation of ISvgDocument from SVG 1.2
		
		public ISvgWindow Window
		{
			get
			{
				return window;
			}
		}
		
		#endregion
		
		#region Other public properties
		
		public new SvgDocument OwnerDocument
		{
			get
			{
				return base.OwnerDocument as SvgDocument;
			}
		}
		
		#endregion
		
		#region Rendering
		
		public void Render(ISvgRenderer renderer)
		{
			SvgSvgElement root = RootElement as SvgSvgElement;
			if ( root != null ) root.Render(renderer);
		}
		
		#endregion
	}
}
