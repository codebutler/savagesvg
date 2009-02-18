using System;
using NUnit.Framework;
using SharpVectors.Polynomials;

        [TestFixture]
        public class SqrtPolynomialTests : PolynomialTests
        {
            [Test]
            public override void TestEval()
            {
                Assert.AreEqual(7, poly.Evaluate(2));
            }

            
            [Test]
            public override void TestTrapezoid()
            {
		    throw new NotImplementedException ();
		    /*
                double[] t = new double[10];

                for ( int i = 0; i < 10; i++ )
                {
                    t[i] = ((SqrtPolynomial) poly).trapezoid(0, 1, i+1);
                }

                Assert.AreEqual(2.0811388300841900, t[0]);
                Assert.AreEqual(1.9419572339080924, t[1]);
                Assert.AreEqual(1.9076575130141613, t[2]);
                Assert.AreEqual(1.8991762591629650, t[3]);
                Assert.AreEqual(1.8970624585984340, t[4]);
                Assert.AreEqual(1.8965344208416803, t[5]);
                Assert.AreEqual(1.8964024372601043, t[6]);
                Assert.AreEqual(1.8963694429821338, t[7]);
                Assert.AreEqual(1.8963611945137506, t[8]);
                Assert.AreEqual(1.8963591324029752, t[9]);
		*/
            }

            [Test]
            public void TestTrapezoid2()
            {
		    throw new NotImplementedException();
		    /*
                double[] t = new double[20];
                SqrtPolynomial poly = new SqrtPolynomial(145800, -259200, 279000, -3600, 900);

                for ( int i = 0; i < 20; i++ )
                {
                    t[i] = poly.trapezoid(0, 1, i+1);
                }

                Assert.AreEqual(392.72319162647350, t[0]);
                Assert.AreEqual(342.61159581323676, t[1]);
                Assert.AreEqual(331.53834637052490, t[2]);
                Assert.AreEqual(328.79094438739287, t[3]);
                Assert.AreEqual(328.10605667592347, t[4]);
                Assert.AreEqual(327.93495792953500, t[5]);
                Assert.AreEqual(327.89219094488620, t[6]);
                Assert.AreEqual(327.88149968013374, t[7]);
                Assert.AreEqual(327.87882689403440, t[8]);
                Assert.AreEqual(327.87815869939020, t[9]);
                Assert.AreEqual(327.87799165084670, t[10]);
                Assert.AreEqual(327.87794988871800, t[11]);
                Assert.AreEqual(327.87793944818645, t[12]);
                Assert.AreEqual(327.87793683805364, t[13]);
                Assert.AreEqual(327.87793618552050, t[14]);
                Assert.AreEqual(327.87793602238645, t[15]);
                Assert.AreEqual(327.87793598160340, t[16]);
                Assert.AreEqual(327.87793597140626, t[17]);
                Assert.AreEqual(327.87793596885720, t[18]);
                Assert.AreEqual(327.87793596821960, t[19]);
		*/
            }

            [Test]
            public override void TestSimpson()
            {
                double result = Math.Floor(poly.Simpson(0,1) * 1e7) / 1e7;

                // This test value was generated from Mathematica 5
                Assert.AreEqual(1.8963584, result);
            }

            protected override Polynomial makePoly()
            {
                return new SqrtPolynomial(1, 2, 3, 4);
            }
        }
