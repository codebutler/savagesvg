using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;



namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgPathSegLinetoAbs.
	/// </summary>
	public class SvgPathSegArcRel : SvgPathSegArc, ISvgPathSegArcRel
	{
		internal SvgPathSegArcRel(float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag) :
		base(SvgPathSegType.ArcRel, x, y, r1, r2, angle, largeArcFlag, sweepFlag)
		{
		}

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
	}
}
