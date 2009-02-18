#region SourceSafe Comments
/* 
 * $Header: /cvsroot/svgdomcsharp/SharpVectorGraphics/src/SharpVectorUnitTests/SharpVectors/Dom/Svg/SvgWindowTest.cs,v 1.2 2005/11/20 20:42:23 jeffrafter Exp $
 * $Log: SvgWindowTest.cs,v $
 * Revision 1.2  2005/11/20 20:42:23  jeffrafter
 * Project wide fixes to eliminate obsolete NUnit calls, minor test related fixes
 *
 * Revision 1.1  2003/02/18 22:05:10  nikgus
 * no message
 *
 * Revision 1.2  2003/01/03 20:45:39  awcoats
 * start of the unittests. Does 2 tests.
 *
 * Revision 1.1  2003/01/03 20:19:54  awcoats
 * initial checkin.
 *
 * Revision 1.1  2003/01/03 20:11:08  awcoats
 * initial checkin.
 *
 * 
 */ 
#endregion
/*
#region Using
using System;
using SharpVectors.Dom.Svg;

using NUnit.Framework;
#endregion

namespace SharpVectorModelUnitTests.Dom.Svg
{
	/// <summary>
	/// Summary description for SvgWindowTest.
	/// </summary>
	[TestFixture]
	public class SvgWindowTest
	{
		public void TestConstructor1()
		{
			SvgWindow window = new SvgWindow( 1,2 );
			Assert.AreEqual("Width",1,window.InnerWidth);
			Assert.AreEqual("Height",2,window.InnerHeight);
		}

		
		/*public void TestConstructor2()
		{
		// the ctor is marked internal - so cannot test it.
			System.Windows.Forms.GroupBox control = new System.Windows.Forms.GroupBox();
			
			SvgWindow window = new SvgWindow( 1, 2, control );
			Assert.AreEqual("Width",1,window.InnerWidth);
			Assert.AreEqual("Height",2,window.InnerHeight);
		}*/
/*
		[ExpectedException(typeof(NullReferenceException))]
		public void TestConstructor3()
		{
			SvgWindow window = new SvgWindow( null );
			long height= window.InnerHeight;
		}
	}
}
*/