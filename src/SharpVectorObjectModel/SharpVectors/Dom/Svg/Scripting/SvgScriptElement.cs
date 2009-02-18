#if !COMPACT 
using System;
using System.Text;
using System.Xml;

// temp for debugging
/*using System.Windows.Forms;*/

namespace SharpVectors.Dom.Svg
{
    /// <summary>
    /// The SVGScriptElement interface corresponds to the 'script' element.
    /// </summary>
    public class SvgScriptElement : SvgElement, ISvgScriptElement
    {
		#region Constructors
        internal SvgScriptElement(string prefix, string localname, string ns, SvgDocument doc) :
            base(prefix, localname, ns, doc) 
        {
			svgURIReference = new SvgURIReference(this);
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
        }
		#endregion

      public string Type 
      {
        get { return GetAttribute("type"); }
        set { SetAttribute("type", value); }
      }

		#region Implementation of ISvgURIReference
		private SvgURIReference svgURIReference;
		public ISvgAnimatedString Href
		{
			get
			{
				return svgURIReference.Href;
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
    }
}
#endif
