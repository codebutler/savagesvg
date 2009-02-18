using System;
using System.Drawing;
using System.IO;

namespace SharpVectors.UnitTests.Renderer
{
	public class CompareUtil
	{
		private BitmapComparator comparator = new BitmapComparator();

		public CompareUtil()
		{
		}

		public BitmapComparator BitmapComparator
		{
			get{return comparator;}
		}

		public bool CompareImages(Bitmap renderedImage, string pngImagePath)
		{
			Bitmap pngRaster = (Bitmap) Bitmap.FromFile(pngImagePath);

			bool result = comparator.Compare( renderedImage, pngRaster );
			if(!result)
			{
				string fromTestPath = pngImagePath.Replace(".png", "_fromtest.png");
				renderedImage.Save(fromTestPath);
      }

			return result;
		}	
	}
}
