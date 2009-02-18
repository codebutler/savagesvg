using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// The SvgPathSegArcAbs interface corresponds to an "absolute arcto" (A) path data command. 
	/// </summary>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>100</completed>
	public interface ISvgPathSegArcAbs : ISvgPathSeg 
	{
		float X{get;set;}
		float Y{get;set;}
		float R1{get;set;}
		float R2{get;set;}
		float Angle{get;set;}
		bool LargeArcFlag{get;set;}
		bool SweepFlag{get;set;}
	}
}
