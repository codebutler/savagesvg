using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using System.Xml;
using System.Xml.XPath;
using System.Drawing;
using System.Collections;

namespace SharpVectors.UnitTests.Svg
{
	public class Util
	{
		public static SvgDocument GetXmlDoc(string content, string style)
		{
			SvgWindow wnd = new SvgWindow(100, 100, null);
			SvgDocument doc = new SvgDocument(wnd);

			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\n";
			xml += "<svg xmlns='" + SvgDocument.SvgNamespace + "' xmlns:xlink='" + SvgDocument.XLinkNamespace + "'>";
			xml += "<style type='text/css'>" + style + "</style>";
			xml += content;
			xml += "</svg>";

			doc.LoadXml(xml);
			return doc;
		}

		public static SvgElement GetXmlElement(string content, string style, string localName)
		{
			SvgDocument doc = GetXmlDoc(content, style);
			return (SvgElement)doc.SelectSingleNode("//*[local-name()='" + localName + "']");
		}
	}
}
