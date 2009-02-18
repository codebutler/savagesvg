
    //		#region Unit tests
    //		#if TEST
    //		[TestFixture]
    //		public class SvgElementTests : SharpVectors.Dom.Css.CssXmlElement.CssXmlElementTests
    //		{
    //			protected override Type elmType
    //			{
    //				get{return typeof(SvgElement);}
    //			}
    //
    //			protected virtual string localName
    //			{
    //				get{return "foo";}
    //			}
    //
    //			[Test]
    //			public override void TestTypeFromDocument()
    //			{
    //				XmlElement elm = TestUtil.GetXmlElement("<" + localName + " xmlns='http://www.w3.org/2000/svg' />", "", localName);
    //				Assert.AreEqual(elmType, elm.GetType());
    //			}
    //
    //			[Test]
    //			public override void TestTypeFromCreateElement()
    //			{
    //				SvgWindow wnd = new SvgWindow(100, 100, null);
    //				SvgDocument doc = new SvgDocument(wnd);
    //				XmlElement elm = doc.CreateElement("", localName, "http://www.w3.org/2000/svg");
    //
    //				Assert.AreEqual(elmType, elm.GetType());
    //			}
    //
    //		}
    //		#endif
    //		#endregion
  }
}
