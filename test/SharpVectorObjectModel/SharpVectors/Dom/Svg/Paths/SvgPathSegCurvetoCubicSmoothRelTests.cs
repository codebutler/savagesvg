using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public class CubicSmoothRelTests : CubicTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M-280,10 C-180,-80 -80,-80 10,10 s190,90 290,0", false);
            }

            public override SvgPathSegCurvetoCubic getTestSegment()
            {
                return (SvgPathSegCurvetoCubic) segments[2];
            }
        }
