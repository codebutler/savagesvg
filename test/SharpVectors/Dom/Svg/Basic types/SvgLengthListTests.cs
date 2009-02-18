using System;

using NUnit.Framework;

using SharpVectors.Dom;

using SharpVectors.Dom.Svg;



namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces

{

	public class SvgLengthListTests : SvgListTests

	{

        #region Fields

        private static int counter = 0;

        #endregion



        #region Additional SvgLengthList-specific tests

        [Test]

        public void TestFromStringEmpty()

        {

            ((SvgLengthList) list).FromString("");

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]

        public void TestFromStringNull()

        {

            ((SvgLengthList) list).FromString(null);

            Assert.AreEqual(0, list.NumberOfItems);

        }



        [Test]


        public void TestFromStringLeadingWhitespace()

        {

            SvgLengthList svgLengthList = (SvgLengthList) list;



            svgLengthList.FromString(" 1px 2em 3in 4cm");

            Assert.AreEqual(1, svgLengthList.GetItem(0).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Px, svgLengthList.GetItem(0).UnitType);

            Assert.AreEqual(2, svgLengthList.GetItem(1).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Ems, svgLengthList.GetItem(1).UnitType);

            Assert.AreEqual(3, svgLengthList.GetItem(2).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.In, svgLengthList.GetItem(2).UnitType);

            Assert.AreEqual(4, svgLengthList.GetItem(3).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Cm, svgLengthList.GetItem(3).UnitType);

        }



        [Test]
        public void TestFromStringTrailingWhitespace()
        {

            SvgLengthList svgLengthList = (SvgLengthList) list;



            svgLengthList.FromString("1px 2em 3in 4cm ");

            Assert.AreEqual(1, svgLengthList.GetItem(0).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Px, svgLengthList.GetItem(0).UnitType);

            Assert.AreEqual(2, svgLengthList.GetItem(1).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Ems, svgLengthList.GetItem(1).UnitType);

            Assert.AreEqual(3, svgLengthList.GetItem(2).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.In, svgLengthList.GetItem(2).UnitType);

            Assert.AreEqual(4, svgLengthList.GetItem(3).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Cm, svgLengthList.GetItem(3).UnitType);

        }



        [Test]

        public void TestFromStringOneValue()

        {

            SvgLengthList svgLengthList = (SvgLengthList) list;



            svgLengthList.FromString("1mm");

            Assert.AreEqual(1, svgLengthList.GetItem(0).ValueInSpecifiedUnits);

        }



        [Test]

        public void TestFromStringSpaceDelimited()

        {

            SvgLengthList svgLengthList = (SvgLengthList) list;



            svgLengthList.FromString("1px 2em  3in    4cm");

            Assert.AreEqual(1, svgLengthList.GetItem(0).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Px, svgLengthList.GetItem(0).UnitType);

            Assert.AreEqual(2, svgLengthList.GetItem(1).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Ems, svgLengthList.GetItem(1).UnitType);

            Assert.AreEqual(3, svgLengthList.GetItem(2).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.In, svgLengthList.GetItem(2).UnitType);

            Assert.AreEqual(4, svgLengthList.GetItem(3).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Cm, svgLengthList.GetItem(3).UnitType);

        }



        [Test]
        public void TestFromStringCommaDelimited()

        {

            SvgLengthList svgLengthList = (SvgLengthList) list;



            svgLengthList.FromString("1px,2em, 3in ,4cm , 5ex");

            Assert.AreEqual(1, svgLengthList.GetItem(0).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Px, svgLengthList.GetItem(0).UnitType);

            Assert.AreEqual(2, svgLengthList.GetItem(1).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Ems, svgLengthList.GetItem(1).UnitType);

            Assert.AreEqual(3, svgLengthList.GetItem(2).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.In, svgLengthList.GetItem(2).UnitType);

            Assert.AreEqual(4, svgLengthList.GetItem(3).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Cm, svgLengthList.GetItem(3).UnitType);

            Assert.AreEqual(5, svgLengthList.GetItem(4).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Exs, svgLengthList.GetItem(4).UnitType);

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas()

        {

            ((SvgLengthList) list).FromString("1px,,2em");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas2()

        {

            ((SvgLengthList) list).FromString("1px, ,2em");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas3()

        {

            ((SvgLengthList) list).FromString("1px , ,2em");

        }



        [Test]

        [ExpectedException(typeof(DomException))]

        public void TestFromStringMultipleCommas4()

        {

            ((SvgLengthList) list).FromString("1px , , 2em");

        }



        [Test]

        public void TestFromStringMixed()

        {

            SvgLengthList svgLengthList = (SvgLengthList) list;



            svgLengthList.FromString("1px 2em  3in,4cm ,5ex , 6mm");

            Assert.AreEqual(1, svgLengthList.GetItem(0).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Px, svgLengthList.GetItem(0).UnitType);

            Assert.AreEqual(2, svgLengthList.GetItem(1).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Ems, svgLengthList.GetItem(1).UnitType);

            Assert.AreEqual(3, svgLengthList.GetItem(2).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.In, svgLengthList.GetItem(2).UnitType);

            Assert.AreEqual(4, svgLengthList.GetItem(3).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Cm, svgLengthList.GetItem(3).UnitType);

            Assert.AreEqual(5, svgLengthList.GetItem(4).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Exs, svgLengthList.GetItem(4).UnitType);

            Assert.AreEqual(6, svgLengthList.GetItem(5).ValueInSpecifiedUnits);

            Assert.AreEqual(SvgLengthType.Mm, svgLengthList.GetItem(5).UnitType);

        }

        #endregion



        #region Support Methods

        protected override SvgList makeList()

        {

            return new SvgLengthList();

        }



        protected new string makeItem()

        {

            return "string" + (counter++).ToString() + "px";

        }

        #endregion

	}

}

