using System;
using System.Xml;
using System.Drawing;

using SharpVectors.Dom.Svg;

namespace SharpVectors.Dom.Svg.Rendering
{

  public delegate void RenderEvent(RectangleF updatedRect);
  
  /// <summary>
	/// Defines the interface required by a renderer to render the SVG DOM.
	/// </summary>
	/// <remarks>
	/// The <see cref="ISvgRenderer">ISvgRenderer</see> is used to render
	/// a <see cref="SvgElement">SvgElement</see> object onto a bitmap.
	/// During the rendering process, it will also generate
	/// <see cref="RenderingNode">RenderingNode</see> objects for each
	/// <see cref="XmlElement">XmlElement</see> object in the DOM tree to
	/// assist in the rendering.
	/// </remarks>
    /// <developer>kevin@kevlindev.com</developer>
    /// <completed>0</completed>
	public interface ISvgRenderer
	{
        /// <summary>
        /// The window that is being rendered to.
        /// </summary>
		ISvgWindow Window
		{
			get;
			set;
		}
		
		/// <summary>
		/// Creates a <see cref="RenderingNode">RenderingNode</see> for
		/// <c>node</c> so that it may be rendered.
		/// </summary>
		/// <param name="node">
		/// The <see cref="XmlEleemnt">XmlElement</see> object for which
		/// the <see cref="RenderingNode">RenderingNode</see> object is
		/// created.
		/// </param>
		/// <returns>
		/// A new <see cref="RenderingNode">RenderingNode</see> object
		/// which can be used to render <c>node</c>.
		/// </returns>
		RenderingNode GetRenderingNode(
			ISvgElement node);
		
        /// <summary>
        /// Creates a new <see cref="ISvgRenderer">ISvgRenderer</see> object.
        /// This method is not used.
        /// </summary>
		ISvgRenderer GetRenderer();
		
		/// <summary>
		/// Renders an <see cref="SvgElement">SvgElement</see> object onto a
		/// bitmap and returns that bitmap.
		/// </summary>
		/// <param name="node">
		/// The SvgElement object to be rendered.
		/// </param>
		/// <returns>
		/// A bitmap with <c>node</c> rendered onto it.
		/// </returns>
		Bitmap Render(
			ISvgElement node);
		
		/// <summary>
		/// Renders an <see cref="SvgDocument">SvgDocument</see> object onto
		/// a bitmap and returns that bitmap.
		/// </summary>
		/// <param name="node">
		/// The SvgDocument object to be rendered.
		/// </param>
		/// <returns>
		/// A bitmap with <c>node</c> rendered onto it.
		/// </returns>
		Bitmap Render(
			ISvgDocument node);

    /// <summary>
    /// Controls the rendering of the document.  
    /// </summary>
    RectangleF InvalidRect 
    {
      get; set;           
    }

    /// <summary>
    /// Allows you to establish or add to the existing invalidation rectangle
    /// </summary>
    /// <param name="rect"></param>
    void InvalidateRect(RectangleF rect);
    

    /// <summary>
    /// Event Delegate to report when the SVG renderer does it's work.
    /// </summary>
    RenderEvent OnRender 
    {
      get; set;     
    }
	}
}
