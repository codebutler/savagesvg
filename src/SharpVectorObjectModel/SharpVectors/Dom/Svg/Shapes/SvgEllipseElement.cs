using System;
using System.Xml;
using System.Drawing.Drawing2D;



namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgEllipseElement class corresponds to the 'ellipse' element. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public class SvgEllipseElement : SvgTransformableElement, ISharpGDIPath, ISvgEllipseElement, IGraphicsElement
	{

		#region Private Fields

		private GraphicsPath gp = null;

		#endregion

		#region Constructors

		internal SvgEllipseElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}

		#endregion
	
		#region Implementation of ISvgEllipseElement
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
  		
		private ISvgAnimatedLength rx;
		public ISvgAnimatedLength Rx
		{
			get
			{
				if(rx == null)
				{
					rx = new SvgAnimatedLength(this, "rx", SvgLengthDirection.Horizontal, "100");
				}
				return rx;
			}
  			
		}

		private ISvgAnimatedLength ry;
		public ISvgAnimatedLength Ry
		{
			get
			{
				if(ry == null)
				{
					ry = new SvgAnimatedLength(this, "ry", SvgLengthDirection.Vertical, "100");
				}
				return ry;
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
				float _rx = (float)Rx.AnimVal.Value;
				float _ry = (float)Ry.AnimVal.Value;

				/*if (_cx <= 1 && _cy <= 1 && _rx <= 1 && _ry <= 1)
				{
					gp.AddEllipse(_cx-_rx, _cy-_ry, _rx*2, _ry*2);
				}
				else
				{
					gp.AddEllipse(_cx-_rx, _cy-_ry, _rx*2 - 1, _ry*2 - 1);
				}*/
				gp.AddEllipse(_cx-_rx, _cy-_ry, _rx*2, _ry*2);
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
          case "rx":
            rx = null;
            Invalidate();
            return;
          case "ry":
            ry = null;
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
