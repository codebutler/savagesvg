using System;
using System.Drawing;
using System.IO;

using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Renderer.Gdi;
using SharpVectors.UnitTests.Renderer;


namespace SharpVectors.UnitTests.Renderer
{
    [TestFixture]
	public class GdiRendererTests
	{
        #region Fields
        private static string baseDir;
        private static SvgWindow window;
        private static GdiRenderer renderer;
        private static BitmapComparator comparator;
        #endregion

        #region Static Constructor
        static GdiRendererTests()
        {
            // init baseDir (relative to current directory)
            baseDir = @"Renderer.Gdi\";
        }
        #endregion

		[SetUp]
		public void SetUp()
		{
			// create a BitmapComparator
			comparator = new BitmapComparator();

			// create an SVGWindow and an associated GdiRenderer
			renderer = new GdiRenderer();
			window = new SvgWindow(75,75, renderer);
		}

        #region Tests
        [Test]
        public void TestCircleFill()
        {
            Assert.IsTrue(CompareImages("circleFill.svg"));
        }

        [Test]
        public void TestCircleFillStroke()
        {
            Assert.IsTrue(CompareImages("circleFillStroke.svg"));
        }

        [Test]
        public void TestCircleStroke()
        {
            Assert.IsTrue(CompareImages("circleStroke.svg"));
        }

        [Test]
        public void TestEllipseFill()
        {
            Assert.IsTrue(CompareImages("ellipseFill.svg"));
        }

        [Test]
        public void TestEllipseFillStroke()
        {
            Assert.IsTrue(CompareImages("ellipseFillStroke.svg"));
        }

        [Test]
        public void TestEllipseStroke()
        {
            Assert.IsTrue(CompareImages("ellipseStroke.svg"));
        }

		[Test]
		public void TestLinearGradient()
		{
			Assert.IsTrue(CompareImages("lineargradient.svg"));
		}

		[Test]
		public void TestLinearGradient2()
		{
			Assert.IsTrue(CompareImages("lineargradient2.svg"));
		}


        [Test]
        public void TestImageSvg()
        {
            Assert.IsTrue(CompareImages("image-svg.svg"));
        }

        [Test]
        public void TestImagePng()
        {
            Assert.IsTrue(CompareImages("image-png.svg"));
        }

        

        [Test]

        public void TestLineStroke()

        {

            Assert.IsTrue(CompareImages("lineStroke.svg"));

        }

        

        [Test]
        public void TestMarkerLine()

        {

            Assert.IsTrue(CompareImages("marker-line.svg"), "Marker - Line");

        }


        [Test]
        public void TestMarkerPath()

        {

            Assert.IsTrue(CompareImages("marker-path.svg"), "Marker - Path");

        }


        [Test]
        public void TestMarkerPolygon()

        {

            Assert.IsTrue(CompareImages("marker-polygon.svg"), "Marker - Polygon");

        }



        [Test]
        public void TestMarkerPolyline()

        {

            Assert.IsTrue(CompareImages("marker-polyline.svg"), "Marker - Polyline");

        }



        [Test]

        public void TestPathFill()

        {

            Assert.IsTrue(CompareImages("pathFill.svg"));

        }

        

        [Test]

        public void TestPathFillStroke()

        {

            Assert.IsTrue(CompareImages("pathFillStroke.svg"));

        }

        

        [Test]

        public void TestPathStroke()

        {

            Assert.IsTrue(CompareImages("pathStroke.svg"));

        }

        

        [Test]

        public void TestPolygonFill()

        {

            Assert.IsTrue(CompareImages("polygonFill.svg"));

        }

        

        [Test]

        public void TestPolygonFillStroke()

        {

            Assert.IsTrue(CompareImages("polygonFillStroke.svg"));

        }

        

        [Test]

        public void TestPolygonStroke()

        {

            Assert.IsTrue(CompareImages("polygonStroke.svg"));

        }

        

        [Test]

        public void TestPolylineFill()

        {

            Assert.IsTrue(CompareImages("polylineFill.svg"));

        }

        

        [Test]

        public void TestPolylineFillStroke()

        {

            Assert.IsTrue(CompareImages("polylineFillStroke.svg"));

        }

        

        [Test]

        public void TestPolylineStroke()

        {

            Assert.IsTrue(CompareImages("polylineStroke.svg"));

        }

        

        [Test]

        public void TestRectangleFill()

        {

            Assert.IsTrue(CompareImages("rectangleFill.svg"));

        }

        

        [Test]

        public void TestRectangleFillStroke()

        {

            Assert.IsTrue(CompareImages("rectangleFillStroke.svg"));

        }

        

        [Test]

        public void TestRectangleStroke()

        {

            Assert.IsTrue(CompareImages("rectangleStroke.svg"));

        }

        

        [Test]

        public void TestRoundedRectangleFill()

        {

            Assert.IsTrue(CompareImages("roundedFill.svg"));

        }



        [Test]

        public void TestRectangleMatrix() {

            Assert.IsTrue(CompareImages("rectangleMatrix.svg"));

        }

        

        [Test]

        public void TestRectangleRotate() {

            Assert.IsTrue(CompareImages("rectangleRotate.svg"));

        }

        

        [Test]

        public void TestRectangleScale() {

            Assert.IsTrue(CompareImages("rectangleScale.svg"));

        }

        

        [Test]

        public void TestRectangleSkewX() {

            Assert.IsTrue(CompareImages("rectangleSkewX.svg"));

        }

        

        [Test]

        public void TestRectangleSkewY() {

            Assert.IsTrue(CompareImages("rectangleSkewY.svg"));

        }

        

        [Test]

        public void TestRectangleTranslate() {

            Assert.IsTrue(CompareImages("rectangleTranslate.svg"));

        }

        

        [Test]

        public void TestRoundedRectangleFillStroke()

        {

            Assert.IsTrue(CompareImages("roundedFillStroke.svg"));

        }

        

        [Test]

        public void TestRoundedRectangleStroke()

        {

            Assert.IsTrue(CompareImages("roundedStroke.svg"));

        }

        

        [Test]

        public void TestUse()

        {

            Assert.IsTrue(CompareImages("use.svg"));

        }

        #endregion

		#region data protocol tests
		[Test]
		public void DataProtocolTestInlineSvgImage()
		{
            Assert.IsTrue(CompareImages("data-image.svg"));
		}
		#endregion

        #region Support Methods

        private bool CompareImages(string svgFile)
        {
			svgFile = Path.Combine(baseDir, svgFile);
			CompareUtil util = new CompareUtil();

			SvgDocument doc = new SvgDocument(window);
			doc.Load(svgFile);

			return util.CompareImages(renderer.Render(doc), svgFile + ".png");
        }
        #endregion

	}

}

