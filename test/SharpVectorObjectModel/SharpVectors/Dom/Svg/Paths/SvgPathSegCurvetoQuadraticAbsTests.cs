using System;
using System.Drawing;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public class QuadraticAbsTests : QuadraticTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M10,10 Q100,100 200,10", false);
            }

            public override SvgPathSegCurvetoQuadratic getTestSegment()
            {
                return (SvgPathSegCurvetoQuadratic) segments[1];
            }
        }
