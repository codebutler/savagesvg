using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;



namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgPathSegLinetoAbs.
	/// </summary>

	public class SvgPathSegArcAbs : SvgPathSegArc, ISvgPathSegArcAbs
	{
		internal SvgPathSegArcAbs(float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag) :
			base(SvgPathSegType.ArcAbs, x, y, r1, r2, angle, largeArcFlag, sweepFlag)
		{
			
		}

		public override PointF AbsXY
		{
			get
			{
				return new PointF(X, Y);
			}
		}
	}
}
