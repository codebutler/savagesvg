using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

namespace SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces
{
	[TestFixture]
	public class SvgLengthTests
	{
		SvgLength length;
		SvgDocument doc;
		SvgElement elm;

		bool initDone = false;

		
		private SvgDocument LoadXml(string content)
		{
			SvgWindow wnd = new SvgWindow(200, 300, null);
			SvgDocument doc = new SvgDocument(wnd);
			string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"no\"?>\n<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.0//EN\" \"http://www.w3.org/TR/2001/REC-SVG-20010904/DTD/svg10.dtd\">\n<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100%\" height=\"100%\">";
			xml += content;
			xml += "</svg>";

			doc.LoadXml(xml);
			return doc;
		}

		[SetUp]
		public void InitTest()
		{
			if(!initDone)
			{
				doc = LoadXml("<rect height='1' width='1' />");
				elm = (SvgElement)doc.SelectSingleNode("//*[local-name()='rect']");
				initDone = true;
			}
		}

		[Test]
		public void TestSettingValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10px");
			Assert.AreEqual(10, length.Value);
			Assert.AreEqual(SvgLengthType.Px, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10px", length.ValueAsString);

			length.ValueAsString = "10cm";
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			length.Value = 200;
			double valueInCm = 200 / 96D * 2.54D;
			Assert.AreEqual(200, length.Value);
			Assert.AreEqual(valueInCm, length.ValueInSpecifiedUnits);
			Assert.AreEqual(valueInCm.ToString(SvgNumber.Format)+"cm", length.ValueAsString);

			// change px value
			length.ValueAsString = "2px";
			Assert.AreEqual(2, length.Value);
			Assert.AreEqual(2, length.ValueInSpecifiedUnits);
			Assert.AreEqual("2px", length.ValueAsString);

			// set to a CM value
			length.NewValueSpecifiedUnits(SvgLengthType.Cm, 23);
			Assert.AreEqual(23, length.ValueInSpecifiedUnits);
			Assert.AreEqual(23 / 2.54D * 96, length.Value);
			Assert.AreEqual("23cm", length.ValueAsString);
			Assert.AreEqual(SvgLengthType.Cm, length.UnitType);

			length.ConvertToSpecifiedUnits(SvgLengthType.Mm);
			Assert.AreEqual(230, length.ValueInSpecifiedUnits);
			Assert.AreEqual("230mm", length.ValueAsString);
			Assert.AreEqual(SvgLengthType.Mm, length.UnitType);
		}

		[Test]
		public void TestPxValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10px");
			Assert.AreEqual(10, length.Value);
			Assert.AreEqual(SvgLengthType.Px, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10px", length.ValueAsString);
		}

		[Test]
		public void TestCmValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10cm");
			Assert.AreEqual(10 / 2.54 * 96, length.Value);
			Assert.AreEqual(SvgLengthType.Cm, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10cm", length.ValueAsString);
		}

		[Test]
		public void TestMmValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10mm");
			Assert.AreEqual(10 / 25.4 * 96, length.Value);
			Assert.AreEqual(SvgLengthType.Mm, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10mm", length.ValueAsString);
		}

		[Test]
		public void TestInValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10in");
			Assert.AreEqual(10 * 96, length.Value);
			Assert.AreEqual(SvgLengthType.In, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10in", length.ValueAsString);
		}

		[Test]
		public void TestPtValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10pt");
			Assert.AreEqual(10 / 72D * 96, length.Value);
			Assert.AreEqual(SvgLengthType.Pt, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10pt", length.ValueAsString);
		}

		[Test]
		public void TestPcValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10pc");
			Assert.AreEqual(10 / 6D * 96, length.Value);
			Assert.AreEqual(SvgLengthType.Pc, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10pc", length.ValueAsString);
		}

		[Test]
		public void TestEmValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10em");
			Assert.AreEqual(SvgLengthType.Ems, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10em", length.ValueAsString);
		}

		[Test]
		[Ignore("em to absolute values not implemented")]
		public void TestEmToAbsValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10em");
			Assert.AreEqual(100, length.Value);
		}

		[Test]
		public void TestExValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10ex");
			Assert.AreEqual(SvgLengthType.Exs, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10ex", length.ValueAsString);
		}

		[Test]
		[Ignore("ex to absolute values not implemented")]
		public void TestExToAbsValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10ex");
			Assert.AreEqual(60, length.Value);
		}

		[Test]
		public void TestPercentValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "10%");
			Assert.AreEqual(20, length.Value);
			Assert.AreEqual(SvgLengthType.Percentage, length.UnitType);
			Assert.AreEqual(10, length.ValueInSpecifiedUnits);
			Assert.AreEqual("10%", length.ValueAsString);

			length = new SvgLength(elm, "test", SvgLengthDirection.Vertical, "20%");
			Assert.AreEqual(60, length.Value);

			length = new SvgLength(elm, "test", SvgLengthDirection.Viewport, "10%");
			Assert.AreEqual(Math.Sqrt(200*200+300*300)/Math.Sqrt(2) * 0.1D, length.Value);
		}

		[Test]
		public void TestScientificValues()
		{
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "2E3px");
			Assert.AreEqual(2000, length.Value);
			Assert.AreEqual(SvgLengthType.Px, length.UnitType);
			Assert.AreEqual(2000, length.ValueInSpecifiedUnits);
			Assert.AreEqual("2000px", length.ValueAsString);

			
			length = new SvgLength(elm, "test", SvgLengthDirection.Horizontal, "1E-1px");
			Assert.IsTrue(Math.Abs(0.1D-length.Value)<0.0001, "Value");
			Assert.AreEqual(SvgLengthType.Px, length.UnitType);
			Assert.IsTrue(Math.Abs(0.1D-length.ValueInSpecifiedUnits)<0.0001, "ValueInSpecifiedUnits");
			//Assert.AreEqual("0.1px", length.ValueAsString);
		}

	}
}
