using System;
using System.Drawing;
using System.Text;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

        [TestFixture]
        public class QuadraticSmoothAbsTests : QuadraticTests
        {
            public override SvgPathSegList makeSegments()
            {
                return new SvgPathSegList("M-180,10 Q-80,-80 10,10 T200,10", false);
            }

            public override SvgPathSegCurvetoQuadratic getTestSegment()
            {
                return (SvgPathSegCurvetoQuadratic) segments[2];
            }
        }
