using System;
using System.Xml;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;



namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgTRefElement.
	/// </summary>
	public class SvgTRefElement : SvgTextPositioningElement, ISvgTRefElement
	{
		internal SvgTRefElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
		{
			svgURIReference = new SvgURIReference(this);
		}

		public string GetText()
		{
			XmlElement refElement = ReferencedElement;
			if(refElement != null)
			{
				return TrimText(refElement.InnerText);
			}
			else
			{
				return String.Empty;
			}
		}

		protected override void GetGraphicsPath(ref PointF ctp)
		{
			gp = new GraphicsPath();

			ctp = this.GetCurrentTextPosition(this, ctp);
			
			this.AddGraphicsPath(ref ctp, GetText());
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

		public XmlElement ReferencedElement
		{
			get
			{
				return svgURIReference.ReferencedNode as XmlElement;
			}
		}
		#endregion
	}
}
