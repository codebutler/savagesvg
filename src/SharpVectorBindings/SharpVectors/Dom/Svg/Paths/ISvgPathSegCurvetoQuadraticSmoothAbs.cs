using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegCurvetoQuadraticSmoothAbs interface corresponds to an "absolute smooth quadratic curveto" (T) path data command.
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegCurvetoQuadraticSmoothAbs : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
	}
}