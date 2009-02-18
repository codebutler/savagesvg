using System;
using System.Drawing;
using SharpVectors.Polynomials;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public abstract class CubicTests
        {
            protected SvgPathSegList segments;
            private SvgPathSegCurvetoCubic segment;

            [SetUp]
            public void SetUp()
            {
                segments = makeSegments();
                segment = getTestSegment();
            }

            [Test]
            public void TestArcLengthPolynomial()
            {
		    /*
                SqrtPolynomial poly = segment.getArcLengthPolynomial();

                Assert.AreEqual(4, poly.Degree);
                Assert.AreEqual(900, poly[4]);
                Assert.AreEqual(-3600, poly[3]);
                Assert.AreEqual(279000, poly[2]);
                Assert.AreEqual(-259200, poly[1]);
                Assert.AreEqual(145800, poly[0]);
		*/
		    throw new NotImplementedException();
            }

            [Test]
            public void TestArcLength()
            {
		    throw new NotImplementedException();
		    /*
                SqrtPolynomial poly = segment.getArcLengthPolynomial();
                float result1 = segment.Length;
                double result2 = Math.Floor(poly.Simpson(0, 1)*1e6)/1e6;

                Assert.AreEqual(327.877900, result1);
                Assert.AreEqual(327.877935, result2);
	    */
            }

            public abstract SvgPathSegList makeSegments();
            public abstract SvgPathSegCurvetoCubic getTestSegment();
        }
