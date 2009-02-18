using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.UnitTests.Svg;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.Gradients_and_Patterns
{
	[TestFixture]
	public class SvgPatternElementTests : SvgElementTests
	{
		#region Utils for SvgElementTests
		protected override Type elmType
		{
			get{return typeof(SvgPatternElement);}
		}

		protected override string localName
		{
			get{return "pattern";}
		}
		#endregion

		[Test]
		public void TestSize()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern x='1' y='2' width='3' height='4' />", "", "pattern") as SvgPatternElement;
			
			Assert.AreEqual(1, elm.X.AnimVal.Value, "x");
			Assert.AreEqual(2, elm.Y.AnimVal.Value, "y");
			Assert.AreEqual(3, elm.Width.AnimVal.Value, "width");
			Assert.AreEqual(4, elm.Height.AnimVal.Value,"height");
		}

		[Test]
		public void TestPatternUnits()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern patternUnits='userSpaceOnUse' />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual((ushort)SvgUnitType.UserSpaceOnUse, elm.PatternUnits.AnimVal);

			elm = Util.GetXmlElement("<pattern patternUnits='objectBoundingBox' />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual((ushort)SvgUnitType.ObjectBoundingBox, elm.PatternUnits.AnimVal);

			elm = Util.GetXmlElement("<pattern />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual((ushort)SvgUnitType.ObjectBoundingBox, elm.PatternUnits.AnimVal);
		}

		[Test]
		public void TestPatternContentUnits()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern  patternContentUnits='userSpaceOnUse' />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual((ushort)SvgUnitType.UserSpaceOnUse, elm.PatternContentUnits.AnimVal);

			elm = Util.GetXmlElement("<pattern  patternContentUnits='objectBoundingBox' />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual((ushort)SvgUnitType.ObjectBoundingBox, elm.PatternContentUnits.AnimVal);

			elm = Util.GetXmlElement("<pattern />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual((ushort)SvgUnitType.UserSpaceOnUse, elm.PatternContentUnits.AnimVal);
		}

		[Test]
		public void TestPatternTransform()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern patternTransform='translate(1,1) rotate(34)' />", "", "pattern") as SvgPatternElement;
      ISvgAnimatedTransformList satl = elm.PatternTransform as ISvgAnimatedTransformList;
			Assert.IsNotNull(satl);
			Assert.AreEqual(2, elm.PatternTransform.AnimVal.NumberOfItems);

			elm = Util.GetXmlElement("<pattern />", "", "pattern") as SvgPatternElement;
      satl = elm.PatternTransform as ISvgAnimatedTransformList;
			Assert.IsNotNull(satl);
			Assert.AreEqual(0, elm.PatternTransform.AnimVal.NumberOfItems);
		}

		[Test]
		public void TestHref()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern xlink:href='kalle.svg#someOtherPattern' />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual("kalle.svg#someOtherPattern", elm.Href.AnimVal);

			elm = Util.GetXmlElement("<pattern />", "", "pattern") as SvgPatternElement;
			Assert.AreEqual("", elm.Href.AnimVal);
		}

		[Test]
		public void TestViewBox()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern viewBox='1 2 3 4' />", "", "pattern") as SvgPatternElement;
			
			Assert.AreEqual(1, elm.ViewBox.AnimVal.X);
			Assert.AreEqual(2, elm.ViewBox.AnimVal.Y);
			Assert.AreEqual(3, elm.ViewBox.AnimVal.Width);
			Assert.AreEqual(4, elm.ViewBox.AnimVal.Height);

			elm = Util.GetXmlElement("<pattern />", "", "pattern") as SvgPatternElement;
			
			Assert.AreEqual(0, elm.ViewBox.AnimVal.X);
			Assert.AreEqual(0, elm.ViewBox.AnimVal.Y);
			Assert.AreEqual(0, elm.ViewBox.AnimVal.Width);
			Assert.AreEqual(0, elm.ViewBox.AnimVal.Height);
		}

		[Test]
		public void TestPreserveAspectRatio()
		{
			SvgPatternElement elm = Util.GetXmlElement("<pattern preserveAspectRatio='xMidYMin slice' />", "", "pattern") as SvgPatternElement;
			
			Assert.AreEqual(SvgPreserveAspectRatioType.XMidYMin, elm.PreserveAspectRatio.AnimVal.Align);
			Assert.AreEqual(SvgMeetOrSlice.Slice, elm.PreserveAspectRatio.AnimVal.MeetOrSlice);

			elm = Util.GetXmlElement("<pattern />", "", "pattern") as SvgPatternElement;
			
			Assert.AreEqual(SvgPreserveAspectRatioType.XMidYMid, elm.PreserveAspectRatio.AnimVal.Align);
			Assert.AreEqual(SvgMeetOrSlice.Meet, elm.PreserveAspectRatio.AnimVal.MeetOrSlice);
		}
	}
}
