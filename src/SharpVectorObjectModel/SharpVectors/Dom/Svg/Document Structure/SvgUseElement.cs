using System;
using System.Xml;
using System.Drawing;
using SharpVectors.Dom.Svg.Rendering;
using SharpVectors.Dom.Css;
using System.Collections;

namespace SharpVectors.Dom.Svg
{
	public class SvgUseElement : SvgTransformableElement, ISvgUseElement
	{
		#region Constructors
		internal SvgUseElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
		{
			svgURIReference = new SvgURIReference(this);
      svgURIReference.referencedNodeChangeHandler += new NodeChangeHandler(ReferencedNodeChange);
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}
		#endregion

		#region Implementation of ISvgUseElement 
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

		private ISvgAnimatedLength width;
		public ISvgAnimatedLength Width
		{
			get
			{
				if(width == null)
				{
					width = new SvgAnimatedLength(this, "width", SvgLengthDirection.Horizontal, String.Empty);
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
					height = new SvgAnimatedLength(this, "height", SvgLengthDirection.Vertical, String.Empty);
				}
				return height;
			}
		}

		private ISvgElementInstance instanceRoot;
		public ISvgElementInstance InstanceRoot
		{
			get
			{
				if(instanceRoot == null)
				{
					instanceRoot = new SvgElementInstance(ReferencedElement, this, null);
				}
				return instanceRoot;
			}
		}

		public ISvgElementInstance AnimatedInstanceRoot
		{
			get
			{
				return InstanceRoot;
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

		#region Update handling
		public override void HandleAttributeChange(XmlAttribute attribute)
		{
			if(attribute.NamespaceURI.Length == 0)
			{
				switch(attribute.LocalName)
				{
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
      }
			else if(attribute.NamespaceURI == SvgDocument.XLinkNamespace)
			{
				switch(attribute.LocalName)
				{
					case "href":
						instanceRoot = null;
            break;
				}
			}

      base.HandleAttributeChange(attribute);
    }

    public void ReferencedNodeChange(Object src, XmlNodeChangedEventArgs args) 
    {
      //TODO - This is getting called too often!
      //instanceRoot = null;
    }
    #endregion    

    #region Rendering   
    private string saveTransform = null;
    private string saveWidth = null;
    private string saveHeight = null;
    public void CopyToReferencedElement(XmlElement refEl) 
    {
      // X and Y become a translate portion of any transform, width and height may get passed on
      if (X.AnimVal.Value != 0 || Y.AnimVal.Value != 0)
      {
        saveTransform = this.GetAttribute("transform");
        this.SetAttribute("transform", saveTransform + " translate(" + X.AnimVal.Value + "," + Y.AnimVal.Value + ")");
      }      
      if (refEl is SvgSymbolElement) 
      {
        refEl.SetAttribute("width", (HasAttribute("width")) ? GetAttribute("width") : "100%");
        refEl.SetAttribute("height", (HasAttribute("height")) ? GetAttribute("height") : "100%");
      }
      if (refEl is SvgSymbolElement) 
      {
        saveWidth = refEl.GetAttribute("width");
        saveHeight = refEl.GetAttribute("height");
        if (HasAttribute("width"))
          refEl.SetAttribute("width",  GetAttribute("width"));
        if (HasAttribute("height"))
          refEl.SetAttribute("height", GetAttribute("height"));
      }
    }

    public void RestoreReferencedElement(XmlElement refEl) 
    {
      if (saveTransform != null)
        this.SetAttribute("transform", saveTransform);
      if (saveWidth != null) 
      {
        refEl.SetAttribute("width", saveWidth);
        refEl.SetAttribute("height", saveHeight);
      }
    }

		public override void Render(ISvgRenderer renderer)
		{
      XmlElement refEl = ReferencedElement;
      if (refEl == null)
        return;
      XmlElement refElParent = (XmlElement)refEl.ParentNode;
			OwnerDocument.Static = true;
      CopyToReferencedElement(refEl);
      refElParent.RemoveChild(refEl);
      this.AppendChild(refEl);      
      base.Render(renderer);
      this.RemoveChild(refEl);
      RestoreReferencedElement(refEl);
      refElParent.AppendChild(refEl);
      OwnerDocument.Static = false;
    }
		
    public override void CacheRenderingRegion(ISvgRenderer renderer) 
    {
      SvgTransformableElement refEl = ReferencedElement as SvgTransformableElement;
      if (refEl == null)
        return;

      if(renderingNode == null)
      {
        renderingNode = renderer.GetRenderingNode(this);
      }

      // Check if it has already been calculated
      if (renderingNode != null && renderingNode.ScreenRegion != RectangleF.Empty)
        return;

      XmlElement refElParent = (XmlElement)refEl.ParentNode;
      OwnerDocument.Static = true;
      CopyToReferencedElement(refEl);
      refElParent.RemoveChild(refEl);
      this.AppendChild(refEl);      
      refEl.CacheRenderingRegion(renderer);
      renderingNode.ScreenRegion = refEl.RenderingNode.ScreenRegion;			      
      this.RemoveChild(refEl);
      RestoreReferencedElement(refEl);
      refElParent.AppendChild(refEl);
      OwnerDocument.Static = false;
    }

    public override void InvalidateRenderingRegion() 
    {
      if (renderingNode != null)
        renderingNode.ScreenRegion = RectangleF.Empty;
      if (ReferencedElement != null && ReferencedElement is SvgElement) 
        ((SvgElement)ReferencedElement).InvalidateRenderingRegion();
    }
    #endregion


	}
}
