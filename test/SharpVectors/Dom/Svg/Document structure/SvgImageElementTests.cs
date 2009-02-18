using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.DocumentStructure
{
	[TestFixture]
	public class SvgImageElementTests : SvgTransformableElementTests
	{
		#region Utils for SvgElementTests
		protected override Type elmType
		{
			get{return typeof(SvgImageElement);}
		}

		protected override string localName
		{
			get{return "image";}
		}
		#endregion

		public SvgImageElement getElm(string href)
		{
            return Util.GetXmlElement("<image xlink:href='" + href + "' width='50' height='50' />", "", "image") as SvgImageElement;
		}

		[Test]
		public void TestHttpPng()
		{
			string url = "http://www.protocol7.com/images/logo.png";
			SvgImageElement elm = getElm(url);
            Assert.AreEqual(url, elm.Href.AnimVal);

			Assert.AreEqual(false, elm.IsSvgImage);
			Assert.IsNull(elm.SvgWindow);
			
			Assert.IsNotNull(elm.Bitmap);
			Assert.AreEqual(350, elm.Bitmap.Width);
			Assert.AreEqual(128, elm.Bitmap.Height);
		}

		[Test]
		public void TestHttpSvg()
		{
			throw new NotImplementedException();
			// This hangs for some reason
			/*
			string url = "http://www.w3.org/Graphics/SVG/Test/20021112/svggen/color-prof-01-f.svg";
			SvgImageElement elm = getElm(url);
			Assert.AreEqual(url, elm.Href.AnimVal);

			Assert.AreEqual(true, elm.IsSvgImage);
			Assert.IsNull(elm.Bitmap);
			
			Assert.IsNotNull(elm.SvgWindow, "Window");
			Assert.IsNotNull(elm.SvgWindow.Document, "Document");
			*/
		}
	}
}
