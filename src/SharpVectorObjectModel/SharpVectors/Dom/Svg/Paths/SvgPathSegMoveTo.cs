using System;
using System.Drawing;

using System.Text;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgMoveToSeg.
	/// </summary>
	public abstract class SvgPathSegMoveto : SvgPathSeg
	{
		protected SvgPathSegMoveto(SvgPathSegType type, float x, float y) : base(type)
		{
			this.x = x;
			this.y = y;
		}

		public abstract override PointF AbsXY{get;}

		public override float StartAngle
		{
			get
			{
				return 0;
			}
		}

		public override float EndAngle
		{
			get
			{
				return 0;
			}
		}

		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(x);
				sb.Append(",");
				sb.Append(y);

				return sb.ToString();
			}
		}

		protected float x;
		public float X
		{
			get{return x;}
      set{x = value;}
    }

		protected float y;
		public float Y
		{
			get{return y;}
      set{y = value;}
    }
	}
}
