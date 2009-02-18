using System;
using System.Xml;
using System.Xml.XPath;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;
using NUnit.Framework;
using SharpVectors.Dom.Css;

		[TestFixture]
		public class XPathSelectorTests
		{
			CssXmlDocument doc = new CssXmlDocument();
			XPathNavigator a;
			XPathNavigator b;
			XPathNavigator c;
			XPathNavigator d;
			XPathNavigator e;
			XPathNavigator f;
			XPathNavigator g;
			Hashtable nsTable = new Hashtable();

			#region Testdata
            string testXml = 
				"<?xml version='1.0' encoding='UTF-8' standalone='no'?>" + 
				"<!DOCTYPE a [" + 
				"	<!ELEMENT a (#PCDATA | b | e | f | ns:g)*>" + 
				"	<!ATTLIST a" + 
				"	xmlns:ns CDATA #REQUIRED" + 
				">" + 
				"	<!ELEMENT b (#PCDATA | c)*>" + 
				"	<!ATTLIST b" + 
				"	id CDATA #REQUIRED" + 
				"		att CDATA #REQUIRED" + 
				"		class CDATA #REQUIRED" + 
				"		ns:nsatt CDATA #REQUIRED" + 
				">" + 
				"	<!ELEMENT c (#PCDATA | d)*>" + 
				"	<!ATTLIST c" + 
				"	id ID #REQUIRED" + 
				"		xml:lang CDATA #REQUIRED" + 
				"		hreflang CDATA #REQUIRED" + 
				">" + 
				"	<!ELEMENT d (#PCDATA)>" + 
				"	<!ELEMENT e EMPTY>" + 
				"	<!ELEMENT f EMPTY>" + 
				"	<!ELEMENT ns:g EMPTY>" + 
				"]>" + 
				"<a xmlns:ns='http://www.sharpvectors.org'>asdsa" + 
				"	<b id='mrB' att='attvalue' class='class1 class2 class3' ns:nsatt='foo'>" + 
				"		<c id='mrC' xml:lang='se-SV' hreflang='sv-FI'>kjjkkjjk" + 
				"			<d>some text</d>" + 
				"		</c>sdfsdf" + 
				"	</b>" + 
				"	<e/>" + 
				"	<e/>" + 
				"	<e/>" + 
				"	<f/>" + 
				"	<ns:g/>" + 
				"</a>";

			#endregion
		

			#region Setup
			[SetUp]
			public void Init()
			{
				doc.LoadXml(testXml);
			
				if(!nsTable.ContainsKey("ns")) nsTable.Add("ns", "http://www.sharpvectors.org");

				a = doc.SelectSingleNode("//a").CreateNavigator();
				b = doc.SelectSingleNode("//b").CreateNavigator();
				c = doc.SelectSingleNode("//c").CreateNavigator();
				d = doc.SelectSingleNode("//d").CreateNavigator();
				e = doc.SelectSingleNode("//e").CreateNavigator();
				f = doc.SelectSingleNode("//f").CreateNavigator();
				g = doc.SelectSingleNode("//*[local-name()='g']").CreateNavigator();
			}
			#endregion

			[Test]
			public void TestSpecificity()
			{
				Assert.AreEqual(0, new XPathSelector("*").Specificity, "*");
				Assert.AreEqual(1, new XPathSelector("LI").Specificity, "LI");
				Assert.AreEqual(1, new XPathSelector("ns|LI", nsTable).Specificity, "ns|LI");
				Assert.AreEqual(2, new XPathSelector("UL LI").Specificity, "UL LI");
				Assert.AreEqual(3, new XPathSelector("UL OL+LI").Specificity, "UL OL+LI");
				Assert.AreEqual(11, new XPathSelector("H1 + *[REL=up]").Specificity, "H1 + *[REL=up]");
				Assert.AreEqual(13, new XPathSelector("UL OL LI.red").Specificity, "UL OL LI.red");
				Assert.AreEqual(21, new XPathSelector("LI.red.level").Specificity, "LI.red.level");
				Assert.AreEqual(100 , new XPathSelector("#x34y").Specificity, "#x34y");
				Assert.AreEqual(101, new XPathSelector("#s12:not(FOO)").Specificity, "#s12:not(FOO)");
			}


		#region Type matching
			[Test]
			public void TestUniversalMatching()
			{
				Assert.IsTrue(new XPathSelector("*").Matches(a));
				Assert.IsTrue(new XPathSelector("*").Matches(b));
			}

			[Test]
			public void TestTypeMatching()
			{
				Assert.IsTrue(new XPathSelector("a").Matches(a));
				Assert.IsTrue(new XPathSelector("b").Matches(b));

				Assert.IsTrue(!(new XPathSelector("a").Matches(b)));
				Assert.IsTrue(!(new XPathSelector("A").Matches(a)));
			}
		#endregion

		#region Relation matching
			[Test]
			public void TestDescendantMatching()
			{
				Assert.IsTrue(new XPathSelector("a b").Matches(b), "a b");
				Assert.IsTrue(new XPathSelector("a		 c").Matches(c), "a		 c");
				Assert.IsTrue(new XPathSelector("b  d").Matches(d), "b  d");
				Assert.IsTrue(!(new XPathSelector("b e").Matches(e)), "b e");
				Assert.IsTrue(!(new XPathSelector("b a").Matches(a)), "b a");
			}

			[Test]
			public void TestChildMatching()
			{
				Assert.IsTrue(new XPathSelector("a>b").Matches(b), "a>b");
				Assert.IsTrue(!(new XPathSelector("a >c").Matches(c)), "a >c");
				Assert.IsTrue(!(new XPathSelector("a > d").Matches(d)), "a > d");
				Assert.IsTrue(new XPathSelector("b>		  c").Matches(c), "b>		  c");
			}

			[Test]
			public void TestDirectAdjacentMatching()
			{
				Assert.IsTrue(new XPathSelector("b +e").Matches(e), "b +e");
				Assert.IsTrue(new XPathSelector("e+f").Matches(f), "e+f");
				Assert.IsTrue(!(new XPathSelector("b+f").Matches(f)), "b+f");
			}

			[Test]
			public void TestIndirectAdjacentMatching()
			{
				Assert.IsTrue(new XPathSelector("b ~e").Matches(e), "b ~e");
				Assert.IsTrue(new XPathSelector("e~f").Matches(f), "e~f");
				Assert.IsTrue(new XPathSelector("b~f").Matches(f), "b~f");
				Assert.IsTrue(!(new XPathSelector("f~e").Matches(e)), "f~e");
			}
		#endregion

		#region Class, Id and namespace matching
			[Test]
			public void TestClassMatching()
			{
				Assert.IsTrue(new XPathSelector(".class1").Matches(b), ".class1");
				Assert.IsTrue(new XPathSelector(".class2").Matches(b), ".class2");
				Assert.IsTrue(new XPathSelector("b.class3").Matches(b), "b.class3");
				Assert.IsTrue(new XPathSelector(".class3.class2").Matches(b), ".class3.class2");
				Assert.IsTrue(new XPathSelector(".class1.class2.class3").Matches(b), ".class1.class2.class3");

				Assert.IsTrue(!(new XPathSelector(".class1").Matches(c)), ".class1");
				Assert.IsTrue(!(new XPathSelector(".dummy").Matches(b)), ".dummy");
			}

			[Test]
			public void TestIdMatching()
			{
				Assert.IsTrue(new XPathSelector("#mrC").Matches(c), "#mrC");
				Assert.IsTrue(new XPathSelector("c#mrC").Matches(c), "c#mrC");

			}

			[Test]
			[Ignore("DTD support disabled")]
			public void TestIdMatchingNoDtd()
			{
				// id on <b> is not defined in the DTD as ID
				Assert.IsTrue(!(new XPathSelector("#mrB").Matches(b)), "#mrB");
			}

			[Test]
			public void TestNsMatching()
			{
				Assert.IsTrue(new XPathSelector("ns|g", nsTable).Matches(g), "ns|g");
				Assert.IsTrue(new XPathSelector("*|g", nsTable).Matches(g), "*|g");
				Assert.IsTrue(new XPathSelector("|a", nsTable).Matches(a), "|a");
				Assert.IsTrue(new XPathSelector("*|a", nsTable).Matches(a), "*|a");

				Assert.IsTrue(!(new XPathSelector("dummy|g", nsTable).Matches(g)), "dummy|g");
				Assert.IsTrue(!(new XPathSelector("ns|a", nsTable).Matches(a)), "ns|a");
			}
		#endregion

		#region Attribute matching
			[Test]
			public void TestAttributeExistsMatching()
			{
				Assert.IsTrue(new XPathSelector("b[att]").Matches(b), "b[att]");
			
				Assert.IsTrue(new XPathSelector("b[ns|nsatt]", nsTable).Matches(b), "b[ns|nsatt]");
				Assert.IsTrue(new XPathSelector("b[*|nsatt]", nsTable).Matches(b), "b[*|nsatt]");
				Assert.IsTrue(new XPathSelector("b[*|att]", nsTable).Matches(b), "b[*|att]");
				Assert.IsTrue(new XPathSelector("b[|att]", nsTable).Matches(b), "b[|att]");

				Assert.IsTrue(!(new XPathSelector("b[|nsatt]", nsTable).Matches(b)), "b[|nsatt]");
				Assert.IsTrue(!(new XPathSelector("b[nsatt]", nsTable).Matches(b)), "b[nsatt]");

				Assert.IsTrue(new XPathSelector("b[ att][ class	]").Matches(b), "b[ att][ class	]");

				Assert.IsTrue(!(new XPathSelector("b[att][dummy]").Matches(b)), "b[att][dummy]");
				Assert.IsTrue(!(new XPathSelector("b[dummy]").Matches(b)), "b[dummy]");
			}

			[Test]
			public void TestAttributeValueMatching()
			{
				Assert.IsTrue(new XPathSelector("b[att=attvalue]").Matches(b), "b[att=attvalue]");
				Assert.IsTrue(new XPathSelector("b[att=	'attvalue' ]").Matches(b), "b[att=	'attvalue' ]");
				Assert.IsTrue(new XPathSelector("b[ att =\"attvalue\"]").Matches(b), "b[ att =\"attvalue\"]");

				Assert.IsTrue(new XPathSelector("b[ns|nsatt='foo']", nsTable).Matches(b), "b[ns|nsatt='foo']");
				Assert.IsTrue(new XPathSelector("b[*|nsatt=foo]", nsTable).Matches(b), "b[*|nsatt=foo]");
				Assert.IsTrue(new XPathSelector("b[*|att=attvalue]", nsTable).Matches(b), "b[*|att=attvalue]");
				Assert.IsTrue(new XPathSelector("b[|att=\"attvalue\"]", nsTable).Matches(b), "b[|att=\"attvalue\"]");

				Assert.IsTrue(!(new XPathSelector("b[|nsatt=foo]", nsTable).Matches(b)), "b[|nsatt=foo]");
				Assert.IsTrue(!(new XPathSelector("b[nsatt=foo]", nsTable).Matches(b)), "b[nsatt=foo]");


				Assert.IsTrue(!(new XPathSelector("b[att=dummy]").Matches(b)), "b[att=dummy]");
			}

			[Test]
			public void TestAttributeValueSpaceSeparatedMatching()
			{
				Assert.IsTrue(new XPathSelector("b[class~=class2]").Matches(b), "b[class~=class2]");
				Assert.IsTrue(new XPathSelector("b[class~=class3]").Matches(b), "b[class~=class3]");
				Assert.IsTrue(new XPathSelector("b[class~=class2][class~=class3]").Matches(b), "b[class~=class2][class~=class3]");

				Assert.IsTrue(!(new XPathSelector("b[class~=dummy]").Matches(b)), "b[class~=dummy]");
			}

			[Test]
			public void TestAttributeValueBeginMatching()
			{
				Assert.IsTrue(new XPathSelector("b[att^=attv]").Matches(b), "b[att^=attv]");
				Assert.IsTrue(new XPathSelector("b[att^=attvalue]").Matches(b), "b[att^=attvalue]");

				Assert.IsTrue(!(new XPathSelector("b[att^=dummy]").Matches(b)), "b[att^=dummy]");
				Assert.IsTrue(!(new XPathSelector("b[att^=ttv]").Matches(b)), "b[att^=ttv]");
			}

			[Test]
			public void TestAttributeValueEndMatching()
			{
				Assert.IsTrue(new XPathSelector("b[att$=lue]").Matches(b), "b[att$=lue]");
				Assert.IsTrue(new XPathSelector("b[att$=attvalue]").Matches(b), "b[att$=attvalue]");

				Assert.IsTrue(!(new XPathSelector("b[att$=dummy]").Matches(b)), "b[att$=dummy]");
				Assert.IsTrue(!(new XPathSelector("b[att$=ttv]").Matches(b)), "b[att$=ttv]");
			}

			[Test]
			public void TestAttributeValueSubStringMatching()
			{
				Assert.IsTrue(new XPathSelector("b[att*=lue]").Matches(b), "b[att*=lue]");
				Assert.IsTrue(new XPathSelector("b[att*=attvalue]").Matches(b), "b[att*=attvalue]");
				Assert.IsTrue(new XPathSelector("b[att*=attv]").Matches(b), "b[att*=attv]");

				Assert.IsTrue(!(new XPathSelector("b[att*=dummy]").Matches(b)), "b[att*=dummy]");
			}

			[Test]
			public void TestAttributeValueHyphenMatching()
			{
				Assert.IsTrue(new XPathSelector("[hreflang|=sv]").Matches(c), "[hreflang|=sv]");

				Assert.IsTrue(!(new XPathSelector("[hreflang|=sv]").Matches(b)), "[hreflang|=sv]");
			}
		#endregion

		#region Misc
			/* Not supported
			[Test]
			public void TestTargetMatching()
			{
				Console.WriteLine(doc.Url);

			}
			*/
		
			[Test]
			public void TestLangMatching()
			{
				Assert.IsTrue(new XPathSelector("c:lang(se-SV)").Matches(c), "c:lang(se-SV)");
				Assert.IsTrue(new XPathSelector("c:lang(se)").Matches(c), "c:lang(se)");
				Assert.IsTrue(new XPathSelector("d:lang(se)").Matches(d), "d:lang(se)");

				Assert.IsTrue(!(new XPathSelector("c:lang(se-FI)").Matches(c)), "c:lang(se-FI)");
				Assert.IsTrue(!(new XPathSelector("c:lang(en)").Matches(c)), "c:lang(en)");
			}

			[Test]
			public void TestNotMatching()
			{
				Assert.IsTrue(new XPathSelector("c:not(:root)").Matches(c), "c:not(:root))");
				Assert.IsTrue(new XPathSelector("a:not(.kalle)").Matches(a), "a:not(.kalle))");
				Assert.IsTrue(new XPathSelector("*:not(b)").Matches(a), "*:not(b)");
				Assert.IsTrue(new XPathSelector("*:not(b)").Matches(g), "*:not(b)");

				Assert.IsTrue(!(new XPathSelector("*:not(b)").Matches(b)), "*:not(b)");
				Assert.IsTrue(!(new XPathSelector("a:not(:root)").Matches(a)), "a:not(:root))");
			}

			[Test]
			public void TestRootMatching()
			{
				Assert.IsTrue(new XPathSelector("a:root").Matches(a), "a:root");
				Assert.IsTrue(!(new XPathSelector("b:root").Matches(b)), "b:root");
			}

			[Test]
			public void TestContainsMatching()
			{
				Assert.IsTrue(new XPathSelector("d:contains(some)").Matches(d), "d:contains(some)");
				Assert.IsTrue(new XPathSelector("d:contains('me te')").Matches(d), "d:contains('me te')");
				Assert.IsTrue(new XPathSelector("d:contains(\"me text\")").Matches(d), "d:contains(\"me text\")");

				Assert.IsTrue(!(new XPathSelector("d:contains(dummy)").Matches(d)), "d:contains(dummy)");
			}

			[Test]
			public void TestOnlyChildMatching()
			{
				Assert.IsTrue(new XPathSelector("c:only-child").Matches(c), "c:only-child");
				Assert.IsTrue(new XPathSelector("d:only-child").Matches(d), "d:only-child");

				Assert.IsTrue(!(new XPathSelector("b:only-child").Matches(b)), "b:only-child");
				Assert.IsTrue(!(new XPathSelector("e:only-child").Matches(e)), "e:only-child");
			}

			[Test]
			public void TestEmptyMatching()
			{
				Assert.IsTrue(new XPathSelector("e:empty").Matches(e), "e:empty");

				Assert.IsTrue(!(new XPathSelector("b:empty").Matches(b)), "b:empty");
				Assert.IsTrue(!(new XPathSelector("d:empty").Matches(d)), "d:empty");
			}
			#endregion

			#region Position matching
			[Test]
			public void TestFirstChildMatching()
			{
				Assert.IsTrue(new XPathSelector("b:first-child").Matches(b), "b:first-child");
				Assert.IsTrue(new XPathSelector("d:first-child").Matches(d), "d:first-child");

				Assert.IsTrue(!(new XPathSelector("e:first-child").Matches(e)), "e:first-child");
			}

			[Test]
			public void TestLastChildMatching()
			{
				Assert.IsTrue(new XPathSelector("c:last-child").Matches(c), "c:last-child");
				Assert.IsTrue(new XPathSelector("d:first-child").Matches(d), "d:first-child");

				Assert.IsTrue(!(new XPathSelector("b:last-child").Matches(b)), "b:last-child");
			}

			[Test]
			public void TestNthChildMatching()
			{
				Assert.IsTrue(new XPathSelector("*:nth-child(2)").Matches(e), "1: *:nth-child(2)");

				Assert.IsTrue(new XPathSelector("e:nth-child(2n)").Matches(e), "e:nth-child(2n)");
				Assert.IsTrue(new XPathSelector("e:nth-child(n)").Matches(e), "e:nth-child(n)");
				Assert.IsTrue(new XPathSelector("e:nth-child(4n-2)").Matches(e), "e:nth-child(4n- 2)");
				Assert.IsTrue(new XPathSelector("g:nth-child(2n)").Matches(g), "g:nth-child(2n)");

				Assert.IsTrue(new XPathSelector("b:nth-child(0n	+ 1)").Matches(b), "b:nth-child( 0n	+ 1)");
				Assert.IsTrue(!(new XPathSelector("e:nth-child( 0n+1)").Matches(e)), "e:nth-child( 0n+1)");

				Assert.IsTrue(new XPathSelector("*:nth-child(-n+2)").Matches(b), "*:nth-child(-n+2)");
				Assert.IsTrue(new XPathSelector("*:nth-child(-n+2)").Matches(e), "*:nth-child(-n+2)");
				Assert.IsTrue(!(new XPathSelector("*:nth-child(-n+2)").Matches(f)), "*:nth-child(-n+2)");
				Assert.IsTrue(!(new XPathSelector("*:nth-child(-n+2)").Matches(g)), "*:nth-child(-n+2)");

				// test of odd and even
				Assert.IsTrue(new XPathSelector("e:nth-child(even)").Matches(e), "e:nth-child(even)");
				Assert.IsTrue(new XPathSelector("b:nth-child(odd)").Matches(b), "b:nth-child(odd)");
				Assert.IsTrue(new XPathSelector("f:nth-child(odd)").Matches(f), "f:nth-child(odd)");
				Assert.IsTrue(!(new XPathSelector("e:nth-child(odd)").Matches(e)), "e:nth-child(odd)");
				Assert.IsTrue(!(new XPathSelector("b:nth-child(even)").Matches(b)), "b:nth-child(even)");

				// tests for false positives
				Assert.IsTrue(!(new XPathSelector("b:nth-child(2n)").Matches(b)), "b:nth-child(2n)");
				Assert.IsTrue(!(new XPathSelector("f:nth-child(2n)").Matches(b)), "f:nth-child(2n)");
			}

			public void TestNthLastChildMatching()
			{
				Assert.IsTrue(new XPathSelector("*:nth-last-child(5)").Matches(e), "1: *:nth-last-child(5)");

				Assert.IsTrue(new XPathSelector("*:nth-last-child(-n+2)").Matches(g), "2: *:nth-last-child(-n+2)");
				Assert.IsTrue(new XPathSelector("*:nth-last-child(-n+2)").Matches(f), "3: *:nth-last-child(-n+2)");
				Assert.IsTrue(!(new XPathSelector("*:nth-last-child(-n+2)").Matches(e)), "4: *:nth-last-child(-n+2)");
				Assert.IsTrue(!(new XPathSelector("*:nth-last-child(-n+2)").Matches(b)), "5: *:nth-last-child(-n+2)");

				Assert.IsTrue(new XPathSelector("*:nth-last-child(odd)").Matches(g), "*:nth-last-child( odd)");
				Assert.IsTrue(new XPathSelector("*:nth-last-child(odd)").Matches(e), "*:nth-last-child(odd)");
				Assert.IsTrue(!(new XPathSelector("*:nth-last-child(odd)").Matches(f)), "*:nth-last-child(odd )");
				Assert.IsTrue(!(new XPathSelector("*:nth-last-child(odd)").Matches(b)), "*:nth-last-child(odd)");

				Assert.IsTrue(new XPathSelector("*:nth-last-child(even)").Matches(f), "*:nth-last-child(even)");
				Assert.IsTrue(new XPathSelector("*:nth-last-child(even)").Matches(b), "*:nth-last-child( even)");
				Assert.IsTrue(!(new XPathSelector("*:nth-last-child(even)").Matches(g)), "*:nth-last-child(even)");
				Assert.IsTrue(!(new XPathSelector("*:nth-last-child(even)").Matches(e)), "*:nth-last-child(even )");
			}
			#endregion

			private void PrintXPath(string sel)
			{
				this.PrintXPath(sel, new Hashtable());
			}

			private void PrintXPath(string sel, Hashtable nsTable)
			{
				XPathSelector xsel = new XPathSelector(sel, nsTable);
				xsel.Matches(e);
				//			Console.WriteLine(xsel.XPath);
			}

		}
