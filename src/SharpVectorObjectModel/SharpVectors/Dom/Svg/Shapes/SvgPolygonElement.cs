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
	public class SvgPolygonElement : SvgPolyElement, ISvgPolygonElement
	{
		#region Constructors
		internal SvgPolygonElement(string prefix, string localname, string ns, SvgDocument doc)
			: base(prefix, localname, ns, doc)
		{
		}
		#endregion

		#region Implementation of ISharpMarkerHost
		public override System.Drawing.PointF[] MarkerPositions
		{
			get
			{
				PointF[] p1 = base.MarkerPositions;
				PointF[] p2 = new PointF[p1.Length + 1];
				Array.Copy(p1, 0, p2, 0, p1.Length);
				p2[p2.Length-1] = p1[0];
				return p2;
			}
		}
		#endregion

	}
}