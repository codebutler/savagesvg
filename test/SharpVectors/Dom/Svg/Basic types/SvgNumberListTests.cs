using System;

using NUnit.Framework;

using SharpVectors.Dom;

using SharpVectors.Dom.Svg;



namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces

{

	public class SvgNumberListTests : SvgListTests

	{

        #region Fields

        private static int counter = 0;

        #endregion



        #region Additional SvgStringList-specific tests

        [Test]

        public void TestFromStringEmpty()

        {

            ((SvgNumberList) list).FromString("");

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        public void TestFromStringNull()

        {

            ((SvgNumberList) list).FromString(null);

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        public void TestFromStringLeadingWhitespace()

        {

            ((SvgNumberList) list).FromString(" 1 2 3 4");

            Assert.AreEqual(1, ((SvgNumberList) list).GetItem(0).Value);

            Assert.AreEqual(2, ((SvgNumberList) list).GetItem(1).Value);

            Assert.AreEqual(3, ((SvgNumberList) list).GetItem(2).Value);

            Assert.AreEqual(4, ((SvgNumberList) list).GetItem(3).Value);

        }



        [Test]

        public void TestFromStringTrailingWhitespace()

        {

            ((SvgNumberList) list).FromString("1 2 3 4 ");

            Assert.AreEqual(1, ((SvgNumberList) list).GetItem(0).Value);

            Assert.AreEqual(2, ((SvgNumberList) list).GetItem(1).Value);

            Assert.AreEqual(3, ((SvgNumberList) list).GetItem(2).Value);

            Assert.AreEqual(4, ((SvgNumberList) list).GetItem(3).Value);

        }



        [Test]

        public void TestFromStringOneValue()

        {

            ((SvgNumberList) list).FromString("1");

            Assert.AreEqual(1, ((SvgNumberList) list).GetItem(0).Value);

        }



        [Test]

        public void TestFromStringSpaceDelimited()

        {

            ((SvgNumberList) list).FromString("1 2  3   4");

            Assert.AreEqual(1, ((SvgNumberList) list).GetItem(0).Value);

            Assert.AreEqual(2, ((SvgNumberList) list).GetItem(1).Value);

            Assert.AreEqual(3, ((SvgNumberList) list).GetItem(2).Value);

            Assert.AreEqual(4, ((SvgNumberList) list).GetItem(3).Value);

        }



        [Test]

        public void TestFromStringCommaDelimited()

        {

            ((SvgNumberList) list).FromString("1,2, 3 ,4 , 5");

            Assert.AreEqual(1, ((SvgNumberList) list).GetItem(0).Value);

            Assert.AreEqual(2, ((SvgNumberList) list).GetItem(1).Value);

            Assert.AreEqual(3, ((SvgNumberList) list).GetItem(2).Value);

            Assert.AreEqual(4, ((SvgNumberList) list).GetItem(3).Value);

            Assert.AreEqual(5, ((SvgNumberList) list).GetItem(4).Value);

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas()

        {

            ((SvgNumberList) list).FromString("1,,2");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas2()

        {

            ((SvgNumberList) list).FromString("1, ,2");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas3()

        {

            ((SvgNumberList) list).FromString("1 , ,2");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas4()

        {

            ((SvgNumberList) list).FromString("1 , , 2");

        }



        [Test]

        public void TestFromStringMixed()

        {

            ((SvgNumberList) list).FromString("1 2  3,4 ,5 , 6");

            Assert.AreEqual(1, ((SvgNumberList) list).GetItem(0).Value);

            Assert.AreEqual(2, ((SvgNumberList) list).GetItem(1).Value);

            Assert.AreEqual(3, ((SvgNumberList) list).GetItem(2).Value);

            Assert.AreEqual(4, ((SvgNumberList) list).GetItem(3).Value);

            Assert.AreEqual(5, ((SvgNumberList) list).GetItem(4).Value);

            Assert.AreEqual(6, ((SvgNumberList) list).GetItem(5).Value);

        }

        #endregion



        #region Support Methods

        protected override SvgList makeList()

        {

            return new SvgNumberList();

        }



        protected new SvgNumber makeItem()

        {

            return new SvgNumber(counter++);

        }

        #endregion

	}

}

