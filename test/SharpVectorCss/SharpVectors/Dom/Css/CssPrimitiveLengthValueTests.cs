using System;
using System.Xml;
using System.Text.RegularExpressions;
using NUnit.Framework;
using SharpVectors.Dom.Css;
using SharpVectors.Dom;

		[TestFixture]
		public class CssPrimitiveLengthValueTests : CssValueTests
		{
			CssPrimitiveLengthValue length;
			protected override string aCssText
			{
				get{return "12px";}
			}

			protected override string anotherCssText		
			{
				get{return "23mm";}
			}

			protected override CssValueType cssValueType
			{
				get{return CssValueType.PrimitiveValue;}
			}

			protected override CssValue _getCssValue(string cssText, bool readOnly)
			{
				return new CssPrimitiveLengthValue(cssText, readOnly);
			}

			protected override Type Type
			{
				get{return typeof(CssPrimitiveLengthValue);}
			}

			[Test]
			public void TestPxValue()
			{
				length = new CssPrimitiveLengthValue("12px", false);
				Assert.AreEqual(12, length.GetFloatValue(CssPrimitiveType.Px));
				try
				{
					length.GetCounterValue();
          Assert.Fail("length.GetCounterValue()");
				}
				catch{}

				try
				{
					length.GetFloatValue(CssPrimitiveType.Ems);
					Assert.Fail("length.GetFloatValue(CssPrimitiveType.Ems)");
				}
				catch(DomException e)
				{
					Assert.AreEqual(DomExceptionType.InvalidAccessErr, e.Code);
				}
			}

			[Test]
			public void TestUnitLessValue()
			{
				length = new CssPrimitiveLengthValue("10", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Number));
			}

			[Test]
			public void TestCmValue()
			{
				length = new CssPrimitiveLengthValue("10cm", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Cm));
				Assert.AreEqual(100, length.GetFloatValue(CssPrimitiveType.Mm));
				Assert.AreEqual(10/2.54D, length.GetFloatValue(CssPrimitiveType.In));
				Assert.AreEqual(10/2.54D * 6, length.GetFloatValue(CssPrimitiveType.Pc));
				Assert.AreEqual(10/2.54D * 72, length.GetFloatValue(CssPrimitiveType.Pt));
			}

			[Test]
			public void TestMmValue()
			{
				length = new CssPrimitiveLengthValue("10mm", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Mm));
				Assert.AreEqual(1, length.GetFloatValue(CssPrimitiveType.Cm));
				Assert.AreEqual(1/2.54D, length.GetFloatValue(CssPrimitiveType.In));
				Assert.AreEqual(1/2.54D * 6, length.GetFloatValue(CssPrimitiveType.Pc));
				Assert.AreEqual(1/2.54D * 72, length.GetFloatValue(CssPrimitiveType.Pt));
			}

			[Test]
			public void TestInValue()
			{
				length = new CssPrimitiveLengthValue("10in", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.In));
				Assert.AreEqual(10*2.54D, length.GetFloatValue(CssPrimitiveType.Cm));
				Assert.AreEqual(100*2.54D, length.GetFloatValue(CssPrimitiveType.Mm));
				Assert.AreEqual(60, length.GetFloatValue(CssPrimitiveType.Pc));
				Assert.AreEqual(720, length.GetFloatValue(CssPrimitiveType.Pt));
			}

			[Test]
			public void TestPcValue()
			{
				length = new CssPrimitiveLengthValue("10pc", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Pc), "To pc");
				Assert.AreEqual(10/6D*2.54D, length.GetFloatValue(CssPrimitiveType.Cm), "To cm");
				Assert.AreEqual(100/6D*2.54D, length.GetFloatValue(CssPrimitiveType.Mm), "To mm");
				Assert.AreEqual(10/6D, length.GetFloatValue(CssPrimitiveType.In), "To in");
				Assert.AreEqual(120, length.GetFloatValue(CssPrimitiveType.Pt), "To pt");
			}

			[Test]
			public void TestPtValue()
			{
				length = new CssPrimitiveLengthValue("10pt", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Pt), "To pt");
				Assert.AreEqual(10/72D*2.54D, length.GetFloatValue(CssPrimitiveType.Cm), "To cm");
				Assert.AreEqual(100/72D*2.54D, length.GetFloatValue(CssPrimitiveType.Mm), "To mm");
				Assert.AreEqual(10/72D, length.GetFloatValue(CssPrimitiveType.In), "To in");
				Assert.AreEqual(10/12D, length.GetFloatValue(CssPrimitiveType.Pc), "To pc");
			}

			[Test]
			public void TestEmValue()
			{
				length = new CssPrimitiveLengthValue("10em", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Ems), "To em");
			}

			[Test]
			public void TestExValue()
			{
				length = new CssPrimitiveLengthValue("10ex", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Exs), "To ex");
			}

			[Test]
			public void TestPercentageValue()
			{
				length = new CssPrimitiveLengthValue("10%", false);
				Assert.AreEqual(10, length.GetFloatValue(CssPrimitiveType.Percentage), "To %");
			}
		}
