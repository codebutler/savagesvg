using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Net
{
	[TestFixture]
	public class ExtendedHttpWebRequestTests
	{
		[Test]
		public void TestRemoteGZip()
		{
            SvgWindow wnd = new SvgWindow(100, 100, null);
			SvgDocument doc = new SvgDocument(wnd);
			doc.Load("http://www.sharpvectors.org/tests/gzip-test.svgz");
		}

		[Test]
		[Ignore("Local svgz not supported")]
		public void TestLocalGZip()
		{
			
			SvgWindow wnd = new SvgWindow(100, 100, null);
			SvgDocument doc = new SvgDocument(wnd);
			doc.Load("gzip-test.svgz");
		}
	}
}
