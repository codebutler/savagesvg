using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegMovetoAbs interface corresponds to an "absolute moveto" (M) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegMovetoAbs : ISvgPathSeg
	{
		float X{get;set;}
		float Y{get;set;}
	}
}
