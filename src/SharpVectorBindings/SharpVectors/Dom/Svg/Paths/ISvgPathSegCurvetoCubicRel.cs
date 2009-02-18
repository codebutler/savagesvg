using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegCurvetoCubicRel interface corresponds to a "relative cubic Bézier curveto" (c) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegCurvetoCubicRel : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
		float X1{get;set;}
		float Y1{get;set;}
		float X2{get;set;}
		float Y2{get;set;}
	}
}