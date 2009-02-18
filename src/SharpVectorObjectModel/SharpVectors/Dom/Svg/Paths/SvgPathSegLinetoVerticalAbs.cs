using System;
using System.Drawing;
using System.Text;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegLinetoVerticalAbs : SvgPathSegLineto, ISvgPathSegLinetoVerticalAbs
	{
		internal SvgPathSegLinetoVerticalAbs(float y) : base(SvgPathSegType.LineToVerticalAbs)
		{
			this.y = y;
		}

		private float y;
		public float Y
		{
			get{return y;}
      set{y = value;}
    }

		public override PointF AbsXY
		{
			get
			{
				SvgPathSeg prevSeg = PreviousSeg;
				PointF prevPoint;
				if(prevSeg == null) prevPoint = new PointF(0,0);
				else prevPoint = prevSeg.AbsXY;
				return new PointF(prevPoint.X, Y);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(Y);

				return sb.ToString();
			}
		}
	}
}
