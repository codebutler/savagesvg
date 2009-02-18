using System;

using NUnit.Framework;

using SharpVectors.Dom;

using SharpVectors.Dom.Svg;



namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces

{

	public class SvgPointListTests : SvgListTests

	{

        #region Fields

        private static int counter = 0;

        #endregion



        #region Additional SvgPointList-specific tests

        [Test]

        public void TestFromStringEmpty()

        {

            ((SvgPointList) list).FromString("");

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        public void TestFromStringNull()

        {

            ((SvgPointList) list).FromString(null);

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        [ExpectedException(typeof(SvgException))]

        public void TestFromStringOddCount()

        {

            ((SvgPointList) list).FromString("1,2,3");

        }



        [Test]

        public void TestFromStringLeadingWhitespace()

        {

            SvgPointList svgPointList = (SvgPointList) list;

            ISvgPoint p1, p2;



            svgPointList.FromString(" 1 2 3 4");

            p1 = svgPointList.GetItem(0);

            p2 = svgPointList.GetItem(1);

            Assert.AreEqual(1, p1.X);

            Assert.AreEqual(2, p1.Y);

            Assert.AreEqual(3, p2.X);

            Assert.AreEqual(4, p2.Y);

        }



        [Test]

        public void TestFromStringTrailingWhitespace()

        {

            SvgPointList svgPointList = (SvgPointList) list;

            ISvgPoint p1, p2;



            svgPointList.FromString("1 2 3 4 ");

            p1 = svgPointList.GetItem(0);

            p2 = svgPointList.GetItem(1);

            Assert.AreEqual(1, p1.X);

            Assert.AreEqual(2, p1.Y);

            Assert.AreEqual(3, p2.X);

            Assert.AreEqual(4, p2.Y);

        }



        [Test]

        public void TestFromStringOneValue()

        {

            SvgPointList svgPointList = (SvgPointList) list;

            ISvgPoint p1;



            svgPointList.FromString("1 2");

            p1 = svgPointList.GetItem(0);

            Assert.AreEqual(1, p1.X);

            Assert.AreEqual(2, p1.Y);

        }



        [Test]

        public void TestFromStringSpaceDelimited()

        {

            SvgPointList svgPointList = (SvgPointList) list;

            ISvgPoint p1, p2;



            svgPointList.FromString("1 2  3   4");

            p1 = svgPointList.GetItem(0);

            p2 = svgPointList.GetItem(1);

            Assert.AreEqual(1, p1.X);

            Assert.AreEqual(2, p1.Y);

            Assert.AreEqual(3, p2.X);

            Assert.AreEqual(4, p2.Y);

        }



        [Test]

        public void TestFromStringCommaDelimited()

        {

            SvgPointList svgPointList = (SvgPointList) list;

            ISvgPoint p1, p2, p3;



            svgPointList.FromString("1,2, 3 ,4 , 5,6");

            p1 = svgPointList.GetItem(0);

            p2 = svgPointList.GetItem(1);

            p3 = svgPointList.GetItem(2);

            Assert.AreEqual(1, p1.X);

            Assert.AreEqual(2, p1.Y);

            Assert.AreEqual(3, p2.X);

            Assert.AreEqual(4, p2.Y);

            Assert.AreEqual(5, p3.X);

            Assert.AreEqual(6, p3.Y);

            bool except = false;
            try 
            {
              svgPointList.FromString("1,2, 3 , , 5,6");
            } 
            catch (SvgException) 
            {
              except = true;
            }
            Assert.IsTrue(except, "Double comma should give an invalid value SVG exception");


        }



        [Test]

        [ExpectedException(typeof(SvgException))]

        public void TestFromStringMultipleCommas()

        {

            ((SvgPointList) list).FromString("1,,2,3");

        }



        [Test]

        [ExpectedException(typeof(SvgException))]

        public void TestFromStringMultipleCommas2()

        {

            ((SvgPointList) list).FromString("1, ,2,3");

        }



        [Test]

        [ExpectedException(typeof(SvgException))]

        public void TestFromStringMultipleCommas3()

        {

            ((SvgPointList) list).FromString("1 , ,2,3");

        }



        [Test]

        [ExpectedException(typeof(SvgException))]

        public void TestFromStringMultipleCommas4()

        {

            ((SvgPointList) list).FromString("1 , , 2,3");

        }



        [Test]

        public void TestFromStringMixed()

        {

            SvgPointList svgPointList = (SvgPointList) list;

            ISvgPoint p1, p2, p3;



            svgPointList.FromString("1 2  3,4 ,5 , 6");

            p1 = svgPointList.GetItem(0);

            p2 = svgPointList.GetItem(1);

            p3 = svgPointList.GetItem(2);

            Assert.AreEqual(1, p1.X);

            Assert.AreEqual(2, p1.Y);

            Assert.AreEqual(3, p2.X);

            Assert.AreEqual(4, p2.Y);

            Assert.AreEqual(5, p3.X);

            Assert.AreEqual(6, p3.Y);

        }

        #endregion



        #region Support Methods

        protected override SvgList makeList()

        {

            return new SvgPointList();

        }



        protected new SvgPoint makeItem()

        {

            return new SvgPoint(counter++,counter++);

        }

        #endregion

	}

}

