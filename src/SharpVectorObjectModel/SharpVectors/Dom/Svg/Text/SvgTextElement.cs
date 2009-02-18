using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Xml;



namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgTextElement.
	/// </summary>
	public class SvgTextElement : SvgTextPositioningElement, ISvgTextElement
	{
		internal SvgTextElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
		{
		}

		public override GraphicsPath GetGraphicsPath()
		{
			if(gp == null)
			{
				PointF ctp = new PointF(0, 0); // current text position

				GetGraphicsPath(ref ctp);
			}

			return gp;
		}
	}
}
