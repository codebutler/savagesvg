using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg
{
	[TestFixture]
	public class CssPropertyProfileTests
	{
		[Test]
		public void TestLength()
		{
			SvgWindow wnd = new SvgWindow(100, 100, null);
			SvgDocument doc = new SvgDocument(wnd);
			Assert.AreEqual(61, doc.CssPropertyProfile.Length);
		}
	}
}
