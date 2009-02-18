using System;
using System.Drawing;

using SharpVectors.Polynomials;


namespace SharpVectors.Dom.Svg
{
	public abstract class SvgPathSegCurvetoQuadratic : SvgPathSegCurveto
	{
		protected SvgPathSegCurvetoQuadratic(SvgPathSegType type) : base(type)
		{
		}
		public abstract override PointF AbsXY{get;}
		public abstract override PointF CubicX1Y1{get;}
		public abstract override PointF CubicX2Y2{get;}

		public abstract PointF QuadraticX1Y1{get;}

        protected override SqrtPolynomial getArcLengthPolynomial() 
        {
            double c2x, c2y, c1x, c1y;
            PointF p1 = PreviousSeg.AbsXY;
            PointF p2 = QuadraticX1Y1;
            PointF p3 = AbsXY;
            
            c2x = (double) p1.X - 2.0*p2.X + p3.X;
            c2y = (double) p1.Y - 2.0*p2.Y + p3.Y;

            c1x = -2.0*p1.X + 2.0*p2.X;
            c1y = -2.0*p1.Y + 2.0*p2.Y;

            // build polynomial
            // dx = dx/dt
            // dy = dy/dt
            // sqrt poly = sqrt( (dx*dx) + (dy*dy) )
            return new SqrtPolynomial(
                c1x*c1x + c1y*c1y,
                4.0*(c1x*c2x + c1y*c2y),
                4.0*(c2x*c2x + c2y*c2y)
            );
        }

        #region unit tests
        #endregion
	}
}
