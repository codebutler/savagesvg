using System;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// This is an extension to the Svg DOM.  It denotes that an element
	/// shouldn't be painted.
	/// </summary>
	/// <remarks>
	/// To prevent an Svg element from being painted, let the Svg
	/// element implement this interface.
	/// </remarks>
	public interface ISharpDoNotPaint
	{
	}
}
