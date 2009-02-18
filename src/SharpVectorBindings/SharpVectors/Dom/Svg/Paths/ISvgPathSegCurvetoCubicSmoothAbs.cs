using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegCurvetoCubicSmoothAbs interface corresponds to an "absolute smooth cubic curveto" (S) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegCurvetoCubicSmoothAbs : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
		float X2{get;set;}
		float Y2{get;set;}
	}
}