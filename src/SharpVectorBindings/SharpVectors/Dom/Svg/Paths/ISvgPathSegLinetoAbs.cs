using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegLinetoAbs interface corresponds to an "absolute lineto" (L) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegLinetoAbs : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
	}
}