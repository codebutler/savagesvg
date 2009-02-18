using System;
using System.Drawing;
using System.Drawing.Drawing2D;


namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgPathSegClosePath.
	/// </summary>
	public class SvgPathSegClosePath : SvgPathSeg, ISvgPathSegClosePath
	{
		internal SvgPathSegClosePath() : base(SvgPathSegType.ClosePath)
		{
		}

		public override PointF AbsXY
		{
			get
			{
				SvgPathSeg item = this;
			
				while(item != null && !(item is SvgPathSegMoveto))
				{
					item = item.PreviousSeg;
				}

				if(item == null)
				{
					return new PointF(0,0);
				}
				else
				{
					return item.AbsXY;
				}
			}
		}

		public override float StartAngle
		{
			get
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

		public override string PathText
		{
			get
			{
				return "z";
			}
		}
	}
}
