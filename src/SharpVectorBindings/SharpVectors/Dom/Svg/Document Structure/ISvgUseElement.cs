using SharpVectors.Dom.Events;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgUseElement interface corresponds to the 'use' element. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>0</completed>
	public interface ISvgUseElement :
		ISvgElement,
		ISvgURIReference,
		ISvgTests,
		ISvgLangSpace,
		ISvgExternalResourcesRequired,
		ISvgStylable,
		ISvgTransformable,
    IEventTarget
	{ 

		ISvgAnimatedLength X{get;}
		ISvgAnimatedLength Y{get;}
		ISvgAnimatedLength Width{get;}
		ISvgAnimatedLength Height{get;}
		ISvgElementInstance InstanceRoot{get;}
		ISvgElementInstance AnimatedInstanceRoot{get;}

	}
}
