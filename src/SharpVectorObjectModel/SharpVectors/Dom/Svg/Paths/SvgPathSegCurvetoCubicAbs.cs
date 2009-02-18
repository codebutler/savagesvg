using System;
using System.Drawing;
using System.Text;

using SharpVectors.Dom.Svg;
using SharpVectors.Polynomials;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegCurvetoCubicAbs : SvgPathSegCurvetoCubic, ISvgPathSegCurvetoCubicAbs
	{
        #region constructors
		internal SvgPathSegCurvetoCubicAbs(float x, float y, float x1, float y1, float x2, float y2) : base(SvgPathSegType.CurveToCubicAbs)
		{
			this.x = x;
			this.y = y;
			this.x1 = x1;
			this.y1 = y1;
			this.x2 = x2;
			this.y2 = y2;
		}
        #endregion

        #region implementation of ISvgPathSegCurvtoCubicAbs
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
				return new PointF(X1, Y1);
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
				sb.Append(X1);
				sb.Append(",");
				sb.Append(Y1);
				sb.Append(",");
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
