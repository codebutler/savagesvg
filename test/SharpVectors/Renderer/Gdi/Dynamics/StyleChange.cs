using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Xml;
using System.IO;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Renderer.Gdi;


namespace SharpVectors.UnitTests.Renderer
{
	[TestFixture]
	public class StyleChange
	{
		string dirPath = "Renderer.Gdi";

		GdiRenderer renderer;
		SvgWindow wnd;
		SvgDocument doc;

		[SetUp]
		public void SetUp()
		{
			renderer = new GdiRenderer();
			wnd = new SvgWindow(75, 75, renderer);
			doc = new SvgDocument(wnd);
		}

		[Test]
		[Ignore("Doens't work. Fix!")]
		public void ChangeStyleAndRender()
		{
			string svgPath = Path.Combine(dirPath, "rectangleFillStroke.svg");
			doc.Load(svgPath);

			CompareUtil util = new CompareUtil();
			Assert.IsTrue(util.CompareImages(renderer.Render(doc), Path.Combine(dirPath, "rectangleFillStroke.svg.png")));

			SvgRectElement elm = doc.GetElementById("theRect") as SvgRectElement;
			elm.Style.SetProperty("fill", "yellow", "");

			Assert.IsTrue(util.CompareImages(renderer.Render(doc), Path.Combine(dirPath, "changeStyle.png")));
		}
	}
}
