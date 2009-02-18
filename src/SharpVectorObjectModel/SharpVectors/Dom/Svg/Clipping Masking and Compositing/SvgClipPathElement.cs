using System;
using System.Drawing.Drawing2D;
using System.Xml;

namespace SharpVectors.Dom.Svg
{
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public class SvgClipPathElement : SvgTransformableElement, ISharpGDIPath, ISvgClipPathElement, ISharpDoNotPaint, IContainerElement
	{
		#region	Constructors
		internal SvgClipPathElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}
		#endregion

		#region Implementation of ISvgClipPathElement
		private ISvgAnimatedEnumeration clipPathUnits;
		public ISvgAnimatedEnumeration ClipPathUnits
		{
			get
			{
				if(clipPathUnits == null)
				{
					SvgUnitType clipPath = SvgUnitType.UserSpaceOnUse;
					if(GetAttribute("clipPathUnits") == "objectBoundingBox")
					{
						clipPath = SvgUnitType.ObjectBoundingBox;
					}
					clipPathUnits = new SvgAnimatedEnumeration((ushort)clipPath);
				}
				return clipPathUnits;
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

		#region Implementation of ISharpGDIPath
		private GraphicsPath _gp = null;
		public void Invalidate()
		{
			_gp = null;
      renderingNode = null;
		}


		/// <summary>
		/// 
		/// </summary>
		/// <returns>Aggregate graphics path of children.</returns>
		public GraphicsPath GetGraphicsPath()
		{
			if(_gp == null)
			{
				_gp = new GraphicsPath();

				foreach( XmlNode node in this.ChildNodes )
				{					
					if (node is ISharpGDIPath && node is SvgStyleableElement)
					{
						GraphicsPath childPath = ((ISharpGDIPath) node).GetGraphicsPath();
						
						string clipRule = ((SvgStyleableElement) node).GetPropertyValue("clip-rule");
						_gp.FillMode = (clipRule == "evenodd") ? FillMode.Alternate : FillMode.Winding;																															

						_gp.AddPath( childPath, true);						
					}
				}
			}
			return _gp;
		}

		#endregion
	}
}
