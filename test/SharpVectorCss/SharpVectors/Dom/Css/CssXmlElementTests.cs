using System;
using System.Xml;
using System.Xml.Serialization;
using SharpVectors.Dom;
using SharpVectors.Dom.Stylesheets;
using NUnit.Framework;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class CssXmlElementTests
		{
			protected virtual XmlElement getElm(string content, string style, string localname)
			{
				return TestUtil.GetXmlElement(content, style, localname);
			}

			protected virtual Type elmType
			{
				get
				{
					return typeof(CssXmlElement);
				}
			}


			[Test]
			public virtual void TestTypeFromDocument()
			{
				CssXmlDocument doc = new CssXmlDocument();
				doc.LoadXml("<dummy />");
				XmlElement elm = doc.DocumentElement;
				Assert.AreEqual(elmType, elm.GetType());
			}

			[Test]
			public virtual void TestTypeFromCreateElement()
			{
				CssXmlDocument doc = new CssXmlDocument();
				XmlElement elm = doc.CreateElement("", "dummy", "");

				Assert.AreEqual(elm.GetType(), elmType);
			}


			private Object lastSrc;
			private XmlNode lastNode;
			private XmlNodeChangedAction lastAction;
			private void clearAllLast()
			{
				lastSrc = null;
				lastNode = null;
				lastAction = 0;
			}
			
			private void elementChangeEvent(Object src, XmlNodeChangedEventArgs args)
			{
				lastSrc = src;
				lastNode = args.Node;
				lastAction = args.Action;
			}

			/*[Test]
			public void TestElementChangeNewChild()
			{
				clearAllLast();
                CssXmlElement elm = getElm("<dummy />", "", "dummy") as CssXmlElement;
				//elm.ElementChange += new ElementChangeHandler(elementChangeEvent);

				elm.AppendChild(elm.OwnerDocument.CreateElement("dd"));

				Console.WriteLine("lastSrc: " + lastSrc);
				Console.WriteLine("lastAction: " + lastAction);
				Assert.AreEqual(elm, lastNode);


                
			}*/

			#region Style attribute tests
			[Test]
			public void TestStyleNoStyleAttr()
			{
				CssXmlElement elm = getElm("<a />", "", "a") as CssXmlElement;
				CssStyleDeclaration csd = (CssStyleDeclaration)elm.Style;
				Assert.AreEqual("", csd.CssText);
				Assert.AreEqual(0, csd.Length);
				Assert.AreEqual(CssStyleSheetType.Inline, csd.Origin);
			}

			[Test]
			public void TestStyleEmptyStyleAttr()
			{
				CssXmlElement elm = getElm("<a style='' />", "", "a") as CssXmlElement;
				CssStyleDeclaration csd = (CssStyleDeclaration)elm.Style;
				Assert.AreEqual("", csd.CssText);
				Assert.AreEqual(0, csd.Length);
				Assert.AreEqual(CssStyleSheetType.Inline, csd.Origin);
			}

			[Test]
			public void TestStyleSingle()
			{
				CssXmlElement elm = getElm("<a style='foo:bar' />", "", "a") as CssXmlElement;
				CssStyleDeclaration csd = (CssStyleDeclaration)elm.Style;
				Assert.AreEqual("foo:bar;", csd.CssText);
				Assert.AreEqual(1, csd.Length);
				Assert.AreEqual("foo", csd[0]);
				Assert.AreEqual("bar", csd.GetPropertyValue("foo"));
				Assert.AreEqual(CssStyleSheetType.Inline, csd.Origin);
			}

			[Test]
			public void TestStyleMultiple()
			{
				CssXmlElement elm = getElm("<a style='foo:bar; kalle:roffe' />", "", "a") as CssXmlElement;
				CssStyleDeclaration csd = (CssStyleDeclaration)elm.Style;
				if(!csd.CssText.Equals("foo:bar;kalle:roffe;") && 
					!csd.CssText.Equals("kalle:roffe;foo:bar;"))
				{
					Assert.Fail();
				}
				Assert.AreEqual(2, csd.Length);
				Assert.AreEqual("bar", csd.GetPropertyValue("foo"));
				Assert.AreEqual("roffe", csd.GetPropertyValue("kalle"));
				Assert.AreEqual(CssStyleSheetType.Inline, csd.Origin);
			}

			[Test]
			public void TestStyleMultipleWithSame()
			{
				CssXmlElement elm = getElm("<a style='foo:bar; kalle:roffe;foo:newvalue' />", "", "a") as CssXmlElement;
				ICssStyleDeclaration csd = elm.Style;
				if(!csd.CssText.Equals("kalle:roffe;foo:newvalue;") && 
					!csd.CssText.Equals("foo:newvalue;kalle:roffe;"))
				{
					Assert.Fail();
				}
				Assert.AreEqual(2, csd.Length);
				Assert.AreEqual("newvalue", csd.GetPropertyValue("foo"));
			}

			[Test]
			public void TestStyleUpdate()
			{
				CssXmlElement elm = getElm("<a style='foo:bar' />", "", "a") as CssXmlElement;
				Assert.AreEqual("foo:bar;", elm.Style.CssText);

				elm.SetAttribute("style", "run:ar");
				Assert.AreEqual("run:ar;", elm.Style.CssText);
			}

			[Test]
			public void TestStyleRemove()
			{
				CssXmlElement elm = getElm("<a style='foo:bar' />", "", "a") as CssXmlElement;

				Assert.AreEqual("foo:bar;", elm.Style.CssText);

				elm.RemoveAttribute("style");
				Assert.AreEqual("", elm.Style.CssText);
			}

			[Test]
			public void TestStyleCreate()
			{
				CssXmlElement elm = getElm("<a />", "", "a") as CssXmlElement;

				Assert.AreEqual("", elm.Style.CssText);

				elm.SetAttribute("style", "run:ar");
				Assert.AreEqual("run:ar;", elm.Style.CssText);
			}
			#endregion
		}
