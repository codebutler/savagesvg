using System;
using NUnit.Framework;
using SharpVectors.Dom.Stylesheets;

namespace SharpVectors.UnitTests.Stylesheets
{
	[TestFixture]
	public class MediaListTests
	{
		[Test]
		public void TestEmptyConstructor()
		{
			MediaList list = new MediaList();
			Assert.AreEqual(0, list.Length);
			Assert.AreEqual("", list.MediaText);
		}

		[Test]
		public void TestStringConstructor()
		{
			MediaList list = new MediaList("all, screen");
			Assert.AreEqual(2, list.Length);
			Assert.AreEqual("all,screen", list.MediaText);
			Assert.AreEqual("all", list[0]);
			Assert.AreEqual("screen", list[1]);
		}

		[Test]
		public void TestToBigIndex()
		{
			MediaList list = new MediaList("all, screen");
			Assert.IsNull(list[2]);
		}

		[Test]
		public void TestAppendMedium()
		{
			MediaList list = new MediaList();
			list.AppendMedium("screen");
			Assert.AreEqual(1, list.Length);
			Assert.AreEqual("screen", list.MediaText);
			Assert.AreEqual("screen", list[0]);

			list.AppendMedium("all");
			Assert.AreEqual(2, list.Length);
			Assert.AreEqual("screen,all", list.MediaText);
			Assert.AreEqual("screen", list[0]);
			Assert.AreEqual("all", list[1]);

			list.AppendMedium("screen");
			Assert.AreEqual(2, list.Length);
			Assert.AreEqual("all,screen", list.MediaText);
			Assert.AreEqual("all", list[0]);
			Assert.AreEqual("screen", list[1]);
		}

		[Test]
		public void TestDeleteMedium()
		{
			MediaList list = new MediaList("screen,		all");
			list.DeleteMedium("screen");
			Assert.AreEqual(1, list.Length);
			Assert.AreEqual("all", list.MediaText);
			Assert.AreEqual("all", list[0]);
		}

		[Test]
		public void TestIncorrectButParsable1()
		{
			MediaList list = new MediaList("screen,,all");
			Assert.AreEqual(2, list.Length);
			Assert.AreEqual("screen,all", list.MediaText);
		}

		[Test]
		public void TestMatchesSame()
		{
			MediaList ssList = new MediaList("screen");
			MediaList rendList = new MediaList("screen");
			
            Assert.IsTrue(ssList.Matches(rendList));
		}

		[Test]
		public void TestMatchesAll()
		{
			MediaList ssList = new MediaList("all");
			MediaList rendList = new MediaList("screen");
			
			Assert.IsTrue(ssList.Matches(rendList));
		}

		[Test]
		public void TestMatchesEmpty()
		{
			MediaList ssList = new MediaList(String.Empty);
			MediaList rendList = new MediaList("screen");
			
			Assert.IsTrue(ssList.Matches(rendList));
		}

		[Test]
		public void TestMatchesNoMatch()
		{
			MediaList ssList = new MediaList("dummy");
			MediaList rendList = new MediaList("screen");
			
			Assert.IsTrue(!ssList.Matches(rendList));
		}

		[Test]
		public void TestMatchesMultiple1()
		{
			MediaList ssList = new MediaList("foo, screen");
			MediaList rendList = new MediaList("screen");
			
			Assert.IsTrue(ssList.Matches(rendList));
		}


	}
}
