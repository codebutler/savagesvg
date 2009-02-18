using SharpVectors.Dom.Css;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgStylable  
	{
		ISvgAnimatedString ClassName{get;}
		ICssStyleDeclaration Style{get;}
		ICssValue GetPresentationAttribute(string name);
	}
}
