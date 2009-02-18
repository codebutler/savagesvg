using System;
using System.Drawing;
using System.Collections;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class CssPrimitiveRgbValueTests : CssValueTests
		{
			CssPrimitiveValue color;
			protected override string aCssText
			{
				get{return "rgb(56,25,173)";}
			}
 
			protected override string anotherCssText		
			{
				get{return "rgb(11,22,33)";}
			}

			protected override CssValueType cssValueType
			{
				get{return CssValueType.PrimitiveValue;}
			}


			protected override CssValue _getCssValue(string cssText, bool readOnly)
			{
				return new CssPrimitiveRgbValue(aCssText, readOnly);
			}

			protected override Type Type
			{
				get{return typeof(CssPrimitiveRgbValue);}
			}

			public void TestAbsoluteRgb()
			{
				color = new CssPrimitiveRgbValue("rgb( 100  ,	123,15)", false);
				RgbColor rgbColor = (RgbColor)color.GetRgbColorValue();
				Assert.AreEqual(100, rgbColor.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(123, rgbColor.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(15, rgbColor.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestPercentageRgb()
			{
				color = new CssPrimitiveRgbValue("rgb(50%,	12%, 100%)", false);
				RgbColor rgbColor = (RgbColor)color.GetRgbColorValue();
				Assert.AreEqual(255*0.5, rgbColor.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(255*0.12, rgbColor.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(255, rgbColor.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestHex()
			{
				color = new CssPrimitiveRgbValue("#12C2a4  ", false);
				RgbColor rgbColor = (RgbColor)color.GetRgbColorValue();
				Assert.AreEqual(18, rgbColor.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(194, rgbColor.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(164, rgbColor.Blue.GetFloatValue(CssPrimitiveType.Number));
			}

			public void TestShortHex()
			{
				color = new CssPrimitiveRgbValue("  #C8f", false);
				RgbColor rgbColor = (RgbColor)color.GetRgbColorValue();
				Assert.AreEqual(204, rgbColor.Red.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(136, rgbColor.Green.GetFloatValue(CssPrimitiveType.Number));
				Assert.AreEqual(255, rgbColor.Blue.GetFloatValue(CssPrimitiveType.Number));
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

					color = new CssPrimitiveRgbValue(name, false);
					CssPrimitiveRgbValue color2 = new CssPrimitiveRgbValue(hexColor, false);

					RgbColor rgbColor = (RgbColor)color.GetRgbColorValue();
					RgbColor rgbColor2 = (RgbColor)color2.GetRgbColorValue();

					Assert.AreEqual(rgbColor2.Red.GetFloatValue(CssPrimitiveType.Number), rgbColor.Red.GetFloatValue(CssPrimitiveType.Number), name + " red");
					Assert.AreEqual(rgbColor2.Green.GetFloatValue(CssPrimitiveType.Number), rgbColor.Green.GetFloatValue(CssPrimitiveType.Number), name + " green");
					Assert.AreEqual(rgbColor2.Blue.GetFloatValue(CssPrimitiveType.Number), rgbColor.Blue.GetFloatValue(CssPrimitiveType.Number), name + " blue");
				}
			}

	
			public void TestCssUnknownNames()
			{
				CssValue cssValue = CssValue.GetCssValue("somedummyname", false);
				Assert.IsTrue(!(cssValue is CssPrimitiveRgbValue));
			}

		}
