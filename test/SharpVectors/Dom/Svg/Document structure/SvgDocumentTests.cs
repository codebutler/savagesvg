using System;
using System.IO;
using System.Xml;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg.DocumentStructure
{
	[TestFixture]
	public class SvgDocumentTests
	{
        #region Fields
        private ISvgDocument document;
        private string baseDir = @"Dom.Svg\";
        private SvgWindow window = new SvgWindow(75,75, null);
        #endregion

        #region Title tests
        [Test]
        public void TestEmptyTitle()
        {
            Load("title_empty.svg");
            Assert.AreEqual("", document.Title);
        }

        [Test]
        public void TestTitle()
        {
            Load("title.svg");
            Assert.AreEqual("This is a test title", document.Title);
        }

        [Test]
        public void TestMultipleTitles()
        {
            Load("title_multiple.svg");
            Assert.AreEqual("This is the title", document.Title);
        }

        [Test]
        public void TestNestedTitle()
        {
            Load("title_nested.svg");
            Assert.AreEqual("", document.Title);
        }

        [Test]
        public void TestMultilineTitle()
        {
            Load("title_multiline.svg");
            Assert.AreEqual("This is a title using multiple lines", document.Title);
        }
        #endregion

		#region Referrer and Domain
		[Test]
		public void TestReferrer()
		{
			Load("title_empty.svg");
			Assert.AreEqual("", document.Referrer);
		}

		[Test]
		public void TestUnknownDomain()
		{
			Load("title_empty.svg");
			Assert.IsNull(document.Domain);
		}

		[Test]
		public void TestKnownDomain()
		{
			SvgWindow wnd = new SvgWindow(75, 75, null);
			SvgDocument doc = new SvgDocument(wnd);
			doc.Load("http://www.shiny-donkey.com/shinyDonkey.svg");
			Assert.AreEqual("www.shiny-donkey.com", doc.Domain);
		}
		#endregion

		[Test]
		public void TestRootElement()
		{
			Load("title_empty.svg");
			
			Assert.AreSame(((XmlDocument)document).DocumentElement, document.RootElement);
		}

		[Test]
		public void TestWindow()
		{
			Load("title_empty.svg");
			
			Assert.AreSame(window, document.Window);
		}

        #region Support Methods
        private void Load(string svgFile)
        {
            string fullPath = new FileInfo(baseDir+svgFile).FullName;
            window.Src = fullPath;
            document = window.Document;
        }
        #endregion
	}
}