using System;
using System.Drawing;
using System.Text;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegLinetoRel : SvgPathSegLineto, ISvgPathSegLinetoRel
	{
		internal SvgPathSegLinetoRel(float x, float y) : base(SvgPathSegType.LineToRel)
		{
			this.x = x;
			this.y = y;
		}

		private float x;
		public float X
		{
			get{return x;}
      set{x = value;}
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
				return new PointF(prevPoint.X + X, prevPoint.Y + Y);
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(X);
				sb.Append(",");
				sb.Append(Y);

				return sb.ToString();
			}
		}
	}
}
