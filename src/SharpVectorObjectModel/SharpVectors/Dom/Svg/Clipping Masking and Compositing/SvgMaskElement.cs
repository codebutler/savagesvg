using System;

namespace SharpVectors.Dom.Svg
{
	public class SvgMaskElement : SvgStyleableElement, ISvgMaskElement, ISharpDoNotPaint, IContainerElement
	{
		#region Constructors

		internal SvgMaskElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}

		#endregion

		#region Implementation of ISvgMaskElement
		private ISvgAnimatedEnumeration maskUnits;
		public ISvgAnimatedEnumeration MaskUnits 
		{
			get
			{ 
				if(maskUnits == null)
				{
					SvgUnitType mask = SvgUnitType.ObjectBoundingBox;
					if(GetAttribute("maskUnits") == "userSpaceOnUse") 
						mask = SvgUnitType.UserSpaceOnUse;
					maskUnits = new SvgAnimatedEnumeration((ushort)mask);
				}
				return maskUnits;
			}
		}

		private ISvgAnimatedEnumeration maskContentUnits;
		public ISvgAnimatedEnumeration MaskContentUnits 
		{
			get
			{
				if(maskContentUnits == null)
				{
					SvgUnitType maskContent = SvgUnitType.UserSpaceOnUse;
					if(GetAttribute("maskContentUnits") == "objectBoundingBox") 
						maskContent = SvgUnitType.ObjectBoundingBox;
					maskContentUnits = new SvgAnimatedEnumeration((ushort)maskContent);
				}
				return maskContentUnits;
			}
		}

		private ISvgAnimatedLength x;
		public ISvgAnimatedLength X 
		{
			get
			{
				if(x == null)
				{
					x = new SvgAnimatedLength(this, "x", SvgLengthDirection.Horizontal, "-10%");
				}
				return x;
			}
		}

		private ISvgAnimatedLength y;
		public ISvgAnimatedLength Y 
		{
			get
			{
				if(y == null)
				{
					y = new SvgAnimatedLength(this, "y", SvgLengthDirection.Vertical, "-10%");
				}
				return y;
			}
		}

		private ISvgAnimatedLength width;
		public ISvgAnimatedLength Width 
		{
			get
			{
				if(width == null)
				{
					width = new SvgAnimatedLength(this, "width", SvgLengthDirection.Viewport, "120%");
				}
				return width;
			}
		}

		private ISvgAnimatedLength height;
		public ISvgAnimatedLength Height 
		{
			get
			{
				if(height == null)
				{
					height = new SvgAnimatedLength(this, "height", SvgLengthDirection.Viewport, "120%");
				}
				return height;
			}
		}
		#endregion

		#region Implementation of ISvgExternalResourcesRequired
		private SvgExternalResourcesRequired svgExternalResourcesRequired;
		public ISvgAnimatedBoolean ExternalResourcesRequired
		{
			get
			{
				return svgExternalResourcesRequired.ExternalResourcesRequired;
			}
		}
		#endregion

		#region Implementation of ISvgTests
		private SvgTests svgTests;
		public ISvgStringList RequiredFeatures
		{
			get { return svgTests.RequiredFeatures; }
		}

		public ISvgStringList RequiredExtensions
		{
			get { return svgTests.RequiredExtensions; }
		}

		public ISvgStringList SystemLanguage
		{
			get { return svgTests.SystemLanguage; }
		}

		public bool HasExtension(string extension)
		{
			return svgTests.HasExtension(extension);
		}
        #endregion
	}
}
