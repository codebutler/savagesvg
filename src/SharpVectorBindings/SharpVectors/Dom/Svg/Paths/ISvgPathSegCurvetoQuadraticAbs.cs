using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegCurvetoQuadraticAbs interface corresponds to an "absolute quadratic Bézier curveto" (Q) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegCurvetoQuadraticAbs : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
		float X1{get;set;}
		float Y1{get;set;}
	}
}