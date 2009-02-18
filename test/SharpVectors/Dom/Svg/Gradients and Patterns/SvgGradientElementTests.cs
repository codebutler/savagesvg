using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.UnitTests.Svg;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.Gradients_and_Patterns
{
	[TestFixture]
	public class SvgGradientElementTests : SvgElementTests
	{
		[Test]
		public void TestGradientUnits()
		{
			SvgGradientElement elm = Util.GetXmlElement("<linearGradient gradientUnits='userSpaceOnUse' />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgUnitType.UserSpaceOnUse, elm.GradientUnits.AnimVal);

			elm = Util.GetXmlElement("<linearGradient gradientUnits='objectBoundingBox' />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgUnitType.ObjectBoundingBox, elm.GradientUnits.AnimVal);

			elm = Util.GetXmlElement("<linearGradient />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgUnitType.ObjectBoundingBox, elm.GradientUnits.AnimVal);
		}

		[Test]
		public void TestGradientTransform()
		{
			SvgGradientElement elm = Util.GetXmlElement("<linearGradient gradientTransform='translate(1,1) rotate(34)' />", "", "linearGradient") as SvgGradientElement;
      ISvgAnimatedTransformList satl = elm.GradientTransform as ISvgAnimatedTransformList;
			Assert.IsNotNull(satl);
			Assert.AreEqual(2, elm.GradientTransform.AnimVal.NumberOfItems);

			elm = Util.GetXmlElement("<linearGradient />", "", "linearGradient") as SvgGradientElement;
      satl = elm.GradientTransform as ISvgAnimatedTransformList;
			Assert.IsNotNull(satl);
			Assert.AreEqual(0, elm.GradientTransform.AnimVal.NumberOfItems);
		}


		[Test]
		public void TestSpreadMethod()
		{
			SvgGradientElement elm = Util.GetXmlElement("<linearGradient spreadMethod='reflect' />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgSpreadMethod.Reflect, elm.SpreadMethod.AnimVal);

			elm = Util.GetXmlElement("<linearGradient spreadMethod='repeat' />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgSpreadMethod.Repeat, elm.SpreadMethod.AnimVal);

			elm = Util.GetXmlElement("<linearGradient spreadMethod='pad' />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgSpreadMethod.Pad, elm.SpreadMethod.AnimVal);

			elm = Util.GetXmlElement("<linearGradient />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual((ushort)SvgSpreadMethod.Pad, elm.SpreadMethod.AnimVal);
		}

		[Test]
		public void TestHref()
		{
			SvgGradientElement elm = Util.GetXmlElement("<linearGradient xlink:href='kalle.svg#someOtherGradient' />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual("kalle.svg#someOtherGradient", elm.Href.AnimVal);

			elm = Util.GetXmlElement("<linearGradient />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual("", elm.Href.AnimVal);
		}

		[Test]
		public void TestStopsCount()
		{
			SvgGradientElement elm = Util.GetXmlElement("<linearGradient><stop offset='5%' stop-color='blue' /><stop offset='10%' stop-color='red' /></linearGradient>", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual(2, elm.Stops.Count);

			elm = Util.GetXmlElement("<linearGradient />", "", "linearGradient") as SvgGradientElement;
			Assert.AreEqual(0, elm.Stops.Count);
		}
	}
}
