using System;
using System.IO;

namespace Viewer
{
	/// <summary>
	/// Summary description for TestFileLoader.
	/// </summary>
	internal class TestFileLoader
	{
		private const string TEST_DIR = @"..\..\..\..\tests";

		public readonly string SourceDirectory;

		//the default consturcotr only works if the location
		//of the tests dir is in the correct relative location
		//TEST_DIR matches the CVS layout and should work for most cases
		public TestFileLoader():this( Path.GetFullPath( TEST_DIR ) )
		{
		}

		public TestFileLoader( string sourceDirectory )
		{
			Console.WriteLine( sourceDirectory );
			SourceDirectory = sourceDirectory;
		}

		public FileInfo[] GetFiles()
		{
			return TestFileLoader.GetFiles( SourceDirectory );
		}

		public static FileInfo[] GetFiles( string sourceDirectory )
		{
			DirectoryInfo dir = new DirectoryInfo( sourceDirectory );
			return dir.GetFiles( "*.svg" );
		}

	}
}
