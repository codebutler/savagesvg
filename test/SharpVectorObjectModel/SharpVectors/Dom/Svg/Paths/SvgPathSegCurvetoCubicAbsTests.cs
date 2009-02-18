using System;
using System.Drawing;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;
using SharpVectors.Polynomials;
        [TestFixture]
        public class CubicAbsTests : CubicTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M10,10 C100,100 200,100 300,10", false);
            }

            public override SvgPathSegCurvetoCubic getTestSegment()
            {
                return (SvgPathSegCurvetoCubic) segments[1];
            }
        }
