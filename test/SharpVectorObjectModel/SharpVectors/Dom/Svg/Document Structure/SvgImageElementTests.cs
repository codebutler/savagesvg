using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Globalization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Drawing2D;
using SharpVectors.Net;
using NUnit.Framework;
using SharpVectors.Dom;
using SharpVectors.Dom.Svg;

		[TestFixture]
		public class Tests
		{
			[Test]
			public void TestDataImage()
			{
				string testData = "<?xml version='1.0'?>\n<svg xmlns='http://www.w3.org/2000/svg' xmlns:xlink='http://www.w3.org/1999/xlink'><image id='theImage' width='50' height='50' xlink:href='data:image/gif;base64,R0lGODdhMAAwAPAAAAAAAP///ywAAAAAMAAwAAAC8IyPqcvt3wCcDkiLc7C0qwyGHhSWpjQu5yqmCYsapyuvUUlvONmOZtfzgFzByTB10QgxOR0TqBQejhRNzOfkVJ+5YiUqrXF5Y5lKh/DeuNcP5yLWGsEbtLiOSpa/TPg7JpJHxyendzWTBfX0cxOnKPjgBzi4diinWGdkF8kjdfnycQZXZeYGejmJlZeGl9i2icVqaNVailT6F5iJ90m6mvuTS4OK05M0vDk0Q4XUtwvKOzrcd3iq9uisF81M1OIcR7lEewwcLp7tuNNkM3uNna3F2JQFo97Vriy/Xl4/f1cf5VWzXyym7PHhhx4dbgYKAAA7'/></svg>";
				SvgWindow wnd = new SvgWindow(50, 50, null);
				SvgDocument doc = new SvgDocument(wnd);
				doc.LoadXml(testData);

				SvgImageElement imgElm = doc.GetElementById("theImage") as SvgImageElement;
				Assert.IsNotNull(imgElm);
				Assert.IsTrue(!imgElm.IsSvgImage, "IsSvgImage");

				Bitmap bmp = imgElm.Bitmap;

				Assert.AreEqual(48, bmp.Width);
				Assert.AreEqual(48, bmp.Height);
			}
		}
