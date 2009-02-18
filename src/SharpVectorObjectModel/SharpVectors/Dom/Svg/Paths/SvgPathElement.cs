using System;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;


namespace SharpVectors.Dom.Svg
{
	public class SvgPathElement : SvgTransformableElement, ISvgPathElement, ISharpGDIPath, ISharpMarkerHost, IGraphicsElement
	{
		#region Constructors
		internal SvgPathElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
		{
			svgTests = new SvgTests(this);
		}

		#endregion

		#region Implementation of ISharpMarkerHost
		public PointF[] MarkerPositions
		{
			get
			{
				return ((SvgPathSegList)PathSegList).Points;
			}
		}
		
		public float GetStartAngle(int index)
		{
			return ((SvgPathSegList)PathSegList).GetStartAngle(index);
		}

		public float GetEndAngle(int index)
		{
			return ((SvgPathSegList)PathSegList).GetEndAngle(index);
		}
		#endregion

		#region Implementation of ISharpGDIPath
		public void Invalidate()
		{
		}

		private GraphicsPath gp = null;
		public GraphicsPath GetGraphicsPath()
		{
			if(gp == null)
			{
				gp = new GraphicsPath();

				PointF initPoint = new PointF(0, 0);
				PointF lastPoint = new PointF(0,0);

				SvgPathSegList segments = (SvgPathSegList)PathSegList;
				SvgPathSeg segment;

				int nElems = segments.NumberOfItems;

				for(int i = 0; i<nElems; i++)
				{
					segment = (SvgPathSeg) segments.GetItem(i);

					if(segment is SvgPathSegMoveto)
					{
						SvgPathSegMoveto seg = (SvgPathSegMoveto) segment;
						gp.StartFigure();
						lastPoint = initPoint = seg.AbsXY;
					}
					else if(segment is SvgPathSegLineto)
					{
						SvgPathSegLineto seg = (SvgPathSegLineto) segment;
						PointF p = seg.AbsXY;
						gp.AddLine(lastPoint.X, lastPoint.Y, p.X, p.Y);

						lastPoint = p;
					}
					else if(segment is SvgPathSegCurveto)
					{
						SvgPathSegCurveto seg = (SvgPathSegCurveto)segment;
						PointF xy = seg.AbsXY;
						PointF x1y1 = seg.CubicX1Y1;
						PointF x2y2 = seg.CubicX2Y2;
						gp.AddBezier(lastPoint.X, lastPoint.Y, x1y1.X, x1y1.Y, x2y2.X, x2y2.Y, xy.X, xy.Y);

						lastPoint = xy;
					}
					else if(segment is SvgPathSegArc)
					{
						SvgPathSegArc seg = (SvgPathSegArc)segment;
						PointF p = seg.AbsXY;
						if (lastPoint.Equals(p)) 
						{
							// If the endpoints (x, y) and (x0, y0) are identical, then this
							// is equivalent to omitting the elliptical arc segment entirely.
						}
						else if (seg.R1 == 0 || seg.R2 == 0) 
						{
							// Ensure radii are valid
							gp.AddLine(lastPoint, p);
						}
						else
						{
							CalculatedArcValues calcValues = seg.GetCalculatedArcValues();

							GraphicsPath gp2 = new GraphicsPath();
							gp2.StartFigure();
							gp2.AddArc(
								calcValues.Cx - calcValues.CorrRx,
								calcValues.Cy - calcValues.CorrRy,
								calcValues.CorrRx*2, 
								calcValues.CorrRy*2, 
								calcValues.AngleStart, 
								calcValues.AngleExtent
								);

							Matrix matrix = new Matrix();
							matrix.Translate(
								-calcValues.Cx, 
								-calcValues.Cy
								);
							gp2.Transform(matrix);

							matrix = new Matrix();
							matrix.Rotate(seg.Angle);
							gp2.Transform(matrix);

							matrix = new Matrix();
							matrix.Translate(calcValues.Cx, calcValues.Cy);
							gp2.Transform(matrix);

							gp.AddPath(gp2, true);
						}
						
						lastPoint = p;
					}
					else if(segment is SvgPathSegClosePath)
					{
						gp.CloseFigure();
						lastPoint = initPoint;
					}
				}
				
				string fillRule = GetPropertyValue("fill-rule");
				if(fillRule == "evenodd") gp.FillMode = FillMode.Alternate;
				else gp.FillMode = FillMode.Winding;
			}

			return gp;
		}

		#endregion

		#region Implementation of ISvgPathElement
		public ISvgAnimatedBoolean ExternalResourcesRequired
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		private ISvgPathSegList pathSegList;
		public ISvgPathSegList PathSegList
		{
			get{
				if(pathSegList == null)
				{
                    pathSegList = new SvgPathSegList(this.GetAttribute("d"), false);
				}
				return pathSegList;
			}
		}

		public ISvgPathSegList NormalizedPathSegList
		{
			get{throw new NotImplementedException();}
		}

		public ISvgPathSegList AnimatedPathSegList
		{
			get{return PathSegList;}
		}

		public ISvgPathSegList AnimatedNormalizedPathSegList
		{
			get{return NormalizedPathSegList;}
		}

		private ISvgAnimatedNumber _pathLength;
		public ISvgAnimatedNumber PathLength
		{
			get
			{
				if(_pathLength == null)
				{
                    _pathLength = new SvgAnimatedNumber(GetAttribute("pathLength"));
				}
				return _pathLength;
			}
		}

		public float GetTotalLength()		
		{
			return ((SvgPathSegList)PathSegList).GetTotalLength();
		}

		public ISvgPoint GetPointAtLength(float distance)		
		{
			throw new NotImplementedException();
		}


		public int GetPathSegAtLength(float distance)		
		{
			return ((SvgPathSegList)PathSegList).GetPathSegAtLength(distance);
		}

		#region Create methods
		public ISvgPathSegClosePath CreateSvgPathSegClosePath()
		{
			return new SvgPathSegClosePath();
		}

		public ISvgPathSegMovetoAbs CreateSvgPathSegMovetoAbs(float x, float y)
		{
			return new SvgPathSegMovetoAbs(x, y);
		}

		public ISvgPathSegMovetoRel CreateSvgPathSegMovetoRel(float x, float y)
		{
			return new SvgPathSegMovetoRel(x, y);
		}

		public ISvgPathSegLinetoAbs CreateSvgPathSegLinetoAbs(float x, float y)
		{
			return new SvgPathSegLinetoAbs(x, y);
		}

		public ISvgPathSegLinetoRel CreateSvgPathSegLinetoRel(float x, float y)
		{
			return new SvgPathSegLinetoRel(x, y);
		}

		public ISvgPathSegCurvetoCubicAbs CreateSvgPathSegCurvetoCubicAbs(float x, 
			float y, 
			float x1, 
			float y1, 
			float x2, 
			float y2)
		{
			return new SvgPathSegCurvetoCubicAbs(x, y, x1, y1, x2, y2);
		}
		
		public ISvgPathSegCurvetoCubicRel CreateSvgPathSegCurvetoCubicRel(float x, 
			float y, 
			float x1, 
			float y1, 
			float x2, 
			float y2)		
		{
			return new SvgPathSegCurvetoCubicRel(x, y, x1, y1, x2, y2);
		}

		
		public ISvgPathSegCurvetoQuadraticAbs CreateSvgPathSegCurvetoQuadraticAbs(float x, 
			float y, 
			float x1, 
			float y1)		
		{
			return new SvgPathSegCurvetoQuadraticAbs(x, y, x1, y1);
		}

		
		public ISvgPathSegCurvetoQuadraticRel CreateSvgPathSegCurvetoQuadraticRel(float x, 
			float y, 
			float x1, 
			float y1)		
		{
			return new SvgPathSegCurvetoQuadraticRel(x, y, x1, y1);
		}


		public ISvgPathSegArcAbs CreateSvgPathSegArcAbs(float x,
			float y,
			float r1,
			float r2,
			float angle,
			bool largeArcFlag,
			bool sweepFlag)		
		{
			return new SvgPathSegArcAbs(x, y, r1, r2, angle, largeArcFlag, sweepFlag);
		}


		public ISvgPathSegArcRel CreateSvgPathSegArcRel(float x,
			float y,
			float r1,
			float r2,
			float angle,
			bool largeArcFlag,
			bool sweepFlag)		
		{
			return new SvgPathSegArcRel(x, y, r1, r2, angle, largeArcFlag, sweepFlag);
		}


		public ISvgPathSegLinetoHorizontalAbs CreateSvgPathSegLinetoHorizontalAbs(float x)		
		{
			return new SvgPathSegLinetoHorizontalAbs(x);
		}

		public ISvgPathSegLinetoHorizontalRel CreateSvgPathSegLinetoHorizontalRel(float x)		
		{
			return new SvgPathSegLinetoHorizontalRel(x);
}

		public ISvgPathSegLinetoVerticalAbs CreateSvgPathSegLinetoVerticalAbs(float y)		
		{
			return new SvgPathSegLinetoVerticalAbs(y);
		}

		public ISvgPathSegLinetoVerticalRel CreateSvgPathSegLinetoVerticalRel(float y)		
		{
			return new SvgPathSegLinetoVerticalRel(y);
		}

		public ISvgPathSegCurvetoCubicSmoothAbs CreateSvgPathSegCurvetoCubicSmoothAbs(float x,
			float y,
			float x2,
			float y2)
		{
			return new SvgPathSegCurvetoCubicSmoothAbs(x, y, x2, y2);
		}

		public ISvgPathSegCurvetoCubicSmoothRel CreateSvgPathSegCurvetoCubicSmoothRel(float x,
			float y,
			float x2,
			float y2)		
		{
			return new SvgPathSegCurvetoCubicSmoothRel(x, y, x2, y2);
		}

		public ISvgPathSegCurvetoQuadraticSmoothAbs CreateSvgPathSegCurvetoQuadraticSmoothAbs(float x,
			float y)		
		{
			return new SvgPathSegCurvetoQuadraticSmoothAbs(x, y);
		}

		public ISvgPathSegCurvetoQuadraticSmoothRel CreateSvgPathSegCurvetoQuadraticSmoothRel(float x,
			float y)		
		{
			return new SvgPathSegCurvetoQuadraticSmoothRel(x, y);
		}
		#endregion
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
					case "d":
						pathSegList = null;
            Invalidate();
						return;
					case "pathLength":
						_pathLength = null;
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
