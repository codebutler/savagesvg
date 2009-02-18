using System;
using System.IO;
using System.Xml;
using System.Collections;

using SharpVectors.Dom.Svg;
using SharpVectors.Renderer.Gdi;

namespace SharpVectors.PerfTest
{
	public class PerfTest
	{
		public PerfTest()
		{
		}

		private string localPath = Environment.CurrentDirectory + @"\tmp.svg";
		private string imgPath = Environment.CurrentDirectory + @"\tmp.png";

		private int singleRun(string filePath, bool saveLocal, bool saveImage)
		{
			DateTime startTime = DateTime.Now;

			GdiRenderer gdiRenderer = new GdiRenderer();
			SvgWindow wnd = new SvgWindow(300, 300, gdiRenderer);

			SvgDocument doc = new SvgDocument(wnd);
			wnd.Document = doc;
			doc.Load(filePath);
			
			//wnd.Render();

			if(((GdiRenderer)wnd.Renderer).RasterImage == null) {
		                Console.WriteLine("ERROR: no image rendered");
			}

			DateTime endTime = DateTime.Now; 
			TimeSpan diff = endTime - startTime;

			if(saveLocal) {
				doc.Save(localPath);
			}

			if(saveImage) {
				((GdiRenderer)wnd.Renderer).RasterImage.Save(imgPath, System.Drawing.Imaging.ImageFormat.Png);
				Console.WriteLine("Reference image saved as :\n" + imgPath);
			}
			
			wnd.Renderer = null;
			wnd = null;
			doc = null;

			return (int)diff.TotalMilliseconds;
		}

		public void Run(string url, int repeats)
		{
			// run once to make sure everything is compiled and ready
			singleRun(url, true, true);

			ArrayList times = new ArrayList();

			for(int i = 0; i<repeats; i++) {
				times.Add(singleRun(localPath, false, false));
			}

			if (File.Exists (localPath)) {
				File.Delete(localPath);
			}
            
			int sum = 0;
			foreach(int time in times) {
				sum += time;
			}

			float average = sum / repeats;

			float stdDevSum = 0;
			
			foreach(int time in times) {
				stdDevSum += (float)Math.Pow(time - average, 2);
			}

			Console.WriteLine("Total time         : " + sum + " ms");
			Console.WriteLine("Repeats            : " + repeats);
			Console.WriteLine("Average time       : " + Math.Round(average, 2) + " ms");
			Console.WriteLine("Standard deviation : +/-" + Math.Round(Math.Sqrt(stdDevSum / repeats), 2) + " ms");
		}

		[STAThread]
		static void Main(string[] args)
		{
			string url = "http://www.protocol7.com/svg.net/people.svg";
			int repeats = 1;
			/*if(args.Length == 0)
			{
				Console.WriteLine("usage: url [noOfRepeats]");
				return;
			}
			else if(args.Length == 2)
			{
                repeats = Convert.ToInt32(args[1]);
			}
            url = args[0];
*/
			PerfTest perfTest = new PerfTest();
			perfTest.Run(url, repeats);
		}
	}
}
