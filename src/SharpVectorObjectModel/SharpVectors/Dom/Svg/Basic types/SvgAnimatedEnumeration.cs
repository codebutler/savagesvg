using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgAnimatedEnumeration.
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <developer>kevin@kevlindev.com</developer>
	/// <completed>100</completed>
	public class SvgAnimatedEnumeration : ISvgAnimatedEnumeration
	{
		#region Private Fields
		private ushort baseVal;
		private ushort animVal;
		#endregion

		#region Constructor
		public SvgAnimatedEnumeration(ushort val)
		{
			baseVal = animVal = val;
		}
		#endregion

        #region ISvgAnimatedEnumeration Interface
		public ushort BaseVal
		{
			get
			{
				return baseVal;
			}
			set
			{
				baseVal = value;
			}
		}

		public ushort AnimVal
		{
			get
			{
				return animVal;
			}
		}
		#endregion
	}
}
