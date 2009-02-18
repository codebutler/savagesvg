using System;

using NUnit.Framework;

using SharpVectors.Dom;

using SharpVectors.Dom.Svg;



namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces

{

	public class SvgStringListTests : SvgListTests

	{

        #region Fields

        private static int counter = 0;

        #endregion



        #region Additional SvgStringList-specific tests

        [Test]

        public void TestFromStringEmpty()

        {

            ((SvgStringList) list).FromString("");

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        public void TestFromStringNull()

        {

            ((SvgStringList) list).FromString(null);

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        public void TestFromStringLeadingWhitespace()

        {

            ((SvgStringList) list).FromString(" one two three four");

            Assert.AreEqual("one", list.GetItem(0));

            Assert.AreEqual("two", list.GetItem(1));

            Assert.AreEqual("three", list.GetItem(2));

            Assert.AreEqual("four", list.GetItem(3));

        }



        [Test]

        public void TestFromStringTrailingWhitespace()

        {

            ((SvgStringList) list).FromString("one two three four ");

            Assert.AreEqual("one", list.GetItem(0));

            Assert.AreEqual("two", list.GetItem(1));

            Assert.AreEqual("three", list.GetItem(2));

            Assert.AreEqual("four", list.GetItem(3));

        }



        [Test]

        public void TestFromStringOneValue()

        {

            ((SvgStringList) list).FromString("one");

            Assert.AreEqual("one", list.GetItem(0));

        }



        [Test]

        public void TestFromStringSpaceDelimited()

        {

            ((SvgStringList) list).FromString("one two  three    four");

            Assert.AreEqual("one", list.GetItem(0));

            Assert.AreEqual("two", list.GetItem(1));

            Assert.AreEqual("three", list.GetItem(2));

            Assert.AreEqual("four", list.GetItem(3));

        }



        [Test]

        public void TestFromStringCommaDelimited()

        {

            ((SvgStringList) list).FromString("one,two, three ,four , five");

            Assert.AreEqual("one", list.GetItem(0));

            Assert.AreEqual("two", list.GetItem(1));

            Assert.AreEqual("three", list.GetItem(2));

            Assert.AreEqual("four", list.GetItem(3));

            Assert.AreEqual("five", list.GetItem(4));

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas()

        {

            ((SvgStringList) list).FromString("one,,two");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas2()

        {

            ((SvgStringList) list).FromString("one, ,two");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas3()

        {

            ((SvgStringList) list).FromString("one , ,two");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas4()

        {

            ((SvgStringList) list).FromString("one , , two");

        }



        [Test]

        public void TestFromStringMixed()

        {

            ((SvgStringList) list).FromString("one two  three,four ,five , six");

            Assert.AreEqual("one", list.GetItem(0));

            Assert.AreEqual("two", list.GetItem(1));

            Assert.AreEqual("three", list.GetItem(2));

            Assert.AreEqual("four", list.GetItem(3));

            Assert.AreEqual("five", list.GetItem(4));

            Assert.AreEqual("six", list.GetItem(5));

        }

        #endregion



        #region Support Methods

        protected override SvgList makeList()

        {

            return new SvgStringList();

        }



        protected new string makeItem()

        {

            return "string" + (counter++).ToString();

        }

        #endregion

	}

}

