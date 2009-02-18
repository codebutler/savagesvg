using System;
using System.Xml;
using System.Drawing.Drawing2D;
using System.Diagnostics;



namespace SharpVectors.Dom.Svg
{
	public delegate void InvalidateEventHandler(Object sender, EventArgs e);
	
	/// <summary>
	/// The SVGCircleElement interface corresponds to the 'rect' element. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public class SvgCircleElement : SvgTransformableElement, ISharpGDIPath, ISvgCircleElement, IGraphicsElement
	{
		#region Private Fields

		private GraphicsPath gp = null;

		#endregion

		#region Constructors

		internal SvgCircleElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}

		#endregion

		#region Implementation of ISvgCircleElement
		private ISvgAnimatedLength cx;
		public ISvgAnimatedLength Cx
		{
			get
			{
				if(cx == null)
				{
					cx = new SvgAnimatedLength(this, "cx", SvgLengthDirection.Horizontal, "0");
				}
				return cx;
			}
		}
  		
		private ISvgAnimatedLength cy;
		public ISvgAnimatedLength Cy
		{
			get
			{
				if(cy == null)
				{
					cy = new SvgAnimatedLength(this, "cy", SvgLengthDirection.Vertical, "0");
				}
				return cy;
			}
  			
		}
  		
		private ISvgAnimatedLength r;
		public ISvgAnimatedLength R
		{
			get
			{
				if(r == null)
				{
					r = new SvgAnimatedLength(this, "r", SvgLengthDirection.Viewport, "100");
				}
				return r;
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

		#region Implementation of ISharpGDIPath
		public void Invalidate()
		{
			/*			if(InvalidateEvent != null)
						{
							EventArgs e = new EventArgs();
							this.InvalidateEvent(this, e);
						}*/
			gp = null;
      renderingNode = null;
		}

		public GraphicsPath GetGraphicsPath()
		{
			if(gp == null)
			{
				gp = new GraphicsPath();
				float _cx = (float)Cx.AnimVal.Value;
				float _cy = (float)Cy.AnimVal.Value;
				float _r = (float)R.AnimVal.Value;

				gp.AddEllipse(_cx-_r, _cy-_r, _r*2, _r*2);
			}
			return gp;
		}

		#endregion

		#region Update handling
    public override void HandleAttributeChange(XmlAttribute attribute)
    {
      if(attribute.NamespaceURI.Length == 0)
      {
        switch(attribute.LocalName)
        {
          case "cx":
            cx = null;
            Invalidate();
            return;
          case "cy":
            cy = null;
            Invalidate();
            return;
          case "r":
            r = null;
            Invalidate();
            return;
            // Color.attrib, Paint.attrib 
          case "color":
          case "fill":
          case "fill-rule":
          case "stroke": 
          case "stroke-dasharray": 
          case "stroke-dashoffset": 
          case "stroke-linecap": 
          case "stroke-linejoin": 
          case "stroke-miterlimit": 
          case "stroke-width": 
            // Opacity.attrib
          case "opacity": 
          case "stroke-opacity": 
          case "fill-opacity": 
            // Graphics.attrib
          case "display": 
          case "image-rendering": 
          case "shape-rendering": 
          case "text-rendering": 
          case "visibility":
            Invalidate();
            break;
          case "transform":
            Invalidate();
            break;
        }

        base.HandleAttributeChange(attribute);
      }
    }
    #endregion
	}
}
