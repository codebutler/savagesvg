using SharpVectors.Dom.Events;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgGElement interface corresponds to the 'g' element. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>99</completed>
	public interface ISvgGElement	: 
		ISvgElement,
		ISvgTests,
		ISvgLangSpace,
		ISvgExternalResourcesRequired,
		ISvgStylable,
		ISvgTransformable,
		IEventTarget
	{

	}
}
