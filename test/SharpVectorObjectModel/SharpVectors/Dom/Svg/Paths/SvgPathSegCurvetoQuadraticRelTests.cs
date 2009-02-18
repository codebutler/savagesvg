using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public class QuadraticRelTests : QuadraticTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M10,10 q90,90 190,0", false);
            }

            public override SvgPathSegCurvetoQuadratic getTestSegment()
            {
                return (SvgPathSegCurvetoQuadratic) segments[1];
            }
        }
