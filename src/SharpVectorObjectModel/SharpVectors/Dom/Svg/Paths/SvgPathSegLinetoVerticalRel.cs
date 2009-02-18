using System;
using System.Drawing;
using System.Text;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegLinetoVerticalRel : SvgPathSegLineto, ISvgPathSegLinetoVerticalRel
	{
		internal SvgPathSegLinetoVerticalRel(float y) : base(SvgPathSegType.LineToVerticalRel)
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
				return new PointF(prevPoint.X, prevPoint.Y + Y);
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
