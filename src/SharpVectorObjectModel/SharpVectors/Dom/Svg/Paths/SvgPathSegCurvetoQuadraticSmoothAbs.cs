using System;
using System.Drawing;
using System.Text;


namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegCurvetoQuadraticSmoothAbs interface corresponds to an "absolute smooth quadratic curveto" (T) path data command. 
	/// </summary>
	public class SvgPathSegCurvetoQuadraticSmoothAbs : SvgPathSegCurvetoQuadratic, ISvgPathSegCurvetoQuadraticSmoothAbs
	{
        #region constructors
		internal SvgPathSegCurvetoQuadraticSmoothAbs(float x, float y) : base(SvgPathSegType.CurveToQuadraticSmoothAbs)
		{
			this.x = x;
			this.y = y;
		}
        #endregion

        #region implementation of SvgPathSegCurvetoQuadraticSmoothAbs
		private float x;
		/// <summary>
		/// The absolute X coordinate for the end point of this path segment. 
		/// </summary>
		public float X
		{
			get{return x;}
      set{x = value;}
    }

		private float y;
		/// <summary>
		/// The absolute Y coordinate for the end point of this path segment. 
		/// </summary>
		public float Y
		{
			get{return y;}
      set{y = value;}
    }
        #endregion

        #region public methods
		public override PointF QuadraticX1Y1
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				if(prevSeg == null || !(prevSeg is SvgPathSegCurvetoQuadratic))
				{
					return prevSeg.AbsXY;
				}
				else
				{
					PointF prevXY = prevSeg.AbsXY;
					PointF prevX1Y1 = ((SvgPathSegCurvetoQuadratic)prevSeg).QuadraticX1Y1;

					return new PointF(2 * prevXY.X - prevX1Y1.X, 2 * prevXY.Y - prevX1Y1.Y);
				}
			}
		}

		public override PointF AbsXY
		{
			get
			{
				return new PointF(X, Y);
			}
		}

		public override PointF CubicX1Y1
		{
			get
			{
				PointF prevPoint = PreviousSeg.AbsXY;
				PointF x1y1 = QuadraticX1Y1;

				float x1 = prevPoint.X + (x1y1.X - prevPoint.X) * 2/3;
				float y1 = prevPoint.Y + (x1y1.Y - prevPoint.Y) * 2/3;
			
				return new PointF(x1, y1);
			}
		}

		public override PointF CubicX2Y2
		{
			get
			{
				PointF x1y1 = QuadraticX1Y1;
				float x2 = x1y1.X + (X - x1y1.X) / 3;
				float y2 = x1y1.Y + (Y - x1y1.Y) / 3;

				return new PointF(x2, y2);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(X);
				sb.Append(",");
				sb.Append(Y);

				return sb.ToString();
			}
		}
        #endregion

        #region unit tests
        #endregion
	}
}
