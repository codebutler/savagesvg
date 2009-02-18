using System;
using System.Xml;
using System.Drawing;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Svg.Rendering;

namespace SharpVectors.Dom.Svg
{
  /// <summary>
  /// Summary description for SvgElement.
  /// </summary>
  /// <developer>niklas@protocol7.com</developer>
  /// <developer>kevin@kevlindev.com</developer>
  /// <completed>75</completed>
  public class SvgElement : CssXmlElement, ISvgElement
  {
    #region Constructors
    protected internal SvgElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
    {
    }
    #endregion

    #region Rendering 
    protected RenderingNode renderingNode;
    public RenderingNode RenderingNode
    {
      get{return renderingNode;}
    }

    public virtual void CacheRenderingRegion(ISvgRenderer renderer) 
    {
      if(renderingNode == null)
      {
        renderingNode = renderer.GetRenderingNode(this);
      }

      // Check if it has already been calculated
      if (renderingNode != null && renderingNode.ScreenRegion != RectangleF.Empty)
        return;

      // Invalidate the children
      foreach (XmlNode node in ChildNodes ) 
      {
        SvgElement element = node as SvgElement;
        if (element != null)
        {
          element.CacheRenderingRegion(renderer);
        }
      }
    }

    public virtual void InvalidateRenderingRegion() 
    {
      if (renderingNode != null)
        renderingNode.ScreenRegion = RectangleF.Empty;

      // Invalidate the children
      foreach (XmlNode node in ChildNodes ) 
      {
        SvgElement element = node as SvgElement;
        if (element != null)
        {
          element.InvalidateRenderingRegion();
        }
      }
    }

    public virtual void Render(ISvgRenderer renderer)
    {
      if ( !(this is ISharpDoNotPaint) || (this is SvgSymbolElement && this.ParentNode is SvgUseElement)) 
      {
        if (renderingNode == null)
        {
          renderingNode = renderer.GetRenderingNode(this);
        }
        if (renderingNode !=  null) 
        {
          if (!renderingNode.NeedRender(renderer)) return;
          renderingNode.BeforeRender(renderer);				
          renderingNode.Render(renderer);
          RenderChildren(renderer);
          renderingNode.AfterRender(renderer);
        }
      }
    }

    public virtual void RenderChildren(ISvgRenderer renderer)
    {
      foreach ( XmlNode node in ChildNodes ) 
      {
        SvgElement element = node as SvgElement;
        if ( element != null )
        {
          element.Render(renderer);
        }
      }
    }
    #endregion
		
    #region Implementation of ISvgElement
    public new SvgDocument OwnerDocument
    {
      get
      {
        return base.OwnerDocument as SvgDocument;
      }
    }

    public string Id
    {
      get
      {
        return GetAttribute("id");
      }
      set
      {
        SetAttribute("id",value);
      }
    }

    public ISvgSvgElement OwnerSvgElement
    {
      get
      {
        if(this.Equals(OwnerDocument.DocumentElement))
        {
          return null;
        }
        else
        {
          XmlNode parent = ParentNode;
          while(parent != null && !(parent is SvgSvgElement))
          {
            parent = parent.ParentNode;
          }
          return parent as SvgSvgElement;
        }
      }
    }

    public ISvgElement ViewportElement
    {
      get
      {
        if(this.Equals(OwnerDocument.DocumentElement))
        {
          return null;
        }
        else
        {
          XmlNode parent = ParentNode;
          while(parent != null && !(parent is SvgSvgElement) &&!(parent is SvgSymbolElement) )
          {
            parent = parent.ParentNode;
          }
          return parent as SvgElement;
        }
      }
    }
    #endregion

    #region Implementation of ISvgLangSpace
    public string XmlSpace
    {
      get
      {
        string s = GetAttribute("xml:space");
        if(s.Length == 0)
        {
          if(ParentNode is SvgElement)
          {
            SvgElement par = (SvgElement) ParentNode;
            s = par.XmlSpace;
          }
          else s = "default";
        }
				
        return s;
      }
      set 
      {
        SetAttribute("xml:space", value);
      }
    }

    public string XmlLang
    {
      get
      {
        string s = this.GetAttribute("xml:lang");
        if(s.Length == 0)
        {
          if(ParentNode is SvgElement)
          {
            SvgElement par = (SvgElement) ParentNode;
            s = par.XmlLang;
          }
          else s = String.Empty;
        }
				
        return s;
      }
      set
      {
        this.SetAttribute("xml:lang", value);
      }
    }
    #endregion

    #region Other public methods
    public string ResolveUri(string uri)
    {
      uri = uri.Trim();
      if(uri.StartsWith("#"))
      {
        return uri;
      }
      else
      {
        string baseUri = BaseURI;
        if(baseUri.Length == 0)
        {
          return uri;
        }
        else
        {
          return new Uri(new Uri(baseUri), uri).AbsoluteUri;
        }
      }
    }

    private ISvgElementInstance elementInstance = null;
    /// <summary>
    /// Whenever an SvgElementInstance is created for an SvgElement this
    /// property is set. The value of this property is used by the renderer 
    /// to dispatch events. SvgElements that are &lt;use&gt;d exist in a 
    /// conceptual "instance tree" and the target of events for those elements
    /// is the conceptual instance node represented by the SvgElementInstance.
    /// <see cref="http://www.w3.org/TR/SVG/struct.html#UseElement"/>
    /// <see cref="http://www.w3.org/TR/SVG/struct.html#InterfaceSVGElementInstance"/>
    /// </summary>
    public ISvgElementInstance ElementInstance 
    {
      get 
      {
        return elementInstance;
      }
      set 
      {
        elementInstance = value;
      }
    }
    #endregion
}
}
