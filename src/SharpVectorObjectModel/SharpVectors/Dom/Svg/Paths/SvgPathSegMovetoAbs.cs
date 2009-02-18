using System;
using System.Drawing;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegMovetoAbs : SvgPathSegMoveto, ISvgPathSegMovetoAbs
	{
		internal SvgPathSegMovetoAbs(float x, float y) : base(SvgPathSegType.MoveToAbs, x, y)
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
