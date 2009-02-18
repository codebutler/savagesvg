using System;
using System.IO;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Css;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.DocumentStructure
{
	[TestFixture]
	public class SvgStyleableElementTests : SvgElementTests
	{
		#region Utils for SvgElementTests
		// there isn't any way of directly creating a SvgStyleableElement. title is one of the simplest subclasses
		protected override Type elmType
		{
			get{return typeof(SvgTitleElement);}
		}

		protected override string localName
		{
			get{return "title";}
		}
		#endregion        

		#region ClassName tests
		[Test]
		public void NoClass()
		{
            SvgStyleableElement elm = Util.GetXmlElement("<title />", "", "title") as SvgStyleableElement;
			Assert.AreEqual("", elm.ClassName.AnimVal);
		}

		[Test]
		public void EmptyClass()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title class='' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual("", elm.ClassName.AnimVal);
		}

		[Test]
		public void SingleClass()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title class='foo' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual("foo", elm.ClassName.AnimVal);
		}

		[Test]
		public void SingleClassDontTrim()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title class='	foo ' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual("	foo ", elm.ClassName.AnimVal);
		}

		[Test]
		public void MultipleClasses()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title class='foo bar run' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual("foo bar run", elm.ClassName.AnimVal);
		}
		#endregion

		#region Presentation attributes
		[Test]
		public void PresAttNonExisting()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title />", "", "title") as SvgStyleableElement;
			Assert.IsNull(elm.GetPresentationAttribute("dummy"));
		}

		[Test]
		public void PresAttExisting()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title fill='black' />", "", "title") as SvgStyleableElement;

			Assert.AreEqual(CssValue.GetCssValue("black", false).CssText, elm.GetPresentationAttribute("fill").CssText);
		}


		[Test]
		public void PresAttSettingNew()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title />", "", "title") as SvgStyleableElement;
			Assert.IsNull(elm.GetPresentationAttribute("stroke"));

			elm.SetAttribute("stroke", "red");
			Assert.AreEqual(CssValue.GetCssValue("red", false).CssText, elm.GetPresentationAttribute("stroke").CssText);
		}

		[Test]
		public void PresAttUpdating()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title fill='black' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual(CssValue.GetCssValue("black", false).CssText, elm.GetPresentationAttribute("fill").CssText);

			elm.SetAttribute("fill", "red");
			Assert.AreEqual(CssValue.GetCssValue("red", false).CssText, elm.GetPresentationAttribute("fill").CssText);
		}

		[Test]
		public void PresAttRemoving()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title fill='black' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual(CssValue.GetCssValue("black", false).CssText, elm.GetPresentationAttribute("fill").CssText);

			elm.RemoveAttribute("fill");
			Assert.IsNull(elm.GetPresentationAttribute("fill"));
		}

		[Test]
		public void PresAttEmptying()
		{
			SvgStyleableElement elm = Util.GetXmlElement("<title fill='black' />", "", "title") as SvgStyleableElement;
			Assert.AreEqual(CssValue.GetCssValue("black", false).CssText, elm.GetPresentationAttribute("fill").CssText);

			elm.SetAttribute("fill", "");
			Assert.IsNull(elm.GetPresentationAttribute("fill"));
		}
		#endregion
	}
}
