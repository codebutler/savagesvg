using System;
using System.Drawing;
using System.Xml;
using System.Drawing.Drawing2D;

namespace SharpVectors.Dom.Svg
{
	public abstract class SvgPolyElement : SvgTransformableElement, ISharpGDIPath, ISharpMarkerHost, IGraphicsElement
	{
		#region Contructors
		internal SvgPolyElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}
		#endregion

		#region Protected Fields
		protected GraphicsPath gp = null;
		#endregion

		#region Public Properties
		public ISvgPointList AnimatedPoints
		{
			get
			{
				return Points;
			}
		}

		private ISvgPointList points;
		public ISvgPointList Points
		{
			get
			{
				if(points == null)
				{
					points = new SvgPointList(GetAttribute("points"));
				}
				return points;
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

				ISvgPointList list = AnimatedPoints;
				ulong nElems = list.NumberOfItems;

				PointF[] points = new PointF[nElems];

				for(uint i = 0; i<nElems; i++)
				{
					points[i] = new PointF((float)list.GetItem(i).X, (float)list.GetItem(i).Y);
				}
			
				if(this is SvgPolygonElement)
				{
					gp.AddPolygon(points);
				}
				else
				{
					gp.AddLines(points);
				}

				string fillRule = GetPropertyValue("fill-rule");
				if(fillRule == "evenodd") gp.FillMode = FillMode.Alternate;
				else gp.FillMode = FillMode.Winding;
			}
			
			return gp;
		}
		#endregion

		#region Implementation of ISharpMarkerHost
		public virtual PointF[] MarkerPositions
		{
			get
			{
				// moved this code from SvgPointList.  This should eventually migrate into
				// the GDI+ renderer
				PointF[] points = new PointF[Points.NumberOfItems];

				for ( uint i = 0; i < Points.NumberOfItems; i++ )
				{
					SvgPoint point = (SvgPoint)Points.GetItem(i);
					points[i] = new PointF((float) point.X, (float) point.Y);
				}

				return points;
			}
		}

		public float GetStartAngle(int index)
		{
			index--;

			PointF[] positions = MarkerPositions;

			if(index > positions.Length - 1)
			{
				throw new Exception("GetStartAngle: index to large");
			}

			PointF p1 = positions[index];
			PointF p2 = positions[index + 1];

			float dx = p2.X - p1.X;
			float dy = p2.Y - p1.Y;

			float a = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
			a -= 90;
			a %= 360;
			return a;
		}

		public float GetEndAngle(int index)
		{
			float a = GetStartAngle(index);
			a += 180;
			a %= 360;
			return a;
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
					case "points":
						points = null;
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
