using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Diagnostics;
using NUnit.Framework;
using System.Collections;
using SharpVectors.Dom.Css;

   	[TestFixture]
		public class RgbColorTests
		{
			RgbColor color;
      [Test]
			public void TestAbsoluteRgb()
			{
				color = new RgbColor("rgb( 100  ,	123,15)");
				Assert.AreEqual(100, color.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(123, color.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(15, color.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestPercentageRgb()
			{
				color = new RgbColor("rgb(50%,	12%, 100%)");
				Assert.AreEqual(255*0.5, color.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(255*0.12, color.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(255, color.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestHex()
			{
				color = new RgbColor("#12C2a4  ");
				Assert.AreEqual(18, color.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(194, color.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(164, color.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestShortHex()
			{
				color = new RgbColor("  #C8f");
				Assert.AreEqual(204, color.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(136, color.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(255, color.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestCssNames()
			{
				Hashtable table = new Hashtable();
				table.Add("maroon", "#800000");
				table.Add("red", "#ff0000");
				table.Add("orange", "#ffA500");
				table.Add("yellow", "#ffff00");
				table.Add("olive", "#808000");
				table.Add("purple", "#800080");
				table.Add("fuchsia", "#ff00ff");
				table.Add("white", "#ffffff");
				table.Add("lime", "#00ff00");
				table.Add("green", "#008000");
				table.Add("navy", "#000080");
				table.Add("blue", "#0000ff");
				table.Add("aqua", "#00ffff");
				table.Add("teal", "#008080");
				table.Add("black", "#000000");
				table.Add("silver", "#c0c0c0");
				table.Add("gray", "#808080");

				IEnumerator colorEnum = table.Keys.GetEnumerator();
				while(colorEnum.MoveNext())
				{
					string name = (string)colorEnum.Current;
					string hexColor = (string)table[name];

					color = new RgbColor(name);
					RgbColor color2 = new RgbColor(hexColor);

					Assert.AreEqual(color2.Red.GetFloatValue(CssPrimitiveType.Number), color.Red.GetFloatValue(CssPrimitiveType.Number), name + " red");
					Assert.AreEqual(color2.Green.GetFloatValue(CssPrimitiveType.Number), color.Green.GetFloatValue(CssPrimitiveType.Number), name + " green");
					Assert.AreEqual(color2.Blue.GetFloatValue(CssPrimitiveType.Number), color.Blue.GetFloatValue(CssPrimitiveType.Number), name + " blue");
				}
			}
		}
