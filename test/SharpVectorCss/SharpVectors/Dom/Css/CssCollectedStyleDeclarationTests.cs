using System;
using System.Xml;
using System.Collections;
using NUnit.Framework;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class CssCollectedStyleDeclarationTests : CssStyleDeclarationTests
		{
			#region Helper methods
			private CssValue _getCssValue(string cssText)
			{
				return CssValue.GetCssValue(cssText, false);
			}

			protected override CssStyleDeclaration getCSD()
			{
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(getElm());
				csd.CollectProperty("foo", 1, _getCssValue("bar"), CssStyleSheetType.Author, String.Empty);
				csd.CollectProperty("length", 1, _getCssValue("23cm"), CssStyleSheetType.Author, "important");
				return csd;
			}
			#endregion

			#region Overriden CssStyleDeclaration tests
			[Test]
			public override void TestOrigin()
			{
				CssStyleDeclaration csd = getCSD();
				Assert.AreEqual(CssStyleSheetType.Collector, csd.Origin);
			}

			[Test]
			public override void TestReadWrite()
			{
			}
			#endregion

			#region Collection tests
			[Test]
			public void Collect()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				Assert.AreEqual(0, csd.Length);
				csd.CollectProperty("foo", 1, _getCssValue("12px"), CssStyleSheetType.Author, "important");
				Assert.AreEqual(1, csd.Length);
				Assert.AreEqual("foo:12px !important;", csd.CssText);

				csd.CollectProperty("bar", 1, _getCssValue("test"), CssStyleSheetType.Author, "");
				Assert.AreEqual(2, csd.Length);
				Assert.AreEqual("foo:12px !important;bar:test;", csd.CssText);

			}

			[Test]
			public void CollectOverrideSameSpecificity()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 1, _getCssValue("value1"), CssStyleSheetType.Author, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.Author, "");
				Assert.AreEqual("foo:value2;", csd.CssText);
			}

			[Test]
			public void CollectOverrideHigherSpecificity()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 1, _getCssValue("value1"), CssStyleSheetType.Author, "");
				csd.CollectProperty("foo", 100, _getCssValue("value2"), CssStyleSheetType.Author, "");
				Assert.AreEqual("foo:value2;", csd.CssText);
			}

			[Test]
			public void CollectOverrideLowerSpecificity()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.Author, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.Author, "");
				Assert.AreEqual("foo:value1;", csd.CssText);
			}

			[Test]
			public void CollectOverrideImportant1()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.Author, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.Author, "important");
				Assert.AreEqual("foo:value2 !important;", csd.CssText);
			}

			[Test]
			public void CollectOverrideImportant2()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 1, _getCssValue("value1"), CssStyleSheetType.User, "important");
				csd.CollectProperty("foo", 100, _getCssValue("value2"), CssStyleSheetType.User, "");
				Assert.AreEqual("foo:value1 !important;", csd.CssText);
			}

			[Test]
			public void CollectOverrideImportant3()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 1, _getCssValue("value1"), CssStyleSheetType.Author, "important");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.Author, "important");
				Assert.AreEqual("foo:value2 !important;", csd.CssText);
			}

			[Test]
			public void CollectOverrideImportantUserAgent()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.UserAgent, "important");
				Assert.AreEqual("foo:value1;", csd.CssText);
			}

			[Test]
			public void CollectOverrideUserAgentVsUser()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.User, "");
				Assert.AreEqual("foo:value2;", csd.CssText);

				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "");
				Assert.AreEqual("foo:value2;", csd.CssText);

				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "important");
				Assert.AreEqual("foo:value2;", csd.CssText);
			}

			[Test]
			public void CollectOverrideUserAgentVsAuthor()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.Author, "");
				Assert.AreEqual("foo:value2;", csd.CssText);

				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "");
				Assert.AreEqual("foo:value2;", csd.CssText);

				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.UserAgent, "important");
				Assert.AreEqual("foo:value2;", csd.CssText);
			}

			[Test]
			public void CollectOverrideUserVsAuthor()
			{
				XmlElement elm = getElm();
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.User, "");
				csd.CollectProperty("foo", 1, _getCssValue("value2"), CssStyleSheetType.Author, "");
				Assert.AreEqual("foo:value2;", csd.CssText);

				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.User, "");
				Assert.AreEqual("foo:value2;", csd.CssText);

				csd.CollectProperty("foo", 100, _getCssValue("value1"), CssStyleSheetType.User, "important");
				Assert.AreEqual("foo:value1 !important;", csd.CssText);

				csd.CollectProperty("foo", 200, _getCssValue("value2"), CssStyleSheetType.Author, "important");
				Assert.AreEqual("foo:value1 !important;", csd.CssText);
			}
			#endregion

			#region Absolute values tests
			[Test]
			public void TestEmsNotFontSize()
			{
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(getElm());
				csd.CollectProperty("notFontSize", 1, CssValue.GetCssValue("2em", false), CssStyleSheetType.Author, "");

				CssPrimitiveValue cssPrimValue = csd.GetPropertyCssValue("notFontSize") as CssPrimitiveValue;
				Assert.AreEqual(typeof(CssAbsPrimitiveLengthValue), cssPrimValue.GetType());
				Assert.AreEqual(20, cssPrimValue.GetFloatValue(CssPrimitiveType.Px));
			}

			[Test]
			public void TestEmsFontSize()
			{
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(getElm());
				csd.CollectProperty("font-size", 1, CssValue.GetCssValue("2em", false), CssStyleSheetType.Author, "");

				CssPrimitiveValue cssPrimValue = csd.GetPropertyCssValue("font-size") as CssPrimitiveValue;
				Assert.AreEqual(20, cssPrimValue.GetFloatValue(CssPrimitiveType.Px));
			}

			[Test]
			public void TestExsNotFontSize()
			{
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(getElm());
				csd.CollectProperty("notFontSize", 1, CssValue.GetCssValue("2ex", false), CssStyleSheetType.Author, "");

				CssPrimitiveValue cssPrimValue = csd.GetPropertyCssValue("notFontSize") as CssPrimitiveValue;
				Assert.AreEqual(10, cssPrimValue.GetFloatValue(CssPrimitiveType.Px));
			}

			[Test]
			public void TestExsFontSize()
			{
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(getElm());
				csd.CollectProperty("font-size", 1, CssValue.GetCssValue("2ex", false), CssStyleSheetType.Author, "");

				CssPrimitiveValue cssPrimValue = csd.GetPropertyCssValue("font-size") as CssPrimitiveValue;
				Assert.AreEqual(10, cssPrimValue.GetFloatValue(CssPrimitiveType.Px));
			}

			[Test]
			public void TestFuncAttr()
			{
				XmlElement elm = getElm();
				elm.SetAttribute("kalle", "", "roffe");
				CssCollectedStyleDeclaration csd = new CssCollectedStyleDeclaration(elm);
				csd.CollectProperty("foo", 1, CssValue.GetCssValue("attr(kalle)", false), CssStyleSheetType.Author, "");

				CssPrimitiveValue cssPrimValue = csd.GetPropertyCssValue("foo") as CssPrimitiveValue;
				Assert.IsNotNull(cssPrimValue);
				Assert.AreEqual("roffe", cssPrimValue.GetStringValue());
			}


			#endregion
		}
