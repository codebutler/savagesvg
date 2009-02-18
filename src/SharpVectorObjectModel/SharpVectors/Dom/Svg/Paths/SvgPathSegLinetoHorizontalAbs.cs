using System;
using System.Drawing;
using System.Text;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegLinetoHorizontalAbs : SvgPathSegLineto, ISvgPathSegLinetoHorizontalAbs
	{
		internal SvgPathSegLinetoHorizontalAbs(float x) : base(SvgPathSegType.LineToHorizontalAbs)
		{
			this.x = x;
		}

		private float x;
		public float X
		{
			get{return x;}
      set{x = value;}
    }

		public override PointF AbsXY
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				PointF prevPoint;
				if(prevSeg == null) prevPoint = new PointF(0,0);
				else prevPoint = prevSeg.AbsXY;
				return new PointF(X, prevPoint.Y);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(X);

				return sb.ToString();
			}
		}
	}
}
