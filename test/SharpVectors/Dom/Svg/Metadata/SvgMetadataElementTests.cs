using System;
using NUnit.Framework;
using SharpVectors.Dom.Svg;

using SharpVectors.UnitTests.Svg.BasicTypesAndInterfaces;

namespace SharpVectors.UnitTests.Svg.Metadata
{
	[TestFixture]
	public class SvgMetadataElementTests : SvgElementTests
	{
		protected override Type elmType
		{
			get{return typeof(SvgMetadataElement);}
		}

		protected override string localName
		{
			get{return "metadata";}
		}

        
	}
}
