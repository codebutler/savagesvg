using System;
using System.Drawing;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public class CubicRelTests : CubicTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M10,10 c90,90 190,90 290,0", false);
            }

            public override SvgPathSegCurvetoCubic getTestSegment()
            {
                return (SvgPathSegCurvetoCubic) segments[1];
            }
        }
