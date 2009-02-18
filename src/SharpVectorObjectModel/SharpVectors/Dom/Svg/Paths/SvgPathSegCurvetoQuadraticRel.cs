using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;


namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgPathSegCurvetoCubicAbs.
	/// </summary>
	public class SvgPathSegCurvetoQuadraticRel : SvgPathSegCurvetoQuadratic, ISvgPathSegCurvetoQuadraticRel
	{
        #region constructors
		internal SvgPathSegCurvetoQuadraticRel(float x, float y, float x1, float y1) : base(SvgPathSegType.CurveToQuadraticRel)
		{
			this.x = x;
			this.y = y;
			this.x1 = x1;
			this.y1 = y1;
		}
        #endregion

        #region implementation of SvgPathSegCurvetoQuadraticRel
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
	  
        #region pubic methods
		public override PointF AbsXY
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				PointF prevPoint;
				if(prevSeg == null) prevPoint = new PointF(0,0);
				else prevPoint = prevSeg.AbsXY;

				return new PointF(prevPoint.X + X, prevPoint.Y + Y);
			}
		}

		public override PointF QuadraticX1Y1
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				PointF prevPoint;
				if(prevSeg == null) prevPoint = new PointF(0,0);
				else prevPoint = prevSeg.AbsXY;

				return new PointF(prevPoint.X + X1, prevPoint.Y + Y1);
			}
		}

		public override PointF CubicX1Y1
		{
			get
			{
				PointF prevPoint = PreviousSeg.AbsXY;

				float x1 = prevPoint.X + X1 * 2/3;
				float y1 = prevPoint.Y + Y1 * 2/3;
			
				return new PointF(x1, y1);
			}
		}

		public override PointF CubicX2Y2
		{
			get
			{
				PointF prevPoint = PreviousSeg.AbsXY;

				float x2 = X1 + prevPoint.X + (X - X1) / 3;
				float y2 = Y1 + prevPoint.Y + (Y - Y1) / 3;

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
