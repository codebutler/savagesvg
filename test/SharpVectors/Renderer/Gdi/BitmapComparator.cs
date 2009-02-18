using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace SharpVectors.UnitTests.Renderer
{
	/// <summary>
	/// Summary description for BitmapComparator.
	/// </summary>
	public class BitmapComparator
	{
        #region Fields
        private int count;
        private int diffCount;
        private float sum;
        private float minimum;
        private float maximum;
        private float average;
        #endregion

        #region Properties
        public int Count
        {
            get { return count; }
        }

        public int DifferenceCount
        {
            get { return diffCount; }
        }

        public float Minimum
        {
            get { return minimum; }
        }

        public float Maximum
        {
            get { return maximum; }
        }

        public float Average
        {
            get { return average; }
        }
        #endregion

		#region Public Methods

        public bool Compare(Bitmap a, Bitmap b)

        {

            bool result = false;



            // init fields

            count = 0;

            diffCount = 0;

            sum = 0.0f;

            minimum = 442.0f;

            maximum = 0.0f;



            if ( a.Width == b.Width && a.Height == b.Height ) {

                BitmapData aData = a.LockBits(

                    new Rectangle(0, 0, a.Width, a.Height),

                    ImageLockMode.ReadOnly,

                    PixelFormat.Format24bppRgb);

                BitmapData bData = b.LockBits(

                    new Rectangle(0, 0, b.Width, b.Height),

                    ImageLockMode.ReadOnly,

                    PixelFormat.Format24bppRgb);



                int aStride = aData.Stride;

                int bStride = bData.Stride;



                int aOffset = aStride - a.Width*3;

                int bOffset = bStride - b.Width*3;



                System.IntPtr aScan0 = aData.Scan0;

                System.IntPtr bScan0 = bData.Scan0;



                unsafe {

                    byte *aChannel = (byte *) aScan0;

                    byte *bChannel = (byte *) bScan0;



                    int diffRed, diffGreen, diffBlue;

                    float length;



                    for( int y = 0; y < a.Height; y++ ) {

                        for( int x = 0; x < a.Width; x++ ) {

                            diffRed   = (int) bChannel[0] - (int) aChannel[0];

                            diffGreen = (int) bChannel[1] - (int) aChannel[1];

                            diffBlue  = (int) bChannel[2] - (int) aChannel[2];



                            // calculate distance between parallel pixels

                            length = (float) Math.Sqrt( diffRed*diffRed + diffGreen*diffGreen + diffBlue*diffBlue );



                            if ( length > 0 ) {

                                // need to increment histogram entry for this length here



                                // adjust maximum and minimum distance values

                                if ( length < minimum ) minimum = length;

                                if ( length > maximum ) maximum = length;



                                // update current sum of lengths and update diffCount

                                sum += length;

                                diffCount++;

                            }



                            // update overall pixel count

                            count++;



                            // advance channel pointers to the next pixel

                            aChannel += 3;

                            bChannel += 3;

                        }



                        // skip over trailing bytes (padding)

                        aChannel += aOffset;

                        bChannel += bOffset;

                    }



                    a.UnlockBits(aData);

                    b.UnlockBits(bData);

                }



                if ( diffCount > 0 ) {

                    average = sum / diffCount;

                    /*Console.WriteLine("diffCount = " + diffCount.ToString());

                    Console.WriteLine("minimum = " + minimum.ToString());

                    Console.WriteLine("maximum = " + maximum.ToString());

                    Console.WriteLine("average = " + average.ToString());

                    Console.WriteLine("sum = " + sum.ToString());*/

                }

                else

                {

                    average = 0;

                    result = true;

                }

            }

            else

            {

                // Console.WriteLine("The dimensions of the two images do not match");

            }



            return result;

        }

        #endregion
	}
}

