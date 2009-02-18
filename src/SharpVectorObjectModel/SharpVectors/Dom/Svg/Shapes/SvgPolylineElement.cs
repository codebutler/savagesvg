using System;
using System.Xml;
using System.Drawing;
using System.Drawing.Drawing2D;




namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>90</completed>
	public class SvgPolylineElement : SvgPolyElement, ISvgPolylineElement
	{
		#region Constructors
		
		internal SvgPolylineElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
		
		}

		#endregion
	}
}
