using System;
using System.Xml;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpVectors.Dom.Svg.Rendering;

namespace SharpVectors.Dom.Svg
{
	public class SvgTransformableElement : SvgStyleableElement, ISvgTransformable
	{
		#region Constructors
		internal SvgTransformableElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
		}

		#endregion

		#region Implementation of ISvgTransformable
		private ISvgAnimatedTransformList transform;
		public ISvgAnimatedTransformList Transform
		{
			get
			{
				if(transform == null)
				{
					transform = new SvgAnimatedTransformList(GetAttribute("transform"));	
				}
				return transform;
			}
		}

		public ISvgElement NearestViewportElement
		{
			get
			{
				XmlNode parent = this.ParentNode;
				while(parent != null)
				{
					if(parent is SvgSvgElement)
					{
						return (ISvgElement)parent;
					}
					parent = parent.ParentNode;
				}
				return null;
			}
		}
		public ISvgElement FarthestViewportElement
		{
			get
			{
				ISvgDocument doc = OwnerDocument;
				//if(doc.RootElement == this) return null;
				/*else */return doc.RootElement;
			}
		}

    public ISvgRect GetBBox() 
    {
      return new SvgRect(GetBRect(0));
    }

    public RectangleF GetBRect(float margin)
    {
      if(this is ISharpGDIPath)
      {
        ISharpGDIPath gdiPathElm = (ISharpGDIPath) this;
        GraphicsPath gp = gdiPathElm.GetGraphicsPath();
        SvgMatrix svgMatrix = (SvgMatrix)this.GetScreenCTM();
        RectangleF bounds = gp.GetBounds(svgMatrix.ToMatrix());
        bounds = RectangleF.Inflate(bounds, margin, margin);
        return bounds; 
      }
      else if (this is ISvgUseElement)        
      {
        SvgUseElement use = (SvgUseElement)this;
        SvgTransformableElement refEl = use.ReferencedElement as SvgTransformableElement;
        if (refEl == null)
          return RectangleF.Empty;
        XmlElement refElParent = (XmlElement)refEl.ParentNode;
        OwnerDocument.Static = true;
        use.CopyToReferencedElement(refEl);
        this.AppendChild(refEl);      
        RectangleF bbox = refEl.GetBRect(margin);
        this.RemoveChild(refEl);
        use.RestoreReferencedElement(refEl);
        refElParent.AppendChild(refEl);
        OwnerDocument.Static = false;
        return bbox;
      } 
      else 
      {
        RectangleF union = RectangleF.Empty;
        SvgTransformableElement transformChild;
        foreach(XmlNode childNode in ChildNodes)
        {
          if (childNode is SvgDefsElement)
            continue;
          if (childNode is ISvgTransformable)
          {
            transformChild = (SvgTransformableElement)childNode;
            RectangleF bbox = transformChild.GetBRect(margin);
            if (bbox != RectangleF.Empty) 
            {
              if(union == RectangleF.Empty) union = bbox;
              else union = RectangleF.Union(union, bbox);
            }
          }
        }
				
        return union;
      }
    }

    /// <summary>
    /// For each given element, the accumulation of all transformations that have been defined 
    /// on the given element and all of its ancestors up to and including the element that 
    /// established the current viewport (usually, the 'svg' element which is the most 
    /// immediate ancestor to the given element) is called the current transformation matrix 
    /// or CTM. 
    /// </summary>
    /// <returns>A matrix representing the mapping of current user coordinates to viewport 
    /// coordinates.</returns>
    public ISvgMatrix GetCTM()
    {
      ISvgMatrix matrix = new SvgMatrix();
      ISvgTransformList svgTList;
      ISvgMatrix vCTM;
      if (this is SvgSvgElement)
      {
        vCTM = (this as SvgSvgElement).ViewBoxTransform;
        matrix = vCTM;
      }
      else if (this.Transform != null) 
      {
        svgTList = this.Transform.AnimVal;
        matrix = svgTList.Consolidate().Matrix;
      }
      
      ISvgElement nVE = this.NearestViewportElement;
      if(nVE != null)
      {
        SvgTransformableElement par = ParentNode as SvgTransformableElement;
        while(par != null && par != nVE)
        {
          svgTList = par.Transform.AnimVal;
          matrix = svgTList.Consolidate().Matrix.Multiply(matrix);
          par = par.ParentNode as SvgTransformableElement;
        }

        if (par == nVE && nVE is SvgSvgElement) 
        {
          vCTM = (nVE as SvgSvgElement).ViewBoxTransform;
          matrix = vCTM.Multiply(matrix);
        }
      } 
      return matrix;
    }

    public ISvgMatrix GetScreenCTM()
    {
      ISvgMatrix matrix = new SvgMatrix();
      ISvgTransformList svgTList;
      ISvgMatrix vCTM;
      if (this is SvgSvgElement)
      {
        vCTM = (this as SvgSvgElement).ViewBoxTransform;
        matrix = vCTM;
      }
      else if (this.Transform != null) 
      {
        svgTList = this.Transform.AnimVal;
        matrix = svgTList.Consolidate().Matrix;
      } 
      
      SvgTransformableElement par = ParentNode as SvgTransformableElement;
      while(par != null)
      {
        // TODO: other elements can establish viewports, not just <svg>!
        if (par is SvgSvgElement) 
        {
          vCTM = (par as SvgSvgElement).ViewBoxTransform;
          matrix = vCTM.Multiply(matrix);
        } 
        else 
        {
          svgTList = par.Transform.AnimVal;
          matrix = svgTList.Consolidate().Matrix.Multiply(matrix);
        }
        par = par.ParentNode as SvgTransformableElement;
      }

      // Now scale out the pixels
      //ISvgSvgElement root = OwnerDocument.RootElement;
      //float innerWidth = this.OwnerDocument.Window.InnerWidth;
      //float innerHeight = this.OwnerDocument.Window.InnerHeight;
      //if (innerWidth != 0 && innerHeight != 0) 
      //{
      //  float screenRatW = (float)root.Width.AnimVal.Value / innerWidth;
      //  float screenRatH = (float)root.Height.AnimVal.Value / innerHeight;
      //  matrix.ScaleNonUniform(screenRatW, screenRatH);
      //}

      return matrix;
    }

		public ISvgMatrix GetTransformToElement(ISvgElement element)
		{
      ISvgLocatable loc = element as ISvgLocatable;
      ISvgMatrix ctm = loc.GetCTM();
      ISvgMatrix vctm;
      XmlNode node = element.ParentNode;
      while (node != null && node != OwnerDocument) 
      {
        if (node.Name == "svg") 
        {
          vctm = (node as SvgSvgElement).ViewBoxTransform;
          ctm = vctm.Multiply(ctm);
        } 
        else 
        {
          loc = node as ISvgLocatable;
          ctm = loc.GetCTM().Multiply(ctm);
        }

        node = node.ParentNode;
      }

      return ctm;
		}

		#endregion
    public override void CacheRenderingRegion(ISvgRenderer renderer) 
    {
      base.CacheRenderingRegion(renderer);

      if (renderingNode != null)
      {
        if (renderingNode.ScreenRegion != RectangleF.Empty)
          return;

        //TODO this is still fairly experimental, a margin of 20 gives us some overlap for leeway
        //TODO in general, overlap is necessary to handle strokes, which are not covered in bbox, but are 
        //TODO for rendering purposes (same with markers)
        string strokeWidth = this.GetPropertyValue("stroke-width");
        if(strokeWidth.Length == 0) strokeWidth = "1px";
        SvgLength strokeWidthLength = new SvgLength(this, "stroke-width", SvgLengthDirection.Viewport, strokeWidth);
        renderingNode.ScreenRegion = GetBRect((float)strokeWidthLength.Value);			
      }
    }


		#region Update handling
    public override void CssInvalidate() 
    {
      base.CssInvalidate();
      
      string strokeWidth = this.GetPropertyValue("stroke-width");
      if(strokeWidth.Length == 0) strokeWidth = "1px";
      SvgLength strokeWidthLength = new SvgLength(this, "stroke-width", SvgLengthDirection.Viewport, strokeWidth);
      
      if (renderingNode != null) 
      {
        // Quick-cache
        renderingNode.ScreenRegion = GetBRect((float)strokeWidthLength.Value);			
        OwnerDocument.Window.Renderer.InvalidateRect(renderingNode.ScreenRegion);
      } 
      else 
      {
        OwnerDocument.Window.Renderer.InvalidateRect(GetBRect((float)strokeWidthLength.Value));
      }
    }

		public override void HandleAttributeChange(XmlAttribute attribute)
		{
			if(attribute.NamespaceURI.Length == 0)
			{
				switch(attribute.LocalName)
				{
          case "transform":
						transform = null;
            renderingNode = null;
            return;
				}
      
        base.HandleAttributeChange(attribute);
      }
		}
		#endregion
	}
}
