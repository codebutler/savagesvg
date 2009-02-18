using System;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SVGLineElement interface corresponds to the 'line' element.  
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public class SvgLineElement : SvgTransformableElement, ISharpGDIPath, ISvgLineElement, ISharpMarkerHost, IGraphicsElement
	{
		#region Private Fields
		
		private GraphicsPath gp = null;

		#endregion

		#region Constructors

		internal SvgLineElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}

		#endregion

		#region Implementation of ISvgLineElement
		private ISvgAnimatedLength x1;
		public ISvgAnimatedLength X1
		{
			get
			{
				if(x1 == null)
				{
					x1 = new SvgAnimatedLength(this, "x1", SvgLengthDirection.Horizontal, "0");
				}
				return x1;
			}
		}
  		
		private ISvgAnimatedLength y1;
		public ISvgAnimatedLength Y1
		{
			get
			{
				if(y1 == null)
				{
					y1 = new SvgAnimatedLength(this, "y1", SvgLengthDirection.Vertical, "0");
				}
				return y1;
			}
  			
		}

		private ISvgAnimatedLength x2;
		public ISvgAnimatedLength X2
		{
			get
			{
				if(x2 == null)
				{
					x2 = new SvgAnimatedLength(this, "x2", SvgLengthDirection.Horizontal, "0");
				}
				return x2;
			}
		}
  		
		private ISvgAnimatedLength y2;
		public ISvgAnimatedLength Y2
		{
			get
			{
				if(y2 == null)
				{
					y2 = new SvgAnimatedLength(this, "y2", SvgLengthDirection.Vertical, "0");
				}
				return y2;
			}
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
				gp.AddLine(
					(float)X1.AnimVal.Value, 
					(float)Y1.AnimVal.Value, 
					(float)X2.AnimVal.Value, 
					(float)Y2.AnimVal.Value);
			}
			
			return gp;
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

		#region Implementation of ISharpMarkerHost
		public System.Drawing.PointF[] MarkerPositions
		{
			get
			{
				return new PointF[]{new PointF((float)X1.AnimVal.Value, (float)Y1.AnimVal.Value), new PointF((float)X2.AnimVal.Value, (float)Y2.AnimVal.Value)};
			}
		}

		public float GetStartAngle(int index)
		{
			return 0;
		}

		public float GetEndAngle(int index)
		{
			return 0;
		}
		#endregion

		#region Update handling
    public override void HandleAttributeChange(XmlAttribute attribute)
    {
      if(attribute.NamespaceURI.Length == 0)
      {
        switch(attribute.LocalName)
        {
          case "x1":
            x1 = null;
            Invalidate();
            return;
          case "y1":
            y1 = null;
            Invalidate();
            return;
          case "x2":
            x2 = null;
            Invalidate();
            return;
          case "y2":
            y2 = null;
            Invalidate();
            return;
          case "marker-start":
          case "marker-mid":
          case "marker-end":
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
