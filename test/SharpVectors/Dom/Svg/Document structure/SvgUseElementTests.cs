using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.DocumentStructure
{
	[TestFixture]
	public class SvgUseElementTests : SvgTransformableElementTests
	{
		#region Utils for SvgElementTests
		protected override Type elmType
		{
			get{return typeof(SvgUseElement);}
		}

		protected override string localName
		{
			get{return "use";}
		}
		#endregion

		[Test]
		public void TestXYWidthHeight()
		{
            SvgUseElement elm = Util.GetXmlElement("<use x='1' y='2' width='3' height='4' />", "", "use") as SvgUseElement;			

			Assert.AreEqual(1, elm.X.AnimVal.Value);
			Assert.AreEqual(2, elm.Y.AnimVal.Value);
			Assert.AreEqual(3, elm.Width.AnimVal.Value);
			Assert.AreEqual(4, elm.Height.AnimVal.Value);
		}

		[Test]
		public void TestInternalReference()
		{
			SvgUseElement elm = Util.GetXmlElement("<use xlink:href='#foo' /><rect id='foo' width='100' height='100' />", "", "use") as SvgUseElement;			
			SvgRectElement rect = elm.OwnerDocument.SelectSingleNode("//*[@id='foo']") as SvgRectElement;
			Assert.IsNotNull(elm.InstanceRoot);
			Assert.AreEqual(elm, elm.InstanceRoot.CorrespondingUseElement);
			Assert.AreEqual(rect, elm.InstanceRoot.CorrespondingElement);
		}
	}
}
