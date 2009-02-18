using System;
using System.Drawing;
using System.Text;

namespace SharpVectors.Dom.Svg
{
	public class SvgPathSegLinetoAbs : SvgPathSegLineto, ISvgPathSegLinetoAbs
	{
		internal SvgPathSegLinetoAbs(float x, float y) : base(SvgPathSegType.LineToAbs)
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
				return new PointF(X, Y);
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
