using System;
using System.Drawing;
using SharpVectors.Polynomials;

namespace SharpVectors.Dom.Svg
{
	public abstract class SvgPathSegCurveto : SvgPathSeg
	{
        #region constructors
		protected SvgPathSegCurveto(SvgPathSegType type) : base(type)
		{
		}
        #endregion

        #region abstract properties
		public abstract override PointF AbsXY{get;}
		public abstract PointF CubicX1Y1{get;}
		public abstract PointF CubicX2Y2{get;}
        #endregion

        #region public properties
        public override float Length
        {
            get
            {
                return (float) this.getArcLengthPolynomial().Simpson(0, 1);
            }
        }

		public override float StartAngle
		{
			get
			{
				PointF p1 = PreviousSeg.AbsXY;
				PointF p2 = CubicX1Y1;

				float dx = p2.X - p1.X;
				float dy = p2.Y - p1.Y;
				float a = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
				a += 270;
				a %= 360;
				return a;
			}
		}

		public override float EndAngle
		{
			get
			{
				PointF p1 = CubicX2Y2;
				PointF p2 = AbsXY;

				float dx = p1.X - p2.X;
				float dy = p1.Y - p2.Y;
				float a = (float)(Math.Atan2(dy, dx) * 180 / Math.PI);
				a += 270;
				a %= 360;
				return a;
			}
		}
        #endregion
	    
        protected abstract SqrtPolynomial getArcLengthPolynomial();
	}
}
