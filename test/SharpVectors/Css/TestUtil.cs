#if TEST
using System;
using NUnit.Framework;
using SharpVectors.Dom.Css;
using System.Xml;
using System.Xml.XPath;
using System.Drawing;
using System.Collections;

namespace SharpVectors.Dom.Css
{
	public class TestUtil
	{
		public static CssXmlDocument GetXmlDoc(string content, string style)
		{
			CssXmlDocument doc = new CssXmlDocument();
			doc.AddStyleElement("", "style");

			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\n<root>";
			xml += "<style type='text/css'>" + style + "</style>";
			xml += content;
			xml += "</root>";

			doc.LoadXml(xml);
			return doc;
		}

		public static XmlElement GetXmlElement(string content, string style, string localName)
		{
			CssXmlDocument doc = GetXmlDoc(content, style);
			return (XmlElement)doc.SelectSingleNode("//*[local-name()='" + localName + "']");
		}
	}
}
#endif