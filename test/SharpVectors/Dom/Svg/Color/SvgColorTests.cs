using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;
using System.Collections;

namespace SharpVectors.UnitTests.Svg.Color
{
	[TestFixture]
	public class SvgColorTests : CssValueTests
	{
		#region Helper stuff for CssValueTests
		protected override string aCssText
		{
			get{return "rgb(67,45,98)";}
		}

		protected override string anotherCssText		
		{
			get{return "rgb(255,234,1)";}
		}

		protected override CssValueType cssValueType
		{
			get{return CssValueType.PrimitiveValue;}
		}


		protected override CssValue _getCssValue(string cssText, bool readOnly)
		{
			return new SvgColor(cssText);
		}


		protected override Type Type
		{
			get{return typeof(SvgColor);}
		}
		#endregion 

		protected virtual SvgColor _createColor(string str)
		{
			return new SvgColor(str);
		}

		[Test]
		public void TestSetColor()
		{
			SvgColor color = _createColor("rgb(12,234 , 121)");
			color.SetColor(SvgColorType.RgbColor, "#ff00ff", "");
			Assert.AreEqual("rgb(255,0,255)", color.CssText);

			color.SetColor(SvgColorType.CurrentColor, null, null);
			Assert.AreEqual("currentColor", color.CssText);
		}

		[Test]
		public void TestSetRgbColor()
		{
			SvgColor color = _createColor("rgb(12,234 , 121)");
			color.SetRgbColor("#ff0000");
			Assert.AreEqual("rgb(255,0,0)", color.CssText);
		}

		[Test]
		[Ignore("ICC colors not supported")]
		public void TestIccColor()
		{
		}

		[Test]
		public void TestReadOnly()
		{
			// should allways be false
			SvgColor color = _createColor("rgb(12,234 , 121)");
			Assert.AreEqual(false, color.ReadOnly);
		}

		[Test]
		[Ignore("ICC colors not supported")]
		public void TestSetRgbIccColor()
		{
			SvgColor color = _createColor("rgb(12,234 , 121)");
			color.SetRgbColorIccColor("#ff0000", "somename");
			Assert.AreEqual("rgb(255,0,0) icc-color(somename)", color.CssText);
		}


		[Test]
		public void TestColorType()
		{
			SvgColor color = _createColor("rgb(12,234 , 121)");
			Assert.AreEqual(SvgColorType.RgbColor, color.ColorType);

			color = _createColor("currentColor");
			Assert.AreEqual(SvgColorType.CurrentColor, color.ColorType);

			color.SetColor(SvgColorType.RgbColor, "rgb(80%, 50%, 12)", null);
			Assert.AreEqual(SvgColorType.RgbColor, color.ColorType);

			color.SetColor(SvgColorType.RgbColorIccColor, "rgb(80%, 50%, 12)", "icc-color(somename)");
			Assert.AreEqual(SvgColorType.RgbColorIccColor, color.ColorType);
		}

		public override void TestCssReadOnly()
		{
		}

		public override void TestCssTextReadOnly()
		{
		}

		[Test]
		public void TestNamedColors()
		{
			Hashtable table = new Hashtable();
			table.Add("aliceblue", "rgb(240, 248, 255)");
			table.Add("antiquewhite", "rgb(250, 235, 215)");
			table.Add("aqua", "rgb( 0, 255, 255)");
			table.Add("aquamarine", "rgb(127, 255, 212)");
			table.Add("azure", "rgb(240, 255, 255)");
			table.Add("beige", "rgb(245, 245, 220)");
			table.Add("bisque", "rgb(255, 228, 196)");
			table.Add("black", "rgb( 0, 0, 0)");
			table.Add("blanchedalmond", "rgb(255, 235, 205)");
			table.Add("blue", "rgb( 0, 0, 255)");
			table.Add("blueviolet", "rgb(138, 43, 226)");
			table.Add("brown", "rgb(165, 42, 42)");
			table.Add("burlywood", "rgb(222, 184, 135)");
			table.Add("cadetblue", "rgb( 95, 158, 160)");
			table.Add("chartreuse", "rgb(127, 255, 0)");
			table.Add("chocolate", "rgb(210, 105, 30)");
			table.Add("coral", "rgb(255, 127, 80)");
			table.Add("cornflowerblue", "rgb(100, 149, 237)");
			table.Add("cornsilk", "rgb(255, 248, 220)");
			table.Add("crimson", "rgb(220, 20, 60)");
			table.Add("cyan", "rgb( 0, 255, 255)");
			table.Add("darkblue", "rgb( 0, 0, 139)");
			table.Add("darkcyan", "rgb( 0, 139, 139)");
			table.Add("darkgoldenrod", "rgb(184, 134, 11)");
			table.Add("darkgray", "rgb(169, 169, 169)");
			table.Add("darkgreen", "rgb( 0, 100, 0)");
			table.Add("darkgrey", "rgb(169, 169, 169)");
			table.Add("darkkhaki", "rgb(189, 183, 107)");
			table.Add("darkmagenta", "rgb(139, 0, 139)");
			table.Add("darkolivegreen", "rgb( 85, 107, 47)");
			table.Add("darkorange", "rgb(255, 140, 0)");
			table.Add("darkorchid", "rgb(153, 50, 204)");
			table.Add("darkred", "rgb(139, 0, 0)");
			table.Add("darksalmon", "rgb(233, 150, 122)");
			table.Add("darkseagreen", "rgb(143, 188, 143)");
			table.Add("darkslateblue", "rgb( 72, 61, 139)");
			table.Add("darkslategray", "rgb( 47, 79, 79)");
			table.Add("darkslategrey", "rgb( 47, 79, 79)");
			table.Add("darkturquoise", "rgb( 0, 206, 209)");
			table.Add("darkviolet", "rgb(148, 0, 211)");
			table.Add("deeppink", "rgb(255, 20, 147)");
			table.Add("deepskyblue", "rgb( 0, 191, 255)");
			table.Add("dimgray", "rgb(105, 105, 105)");
			table.Add("dimgrey", "rgb(105, 105, 105)");
			table.Add("dodgerblue", "rgb( 30, 144, 255)");
			table.Add("firebrick", "rgb(178, 34, 34)");
			table.Add("floralwhite", "rgb(255, 250, 240)");
			table.Add("forestgreen", "rgb( 34, 139, 34)");
			table.Add("fuchsia", "rgb(255, 0, 255)");
			table.Add("gainsboro", "rgb(220, 220, 220)");
			table.Add("ghostwhite", "rgb(248, 248, 255)");
			table.Add("gold", "rgb(255, 215, 0)");
			table.Add("goldenrod", "rgb(218, 165, 32)");
			table.Add("gray", "rgb(128, 128, 128)");
			table.Add("grey", "rgb(128, 128, 128)");
			table.Add("green", "rgb( 0, 128, 0)");
			table.Add("greenyellow", "rgb(173, 255, 47)");
			table.Add("honeydew", "rgb(240, 255, 240)");
			table.Add("hotpink", "rgb(255, 105, 180)");
			table.Add("indianred", "rgb(205, 92, 92)");
			table.Add("indigo", "rgb( 75, 0, 130)");
			table.Add("ivory", "rgb(255, 255, 240)");
			table.Add("khaki", "rgb(240, 230, 140)");
			table.Add("lavender", "rgb(230, 230, 250)");
			table.Add("lavenderblush", "rgb(255, 240, 245)");
			table.Add("lawngreen", "rgb(124, 252, 0)");
			table.Add("lemonchiffon", "rgb(255, 250, 205)");
			table.Add("lightblue", "rgb(173, 216, 230)");
			table.Add("lightcoral", "rgb(240, 128, 128)");
			table.Add("lightcyan", "rgb(224, 255, 255)");
			table.Add("lightgoldenrodyellow", "rgb(250, 250, 210)");
			table.Add("lightgray", "rgb(211, 211, 211)");
			table.Add("lightgreen", "rgb(144, 238, 144)");
			table.Add("lightgrey", "rgb(211, 211, 211)");
			table.Add("lightpink", "rgb(255, 182, 193)");
			table.Add("lightsalmon", "rgb(255, 160, 122)");
			table.Add("lightseagreen", "rgb( 32, 178, 170)");
			table.Add("lightskyblue", "rgb(135, 206, 250)");
			table.Add("lightslategray", "rgb(119, 136, 153)");
			table.Add("lightslategrey", "rgb(119, 136, 153)");
			table.Add("lightsteelblue", "rgb(176, 196, 222)");
			table.Add("lightyellow", "rgb(255, 255, 224)");
			table.Add("lime", "rgb( 0, 255, 0)");
			table.Add("limegreen", "rgb( 50, 205, 50)");
			table.Add("linen", "rgb(250, 240, 230)");
			table.Add("magenta", "rgb(255, 0, 255)");
			table.Add("maroon", "rgb(128, 0, 0)");
			table.Add("mediumaquamarine", "rgb(102, 205, 170)");
			table.Add("mediumblue", "rgb( 0, 0, 205)");
			table.Add("mediumorchid", "rgb(186, 85, 211)");
			table.Add("mediumpurple", "rgb(147, 112, 219)");
			table.Add("mediumseagreen", "rgb( 60, 179, 113)");
			table.Add("mediumslateblue", "rgb(123, 104, 238)");
			table.Add("mediumspringgreen", "rgb( 0, 250, 154)");
			table.Add("mediumturquoise", "rgb( 72, 209, 204)");
			table.Add("mediumvioletred", "rgb(199, 21, 133)");
			table.Add("midnightblue", "rgb( 25, 25, 112)");
			table.Add("mintcream", "rgb(245, 255, 250)");
			table.Add("mistyrose", "rgb(255, 228, 225)");
			table.Add("moccasin", "rgb(255, 228, 181)");
			table.Add("navajowhite", "rgb(255, 222, 173)");
			table.Add("navy", "rgb( 0, 0, 128)");
			table.Add("oldlace", "rgb(253, 245, 230)");
			table.Add("olive", "rgb(128, 128, 0)");
			table.Add("olivedrab", "rgb(107, 142, 35)");
			table.Add("orange", "rgb(255, 165, 0)");
			table.Add("orangered", "rgb(255, 69, 0)");
			table.Add("orchid", "rgb(218, 112, 214)");
			table.Add("palegoldenrod", "rgb(238, 232, 170)");
			table.Add("palegreen", "rgb(152, 251, 152)");
			table.Add("paleturquoise", "rgb(175, 238, 238)");
			table.Add("palevioletred", "rgb(219, 112, 147)");
			table.Add("papayawhip", "rgb(255, 239, 213)");
			table.Add("peachpuff", "rgb(255, 218, 185)");
			table.Add("peru", "rgb(205, 133, 63)");
			table.Add("pink", "rgb(255, 192, 203)");
			table.Add("plum", "rgb(221, 160, 221)");
			table.Add("powderblue", "rgb(176, 224, 230)");
			table.Add("purple", "rgb(128, 0, 128)");
			table.Add("red", "rgb(255, 0, 0)");
			table.Add("rosybrown", "rgb(188, 143, 143)");
			table.Add("royalblue", "rgb( 65, 105, 225)");
			table.Add("saddlebrown", "rgb(139, 69, 19)");
			table.Add("salmon", "rgb(250, 128, 114)");
			table.Add("sandybrown", "rgb(244, 164, 96)");
			table.Add("seagreen", "rgb( 46, 139, 87)");
			table.Add("seashell", "rgb(255, 245, 238)");
			table.Add("sienna", "rgb(160, 82, 45)");
			table.Add("silver", "rgb(192, 192, 192)");
			table.Add("skyblue", "rgb(135, 206, 235)");
			table.Add("slateblue", "rgb(106, 90, 205)");
			table.Add("slategray", "rgb(112, 128, 144)");
			table.Add("slategrey", "rgb(112, 128, 144)");
			table.Add("snow", "rgb(255, 250, 250)");
			table.Add("springgreen", "rgb( 0, 255, 127)");
			table.Add("steelblue", "rgb( 70, 130, 180)");
			table.Add("tan", "rgb(210, 180, 140)");
			table.Add("teal", "rgb( 0, 128, 128)");
			table.Add("thistle", "rgb(216, 191, 216)");
			table.Add("tomato", "rgb(255, 99, 71)");
			table.Add("turquoise", "rgb( 64, 224, 208)");
			table.Add("violet", "rgb(238, 130, 238)");
			table.Add("wheat", "rgb(245, 222, 179)");
			table.Add("white", "rgb(255, 255, 255)");
			table.Add("whitesmoke", "rgb(245, 245, 245)");
			table.Add("yellow", "rgb(255, 255, 0)");
			table.Add("yellowgreen", "rgb(154, 205, 50)");

			IEnumerator colorEnum = table.Keys.GetEnumerator();
			while(colorEnum.MoveNext())
			{
				string name = (string)colorEnum.Current;
				string hexColor = (string)table[name];

				SvgColor color = _createColor(name);
				SvgColor color2 = _createColor(hexColor);

				Assert.AreEqual(color2.RgbColor.Red.GetFloatValue(CssPrimitiveType.Number), color.RgbColor.Red.GetFloatValue(CssPrimitiveType.Number), name + " red");
				Assert.AreEqual(color2.RgbColor.Green.GetFloatValue(CssPrimitiveType.Number), color.RgbColor.Green.GetFloatValue(CssPrimitiveType.Number), name + " green");
				Assert.AreEqual(color2.RgbColor.Blue.GetFloatValue(CssPrimitiveType.Number), color.RgbColor.Blue.GetFloatValue(CssPrimitiveType.Number), name + " blue");
			}
		}
	}
}
