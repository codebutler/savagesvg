using System;
using System.Drawing;
using System.Text;


namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgPathSegCurvetoCubicAbs.
	/// </summary>
	public class SvgPathSegCurvetoQuadraticAbs : SvgPathSegCurvetoQuadratic, ISvgPathSegCurvetoQuadraticAbs
	{
        #region constructors
		internal SvgPathSegCurvetoQuadraticAbs(float x, float y, float x1, float y1) : base(SvgPathSegType.CurveToQuadraticAbs)
		{
			this.x = x;
			this.y = y;
			this.x1 = x1;
			this.y1 = y1;
		}
        #endregion

        #region implementation of ISvgPathSegCurvetoQuadraticAbs
		private float x;
		public float X
		{
			get{return x;}
      set{x = value;}
    }		  

		private float y;		
		public float Y
		{
			get{return y;}
      set{y = value;}
    }		  

		private float x1;
		public float X1		
		{
			get{return x1;}
      set{x1 = value;}
    }		  

		private float y1;		
		public float Y1
		{
			get{return y1;}
      set{y1 = value;}
    }
        #endregion
		
        #region public methods
		public override PointF AbsXY
		{
			get
			{
				return new PointF(X, Y);
			}
		}

		public override PointF QuadraticX1Y1
		{
			get
			{
				return new PointF(X1, Y1);
			}
		}

		/*
		* Convert to cubic bezier using the algorithm from Math:Bezier:Convert in CPAN
		* $p0x+($p1x-$p0x)*2/3
		* $p0y+($p1y-$p0y)*2/3
		* $p1x+($p2x-$p1x)/3
		* $p1x+($p2x-$p1x)/3
		* */

		public override PointF CubicX1Y1
		{
			get
			{
				PointF prevPoint = PreviousSeg.AbsXY;

				float x1 = prevPoint.X + (X1 - prevPoint.X) * 2/3;
				float y1 = prevPoint.Y + (Y1 - prevPoint.Y) * 2/3;
			
				return new PointF(x1, y1);
			}
		}

		public override PointF CubicX2Y2
		{
			get
			{
				float x2 = X1 + (X - X1) / 3;
				float y2 = Y1 + (Y - Y1) / 3;

				return new PointF(x2, y2);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(X1);
				sb.Append(",");
				sb.Append(Y1);
				sb.Append(",");
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
