using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;
using System.Xml;

namespace SharpVectors.UnitTests.Svg
{
	[TestFixture]
	public class CssSelectorsTests
	{
		private SvgDocument doc;
		private string correctValue = "rgb(0,128,0)";
		
		private SvgRectElement getRect(int nr)
		{
			return (SvgRectElement)doc.SelectSingleNode("//*[@id='g" + nr + "']/*[local-name()='rect']");
		}

		private string getFill(int nr)
		{
            return getRect(nr).GetComputedStyle("").GetPropertyValue("fill");
		}

		[SetUp]
		public void SetUp()
		{
			if(doc == null)
			{
				SvgWindow wnd = new SvgWindow(75, 75, null);
				doc = new SvgDocument(wnd);

				doc.Load(@"Renderer.Gdi\cssSelectors.svg");
			}
		}

		[Test]
		public void TestStyleSheetLength()
		{
            Assert.AreEqual(1, doc.StyleSheets.Length);
		}

		[Test]
		public void TestPropertyAttribute()
		{
			Assert.AreEqual(correctValue, getFill(1));
		}

		[Test]
		public void TestId()
		{
			Assert.AreEqual(correctValue, getFill(2));
		}

		[Test]
		public void TestType()
		{
			Assert.AreEqual(correctValue, getFill(3));
		}

		[Test]
		public void TestClass()
		{
			Assert.AreEqual(correctValue, getFill(4));
		}

		[Test]
		public void TestClass2()
		{
			Assert.AreEqual(correctValue, getFill(5));
		}

		[Test]
		public void TestUniversal()
		{
			Assert.AreEqual(correctValue, getFill(6));
		}

		[Test]
		public void TestAttribute()
		{
			Assert.AreEqual(correctValue, getFill(7));
		}

		[Test]
		public void TestAttributeEquals()
		{
			Assert.AreEqual(correctValue, getFill(8));
		}

		[Test]
		public void TestAttributeStartsWith()
		{
			Assert.AreEqual(correctValue, getFill(9));
		}

		[Test]
		public void TestAttributeEndsWith()
		{
			Assert.AreEqual(correctValue, getFill(10));
		}

		[Test]
		public void TestNotType()
		{
			Assert.AreEqual(correctValue, getFill(11));
		}

		[Test]
		public void TestNotId()
		{
			Assert.AreEqual(correctValue, getFill(12));
		}

		[Test]
		public void TestNotClass()
		{
			Assert.AreEqual(correctValue, getFill(13));
		}

		[Test]
		public void TestLang()
		{
			Assert.AreEqual(correctValue, getFill(14));
		}
	
		[Test]
		public void TestEmpty()
		{
			Assert.AreEqual(correctValue, getFill(15));
		}
	}
}
