using SharpVectors.Dom.Events;

namespace SharpVectors.Dom.Svg
{
	public interface ISvgSymbolElement : ISvgElement,
		ISvgLangSpace,
		ISvgExternalResourcesRequired,
		ISvgStylable,
		ISvgFitToViewBox,
    IEventTarget
	{
	}
}
