using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces
{
    // The resulting test values were generated using MuPad Light
    // NOTE: The original implementation of SvgMatrix returned doubles when accessing properties.  To stay consistent with the SVG specification, these were switched to floats.  The original double values used in the assertions have been left "just in case".  They are being converted to floats using the trailing "f".
    [TestFixture]
	public class SvgMatrixTests
	{
        [Test]
        public void TestConstructor()
        {
            ISvgMatrix m = new SvgMatrix();

            Assert.AreEqual(1, m.A);
            Assert.AreEqual(0, m.B);
            Assert.AreEqual(0, m.C);
            Assert.AreEqual(1, m.D);
            Assert.AreEqual(0, m.E);
            Assert.AreEqual(0, m.F);
        }

        [Test]
        public void TestConstructor2()
        {
            ISvgMatrix m = new SvgMatrix(1, 2, 3, 4, 5, 6);

            Assert.AreEqual(1, m.A);
            Assert.AreEqual(2, m.B);
            Assert.AreEqual(3, m.C);
            Assert.AreEqual(4, m.D);
            Assert.AreEqual(5, m.E);
            Assert.AreEqual(6, m.F);
        }

        [Test]
        public void TestMultiply()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = new SvgMatrix(7, 8, 9, 10, 11, 12);
            ISvgMatrix m3 = m1.Multiply(m2);

            Assert.AreEqual(31, m3.A);
            Assert.AreEqual(46, m3.B);
            Assert.AreEqual(39, m3.C);
            Assert.AreEqual(58, m3.D);
            Assert.AreEqual(52, m3.E);
            Assert.AreEqual(76, m3.F);
        }

        [Test]
        public void TestInverse()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.Inverse();

            Assert.AreEqual(-2, m2.A);
            Assert.AreEqual(1, m2.B);
            Assert.AreEqual(1.5, m2.C);
            Assert.AreEqual(-0.5, m2.D);
            Assert.AreEqual(1, m2.E);
            Assert.AreEqual(-2, m2.F);
        }

        [Test]
        [ExpectedException(typeof(SvgException))]
        public void TestNoInverse()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 6, 0, 0);
            ISvgMatrix m2 = m1.Inverse();
        }

        [Test]
        public void TestTranslate()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.Translate(10,20);

            Assert.AreEqual(1, m2.A);
            Assert.AreEqual(2, m2.B);
            Assert.AreEqual(3, m2.C);
            Assert.AreEqual(4, m2.D);
            Assert.AreEqual(75, m2.E);
            Assert.AreEqual(106, m2.F);
        }

        [Test]
        public void TestScale()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.Scale(10);

            Assert.AreEqual(10, m2.A);
            Assert.AreEqual(20, m2.B);
            Assert.AreEqual(30, m2.C);
            Assert.AreEqual(40, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestScaleNonUniform()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.ScaleNonUniform(10,20);

            Assert.AreEqual(10, m2.A);
            Assert.AreEqual(20, m2.B);
            Assert.AreEqual(60, m2.C);
            Assert.AreEqual(80, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestRotate()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.Rotate(30);

            Assert.AreEqual(2.36602540378444f, m2.A);
            Assert.AreEqual(3.73205080756888f, m2.B);
            Assert.AreEqual(2.09807621135332f, m2.C);
            Assert.AreEqual(2.46410161513775f, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestRotateFromVector()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.RotateFromVector(1.73205080756888f, 1);

            Assert.AreEqual(2.36602540378444f, m2.A);
            Assert.AreEqual(3.73205080756888f, m2.B);
            Assert.AreEqual(2.09807621135332f, m2.C);
            //D property incorrect when using doubles, probably due to rounding
            //Assert.AreEqual(2.46410161513775, m2.D);
            Assert.AreEqual(2.46410161513776f, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        [ExpectedException(typeof(SvgException))]
        public void TestRotateFromVectorZeroX()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 6, 0, 0);
            ISvgMatrix m2 = m1.RotateFromVector(0, 1);
        }

        [Test]
        [ExpectedException(typeof(SvgException))]
        public void TestRotateFromVectorZeroY()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 6, 0, 0);
            ISvgMatrix m2 = m1.RotateFromVector(1, 0);
        }

        [Test]
        public void TestFlipX()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.FlipX();

            Assert.AreEqual(-1, m2.A);
            Assert.AreEqual(-2, m2.B);
            Assert.AreEqual(3, m2.C);
            Assert.AreEqual(4, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestFlipY()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.FlipY();

            Assert.AreEqual(1, m2.A);
            Assert.AreEqual(2, m2.B);
            Assert.AreEqual(-3, m2.C);
            Assert.AreEqual(-4, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestSkewX()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.SkewX(30);

            Assert.AreEqual(1, m2.A);
            Assert.AreEqual(2, m2.B);
            Assert.AreEqual(3.57735026918963f, m2.C);
            Assert.AreEqual(5.15470053837925f, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestSkewY()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = m1.SkewY(30);

            Assert.AreEqual(2.73205080756888f, m2.A);
            Assert.AreEqual(4.3094010767585f, m2.B);
            Assert.AreEqual(3, m2.C);
            Assert.AreEqual(4, m2.D);
            Assert.AreEqual(5, m2.E);
            Assert.AreEqual(6, m2.F);
        }

        [Test]
        public void TestMultiply2()
        {
            ISvgMatrix m1 = new SvgMatrix(1, 2, 3, 4, 5, 6);
            ISvgMatrix m2 = new SvgMatrix(7, 8, 9, 10, 11, 12);
            SvgMatrix m3 = (SvgMatrix) m1 * (SvgMatrix) m2;

            Assert.AreEqual(31, m3.A);
            Assert.AreEqual(46, m3.B);
            Assert.AreEqual(39, m3.C);
            Assert.AreEqual(58, m3.D);
            Assert.AreEqual(52, m3.E);
            Assert.AreEqual(76, m3.F);
        }
	}
}