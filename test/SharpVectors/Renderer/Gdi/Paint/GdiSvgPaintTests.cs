using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Renderer.Gdi;
using SharpVectors.UnitTests.Renderer;

namespace SharpVectors.UnitTests.Renderer
{
    [TestFixture]	
	public class GDISvgPaintTests
	{
		SvgStyleableElement elm;

		[SetUp]
		public void SetUp()
		{
      SvgWindow wnd = new SvgWindow(100, 100, new GdiRenderer());
			SvgDocument doc = wnd.CreateEmptySvgDocument();
			doc.LoadXml("<svg xmlns='" + SvgDocument.SvgNamespace + "'><rect /></svg>");
			elm = (SvgStyleableElement)doc.SelectSingleNode("//*[local-name()='rect']");
		}

		private GraphicsPath getGp()
		{
			GraphicsPath gp = new GraphicsPath();
			gp.AddEllipse(100, 100, 100, 100);
			return gp;            
		}

		private bool isSameColor(Color c1, Color c2)
		{
			return (c1.A == c2.A && c1.R == c2.R && c1.G == c2.G && c1.B == c2.B);

		}

		[Test]
		public void TestColorFill()
		{
			elm.SetAttribute("fill", "red");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "fill");


			Brush brush = paint.GetBrush(getGp());

			Assert.AreEqual(typeof(SolidBrush), brush.GetType());
            Assert.IsTrue(isSameColor(Color.Red, ((SolidBrush)brush).Color));
		}

		[Test]
		public void TestColorStroke()
		{
			elm.SetAttribute("stroke", "green");
			elm.SetAttribute("stroke-width", "23px");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");

			Pen pen = paint.GetPen(getGp());

			Assert.IsTrue(isSameColor(Color.Green, pen.Color));
			Assert.AreEqual(23, pen.Width);
		}

		[Test]
		public void TestOpacityStroke()
		{
			elm.SetAttribute("stroke", "white");
			elm.SetAttribute("opacity", "0.5");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			
			Pen pen = paint.GetPen(getGp());
			Assert.AreEqual(128, pen.Color.A);
		}

		[Test]
		public void TestOpacityFill()
		{
			elm.SetAttribute("opacity", "0.5");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "fill");
			Brush brush = paint.GetBrush(getGp());
			Assert.AreEqual(128, ((SolidBrush)brush).Color.A);
		}

		[Test]
		public void TestOpacityOver1()
		{
			elm.SetAttribute("stroke", "white");
			elm.SetAttribute("opacity", "2");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			Pen pen = paint.GetPen(getGp());
			Assert.AreEqual(255, pen.Color.A);
		}

		[Test]
		public void TestOpacityStrokeOpacityAndOpacity()
		{
			elm.SetAttribute("stroke", "white");
			elm.SetAttribute("opacity", "0.1");
			elm.SetAttribute("stroke-opacity", "0.5");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			Pen pen = paint.GetPen(getGp());
			Assert.AreEqual(Convert.ToInt32(255*0.1*0.5), pen.Color.A);
		}

		[Test]
		public void TestDashPattern()
		{
			elm.SetAttribute("stroke", "white");
			elm.SetAttribute("stroke-width", "2px");
			elm.SetAttribute("stroke-dasharray", "5,3,2");
			//elm.SetAttribute("stroke-dashoffset", "0.5");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			Pen pen = paint.GetPen(getGp());
			float[] correct = new float[]{2.5F, 1.5F, 1F, 2.5F, 1.5F, 1F};
			float[] actual = pen.DashPattern;

			Assert.AreEqual(6, actual.Length);
			Assert.AreEqual(2.5F, actual[0]);
			Assert.AreEqual(1.5F, actual[1]);
			Assert.AreEqual(1F, actual[2]);

			Assert.AreEqual(2.5F, actual[3]);
			Assert.AreEqual(1.5F, actual[4]);
			Assert.AreEqual(1F, actual[5]);
		}

		[Test]
		public void TestNonExistingGradientRgbColor()
		{
			elm.SetAttribute("stroke", "url(#myGradient) blue");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			
			Assert.AreEqual(SvgPaintType.UriRgbColor, paint.PaintType);

			Pen pen = paint.GetPen(getGp());
			Assert.IsTrue(isSameColor(Color.Blue, pen.Color));
		}

		[Test]
		public void TestNonExistingGradient()
		{
			elm.SetAttribute("fill", "url(#myGradient)");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "fill");
			
			Assert.AreEqual(SvgPaintType.Uri, paint.PaintType);

			Brush brush = paint.GetBrush(getGp());
			Assert.IsNull(brush);
		}

		[Test]
		public void TestNonExistingGradientCurrentColor()
		{
			elm.SetAttribute("color", "red");
			elm.SetAttribute("fill", "url(#myGradient) currentColor");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "fill");
			
			Assert.AreEqual(SvgPaintType.UriCurrentColor, paint.PaintType);

			Brush brush = paint.GetBrush(getGp());
			Assert.IsTrue(isSameColor(Color.Red, ((SolidBrush)brush).Color));
		}

		[Test]
		public void TestNone()
		{
			elm.SetAttribute("stroke", "none");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			Pen pen = paint.GetPen(getGp());

			Assert.IsNull(pen);
		}

		[Test]
		public void TestCurrentColor()
		{
			elm.SetAttribute("stroke", "currentColor");
			elm.SetAttribute("color", "red");
			GdiSvgPaint paint = new GdiSvgPaint(elm, "stroke");
			
			Pen pen = paint.GetPen(getGp());

			Assert.IsTrue(isSameColor(Color.Red, pen.Color));
		}
	}
}

