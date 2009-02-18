using System;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections;
using SharpVectors.Dom;
using NUnit.Framework;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class CssStyleDeclarationTests
		{

			protected CssXmlElement getElm()
			{
				return TestUtil.GetXmlElement("<a />", "", "a") as CssXmlElement;
			}

			protected virtual CssStyleDeclaration getCSD()
			{
				return getCSD(true);
			}

			protected virtual CssStyleDeclaration getCSD(bool readOnly)
			{
				CssStyleSheet ss = new CssStyleSheet(null, "", "", "", null, CssStyleSheetType.Author);
				CssRule rule = new CssMediaRule("", ss, false, new string[0], CssStyleSheetType.Author);
				string cssText = "{length: \n23cm	 !important;foo:		bar;}";
				return new CssStyleDeclaration(ref cssText, rule, readOnly, CssStyleSheetType.Author);
			}

			[Test]
			public void TestCssText()
			{
				CssStyleDeclaration csd = getCSD();
				if(csd.CssText.Equals("length:23cm !important;foo:bar;") || 
					csd.CssText.Equals("foo:bar;length:23cm !important;"))
				{
				}
				else
				{
					Assert.Fail();
				}
			}

			[Test]
			public void TestLength()
			{
				CssStyleDeclaration csd = getCSD();
				Assert.AreEqual(2, csd.Length);
			}

			[Test]
			public virtual void TestOrigin()
			{
				CssStyleDeclaration csd = getCSD();
				Assert.AreEqual(CssStyleSheetType.Author, csd.Origin);
			}

			[Test]
			public void TestPropertyValue()
			{
				CssStyleDeclaration csd = getCSD();
				Assert.AreEqual("bar", csd.GetPropertyValue("foo"));
				Assert.AreEqual("23cm", csd.GetPropertyValue("length"));
			}

			[Test]
			public void TestPriority()
			{
				CssStyleDeclaration csd = getCSD();
				Assert.AreEqual("", csd.GetPropertyPriority("foo"));
				Assert.AreEqual("important", csd.GetPropertyPriority("length"));
			}

			[Test]
			public void TestCssPropertyValue()
			{
				CssStyleDeclaration csd = getCSD();
				CssValue cssValue = (CssValue)csd.GetPropertyCssValue("foo");

				Assert.AreEqual("bar", cssValue.CssText);
				Assert.AreEqual(CssValueType.PrimitiveValue, cssValue.CssValueType, "1");

				cssValue = (CssValue)csd.GetPropertyCssValue("length");
				Assert.AreEqual("23cm", cssValue.CssText);
				Assert.AreEqual(CssValueType.PrimitiveValue, cssValue.CssValueType, "2");
			}

			[Test]
			[ExpectedException(typeof(DomException))]
			public void TestReadOnly()
			{
				CssStyleDeclaration csd = getCSD();
				csd.SetProperty("foo", "bar", "");
			}

			[Test]
			public virtual void TestReadWrite()
			{
				CssStyleDeclaration csd = getCSD(false);
				csd.SetProperty("foo", "newvalue", "");

				CssValue cssValue = (CssValue)csd.GetPropertyCssValue("foo");
				Assert.AreEqual("newvalue", cssValue.CssText);
				Assert.AreEqual("", csd.GetPropertyPriority("foo"));

				csd.SetProperty("foo", "value2", "important");
				cssValue = (CssValue)csd.GetPropertyCssValue("foo");
				Assert.AreEqual("value2", cssValue.CssText);
				Assert.AreEqual("important", csd.GetPropertyPriority("foo"));
			}

			[Test]
			public virtual void TestIndex()
			{
				CssStyleDeclaration csd = getCSD();
				if(csd[0].Equals("length") && csd[1].Equals("foo"))
				{
				}
				else if(csd[0].Equals("foo") && csd[1].Equals("length"))
				{
				}
				else
				{
					Assert.Fail();
				}
			}
		}
