using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;

using SharpVectors.Net;


namespace SharpVectors.Dom.Svg
{
	public class SvgImageElement : SvgTransformableElement, ISvgImageElement
	{
		#region Constructors
		internal SvgImageElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
			svgURIReference = new SvgURIReference(this);
			svgFitToViewBox = new SvgFitToViewBox(this);
		}
		#endregion

		#region Implementation of ISvgImageElement
		private ISvgAnimatedLength width;
		public ISvgAnimatedLength Width
		{
			get
			{
				if(width == null)
				{
					width = new SvgAnimatedLength(this, "width", SvgLengthDirection.Horizontal, "0");
				}
				return width;
			}
		}
  		
		private ISvgAnimatedLength height;
		public ISvgAnimatedLength Height
		{
			get
			{
				if(height == null)
				{
					height = new SvgAnimatedLength(this, "height", SvgLengthDirection.Vertical, "0");
				}
				return height;
			}
  			
		}
  		
		private ISvgAnimatedLength x;
		public ISvgAnimatedLength X
		{
			get
			{
				if(x == null)
				{
					x = new SvgAnimatedLength(this, "x", SvgLengthDirection.Horizontal, "0");
				}
				return x;
			}
  			
		}

		private ISvgAnimatedLength y;
		public ISvgAnimatedLength Y
		{
			get
			{
				if(y == null)
				{
					y = new SvgAnimatedLength(this, "y", SvgLengthDirection.Vertical, "0");
				}
				return y;
			}
  			
		}
		#endregion

		#region Implementation of ISvgURIReference
		private SvgURIReference svgURIReference;
		public ISvgAnimatedString Href
		{
			get
			{
				return svgURIReference.Href;
			}
		}

		public XmlElement ReferencedElement
		{
			get
			{
				return svgURIReference.ReferencedNode as XmlElement;
			}
		}
		#endregion

		#region Implementation of ISvgFitToViewBox
		private SvgFitToViewBox svgFitToViewBox;
		public ISvgAnimatedPreserveAspectRatio PreserveAspectRatio
		{
			get
			{
				return svgFitToViewBox.PreserveAspectRatio;
			}
		}
		#endregion

		#region Implementation of ISvgImageElement from SVG 1.2
		public SvgDocument GetImageDocument()
		{
            SvgWindow window = SvgWindow;
			if(window == null)
			{
				return null;
			}
			else
			{
                return (SvgDocument)window.Document;
			}
		}

		#endregion

		#region Public properties
		public SvgRect CalulatedViewbox
		{
			get
			{
				SvgRect viewBox;

				if ( IsSvgImage )
				{
                    SvgDocument doc = GetImageDocument();
					SvgSvgElement outerSvg = (SvgSvgElement)doc.DocumentElement;

					if ( outerSvg.HasAttribute("viewBox") )
					{
						viewBox = (SvgRect)outerSvg.ViewBox.AnimVal;
					}
					else
					{
                        viewBox = SvgRect.Empty;                        
					}
				}
				else
				{
					viewBox = new SvgRect(0,0, Bitmap.Size.Width, Bitmap.Size.Height);
				}

				return viewBox;
			}

		}

		public bool IsSvgImage
		{
			get
			{
				if(!Href.AnimVal.StartsWith("data:"))
				{
					WebResponse resource = svgURIReference.ReferencedResource;

					// local files are returning as binary/octet-stream
					// this "fix" tests the file extension for .svg and .svgz
					string name = resource.ResponseUri.ToString().ToLower(CultureInfo.InvariantCulture);
					return (
						resource.ContentType.StartsWith("image/svg+xml") ||
						name.EndsWith(".svg") ||
						name.EndsWith(".svgz") );
				}
				else
					return false;
			}
		}

		public Bitmap Bitmap
		{
			get
			{
				if(!IsSvgImage)
				{
					if(!Href.AnimVal.StartsWith("data:")) 
					{
						Stream stream = svgURIReference.ReferencedResource.GetResponseStream();
						return (Bitmap)Bitmap.FromStream(stream);
					}
					else 
					{
						string sURI = Href.AnimVal;
						int nColon = sURI.IndexOf(":");
						int nSemiColon = sURI.IndexOf(";");
						int nComma = sURI.IndexOf(",");

						string sMimeType = sURI.Substring(nColon + 1,nSemiColon - nColon - 1);

						string sContent = sURI.Substring(nComma + 1);
						byte[] bResult = Convert.FromBase64CharArray(sContent.ToCharArray(),0,sContent.Length);

						MemoryStream ms = new MemoryStream(bResult);

						return (Bitmap)Bitmap.FromStream(ms);
					}
				}
				else
				{
					return null;
				}
			}
		}

		public SvgWindow SvgWindow
		{
			get
			{
				if(IsSvgImage)
				{
					SvgWindow parentWindow = (SvgWindow)OwnerDocument.Window;

					SvgWindow wnd = new SvgWindow(parentWindow, (long)Width.AnimVal.Value, (long)Height.AnimVal.Value);

					SvgDocument doc = new SvgDocument(wnd);
					wnd.Document = doc;

					string absoluteUri = svgURIReference.AbsoluteUri;

					Stream resStream = svgURIReference.ReferencedResource.GetResponseStream();
					doc.Load(absoluteUri, resStream);

					return wnd;
				}
				else
				{
					return null;
				}
			}
		}
		#endregion

    #region Update handling		
    public override void HandleAttributeChange(XmlAttribute attribute)
    {
      if(attribute.NamespaceURI.Length == 0)
      {
        // This list may be too long to be useful...
        switch(attribute.LocalName)
        {
            // Additional attributes
          case "x":
            x = null;
            return;
          case "y":
            y = null;
            return;
          case "width":
            width = null;
            return;
          case "height":
            height = null;
            return;
        }
      
        base.HandleAttributeChange(attribute);
      } 
    }
    #endregion


		#region Implementation of ISvgExternalResourcesRequired
		private SvgExternalResourcesRequired svgExternalResourcesRequired;
		public ISvgAnimatedBoolean ExternalResourcesRequired
		{
			get
			{
				return svgExternalResourcesRequired.ExternalResourcesRequired;
			}
		}
		#endregion

		#region Implementation of ISvgTests
		private SvgTests svgTests;
		public ISvgStringList RequiredFeatures
		{
			get { return svgTests.RequiredFeatures; }
		}

		public ISvgStringList RequiredExtensions
		{
			get { return svgTests.RequiredExtensions; }
		}

		public ISvgStringList SystemLanguage
		{
			get { return svgTests.SystemLanguage; }
		}

		public bool HasExtension(string extension)
		{
			return svgTests.HasExtension(extension);
		}
        #endregion

		#region UnitTests
		#endregion
		
	}
}
