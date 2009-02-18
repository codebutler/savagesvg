using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections;
using System.Xml;
using NUnit.Framework;
using SharpVectors.Dom.Css;
using SharpVectors.Dom;

		[TestFixture]
		public class CssValueTests
		{
			protected virtual string aCssText
			{
				get{return "sometext";}
			}

			protected virtual string anotherCssText		
			{
				get{return "kalle";}
			}

			protected virtual CssValueType cssValueType
			{
				get{return CssValueType.Custom;}
			}


			protected virtual CssValue _getCssValue(string cssText, bool readOnly)
			{
				return new CssValue(CssValueType.Custom, cssText, readOnly);
			}

			protected virtual Type Type
			{
				get{return typeof(CssValue);}
			}

			[Test]
			public void TestCssText()
			{
				CssValue cssValue = _getCssValue(aCssText, false);
				Assert.AreEqual(Type, cssValue.GetType());
			}

			[Test]
			public void TestType()
			{
				CssValue cssValue = _getCssValue(aCssText, false);
				Assert.AreEqual(aCssText, cssValue.CssText);
			}

			[Test]
			public void TestCssTextTrim()
			{
				CssValue cssValue = _getCssValue(" " + aCssText + " ", false);
				Assert.AreEqual(aCssText, cssValue.CssText);
			}

			[Test]
			public void TestCssValueType()
			{
				CssValue cssValue = _getCssValue(aCssText, false);
				Assert.AreEqual(cssValueType, cssValue.CssValueType);
			}

			[Test]
			public virtual void TestCssReadOnly()
			{
				CssValue cssValue = _getCssValue(aCssText, false);
				Assert.AreEqual(false, cssValue.ReadOnly);

				cssValue = _getCssValue(aCssText, true);
				Assert.AreEqual(true, cssValue.ReadOnly);
			}

			[Test]
			public void TestCssTextReadWrite()
			{
				CssValue cssValue = _getCssValue(aCssText, false);
				cssValue.CssText = anotherCssText;
				Assert.AreEqual(anotherCssText, cssValue.CssText);
			}

			[Test]
			[ExpectedException(typeof(DomException))]
			public virtual void TestCssTextReadOnly()
			{
				CssValue cssValue = _getCssValue(aCssText, true);
				cssValue.CssText = anotherCssText;
			}

			[Test]
			public void CssValueInheritTest()
			{
				CssValue cssValue = new CssValue(CssValueType.Inherit, "inherit", false);
				Assert.AreEqual("inherit", cssValue.CssText);
				Assert.AreEqual(CssValueType.Inherit, cssValue.CssValueType);
			}

			[Test]
			public void CssValueCustomTest()
			{
				CssValue cssValue = new CssValue(CssValueType.Custom, "some custom value ", false);
				Assert.AreEqual("some custom value", cssValue.CssText);
				Assert.AreEqual(CssValueType.Custom, cssValue.CssValueType);
			}
		}
