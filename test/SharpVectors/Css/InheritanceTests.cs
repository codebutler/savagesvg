#if TEST
using System;
using System.Xml;
using NUnit.Framework;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;

namespace SharpVectors.Dom.Css
{
	[TestFixture]
	public class InheritanceTests
	{
		private CssXmlDocument loadXml(string content, string style)
		{
			CssXmlDocument doc = TestUtil.GetXmlDoc(content, style);
			doc.CssPropertyProfile.Add("inher", true, "init");
			doc.CssPropertyProfile.Add("not", false, "init");
			doc.CssPropertyProfile.Add("font-size", true, "12px");

			return doc;
		}

		private XmlElement getElm(CssXmlDocument doc, string localname)
		{
			return (XmlElement)doc.GetElementsByTagName(localname)[0];
		}

		private CssStyleDeclaration getStyles(string xmlContent, string style, string localName)
		{
			CssXmlDocument doc = loadXml(xmlContent, style);
			XmlElement elm = getElm(doc, localName);
			return (CssStyleDeclaration)doc.GetComputedStyle(elm, "");
        }

		[Test]
		public void TestNoInherit()
		{
            CssStyleDeclaration csd = getStyles("<a />", "a{foo:bar;runar:'carola';}", "a");
			Assert.AreEqual("bar", csd.GetPropertyValue("foo"));
			Assert.AreEqual("\"carola\"", csd.GetPropertyValue("runar"));
		}
		
		[Test]
		public void TestSimple()
		{
			CssStyleDeclaration csd = getStyles("<a />", "root{inher:12px} a{not:bar;}", "a");
			Assert.AreEqual("bar", csd.GetPropertyValue("not"));
			Assert.AreEqual("12px", csd.GetPropertyValue("inher"));
		}

		[Test]
		public void TestNonInherit()
		{
			CssStyleDeclaration csd = getStyles("<a />", "root{not:12px} a{}", "a");
			Assert.AreEqual("init", csd.GetPropertyValue("not"));
		}

		[Test]
		public void TestInheritUnknown()
		{
			CssStyleDeclaration csd = getStyles("<a />", "", "a");
			Assert.AreEqual(null, csd.GetPropertyCssValue("dummy"));
		}

		[Test]
		public void TestInheritEm()
		{
			CssStyleDeclaration csd = getStyles("<a />", "root{font-size:18px} a{inher:3em}", "a");
			CssPrimitiveValue primValue = csd.GetPropertyCssValue("inher") as CssPrimitiveValue;
			Assert.AreEqual(54, primValue.GetFloatValue(CssPrimitiveType.Px));
		}
	}
}
#endif