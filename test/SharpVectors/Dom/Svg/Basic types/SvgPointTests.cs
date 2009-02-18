using System;

using NUnit.Framework;

using SharpVectors.Dom.Svg;



namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces

{

    [TestFixture]

	public class SvgPointTests

	{

        #region Fields

        private SvgPoint p;

        #endregion



        #region SetUp

        [SetUp]

        public void SetUp()

        {

            p = new SvgPoint(10,20);

        }

        #endregion



        [Test]

        public void TestConstructor()

        {

            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

        }



        [Test]

        public void TestSetX()

        {

            p.X = 30;

            Assert.AreEqual(30, p.X);

            Assert.AreEqual(20, p.Y);

        }



        [Test]

        public void TestSetY()

        {

            p.Y = 30;

            Assert.AreEqual(10, p.X);

            Assert.AreEqual(30, p.Y);

        }



        [Test]

        public void TestMatrixTransformIdentity()

        {

            SvgMatrix m = new SvgMatrix(1, 2, 3, 4, 5, 6);

            ISvgPoint p2 = p.MatrixTransform(m);



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(75, p2.X);

            Assert.AreEqual(106, p2.Y);

        }



        [Test]

        public void TestLerp()

        {

            SvgPoint p2 = new SvgPoint(40,30);

            SvgPoint p3 = p.lerp(p2, 0.25);



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(40, p2.X);

            Assert.AreEqual(30, p2.Y);

            Assert.AreEqual(17.5, p3.X);

            Assert.AreEqual(22.5, p3.Y);

        }



        [Test]

        public void TestAddition()

        {

            SvgPoint p2 = new SvgPoint(40,30);

            SvgPoint p3 = p + p2;



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(40, p2.X);

            Assert.AreEqual(30, p2.Y);

            Assert.AreEqual(50, p3.X);

            Assert.AreEqual(50, p3.Y);

        }



        [Test]

        public void TestSubtraction()

        {

            SvgPoint p2 = new SvgPoint(40,30);

            SvgPoint p3 = p2 - p;



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(40, p2.X);

            Assert.AreEqual(30, p2.Y);

            Assert.AreEqual(30, p3.X);

            Assert.AreEqual(10, p3.Y);

        }



        [Test]

        public void TestMultiply1()

        {

            SvgPoint p2 = p * 3.5;



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(35, p2.X);

            Assert.AreEqual(70, p2.Y);

        }

        

        [Test]

        public void TestMultiply2()

        {

            SvgPoint p2 = 3.5 * p;



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(35, p2.X);

            Assert.AreEqual(70, p2.Y);

        }

        

        [Test]

        public void TestDivide1()

        {

            SvgPoint p2 = p / 2.5;



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(4, p2.X);

            Assert.AreEqual(8, p2.Y);

        }

        

        [Test]

        public void TestDivide2()

        {

            SvgPoint p2 = 100 / p;



            Assert.AreEqual(10, p.X);

            Assert.AreEqual(20, p.Y);

            Assert.AreEqual(10, p2.X);

            Assert.AreEqual(5, p2.Y);

        }

	}

}

