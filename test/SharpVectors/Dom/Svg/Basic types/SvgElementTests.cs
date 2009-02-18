using System;
using System.Xml;
using NUnit.Framework;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces
{
	[TestFixture]
	public class SvgElementTests : CssXmlElementTests
	{
		protected override Type elmType
		{
			get{return typeof(SvgElement);}
		}

		protected virtual string localName
		{
			get{return "foo";}
		}

		[Test]
		public override void TestTypeFromDocument()
		{
			XmlElement elm = Util.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' />", "", localName);
            Assert.AreEqual(elmType, elm.GetType());
		}

		[Test]
		public override void TestTypeFromCreateElement()
		{
			SvgWindow wnd = new SvgWindow(100, 100, null);
			SvgDocument doc = new SvgDocument(wnd);
			XmlElement elm = doc.CreateElement("", localName, "http://www.w3.org/2000/svg");

			Assert.AreEqual(elmType, elm.GetType());
		}

		[Test]
		public void TestId()
		{
			SvgElement elm = Util.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' id='kalle' />", "", localName) as SvgElement;
            Assert.AreEqual("kalle", elm.Id);
		}

		[Test]
		public void TestOwnerDocument()
		{
			SvgElement elm = Util.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' />", "", localName) as SvgElement;
      ISvgDocument doc = elm.OwnerDocument as ISvgDocument;
			Assert.IsNotNull(doc);
		}

		[Test]
		public void TestOwnerSvgElement()
		{
			SvgElement elm = Util.GetXmlElement("<svg id='svgElm' xmlns='http://www.w3.org/2000/svg'><" + localName + " /></svg>", "", localName) as SvgElement;
			Assert.AreEqual(elm.OwnerDocument.SelectSingleNode("//*[@id='svgElm']"), elm.OwnerSvgElement, "2");
		}

		[Test]
		public void TestViewportElement()
		{
			SvgElement elm = Util.GetXmlElement("<svg id='svgElm' xmlns='http://www.w3.org/2000/svg'><" + localName + " /></svg>", "", localName) as SvgElement;
			Assert.AreEqual(elm.OwnerDocument.SelectSingleNode("//*[@id='svgElm']"), elm.ViewportElement);
		}

		[Test]
		public void TestXmlLang()
		{
			SvgElement elm = Util.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' xml:lang='sv-SE' />", "", localName) as SvgElement;
			Assert.AreEqual("sv-SE", elm.XmlLang);
		}

		[Test]
		public void TestInheritedXmlLang()
		{
			SvgElement elm = Util.GetXmlElement("<svg id='svgElm' xmlns='http://www.w3.org/2000/svg' xml:lang='sv-SE'><" + localName + " /></svg>", "", localName) as SvgElement;
			Assert.AreEqual("sv-SE", elm.XmlLang);
		}

		[Test]
		public void TestXmlSpace()
		{
			SvgElement elm = Util.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' xml:space='default' />", "", localName) as SvgElement;
			Assert.AreEqual("default", elm.XmlSpace);
		}

		[Test]
		public void TestDefaultXmlSpace()
		{
			SvgElement elm = Util.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' />", "", localName) as SvgElement;
			Assert.AreEqual("default", elm.XmlSpace);
		}

		[Test]
		public void TestInheritedXmlSpace()
		{
			SvgElement elm = Util.GetXmlElement("<svg id='svgElm' xmlns='http://www.w3.org/2000/svg' xml:space='preserve'><" + localName + " /></svg>", "", localName) as SvgElement;
			Assert.AreEqual("preserve", elm.XmlSpace);
		}

	}
}
