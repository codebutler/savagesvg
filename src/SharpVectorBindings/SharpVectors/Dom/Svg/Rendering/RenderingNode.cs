using System;
using System.Drawing;
using SharpVectors.Dom.Svg;

namespace SharpVectors.Dom.Svg.Rendering
{
  /// <summary>
  /// Defines the interface required for a rendering node to interact with the renderer and the SVG DOM
  /// </summary>
  /// <developer>kevin@kevlindev.com</developer>
  /// <completed>0</completed>
  public abstract class RenderingNode
  {
    #region Fields
    protected ISvgElement element;
    #endregion
        
    protected RenderingNode(ISvgElement element) 
    {
      this.element = element;
    }

    public ISvgElement Element
    {
      get{return element;}
    }

    protected RectangleF screenRegion = RectangleF.Empty;
    public RectangleF ScreenRegion
    {
      get { return screenRegion; }
      set { screenRegion = value; }
    }

    public virtual bool NeedRender(ISvgRenderer renderer) 
    {
      // We make this assumption so that the first pass is still fast
      // That way we don't have to calculate the screen regions
      // Before a full rerender
      if (screenRegion == RectangleF.Empty) 
        return true;
      if (renderer.InvalidRect == RectangleF.Empty)
        return true;
      if (renderer.InvalidRect.IntersectsWith(screenRegion))
        // TODO: Eventually add a full path check here?
        return true;

      return false;
    }
      
    // define empty handlers by default
    public virtual void BeforeRender(ISvgRenderer renderer) {}
    public virtual void Render(ISvgRenderer renderer) {}
    public virtual void AfterRender(ISvgRenderer renderer) {}

  }
}


