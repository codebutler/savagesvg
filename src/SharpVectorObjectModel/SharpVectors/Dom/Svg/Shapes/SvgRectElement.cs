using System;
using System.Xml;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;

using SharpVectors.Dom.Events;


namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SVGRectElement interface corresponds to the 'rect' element. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public class SvgRectElement
		: SvgTransformableElement
		, ISharpGDIPath
		, ISvgRectElement
		, IGraphicsElement
	{
		#region Constructors
		
		internal SvgRectElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
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

		#region Implementation of ISvgRectElement
		private ISvgAnimatedLength width;
		public ISvgAnimatedLength Width
		{
			get
			{
				if(width == null)
				{
					width =  new SvgAnimatedLength(this, "width", SvgLengthDirection.Horizontal, "100");
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
					height = new SvgAnimatedLength(this, "height", SvgLengthDirection.Vertical, "100");
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

		private ISvgAnimatedLength rx;
		public ISvgAnimatedLength Rx
		{
			get
			{
				if(rx == null)
				{
					rx = new SvgAnimatedLength(this, "rx", SvgLengthDirection.Horizontal, "0");
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
					ry = new SvgAnimatedLength(this, "ry", SvgLengthDirection.Vertical, "0");
				}
				return ry;
			}
		}

		#endregion

		#region Implementation of ISharpGDIPath

		public void Invalidate()
		{
			gp = null;
      renderingNode = null;
		}

		private void addRoundedRect(GraphicsPath graphicsPath, RectangleF rect, float rx, float ry)
		{
			if(rx == 0F) rx = ry;
			else if(ry == 0F) ry = rx;

			rx = Math.Min(rect.Width/2, rx);
			ry = Math.Min(rect.Height/2, ry);

			float a = rect.X + rect.Width - rx;
			graphicsPath.AddLine(rect.X + rx, rect.Y, a, rect.Y);
			graphicsPath.AddArc(a-rx, rect.Y, rx*2, ry*2, 270, 90);
			
			float right = rect.X + rect.Width;	// rightmost X
			float b = rect.Y + rect.Height - ry;

			graphicsPath.AddLine(right, rect.Y + ry, right, b);
			graphicsPath.AddArc(right - rx*2, b-ry, rx*2, ry*2, 0, 90);
			
			graphicsPath.AddLine(right - rx, rect.Y + rect.Height, rect.X + rx, rect.Y + rect.Height);
			graphicsPath.AddArc(rect.X, b-ry, rx*2, ry*2, 90, 90);
			
			graphicsPath.AddLine(rect.X, b, rect.X, rect.Y + ry);
			graphicsPath.AddArc(rect.X, rect.Y, rx*2, ry*2, 180, 90);
		}

		
		private GraphicsPath gp = null;
		public GraphicsPath GetGraphicsPath()
		{
			if(gp == null)
			{
				gp = new GraphicsPath();

				RectangleF rect = new RectangleF((float)X.AnimVal.Value, (float)Y.AnimVal.Value, (float)Width.AnimVal.Value, (float)Height.AnimVal.Value);
			
        float rx = (float)Rx.AnimVal.Value;
				float ry = (float)Ry.AnimVal.Value;

				if(rx == 0F && ry == 0F)
				{
					gp.AddRectangle(rect);
				}
				else
				{
					addRoundedRect(gp, rect, rx, ry);
				}
			}
			return gp;
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
            Invalidate();
						return;
					case "y":
						y = null;
            Invalidate();
            return;
					case "width":
						width = null;
            Invalidate();
            return;
					case "height":
						height = null;
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
          case "onclick":
            break;

        }
      
        base.HandleAttributeChange(attribute);
      }
		}
		#endregion
	}
}
