using System;
using System.Drawing;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public class CubicSmoothAbsTests : CubicTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M-280,10 C-180,-80 -80,-80 10,10 S200,100 300,10", false);
            }

            public override SvgPathSegCurvetoCubic getTestSegment()
            {
                return (SvgPathSegCurvetoCubic) segments[2];
            }
        }
