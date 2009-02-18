using System;
using System.Drawing.Drawing2D;

namespace SharpVectors.Dom.Svg
{
	/// <summary>
	/// This is an extension to the Svg DOM. It denotes that an element has a
	/// drawable shape.
	/// </summary>
	/// <remarks>
	/// To give an Svg element the capability to be drawn, let the Svg
	/// element implement this interface.  To implement this interface,
	/// the element needs to maintain a
	/// <see cref="GraphicsPath">GraphicsPath</see>
	/// object that is populated with drawing information.  The
	/// <see cref="GraphicsPath">GraphicsPath</see>
	/// object should be returned from
	/// <see cref="GetGraphicsPath">GetGraphicsPath</see> method and
	/// invalidated with the
	/// <see cref="Invalidate">Invalidate</see> method.
	/// </remarks>
	/// <developer>niklas@protocol7.com</developer>
	/// <completed>50</completed>
	public interface ISharpGDIPath
	{
		/// <summary>
		/// Returns the
		/// <see cref="GraphicsPath">GraphicsPath</see>
		/// object that describes the shape
		/// of the SvgElement.
		/// </summary>
		GraphicsPath GetGraphicsPath();
		
		/// <summary>
		/// Invalidates the
		/// <see cref="GetGraphicsPath">GetGraphicsPath</see>
		/// object.
		/// </summary>
		/// <remarks>
		/// When this method is called, the object will remove the stored
		/// reference to the <see cref="GraphicsPath">GraphicsPath</see>
		/// so that the next call to
		/// <see cref="GetGraphicsPath">GetGraphicsPath</see> will generate
		/// a new <see cref="GraphicsPath">GraphicsPath</see> object.
		/// </remarks>
		void Invalidate();
	}
}
