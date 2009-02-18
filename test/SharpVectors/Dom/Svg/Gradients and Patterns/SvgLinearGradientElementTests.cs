using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.UnitTests.Svg;


namespace SharpVectors.UnitTests.Svg.Gradients_and_Patterns
{
	[TestFixture]
	public class SvgLinearGradientElementTests : SvgGradientElementTests
	{
		#region Utils for SvgElementTests
		protected override Type elmType
		{
			get{return typeof(SvgLinearGradientElement);}
		}

		protected override string localName
		{
			get{return "linearGradient";}
		}
		#endregion


		[Test]
		public void TestSize()
		{
			SvgLinearGradientElement elm = Util.GetXmlElement("<linearGradient x1='1' y1='2' x2='3' y2='4' />", "", "linearGradient") as SvgLinearGradientElement;
			
			Assert.AreEqual(1, elm.X1.AnimVal.Value, "x1");
			Assert.AreEqual(2, elm.Y1.AnimVal.Value, "y1");
			Assert.AreEqual(3, elm.X2.AnimVal.Value, "x2");
			Assert.AreEqual(4, elm.Y2.AnimVal.Value, "y2");
		}
	
	}
}
