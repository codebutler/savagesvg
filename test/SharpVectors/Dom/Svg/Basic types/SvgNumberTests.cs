using System;
using System.Drawing;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces
{
	[TestFixture]
	public class SvgNumberTests
	{
		[Test]
		public void TestCalcAngleDiff()
		{
			Assert.AreEqual(107, SvgNumber.CalcAngleDiff(197, 90));
			Assert.AreEqual(287, SvgNumber.CalcAngleDiff(197, -90));
			Assert.AreEqual(287, SvgNumber.CalcAngleDiff(197, 270));
			Assert.AreEqual(186, SvgNumber.CalcAngleDiff(23, 197));
			Assert.AreEqual(230, SvgNumber.CalcAngleDiff(230, 0));
			Assert.AreEqual(0, SvgNumber.CalcAngleDiff(360, 0));
			Assert.AreEqual(15, SvgNumber.CalcAngleDiff(375, 0));
			Assert.AreEqual(345, SvgNumber.CalcAngleDiff(0, 375));
		}

		[Test]
		public void TestCalcAngleBiSector()
		{
			Assert.AreEqual(135, SvgNumber.CalcAngleBisection(180, 90));

			Assert.AreEqual(315, SvgNumber.CalcAngleBisection(90, 180));
			Assert.AreEqual(185, SvgNumber.CalcAngleBisection(280, 90));
			Assert.AreEqual(185, SvgNumber.CalcAngleBisection(0, 370));
		}
	}
}
