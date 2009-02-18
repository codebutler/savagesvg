using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegCurvetoCubicSmoothRel interface corresponds to a "relative smooth cubic curveto" (s) path data command.
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegCurvetoCubicSmoothRel : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
		float X2{get;set;}
		float Y2{get;set;}
	}
}