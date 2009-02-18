using System;
using System.Drawing;
using System.Text;

namespace SharpVectors.Dom.Svg
{
	public abstract class SvgPathSegLineto : SvgPathSeg
	{
		protected SvgPathSegLineto(SvgPathSegType type) : base(type)
		{
		}

		public abstract override PointF AbsXY{get;}

		private PointF getPrevPoint()
		{
			SvgPathSeg prevSeg = PreviousSeg;
			PointF prevPoint;
			if(prevSeg == null)
			{
				prevPoint = new PointF(0,0);
			}
			else
			{
				prevPoint = prevSeg.AbsXY;
			}
			return prevPoint;
		}
		public override float StartAngle
		{
			get
			{
				PointF prevPoint = getPrevPoint();
				PointF curPoint = AbsXY;

				float dx = curPoint.X - prevPoint.X;
				float dy = curPoint.Y - prevPoint.Y;

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
				float a = StartAngle;
				a += 180;
				a %= 360;
				return a;
			}
		}

		public override float Length
		{
			get
			{
				PointF prevPoint = getPrevPoint();
				PointF thisPoint = AbsXY;

				float dx = thisPoint.X - prevPoint.X;
				float dy = thisPoint.Y - prevPoint.Y;

				return (float)Math.Sqrt(dx*dx+dy*dy);
			}
		}
	}
}
