using System;
using System.Xml;
using System.IO;
using System.Net;
using SharpVectors.Net;
using SharpVectors.Dom.Css;

namespace SharpVectors.Dom.Svg
{
	public class SvgURIReference : ISvgURIReference
	{
		public SvgURIReference(SvgElement ownerElement)
		{
			this.ownerElement = ownerElement;
			this.ownerElement.attributeChangeHandler += new NodeChangeHandler(AttributeChange);
		}

		#region Private fields
		private SvgElement ownerElement;
		#endregion

		#region Update handling
		private void AttributeChange(Object src, XmlNodeChangedEventArgs args)
		{
			XmlAttribute attribute = src as XmlAttribute;

			if(attribute.NamespaceURI == SvgDocument.XLinkNamespace &&
				attribute.LocalName == "href")
			{
				href = null;
				referencedNode = null;
				referencedResource = null;
				absoluteUri = null;
			}
		}

    public NodeChangeHandler referencedNodeChangeHandler;
    private void ReferencedNodeChange(Object src, XmlNodeChangedEventArgs args) 
    {
      if (referencedNodeChangeHandler != null) 
      {
        referencedNodeChangeHandler(src, args);
      }
    }
		#endregion

		#region Implementation of ISvgURIReference
		private ISvgAnimatedString href;
		public ISvgAnimatedString Href
		{
			get
			{
				if(href == null)
				{
					href = new SvgAnimatedString(ownerElement.GetAttribute("href", SvgDocument.XLinkNamespace));
				}
				return href;
			}
		}
		#endregion

		#region And you get these extras for free!
		private string absoluteUri;
		public string AbsoluteUri
		{
			get
			{
				if(absoluteUri == null)
				{
					if(ownerElement.HasAttribute("href", SvgDocument.XLinkNamespace))
					{
						string href = Href.AnimVal.Trim();

						if(href.StartsWith("#"))
						{
							return href;
						}
						else
						{
							string baseUri = ownerElement.BaseURI;
							if(baseUri.Length == 0)
							{
								absoluteUri = new Uri(Href.AnimVal).ToString();

							}
							else
							{
								absoluteUri = new Uri(new Uri(ownerElement.BaseURI), Href.AnimVal).ToString();
							}
						}
					}
				}
				return absoluteUri;
			}
		}

		private XmlNode referencedNode;
		public XmlNode ReferencedNode
		{
			get
			{
				if(referencedNode == null)
				{
					if(ownerElement.HasAttribute("href", SvgDocument.XLinkNamespace))
					{
						referencedNode = ownerElement.OwnerDocument.GetNodeByUri(AbsoluteUri);

            if(referencedNode == null && ownerElement is ISvgExternalResourcesRequired)
            {
              ISvgExternalResourcesRequired extReqElm = (ISvgExternalResourcesRequired)ownerElement;
							
              if(extReqElm.ExternalResourcesRequired.AnimVal)
              {
                throw new SvgExternalResourcesRequiredException();
              }
            } 
            else if (referencedNode is CssXmlElement)
            {
              CssXmlElement cssRef = (CssXmlElement)referencedNode;
              cssRef.attributeChangeHandler += new NodeChangeHandler(ReferencedNodeChange);
              cssRef.elementChangeHandler += new NodeChangeHandler(ReferencedNodeChange);
              cssRef.parentNodeChangeHandler += new NodeChangeHandler(ReferencedNodeChange);
              cssRef.childNodeChangeHandler += new NodeChangeHandler(ReferencedNodeChange);
            }
					}
					else
					{
						referencedNode = null; 
					}
				}
				return referencedNode;
			}
		}

		private WebResponse referencedResource;
		public WebResponse ReferencedResource
		{
			get
			{
				if(referencedResource == null)
				{
					if(ownerElement.HasAttribute("href", SvgDocument.XLinkNamespace))
					{

						referencedResource = ownerElement.OwnerDocument.GetResource(new Uri(AbsoluteUri));

						if(referencedResource == null && ownerElement is ISvgExternalResourcesRequired)
						{
							ISvgExternalResourcesRequired extReqElm = (ISvgExternalResourcesRequired)ownerElement;
							
							if(extReqElm.ExternalResourcesRequired.AnimVal)
							{
								throw new SvgExternalResourcesRequiredException();
							}
						}
					}
					else
					{
						referencedResource = null; 
					}
				}
				return referencedResource;
			}
		}
		#endregion
	}
}
