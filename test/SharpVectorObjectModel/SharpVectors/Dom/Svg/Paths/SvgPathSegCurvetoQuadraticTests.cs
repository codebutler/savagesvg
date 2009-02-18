using System;
using System.Drawing;
using SharpVectors.Polynomials;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public abstract class QuadraticTests
        {
            protected SvgPathSegList segments;
            private SvgPathSegCurvetoQuadratic segment;

            [SetUp]
            public void SetUp()
            {
                segments = makeSegments();
                segment = getTestSegment();
            }

            [Test]
            public void TestArcLengthPolynomial()
            {
		    throw new NotImplementedException();
		    /*
                SqrtPolynomial poly = segment.getArcLengthPolynomial();

                Assert.AreEqual(2, poly.Degree);
                Assert.AreEqual(130000, poly[2]);
                Assert.AreEqual(-122400, poly[1]);
                Assert.AreEqual(64800, poly[0]);
		*/
            }

            [Test]
            public void TestArcLength()
            {
		    throw new NotImplementedException();
		    /*
                SqrtPolynomial poly = segment.getArcLengthPolynomial();
                float result1 = segment.Length;
                double result2 = Math.Floor(poly.Simpson(0, 1)*1e6)/1e6;

                Assert.AreEqual(215.486400, result1);
                Assert.AreEqual(215.486377, result2);
		*/
            }

            public abstract SvgPathSegList makeSegments();
            public abstract SvgPathSegCurvetoQuadratic getTestSegment();
        }
