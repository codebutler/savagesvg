using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.UnitTests.Svg;


namespace SharpVectors.UnitTests.Svg.Gradients_and_Patterns
{
	[TestFixture]
	public class SvgRadialGradientElementTests : SvgGradientElementTests
	{
		#region Utils for SvgElementTests
		protected override Type elmType
		{
			get{return typeof(SvgRadialGradientElement);}
		}

		protected override string localName
		{
			get{return "radialGradient";}
		}
		#endregion

		[Test]
		public void TestSize()
		{
			SvgRadialGradientElement elm = Util.GetXmlElement("<radialGradient cx='1' cy='2' r='3' fx='4' fy='5' />", "", "radialGradient") as SvgRadialGradientElement;
			
			Assert.AreEqual(1, elm.Cx.AnimVal.Value, "cx");
			Assert.AreEqual(2, elm.Cy.AnimVal.Value, "cy");
			Assert.AreEqual(3, elm.R.AnimVal.Value, "r");
			Assert.AreEqual(4, elm.Fx.AnimVal.Value, "fx");
			Assert.AreEqual(5, elm.Fy.AnimVal.Value, "fy");
		}

		[Test]
		public void TestNoFx()
		{
			SvgRadialGradientElement elm = Util.GetXmlElement("<radialGradient fy='5' />", "", "radialGradient") as SvgRadialGradientElement;
			
			Assert.AreEqual(5, elm.Fx.AnimVal.Value, "fx");
			Assert.AreEqual(5, elm.Fy.AnimVal.Value, "fy");
		}
	
	}
}
