#if TEST
using System;
using NUnit.Framework;
using SharpVectors.Dom.Css;
using System.Diagnostics;
using System.Drawing;

namespace SharpVectors.Dom.Css
{
	[TestFixture]
	public class CssTests
	{
		private CssXmlDocument doc;
		private CssStyleSheet cssStyleSheet;
		private CssStyleRule rule;
		private CssStyleDeclaration colorRules;

		private bool initDone = false;

		#region Setup
		[SetUp]
		public void Init()
		{
			if(!initDone)
			{
				doc = new CssXmlDocument();
				doc.AddStyleElement("http://www.w3.org/2000/svg", "style");
				doc.Load("http://www.sharpvectors.org/tests/css_unittest_01.svg");
				cssStyleSheet = (CssStyleSheet)doc.StyleSheets[0];
				colorRules = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[4]).Style;
				
				initDone = true;
			}
		}

		#endregion

		#region Basic structure tests
		[Test]
		public void TestStylesheets()
		{
			Assert.AreEqual(2, doc.StyleSheets.Length, "Number of stylesheets");
		}

		[Test]
		public void TestCssStyleSheet()
		{
			Assert.IsTrue(doc.StyleSheets[0] is CssStyleSheet);
			cssStyleSheet = (CssStyleSheet)doc.StyleSheets[0];
			Assert.IsTrue(cssStyleSheet.AbsoluteHref.AbsolutePath.EndsWith("css_unittest_01.css"), "AbsoluteHref");
			Assert.AreEqual(cssStyleSheet.Title, "Test title", "Title");
			Assert.AreEqual("text/css", cssStyleSheet.Type);
			Assert.AreEqual(false, cssStyleSheet.Disabled);
		}

		[Test]
		public void TestCssRules()
		{
			Assert.AreEqual(16, cssStyleSheet.CssRules.Length, "CssRules.Length");
			Assert.IsTrue(cssStyleSheet.CssRules[0] is CssStyleRule);
		}

		[Test]
		public void TestCssStyleRule()
		{
      rule = (CssStyleRule)cssStyleSheet.CssRules[0];
			Assert.IsNull(rule.ParentRule);
			Assert.AreEqual("g", rule.SelectorText);
			Assert.AreEqual("g{fill:#123456 !important;opacity:0.5;}", rule.CssText);
			Assert.AreEqual(CssRuleType.StyleRule, rule.Type);
			Assert.AreSame(cssStyleSheet, rule.ParentStyleSheet);
			Assert.IsTrue(rule.Style is CssStyleDeclaration);
		}

		[Test]
		public void TestCssStyleDeclaration()
		{
      rule = (CssStyleRule)cssStyleSheet.CssRules[0];
      CssStyleDeclaration csd = (CssStyleDeclaration)rule.Style;
      Assert.AreEqual("fill:#123456 !important;opacity:0.5;", csd.CssText);
      Assert.AreEqual(2, csd.Length);
      Assert.AreSame(rule, csd.ParentRule);
      Assert.AreEqual("important", csd.GetPropertyPriority("fill"));
      Assert.AreEqual("0.5", csd.GetPropertyValue("opacity"));
      Assert.AreEqual("", csd.GetPropertyPriority("opacity"));
      Assert.AreEqual("#123456", csd.GetPropertyValue("fill"));
			
			csd.SetProperty("opacity", "0.8", "");
			Assert.AreEqual("0.8", csd.GetPropertyValue("opacity"));
			Assert.AreEqual("", csd.GetPropertyPriority("opacity"));

			csd.SetProperty("opacity", "0.2", "important");
			Assert.AreEqual("0.2", csd.GetPropertyValue("opacity"));
			Assert.AreEqual("important", csd.GetPropertyPriority("opacity"));
			
			Assert.AreEqual("0.2", csd.RemoveProperty("opacity"));
			Assert.AreEqual(1, csd.Length);

			csd.SetProperty("foo", "bar", "");
			Assert.AreEqual("bar", csd.GetPropertyValue("foo"));
			Assert.AreEqual(2, csd.Length);

			// reset values 
			csd.RemoveProperty("foo");
			csd.SetProperty("opacity", "0.5", "");
		}

		#endregion

		#region Color tests
		[Test]
		public void TestColorLongHexValue()
		{
			CssValue val = (CssValue)colorRules.GetPropertyCssValue("longhex");
			Assert.IsTrue(val is CssPrimitiveValue, "1");
			CssPrimitiveValue primValue = (CssPrimitiveValue)colorRules.GetPropertyCssValue("longhex");
			Assert.AreEqual("rgb(101,67,33)", primValue.CssText, "2");
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType, "3");
			Assert.AreEqual(CssPrimitiveType.RgbColor, primValue.PrimitiveType, "4");
			RgbColor color = (RgbColor)primValue.GetRgbColorValue();
			Assert.AreEqual(101, color.Red.GetFloatValue(CssPrimitiveType.Number), "5");
			Assert.AreEqual(67, color.Green.GetFloatValue(CssPrimitiveType.Number), "6");
			Assert.AreEqual(33, color.Blue.GetFloatValue(CssPrimitiveType.Number), "7");
			Assert.AreEqual(ColorTranslator.FromHtml("#654321"), color.GdiColor, "8");
		}

		[Test]
		public void TestColorShortHexValue()
		{
			CssPrimitiveValue primValue = (CssPrimitiveValue)colorRules.GetPropertyCssValue("shorthex");
			Assert.AreEqual("rgb(17,34,51)", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.RgbColor, primValue.PrimitiveType);
			RgbColor color = (RgbColor)primValue.GetRgbColorValue();
			Assert.AreEqual(17, color.Red.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(34, color.Green.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(51, color.Blue.GetFloatValue(CssPrimitiveType.Number));
		}

		[Test]
		public void TestColorNameValue()
		{
			CssPrimitiveValue primValue = (CssPrimitiveValue)colorRules.GetPropertyCssValue("name");
			Assert.AreEqual("rgb(60,179,113)", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.RgbColor, primValue.PrimitiveType);
			RgbColor color = (RgbColor)primValue.GetRgbColorValue();
			Assert.AreEqual(60, color.Red.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(179, color.Green.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(113, color.Blue.GetFloatValue(CssPrimitiveType.Number));

			primValue = (CssPrimitiveValue)colorRules.GetPropertyCssValue("grey-name");
			color = (RgbColor)primValue.GetRgbColorValue();
			Assert.AreEqual(119, color.Red.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(136, color.Green.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(153, color.Blue.GetFloatValue(CssPrimitiveType.Number));
		}

		[Test]
		public void TestColorRgbAbsValue()
		{
			CssPrimitiveValue primValue = (CssPrimitiveValue)colorRules.GetPropertyCssValue("rgbabs");
			Assert.AreEqual("rgb(45,78,98)", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.RgbColor, primValue.PrimitiveType);
			RgbColor color = (RgbColor)primValue.GetRgbColorValue();
			Assert.AreEqual(45, color.Red.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(78, color.Green.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(98, color.Blue.GetFloatValue(CssPrimitiveType.Number));
		}

		[Test]
		public void TestColorRgbPercValue()
		{
			CssPrimitiveValue primValue = (CssPrimitiveValue)colorRules.GetPropertyCssValue("rgbperc");
			Assert.AreEqual("rgb(59,115,171)", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.RgbColor, primValue.PrimitiveType);
			RgbColor color = (RgbColor)primValue.GetRgbColorValue();
			Assert.AreEqual(0.23*255, color.Red.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(0.45*255, color.Green.GetFloatValue(CssPrimitiveType.Number));
			Assert.AreEqual(0.67*255, color.Blue.GetFloatValue(CssPrimitiveType.Number));
		}
		#endregion

		#region String tests
		[Test]
		public void TestStringValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[1]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("string");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("string");
			Assert.AreEqual("\"a string\"", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.String, primValue.PrimitiveType);
			string str = primValue.GetStringValue();
			Assert.AreEqual("a string", str);
		}
		#endregion

		#region rect tests
		[Test]
		public void TestRectValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[1]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("rect");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("rect");
			Assert.AreEqual("rect(10cm 23px 45px 89px)", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.Rect, primValue.PrimitiveType);
			IRect rect = primValue.GetRectValue();
			
			ICssPrimitiveValue rectValue = rect.Top;
			Assert.AreEqual(100, rectValue.GetFloatValue(CssPrimitiveType.Mm));
			Assert.AreEqual(CssPrimitiveType.Cm, rectValue.PrimitiveType);

			rectValue = rect.Right;
			Assert.AreEqual(23, rectValue.GetFloatValue(CssPrimitiveType.Px));
			Assert.AreEqual(CssPrimitiveType.Px, rectValue.PrimitiveType);

			rectValue = rect.Bottom;
			Assert.AreEqual(45, rectValue.GetFloatValue(CssPrimitiveType.Px));
			Assert.AreEqual(CssPrimitiveType.Px, rectValue.PrimitiveType);

			rectValue = rect.Left;
			Assert.AreEqual(89, rectValue.GetFloatValue(CssPrimitiveType.Px));
			Assert.AreEqual(CssPrimitiveType.Px, rectValue.PrimitiveType);

		}
		#endregion

		#region Float tests
		[Test]
		public void TestFloatPxValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-px");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-px");
			Assert.AreEqual("12px", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.Px, primValue.PrimitiveType);
			double res = primValue.GetFloatValue(CssPrimitiveType.Px);
			Assert.AreEqual(12, res);
		}

		[Test]
		public void TestFloatUnitlessValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-unitless");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-unitless");
			Assert.AreEqual("67", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.Number, primValue.PrimitiveType);
			double res = primValue.GetFloatValue(CssPrimitiveType.Number);
			Assert.AreEqual(67, res);
		}

		[Test]
		public void TestFloatCmValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-cm");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-cm");
			Assert.AreEqual("10cm", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.Cm, primValue.PrimitiveType);
			Assert.AreEqual(10, primValue.GetFloatValue(CssPrimitiveType.Cm));
		}

		[Test]
		public void TestFloatMmValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-mm");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-mm");
			Assert.AreEqual("10mm", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.Mm, primValue.PrimitiveType);
			Assert.AreEqual(10, primValue.GetFloatValue(CssPrimitiveType.Mm));
		}

		[Test]
		public void TestFloatInValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-in");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-in");
			Assert.AreEqual("10in", primValue.CssText);
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType);
			Assert.AreEqual(CssPrimitiveType.In, primValue.PrimitiveType);
			Assert.AreEqual(10, primValue.GetFloatValue(CssPrimitiveType.In));
		}

		[Test]
		public void TestFloatPcValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-pc");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-pc");
			Assert.AreEqual("10pc", primValue.CssText, "CssText");
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType, "CssValueType");
			Assert.AreEqual(CssPrimitiveType.Pc, primValue.PrimitiveType, "PrimitiveType");
			Assert.AreEqual(10, primValue.GetFloatValue(CssPrimitiveType.Pc), "To PC");
		}

		[Test]
		public void TestFloatPtValue()
		{
			CssStyleDeclaration csd = (CssStyleDeclaration)((CssStyleRule)cssStyleSheet.CssRules[5]).Style;
			CssValue val = (CssValue)csd.GetPropertyCssValue("float-pt");
			Assert.IsTrue(val is CssPrimitiveValue);
			CssPrimitiveValue primValue = (CssPrimitiveValue)csd.GetPropertyCssValue("float-pt");
			Assert.AreEqual("10pt", primValue.CssText, "CssText");
			Assert.AreEqual(CssValueType.PrimitiveValue, primValue.CssValueType, "CssValueType");
			Assert.AreEqual(CssPrimitiveType.Pt, primValue.PrimitiveType, "PrimitiveType");
			Assert.AreEqual(10, primValue.GetFloatValue(CssPrimitiveType.Pt), "To PC");
			Assert.AreEqual(10/72D*2.54D, primValue.GetFloatValue(CssPrimitiveType.Cm), "To CM");
			Assert.AreEqual(100/72D*2.54D, primValue.GetFloatValue(CssPrimitiveType.Mm), "To MM");
			Assert.AreEqual(10/72D, primValue.GetFloatValue(CssPrimitiveType.In), "To IN");
			Assert.AreEqual(10/12D, primValue.GetFloatValue(CssPrimitiveType.Pc), "To PT");
		}
		#endregion
	}
}
#endif