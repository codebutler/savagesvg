using System;
using System.Text.RegularExpressions;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class CssPrimitiveAngleValueTests : CssValueTests
		{
			CssPrimitiveAngleValue angle;
			protected override string aCssText
			{
				get{return "12deg";}
			}

			protected override string anotherCssText		
			{
				get{return "2rad";}
			}

			protected override CssValueType cssValueType
			{
				get{return CssValueType.PrimitiveValue;}
			}


			protected override CssValue _getCssValue(string cssText, bool readOnly)
			{
				return new CssPrimitiveAngleValue(aCssText, readOnly);
			}

			protected override Type Type
			{
				get{return typeof(CssPrimitiveAngleValue);}
			}

			[Test]
			public void TestDegValue()
			{
				angle = new CssPrimitiveAngleValue("90deg", false);
				Assert.AreEqual(90, angle.GetFloatValue(CssPrimitiveType.Deg));
				Assert.AreEqual(100, angle.GetFloatValue(CssPrimitiveType.Grad));
				Assert.AreEqual(Math.PI/2, angle.GetFloatValue(CssPrimitiveType.Rad));

				angle = new CssPrimitiveAngleValue("47", false);
				Assert.AreEqual(47, angle.GetFloatValue(CssPrimitiveType.Deg));

				angle = new CssPrimitiveAngleValue("385deg", false);
				Assert.AreEqual(25, angle.GetFloatValue(CssPrimitiveType.Deg));

				angle = new CssPrimitiveAngleValue("-90deg", false);
				Assert.AreEqual(270, angle.GetFloatValue(CssPrimitiveType.Deg));
			}

			[Test]
			public void TestRadValue()
			{
				angle = new CssPrimitiveAngleValue("1rad", false);
				Assert.AreEqual(1, angle.GetFloatValue(CssPrimitiveType.Rad));
				Assert.AreEqual(1 * 180 / Math.PI, angle.GetFloatValue(CssPrimitiveType.Deg));
				Assert.AreEqual(1 * 200 / Math.PI, angle.GetFloatValue(CssPrimitiveType.Grad));

				angle = new CssPrimitiveAngleValue("-2rad", false);
				Assert.AreEqual(2*Math.PI - 2, angle.GetFloatValue(CssPrimitiveType.Rad));

				angle = new CssPrimitiveAngleValue("8rad", false);
				Assert.AreEqual(8%(2*Math.PI), angle.GetFloatValue(CssPrimitiveType.Rad));
			}

			[Test]
			public void TestGradValue()
			{
				angle = new CssPrimitiveAngleValue("100grad", false);
				Assert.AreEqual(100, angle.GetFloatValue(CssPrimitiveType.Grad));
				Assert.AreEqual(90, angle.GetFloatValue(CssPrimitiveType.Deg));
				Assert.AreEqual(Math.PI / 2, angle.GetFloatValue(CssPrimitiveType.Rad));

				angle = new CssPrimitiveAngleValue("600grad", false);
				Assert.AreEqual(200, angle.GetFloatValue(CssPrimitiveType.Grad));
			}
		}
