using System;
using NUnit.Framework;
using SharpVectors.Polynomials;

        [TestFixture]
        public class PolynomialTests
        {
            protected Polynomial poly;

            [SetUp]
            public void Setup()
            {
                poly = makePoly();
            }

            [Test]
            public void TestConstructor()
            {
                Polynomial poly2 = new Polynomial(1, 2, 3, 0);

                Assert.AreEqual(2, poly2.Degree);
                Assert.AreEqual(1, poly2[0]);
                Assert.AreEqual(2, poly2[1]);
                Assert.AreEqual(3, poly2[2]);
            }

            [Test]
            public void TestConstructor2()
            {
                Assert.AreEqual(3, poly.Degree);
                Assert.AreEqual(1, poly[0]);
                Assert.AreEqual(2, poly[1]);
                Assert.AreEqual(3, poly[2]);
                Assert.AreEqual(4, poly[3]);
            }

            [Test]
            public void TestConstructor3()
            {
                Polynomial poly2 = new Polynomial(poly);

                Assert.AreEqual(3, poly2.Degree);
                Assert.AreEqual(1, poly2[0]);
                Assert.AreEqual(2, poly2[1]);
                Assert.AreEqual(3, poly2[2]);
                Assert.AreEqual(4, poly2[3]);
            }

            [Test]
            public virtual void TestEval()
            {
                Assert.AreEqual(49, poly.Evaluate(2));
            }

            [Test]
            public virtual void TestTrapezoid()
            {
		    throw new NotImplementedException();
		    /*
                double[] t = new double[10];

                for ( int i = 0; i < 10; i++ )
                {
                    t[i] = poly.trapezoid(0, 1, i+1);
                }

                Assert.AreEqual(5.500000000000000, t[0]);
                Assert.AreEqual(4.375000000000000, t[1]);
                Assert.AreEqual(4.093750000000000, t[2]);
                Assert.AreEqual(4.023437500000000, t[3]);
                Assert.AreEqual(4.005859375000000, t[4]);
                Assert.AreEqual(4.001464843750000, t[5]);
                Assert.AreEqual(4.000366210937500, t[6]);
                Assert.AreEqual(4.000091552734375, t[7]);
                Assert.AreEqual(4.000022888183594, t[8]);
                Assert.AreEqual(4.000005722045898, t[9]);
		*/
            }

            [Test]
            public virtual void TestSimpson()
            {
                // This test value was generated from Mathematica 5
                Assert.AreEqual(4, poly.Simpson(0, 1));
            }

            protected virtual Polynomial makePoly()
            {
                return new Polynomial(1, 2, 3, 4);
            }
        }
