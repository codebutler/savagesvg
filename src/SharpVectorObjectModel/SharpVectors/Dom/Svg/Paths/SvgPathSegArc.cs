using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.Text;



namespace SharpVectors.Dom.Svg
{
	internal struct CalculatedArcValues
	{
		public float CorrRx;
		public float CorrRy;
        public float Cx;
		public float Cy;
		public float AngleStart;
		public float AngleExtent;
	}

	public abstract class SvgPathSegArc : SvgPathSeg
	{
		#region Constructors
		protected SvgPathSegArc(SvgPathSegType type, float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag) : base(type)
		{
			this.x = x;
			this.y = y;
			this.r1 = r1;
			this.r2 = r2;
			this.angle = angle;
			this.largeArcFlag = largeArcFlag;
			this.sweepFlag = sweepFlag;
		}

		#endregion

		#region Implementation of arc
		private float x;
		public float X
		{
			get{return x;}
      set {x = value;}
		}

		private float y;
		public float Y
		{
			get{return y;}
      set {y = value;}
    }
		
		private float r1;
		public float R1
		{
			get{return r1;}
      set {r1 = value;}
    }
		
		private float r2;
		public float R2
		{
			get{return r2;}
      set {r2 = value;}
    }
		
		private float angle;
		public float Angle
		{
			get{return angle;}
      set {angle = value;}
    }
		
		private bool largeArcFlag;
		public bool LargeArcFlag
		{
			get{return largeArcFlag;}
      set {largeArcFlag = value;}
    }
		
		private bool sweepFlag;
		public bool SweepFlag
		{
			get{return sweepFlag;}
      set {sweepFlag = value;}
    }

		#endregion

		#region Public convinience methods/properties
		public abstract override PointF AbsXY{get;}

		private float getAngle(bool addExtent)
		{
			CalculatedArcValues calcValues = GetCalculatedArcValues();

			double radAngle = calcValues.AngleStart;
			if(addExtent)
			{
				radAngle += calcValues.AngleExtent;
			}

			radAngle *= (Math.PI / 180);
			double cosAngle = Math.Cos(radAngle);
			double sinAngle = Math.Sin(radAngle);
	
			double denom = Math.Sqrt(
				calcValues.CorrRy * calcValues.CorrRy * cosAngle * cosAngle + 
				calcValues.CorrRx * calcValues.CorrRx * sinAngle * sinAngle
				);
			
			double xt = -calcValues.CorrRx * sinAngle  / denom;
			double yt = calcValues.CorrRy * cosAngle  / denom;

			float a = (float)(Math.Atan2(yt, xt) * 180/Math.PI);
			a += Angle;
			return a;
		}

		public override float StartAngle
		{
			get
			{
				float a = getAngle(false);
				a += 270;
				a += 360;
				a = a % 360;
				return a;
			}
		}

		public override float EndAngle
		{
			get
			{
				float a = getAngle(true);
				a += 90;
				a += 360;
				a = a % 360;

				return a;
			}
		}

		internal CalculatedArcValues GetCalculatedArcValues()
		{
			CalculatedArcValues calcVal = new CalculatedArcValues();

			/*
			 *	This algorithm is taken from the Batik source. All cudos to the Batik crew.
			 */

			PointF startPoint = PreviousSeg.AbsXY;
			PointF endPoint = AbsXY;

			float x0 = startPoint.X;
			float y0 = startPoint.Y;

			float x = endPoint.X;
			float y = endPoint.Y;

			// Compute the half distance between the current and the final point
			double dx2 = (x0 - x) / 2.0;
			double dy2 = (y0 - y) / 2.0;

			// Convert angle from degrees to radians
			double radAngle = Angle * Math.PI / 180;
			double cosAngle = Math.Cos(radAngle);
			double sinAngle = Math.Sin(radAngle);

			//
			// Step 1 : Compute (x1, y1)
			//
			double x1 = (cosAngle * dx2 + sinAngle * dy2);
			double y1 = (-sinAngle * dx2 + cosAngle * dy2);
			// Ensure radii are large enough

			double rx = Math.Abs(R1);
			double ry = Math.Abs(R2);

			double Prx = rx * rx;
			double Pry = ry * ry;
			double Px1 = x1 * x1;
			double Py1 = y1 * y1;

			// check that radii are large enough
			double radiiCheck = Px1/Prx + Py1/Pry;
			if (radiiCheck > 1) 
			{
				rx = Math.Sqrt(radiiCheck) * rx;
				ry = Math.Sqrt(radiiCheck) * ry;
				Prx = rx * rx;
				Pry = ry * ry;
			}

			//
			// Step 2 : Compute (cx1, cy1)
			//
			double sign = (LargeArcFlag == SweepFlag) ? -1 : 1;
			double sq = ((Prx*Pry)-(Prx*Py1)-(Pry*Px1)) / ((Prx*Py1)+(Pry*Px1));
			sq = (sq < 0) ? 0 : sq;
			double coef = (sign * Math.Sqrt(sq));
			double cx1 = coef * ((rx * y1) / ry);
			double cy1 = coef * -((ry * x1) / rx);

			//
			// Step 3 : Compute (cx, cy) from (cx1, cy1)
			//
			double sx2 = (x0 + x) / 2.0;
			double sy2 = (y0 + y) / 2.0;
			double cx = sx2 + (cosAngle * cx1 - sinAngle * cy1);
			double cy = sy2 + (sinAngle * cx1 + cosAngle * cy1);

			//
			// Step 4 : Compute the angleStart (angle1) and the angleExtent (dangle)
			//
			double ux = (x1 - cx1); // rx;
			double uy = (y1 - cy1); // ry;
			double vx = (-x1 - cx1); // rx;
			double vy = (-y1 - cy1); // ry;
			double p, n;
			// Compute the angle start
			n = Math.Sqrt((ux * ux) + (uy * uy));
			p = ux; // (1 * ux) + (0 * uy)
			sign = (uy < 0) ? -1d : 1d;
			double angleStart = sign * Math.Acos(p / n);
			angleStart = angleStart * 180 / Math.PI;

			// Compute the angle extent
			n = Math.Sqrt((ux * ux + uy * uy) * (vx * vx + vy * vy));
			p = ux * vx + uy * vy;
			sign = (ux * vy - uy * vx < 0) ? -1d : 1d;
			double angleExtent = sign * Math.Acos(p / n);
			angleExtent = angleExtent * 180 / Math.PI;

			if(!sweepFlag && angleExtent > 0) 
			{
				angleExtent -= 360f;
			} 
			else if (sweepFlag && angleExtent < 0) 
			{
				angleExtent += 360f;
			}
			angleExtent %= 360f;
			angleStart %= 360f;

			calcVal.CorrRx = (float)rx;
			calcVal.CorrRy = (float)ry;
			calcVal.Cx = (float)cx;
			calcVal.Cy = (float)cy;
			calcVal.AngleStart = (float)angleStart;
			calcVal.AngleExtent = (float)angleExtent;


			return calcVal;
		}


		public override string PathText
		{
			get
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(PathSegTypeAsLetter);
				sb.Append(R1);
				sb.Append(",");
				sb.Append(R2);
				sb.Append(",");
				sb.Append(Angle);
				sb.Append(",");

				if(LargeArcFlag) sb.Append("1");
				else sb.Append("0");
				
				sb.Append(",");

				if(SweepFlag) sb.Append("1");
				else sb.Append("0");

				sb.Append(",");
				sb.Append(X);
				sb.Append(",");
				sb.Append(Y);

				return sb.ToString();
			}
		}
		#endregion
	}
}
