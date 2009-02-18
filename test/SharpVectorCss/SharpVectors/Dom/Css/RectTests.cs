using System;
using System.Drawing;
using NUnit.Framework;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class RectTests
		{
			Rect rect;
			[Test]
			public void TestRect()
			{
				rect = new Rect("rect(0 100cm 20% 23em)", false);

				// test top
				Assert.AreEqual(CssPrimitiveType.Number, rect.Top.PrimitiveType);
				Assert.AreEqual(0, rect.Top.GetFloatValue(CssPrimitiveType.Cm));

				// test right
				Assert.AreEqual(CssPrimitiveType.Cm, rect.Right.PrimitiveType);
				Assert.AreEqual(100, rect.Right.GetFloatValue(CssPrimitiveType.Cm));

				// test bottom
				Assert.AreEqual(CssPrimitiveType.Percentage, rect.Bottom.PrimitiveType);
				Assert.AreEqual(20, rect.Bottom.GetFloatValue(CssPrimitiveType.Percentage));

				// test left
				Assert.AreEqual(CssPrimitiveType.Ems, rect.Left.PrimitiveType);
				Assert.AreEqual(23, rect.Left.GetFloatValue(CssPrimitiveType.Ems));

			}
		}
