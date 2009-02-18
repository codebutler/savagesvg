using System;
using System.Drawing;
using System.Text;


namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegCurvetoCubicSmoothAbs : SvgPathSegCurvetoCubic, ISvgPathSegCurvetoCubicSmoothAbs
	{
        #region constructors
		internal SvgPathSegCurvetoCubicSmoothAbs(float x, float y, float x2, float y2) : base(SvgPathSegType.CurveToCubicSmoothAbs)
		{
			this.x = x;
			this.y = y;
			this.x2 = x2;
			this.y2 = y2;
		}
        #endregion

        #region implementation of ISvgPathSegCurvetoCubicSmoothAbs
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

		private float x2;
		public float X2		
		{
			get{return x2;}
      set{x2 = value;}
    }		  

		private float y2;		
		public float Y2
		{
			get{return y2;}
      set{y2 = value;}
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

		public override PointF CubicX1Y1
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				if(prevSeg == null || !(prevSeg is SvgPathSegCurvetoCubic))
				{
					return prevSeg.AbsXY;
				}
				else
				{
					PointF prevXY = prevSeg.AbsXY;
					PointF prevX2Y2 = ((SvgPathSegCurvetoCubic)prevSeg).CubicX2Y2;

					return new PointF(2 * prevXY.X - prevX2Y2.X, 2 * prevXY.Y - prevX2Y2.Y);
				}
			}
		}

		public override PointF CubicX2Y2
		{
			get
			{
				return new PointF(X2, Y2);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(X2);
				sb.Append(",");
				sb.Append(Y2);
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
