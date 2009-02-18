using System;
using System.Diagnostics;
using System.Globalization;
using System.Text.RegularExpressions;

using SharpVectors.Dom.Css;

namespace SharpVectors.Dom.Svg
{
	public class SvgNumber : ISvgNumber
	{
		#region Static members
		internal static string numberPattern = @"(?<number>(\+|-)?\d*\.?\d+((e|E)(\+|-)?\d+)?)";
		internal static Regex reNumber = new Regex("^" + numberPattern + "$");

		public static NumberFormatInfo Format
		{
			get
			{
				return CssNumber.Format;
			}
		}

		private static Regex reUnit = new Regex("[a-z]+$");
		public static string ScientificToDec(string sc)
		{
			if(sc.IndexOfAny(new char[]{'e','E'})>-1)
			{
				sc = sc.Trim();
				// remove the unit
				Match match = reUnit.Match(sc);
				return SvgNumber.ParseToFloat(sc.Substring(0, sc.Length - match.Length)).ToString(Format) + match.Value;
			}
			else
			{
				return sc;
			}
		}

		public static float ParseToFloat(string str)
		{
			float val;
			int index = str.IndexOfAny(new Char[]{'E','e'});
			if(index>-1)
			{
				float number = SvgNumber.ParseToFloat(str.Substring(0, index));
				float power = SvgNumber.ParseToFloat(str.Substring(index+1));

				val = (float) Math.Pow(10, power) * number;
			}
			else
			{
				try
				{
					val = Single.Parse(str, SvgNumber.Format);
				}
				catch(Exception e)
				{
					throw new DomException(DomExceptionType.SyntaxErr, "Input string was not in a correct format: " + str, e);
				}
			}
			return val;
		}
		

		public static float CalcAngleDiff(float a1, float a2)
		{
			while(a1 < 0) a1 += 360;
			a1 %= 360;

			while(a2 < 0) a2 += 360;
			a2 %= 360;

			float diff = (a1-a2);

			while(diff<0) diff += 360;
			diff %= 360;
            
			return diff;
		}
		public static float CalcAngleBisection(float a1, float a2)
		{
			float diff = CalcAngleDiff(a1, a2);
			float bisect = a1 - diff/2F;

			while(bisect<0) bisect += 360;

			bisect %= 360;
			return bisect;
		}
		#endregion

		#region Constructors
		public SvgNumber(float val)
		{
			_value = val;
		}

		public SvgNumber(string str)
		{
			_value = SvgNumber.ParseToFloat(str);
		}

		#endregion

		#region Implementation of ISvgNumber
		private float _value;
		public float Value
		{
			get
			{
				return _value;
			}
			set
			{
				this._value = value;
			}
		}

		#endregion

	}
}
