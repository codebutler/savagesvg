/*
using System;
using System.Net;
using System.IO;
using System.Text;
using NUnit.Framework;
using SharpVectors.Net;

namespace SharpVectors.UnitTests.Net
{
	[TestFixture]
	public class DataWebRequestTests
	{
		private DataWebResponse getResponse(string uri)
		{
			WebRequest request = WebRequest.Create(uri);
			return request.GetResponse() as DataWebResponse;
		}

		[SetUp]
		public void Setup()
		{
			DataWebRequest.Register();
		}

		[Test]
		public void TestSimpleText()
		{
			DataWebResponse response = getResponse("data:,A%20brief%20note");

			Assert.AreEqual("text/plain;charset=US-ASCII", response.ContentType);
			Assert.AreEqual(Encoding.ASCII, response.ContentEncoding);

			Stream stream = response.GetResponseStream();
			StreamReader sr = new StreamReader(stream, response.ContentEncoding);
			string content = sr.ReadToEnd();
			
			Assert.AreEqual("A brief note", content);
		}

		[Test]
		public void TestEncoding()
		{
			DataWebResponse response = getResponse("data:text/plain;charset=iso-8859-7,%be%fg%be");

			Assert.AreEqual("text/plain;charset=iso-8859-7", response.ContentType);
			Assert.AreEqual(Encoding.GetEncoding("iso-8859-7"), response.ContentEncoding);
			
			Stream stream = response.GetResponseStream();
			StreamReader sr = new StreamReader(stream, response.ContentEncoding);
			string content = sr.ReadToEnd();

			// TODO: Not sure how to test this
			// Assert.AreEqual("", content);
		}

		[Test]
		public void TestBase64()
		{
			DataWebResponse response = getResponse("data:image/gif;base64,R0lGODdhMAAwAPAAAAAAAP///ywAAAAAMAAwAAAC8IyPqcvt3wCcDkiLc7C0qwyGHhSWpjQu5yqmCYsapyuvUUlvONmOZtfzgFz\n\tByTB10QgxOR0TqBQejhRNzOfkVJ+5YiUqrXF5Y5lKh/DeuNcP5yLWGsEbtLiOSp\n\ta/TPg7JpJHxyendzWTBfX0cxOnKPjgBzi4diinWGdkF8kjdfnycQZXZeYGejmJl\n\tZeGl9i2icVqaNVailT6F5iJ90m6mvuTS4OK05M0vDk0Q4XUtwvKOzrcd3iq9uis\n\tF81M1OIcR7lEewwcLp7tuNNkM3uNna3F2JQFo97Vriy/Xl4/f1cf5VWzXyym7PH\n\thhx4dbgYKAAA7");

			Assert.AreEqual("image/gif", response.ContentType);
			
			Stream stream = response.GetResponseStream();

			Assert.AreEqual(273, stream.Length);
		}
	}
}
*/
