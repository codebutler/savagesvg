using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;
using System.Collections;

using SharpVectors.UnitTests.Svg.Color;

namespace SharpVectors.UnitTests.Svg
{
	[TestFixture]
	public class SvgPaintTests : SvgColorTests
	{
		#region Helper stuff for CssValueTests
		protected override string aCssText
		{
			get{return "rgb(67,45,98)";}
		}

		protected override string anotherCssText		
		{
			get{return "url(someuri) rgb(255,234,1)";}
		}

		protected override CssValueType cssValueType
		{
			get{return CssValueType.PrimitiveValue;}
		}


		protected override CssValue _getCssValue(string cssText, bool readOnly)
		{
			return new SvgPaint(cssText);
		}


		protected override Type Type
		{
			get{return typeof(SvgPaint);}
		}
		#endregion 

		protected override SvgColor _createColor(string str)
		{
			return new SvgPaint(str);
		}

		[Test]
		public void TestPaintTypes()
		{
			SvgPaint paint;
			paint = new SvgPaint("url(rr)");
			Assert.AreEqual(SvgPaintType.Uri, paint.PaintType);

			paint = new SvgPaint("url(rr) #34ff23");
			Assert.AreEqual(SvgPaintType.UriRgbColor, paint.PaintType);

			paint = new SvgPaint("url(rr) #34ff23 icc-color(somename)");
			Assert.AreEqual(SvgPaintType.UriRgbColorIccColor, paint.PaintType);

			paint = new SvgPaint("url(rr) none");
			Assert.AreEqual(SvgPaintType.UriNone, paint.PaintType);

			paint = new SvgPaint("url(rr)	 currentColor");
			Assert.AreEqual(SvgPaintType.UriCurrentColor, paint.PaintType);

			paint = new SvgPaint("currentColor");
			Assert.AreEqual(SvgPaintType.CurrentColor, paint.PaintType);

			paint = new SvgPaint("none");
			Assert.AreEqual(SvgPaintType.None, paint.PaintType);

			paint = new SvgPaint("rgb(12%, 23%, 12)");
			Assert.AreEqual(SvgPaintType.RgbColor, paint.PaintType);

			paint = new SvgPaint("rgb(12%, 23%, 45) icc-color(somename)");
			Assert.AreEqual(SvgPaintType.RgbColorIccColor, paint.PaintType);
		}

		[Test]
		public void TestSetUri()
		{
			SvgPaint paint = new SvgPaint("none");
			paint.SetUri("uri");
			Assert.AreEqual("uri", paint.Uri);
			Assert.AreEqual(SvgPaintType.Uri, paint.PaintType);
		}

		[Test]
		public void TestSetPaint()
		{
			SvgPaint paint = new SvgPaint("none");

			paint.SetPaint(SvgPaintType.Uri, "someuri", null, null);
			Assert.AreEqual("someuri", paint.Uri);
			Assert.AreEqual("url(someuri)", paint.CssText);
			Assert.AreEqual(SvgPaintType.Uri, paint.PaintType);

			paint.SetPaint(SvgPaintType.UriCurrentColor, "someuri", null, null);
			Assert.AreEqual("someuri", paint.Uri);
			Assert.AreEqual("url(someuri) currentColor", paint.CssText);
			Assert.AreEqual(SvgPaintType.UriCurrentColor, paint.PaintType);

			paint.SetPaint(SvgPaintType.UriNone, "someuri", null, null);
			Assert.AreEqual("someuri", paint.Uri);
			Assert.AreEqual("url(someuri) none", paint.CssText);
			Assert.AreEqual(SvgPaintType.UriNone, paint.PaintType);

			paint.SetPaint(SvgPaintType.None, null, null, null);
			Assert.AreEqual("none", paint.CssText);
			Assert.AreEqual(SvgPaintType.None, paint.PaintType);

			paint.SetPaint(SvgPaintType.CurrentColor, null, null, null);
			Assert.AreEqual("currentColor", paint.CssText);
			Assert.AreEqual(SvgPaintType.CurrentColor, paint.PaintType);

			paint.SetPaint(SvgPaintType.UriRgbColor, "someuri", "#ff00ff", null);
			Assert.AreEqual("url(someuri) rgb(255,0,255)", paint.CssText);
			Assert.AreEqual(SvgPaintType.UriRgbColor, paint.PaintType);
		}
	}
}
