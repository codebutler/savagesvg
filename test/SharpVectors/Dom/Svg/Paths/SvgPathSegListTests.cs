using System;
using System.Drawing;
using System.Xml;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;
using SharpVectors.Dom;

namespace SharpVectors.UnitTests.Svg.Paths
{
	[TestFixture]
	public class SvgPathSegListTests
	{
		#region Parse tests
		[Test]
		public void ParseTest1()
		{
			SvgPathSegList list = new SvgPathSegList("M10, 30L70-20,23 -12L23 34z", false);
			Assert.AreEqual(5, list.NumberOfItems);
			Assert.AreEqual("M", list[0].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(10,30), ((SvgPathSegMovetoAbs)list[0]).AbsXY);
			Assert.AreEqual("L", list[1].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(70,-20), ((SvgPathSegLinetoAbs)list[1]).AbsXY);
			Assert.AreEqual("L", list[2].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(23,-12), ((SvgPathSegLinetoAbs)list[2]).AbsXY);
			Assert.AreEqual("L", list[3].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(23,34), ((SvgPathSegLinetoAbs)list[3]).AbsXY);
			Assert.AreEqual("z", list[4].PathSegTypeAsLetter);
		}

		/// <summary>
		/// Tests that multiple M commands turns into one M and the rest as L
		/// </summary>
		[Test]
		public void TestMultipleMovetosAbs()
		{
			SvgPathSegList list = new SvgPathSegList("M10, 30 70-20,23 -12", false);
			Assert.AreEqual(3, list.NumberOfItems);
			Assert.AreEqual("M", list[0].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(10,30), ((SvgPathSegMovetoAbs)list[0]).AbsXY);
			Assert.AreEqual("L", list[1].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(70,-20), ((SvgPathSegLinetoAbs)list[1]).AbsXY);
			Assert.AreEqual("L", list[2].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(23,-12), ((SvgPathSegLinetoAbs)list[2]).AbsXY);
		}
        
		[Test]
		public void TestMultipleMovetosRel()
		{
			SvgPathSegList list = new SvgPathSegList("m10,30 20,20", false);
			Assert.AreEqual(2, list.NumberOfItems);
			Assert.AreEqual("m", list[0].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(10,30), ((SvgPathSegMovetoRel)list[0]).AbsXY);
			Assert.AreEqual("l", list[1].PathSegTypeAsLetter);
			Assert.AreEqual(new PointF(30,50), ((SvgPathSegLinetoRel)list[1]).AbsXY);
		}
		#endregion

		#region Tests for start and end angles and angle bisectors
		[Test]
		public void TestStartEndAngle1()
		{
			SvgPathSegList list = new SvgPathSegList("M10,10L100,10,100,100,10,100z", false);

			Assert.AreEqual(270, ((SvgPathSeg)list[1]).StartAngle);
			Assert.AreEqual(90, ((SvgPathSeg)list[1]).EndAngle);

			Assert.AreEqual(180, ((SvgPathSeg)list[4]).StartAngle);
			Assert.AreEqual(0, ((SvgPathSeg)list[4]).EndAngle);
		}

		private bool floatsTest(string label, float f1, float f2)
		{
			bool ret = Math.Abs(f1-f2)<1;
			if(!ret)
			{
				// this will allways fail giving a nice output message
				Assert.AreEqual(f1, f2, label);
			}
			return ret;
		}

		private void diffAndBisectTest(SvgPathSegList list, int startSeg, float expectedDiff, float expectedBisect)
		{
			float diff = SvgNumber.CalcAngleDiff(((SvgPathSeg)list[startSeg]).EndAngle, ((SvgPathSeg)list[startSeg+1]).StartAngle);
			float bisect = SvgNumber.CalcAngleBisection(((SvgPathSeg)list[startSeg]).EndAngle, ((SvgPathSeg)list[startSeg+1]).StartAngle);

			string label = startSeg + "-" + (startSeg+1);
			
			floatsTest(label + " diff", expectedDiff, diff);
			floatsTest(label + " bisect", expectedBisect, bisect);
		}

		[Test]
		public void TestStartEndAngle2()
		{
			SvgPathSegList list = new SvgPathSegList("M5,5 L15,5 25,25 Q30,40 40,30 L50 20 a25,25 -30 0,1 0,50 l-40 20 z", false);

			floatsTest("1 startAngle", 270, ((SvgPathSeg)list[1]).StartAngle);
			floatsTest("1 endAngle", 90, ((SvgPathSeg)list[1]).EndAngle);

			diffAndBisectTest(list, 1, 117, 31.5f);

			floatsTest("2 startAngle", 333, ((SvgPathSeg)list[2]).StartAngle);
			floatsTest("2 endAngle", 153, ((SvgPathSeg)list[2]).EndAngle);

			diffAndBisectTest(list, 2, 172, 67.5f);

			floatsTest("3 startAngle", 342, ((SvgPathSeg)list[3]).StartAngle);
			floatsTest("3 endAngle", 45, ((SvgPathSeg)list[3]).EndAngle);

			diffAndBisectTest(list, 3, 180, 315f);

			floatsTest("4 startAngle", 225, ((SvgPathSeg)list[4]).StartAngle);
			floatsTest("4 endAngle", 45, ((SvgPathSeg)list[4]).EndAngle);

			diffAndBisectTest(list, 4, 135, 337.5f);

			floatsTest("5 startAngle", 270, ((SvgPathSeg)list[5]).StartAngle);
			floatsTest("5 endAngle", 270, ((SvgPathSeg)list[5]).EndAngle);

			diffAndBisectTest(list, 5, 207, 166.5f);

			//rel Lineto 50,70	=> 10,90
			floatsTest("6 startAngle", 63, ((SvgPathSeg)list[6]).StartAngle);
			floatsTest("6 endAngle", 243, ((SvgPathSeg)list[6]).EndAngle);

			diffAndBisectTest(list, 6, 67, 210f);

			//close 10,90	=> 5,5
			floatsTest("7 startAngle", 177, ((SvgPathSeg)list[7]).StartAngle);
			floatsTest("7 endAngle", 357, ((SvgPathSeg)list[7]).EndAngle);
		}
		#endregion

		#region Helper methods
		private SvgPathSegList getEmptyList()
		{
			return new SvgPathSegList("", false);
		}

		private SvgPathSegList getNonEmptyList()
		{
			return new SvgPathSegList("M10, 20L10,10,l23,34", false);
		}

		private SvgPathElement getPathElement()
		{
			SvgWindow wnd = new SvgWindow(100, 100, null);
			SvgDocument doc = new SvgDocument(wnd);
			return (SvgPathElement)doc.CreateElement("", "path", SvgDocument.SvgNamespace);
		}

		private SvgPathSegLinetoAbs getLineto()
		{
			SvgPathElement path = getPathElement();
			return (SvgPathSegLinetoAbs)path.CreateSvgPathSegLinetoAbs(20, 30);
		}
		#endregion

		#region Tests for ISvgPathSegList members


		[Test]
		public void TestEmptyList()
		{
			SvgPathSegList list = getEmptyList();
			Assert.AreEqual(0, list.NumberOfItems);
		}


		[Test]
		public void TestAppend()
		{
			SvgPathSegList list = getEmptyList();
			list.AppendItem(getLineto());
			Assert.AreEqual(1, list.NumberOfItems);
			Assert.AreEqual(SvgPathSegType.LineToAbs, list[0].PathSegType);
		}

		[Test]
		public void TestRemove()
		{
			SvgPathSegList list = getNonEmptyList();
			list.RemoveItem(1);
			Assert.AreEqual(2, list.NumberOfItems);
			Assert.AreEqual(0, ((SvgPathSeg)list[0]).Index);
			Assert.AreEqual(1, ((SvgPathSeg)list[1]).Index);
			Assert.AreEqual(SvgPathSegType.LineToRel, list[1].PathSegType);
		}

		[Test]
		public void TestReplace()
		{
			SvgPathSegList list = getNonEmptyList();
			list.ReplaceItem(getLineto(), 0);
			Assert.AreEqual(3, list.NumberOfItems);
			Assert.AreEqual(SvgPathSegType.LineToAbs, list[0].PathSegType);
		}

		[Test]
		public void TestInsert()
		{
			SvgPathSegList list = getNonEmptyList();
			list.InsertItemBefore(getLineto(), 1);
			Assert.AreEqual(4, list.NumberOfItems);

			Assert.AreEqual(1, ((SvgPathSeg)list[1]).Index);
			Assert.AreEqual(2, ((SvgPathSeg)list[2]).Index);
			Assert.AreEqual(SvgPathSegType.MoveToAbs, list[0].PathSegType);
			Assert.AreEqual(SvgPathSegType.LineToAbs, list[1].PathSegType);
			Assert.AreEqual(SvgPathSegType.LineToAbs, list[2].PathSegType);
			Assert.AreEqual(SvgPathSegType.LineToRel, list[3].PathSegType);
		}

		[Test]
		public void TestInitialize()
		{
			SvgPathSegList list = getNonEmptyList();

			list.Initialize(getLineto());
			Assert.AreEqual(1, list.NumberOfItems);
			Assert.AreEqual(SvgPathSegType.LineToAbs, list[0].PathSegType);
			Assert.AreEqual(0, ((SvgPathSeg)list[0]).Index);
		}

		[Test]
		[ExpectedException(typeof(DomException))]
		public void TestReadOnlyAppend()
		{
			SvgPathSegList list = new SvgPathSegList("", true);
			list.AppendItem(getLineto());
		}

		[Test]
		[ExpectedException(typeof(DomException))]
		public void TestReadOnlyClear()
		{
			SvgPathSegList list = new SvgPathSegList("", true);
			list.Clear();
		}

		#endregion

		#region Tests for PathText
		[Test]
		public void TestPathText()
		{
			string d = "M1,2L3,4l5,6H7h8V9v0zC1,2,3,4,5,6c7,8,9,0,1,2S3,4,5,6s7,8,9,0Q1,2,3,4q5,6,7,8T9,0t1,2A3,4,5,1,0,8,9a0,1,2,0,1,5,6";
			SvgPathSegList list = new SvgPathSegList(d, false);
 
			Assert.AreEqual(d, list.PathText);
		}
		#endregion

	}
}

