using System;
using System.IO;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.DocumentStructure
{
	[TestFixture]
	public class SvgTransformableElementTests : SvgStyleableElementTests
	{
		[Test]
		public void TestContainerBBoxWithSingleChild()
		{
			SvgTransformableElement elm = Util.GetXmlElement("<g><rect x='1' y='2' width='3' height='4' /></g>", "", "g") as SvgTransformableElement;
			ISvgRect rect = elm.GetBBox();
            Assert.AreEqual(1, rect.X);
			Assert.AreEqual(2, rect.Y);
			Assert.AreEqual(3, rect.Width);
			Assert.AreEqual(4, rect.Height);
		}

		[Test]
		public void TestContainerBBoxWithMulipleChilds()
		{
			SvgTransformableElement elm = Util.GetXmlElement("<g><rect x='1' y='2' width='3' height='4' /><rect x='10' y='20' width='3' height='4' /></g>", "", "g") as SvgTransformableElement;
			ISvgRect rect = elm.GetBBox();
			Assert.AreEqual(1, rect.X);
			Assert.AreEqual(2, rect.Y);
			Assert.AreEqual(12, rect.Width);
			Assert.AreEqual(22, rect.Height);
		}

		[Test]
		public void TestShapeBBox()
		{
			SvgTransformableElement elm = Util.GetXmlElement("<rect x='1' y='2' width='3' height='4' />", "", "rect") as SvgTransformableElement;
			ISvgRect rect = elm.GetBBox();
			Assert.AreEqual(1, rect.X);
			Assert.AreEqual(2, rect.Y);
			Assert.AreEqual(3, rect.Width);
			Assert.AreEqual(4, rect.Height);
		}
	}
}
