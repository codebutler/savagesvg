using System;
using System.Drawing;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegMovetoRel interface corresponds to an "relative moveto" (m) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public class SvgPathSegMovetoRel : SvgPathSegMoveto, ISvgPathSegMovetoRel
	{
		internal SvgPathSegMovetoRel(float x, float y) : base(SvgPathSegType.MoveToRel, x, y)
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
