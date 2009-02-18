using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces
{
	[TestFixture]
	public class SvgAngleTests
	{
		private SvgAngle angle;
		[Test]
		public void TestSettingValues()
		{
			angle = new SvgAngle("100grad", null, false);
			Assert.AreEqual(90, angle.Value);

			angle.Value = 45;
			Assert.AreEqual(45, angle.Value);
			Assert.AreEqual("50grad", angle.ValueAsString);
			Assert.AreEqual(50, angle.ValueInSpecifiedUnits);
			Assert.AreEqual(SvgAngleType.Grad, angle.UnitType);

			angle.ValueInSpecifiedUnits = 300;
			Assert.AreEqual(270, angle.Value);
			Assert.AreEqual("300grad", angle.ValueAsString);
			Assert.AreEqual(300, angle.ValueInSpecifiedUnits);
			Assert.AreEqual(SvgAngleType.Grad, angle.UnitType);

			angle.ValueAsString = "180deg";
			Assert.AreEqual(180, angle.Value);

			angle.NewValueSpecifiedUnits(SvgAngleType.Rad, Math.PI);
			Assert.AreEqual(180, angle.Value);
			Assert.AreEqual(Math.PI.ToString(SvgNumber.Format)+"rad", angle.ValueAsString);

			angle.NewValueSpecifiedUnits(SvgAngleType.Unspecified, 270);
			Assert.AreEqual(270, angle.Value);
			Assert.AreEqual("270", angle.ValueAsString);

			angle.ConvertToSpecifiedUnits(SvgAngleType.Grad);
			Assert.AreEqual(270, angle.Value);
			Assert.AreEqual(300, angle.ValueInSpecifiedUnits);
			Assert.AreEqual("300grad", angle.ValueAsString);

			// test default value
			angle = new SvgAngle("", "90deg", false);
			Assert.AreEqual(90, angle.Value);
		}

		
		public void TestDegValues()
		{
			angle = new SvgAngle("90deg", null, false);
			Assert.AreEqual(90, angle.Value);
			Assert.AreEqual(90, angle.ValueInSpecifiedUnits);
			Assert.AreEqual("90deg", angle.ValueAsString);
			Assert.AreEqual(SvgAngleType.Deg, angle.UnitType);
		}

		public void TestGradValues()
		{
			angle = new SvgAngle("200grad", null, false);
			Assert.AreEqual(180, angle.Value);
			Assert.AreEqual(200, angle.ValueInSpecifiedUnits);
			Assert.AreEqual("200grad", angle.ValueAsString);
			Assert.AreEqual(SvgAngleType.Grad, angle.UnitType);
		}

		public void TestRadValues()
		{
			angle = new SvgAngle("2rad", null, false);
			Assert.AreEqual(2 * 180/Math.PI, angle.Value);
			Assert.AreEqual(2, angle.ValueInSpecifiedUnits);
			Assert.AreEqual("2rad", angle.ValueAsString);
			Assert.AreEqual(SvgAngleType.Rad, angle.UnitType);
		}
	}
}
