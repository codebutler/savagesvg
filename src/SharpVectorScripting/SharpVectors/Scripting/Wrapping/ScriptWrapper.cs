using System;
using System.Collections;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Views;
using SharpVectors.Xml;
using SharpVectors.Collections;

namespace SharpVectors.Scripting
{
  /// 
  /// Base class for all wrappers
  /// 
  public class ScriptableObject
  {
    internal object baseObject = null;

    /// <summary>
    /// Base constructor, if used you must assign the baseObject after the call.
    /// This constructor should only be called internally. Higher order classes should construct
    /// new wrappers using the CreateWrapper function to allow for type lookups.
    /// </summary>
    public ScriptableObject()
    {
      this.baseObject = null;
    }

    /// <summary>
    /// Base constructor, accepts the baseObject that will be wrapped with all inherited calls. 
    /// This constructor should only be called internally. Higher order classes should construct
    /// new wrappers using the CreateWrapper function to allow for type lookups.
    /// </summary>
    /// <param name="baseObject">The object to wrap with a scriptable object.</param>
    public ScriptableObject(object baseObject)
    {
      this.baseObject = baseObject;
    }

    ~ScriptableObject() 
    {
      // We need to remove the item from the global hash table
      ScriptableObject.RemoveWrapper(baseObject);
    }

    private static Object[] args = new Object[1];
    private static Hashtable wrappers = new Hashtable();
    
    /// <summary>
    /// Creates a new scriptable wrapper for the specified object. Use this function instead
    /// of calling the ScriptableObject constructor.
    /// </summary>
    /// <param name="wrappableObject">The object to wrap. It's type will be used as a key
    /// in a lookup for creating the correct wrappable type.</param>
    /// <returns>A new scriptable object that has been created with a type corresponding
    /// to the wrappableObject's type.</returns>
    public static ScriptableObject CreateWrapper(object wrappableObject) 
    {
      // return null if we get null
      if (wrappableObject == null)
        return null;

      // Check that the static table is built
      if (wrapperTypes == null) 
        InitializeWrapperTypes();

      // Do we already have a wrapper for this object?
      WeakReference weak = (WeakReference)wrappers[wrappableObject];
      ScriptableObject so = null;
      if (weak != null) 
      {
        so = (ScriptableObject)weak.Target;
        if (so != null)
          return so;
      }

      // Return a new instance
      try 
      {
        // Normal
        try 
        {
          args[0] = wrappableObject;
          so = (ScriptableObject)wrapperTypes.CreateInstance(wrappableObject.GetType().Name, args);
          wrappers[wrappableObject] = new WeakReference(so);
          return so;
        }
        catch (Exception) 
        {
          // Try the ancestor
          so = (ScriptableObject)wrapperTypes.CreateInstance(wrappableObject.GetType().BaseType.Name, args);
          wrappers[wrappableObject] = new WeakReference(so);        
          return so;
        }
      } 
      catch(Exception e)
      {
         throw new SvgException(SvgExceptionType.SvgWrongTypeErr, "Could not create wrappable type for " + wrappableObject.GetType().FullName, e);
      }

    }

    /// <summary>
    /// Removes the wrapper and base object key value pair. This function is called by the ScriptableObject destructor.
    /// </summary>
    /// <param name="wrappableObject">The key object that was wrapped, to be removed.</param>
    public static void RemoveWrapper(object wrappableObject) 
    {
      if (wrappableObject == null)
        return;

      // Remove it
      wrappers.Remove(wrappableObject);
    }

    // The table of key types to wrappable type values
    private static TypeDictionary wrapperTypes = null;

    /// <summary>
    /// Builds the wrapper type table for static lookups
    /// </summary>
    private static void InitializeWrapperTypes() 
    {
      wrapperTypes = new TypeDictionary();
      
      // CSS Types
      wrapperTypes[typeof(CssRuleList).Name] = typeof(ScriptableCssRuleList);
      wrapperTypes[typeof(CssRule).Name] = typeof(ScriptableCssRule);
      wrapperTypes[typeof(CssStyleRule).Name] = typeof(ScriptableCssStyleRule);
      wrapperTypes[typeof(CssMediaRule).Name] = typeof(ScriptableCssMediaRule);
      wrapperTypes[typeof(CssFontFaceRule).Name] = typeof(ScriptableCssFontFaceRule);
      wrapperTypes[typeof(CssPageRule).Name] = typeof(ScriptableCssPageRule);
      wrapperTypes[typeof(CssImportRule).Name] = typeof(ScriptableCssImportRule);
      wrapperTypes[typeof(CssCharsetRule).Name] = typeof(ScriptableCssCharsetRule);
      wrapperTypes[typeof(CssUnknownRule).Name] = typeof(ScriptableCssUnknownRule);
      wrapperTypes[typeof(CssStyleDeclaration).Name] = typeof(ScriptableCssStyleDeclaration);
      wrapperTypes[typeof(CssValue).Name] = typeof(ScriptableCssValue);
      wrapperTypes[typeof(CssPrimitiveValue).Name] = typeof(ScriptableCssPrimitiveValue);
      //TODO wrapperTypes[typeof(CssValueList).Name] = typeof(ScriptableCssValueList);
      wrapperTypes[typeof(RgbColor).Name] = typeof(ScriptableRgbColor);
      wrapperTypes[typeof(Rect).Name] = typeof(ScriptableRect);
      //TODO wrapperTypes[typeof(Counter).Name] = typeof(ScriptableCounter);
      //TODO wrapperTypes[typeof(ElementCssInlineStyle).Name] = typeof(ScriptableElementCssInlineStyle);
      //TODO wrapperTypes[typeof(Css2Properties).Name] = typeof(ScriptableCss2Properties);
      wrapperTypes[typeof(CssStyleSheet).Name] = typeof(ScriptableCssStyleSheet);
      //TODO wrapperTypes[typeof(ViewCss).Name] = typeof(ScriptableViewCss);
      //TODO wrapperTypes[typeof(DocumentCss).Name] = typeof(ScriptableDocumentCss);
      //TODO wrapperTypes[typeof(DomImplementationCss).Name] = typeof(ScriptableDomImplementationCss);
    
      // DOM Types
      wrapperTypes[typeof(SharpVectors.Dom.DomImplementation).Name] = typeof(ScriptableDomImplementation);
      wrapperTypes[typeof(System.Xml.XmlNode).Name] = typeof(ScriptableNode);
      wrapperTypes[typeof(SharpVectors.Dom.NodeListAdapter).Name] = typeof(ScriptableNodeList);
      wrapperTypes[typeof(System.Xml.XmlNodeList).Name] = typeof(ScriptableNodeList);
      wrapperTypes[typeof(SharpVectors.Dom.NodeListAdapter).Name] = typeof(ScriptableNodeList);
      wrapperTypes[typeof(System.Xml.XmlNamedNodeMap).Name] = typeof(ScriptableNamedNodeMap);
      wrapperTypes[typeof(System.Xml.XmlCDataSection).Name] = typeof(ScriptableCharacterData);
      wrapperTypes[typeof(SharpVectors.Dom.Attribute).Name] = typeof(ScriptableAttr);
      wrapperTypes[typeof(SharpVectors.Dom.Element).Name] = typeof(ScriptableElement);
      wrapperTypes[typeof(SharpVectors.Dom.Text).Name] = typeof(ScriptableText);
      wrapperTypes[typeof(SharpVectors.Dom.Comment).Name] = typeof(ScriptableComment);
      wrapperTypes[typeof(SharpVectors.Dom.CDataSection).Name] = typeof(ScriptableCDataSection);
      wrapperTypes[typeof(SharpVectors.Dom.DocumentType).Name] = typeof(ScriptableDocumentType);
      wrapperTypes[typeof(System.Xml.XmlNotation).Name] = typeof(ScriptableNotation);
      wrapperTypes[typeof(System.Xml.XmlEntity).Name] = typeof(ScriptableEntity);
      wrapperTypes[typeof(SharpVectors.Dom.EntityReference).Name] = typeof(ScriptableEntityReference);
      wrapperTypes[typeof(SharpVectors.Dom.ProcessingInstruction).Name] = typeof(ScriptableProcessingInstruction);
      wrapperTypes[typeof(SharpVectors.Dom.DocumentFragment).Name] = typeof(ScriptableDocumentFragment);
      wrapperTypes[typeof(SharpVectors.Dom.Document).Name] = typeof(ScriptableDocument);

      // Events Types
      wrapperTypes[typeof(EventTarget).Name] = typeof(ScriptableEventTarget);
      //TODO wrapperTypes[typeof(EventListener).Name] = typeof(ScriptableEventListener);
      wrapperTypes[typeof(Event).Name] = typeof(ScriptableEvent);
      //TODO, I think this is handled under Document: wrapperTypes[typeof(DocumentEvent).Name] = typeof(ScriptableDocumentEvent);
      wrapperTypes[typeof(UiEvent).Name] = typeof(ScriptableUiEvent);
      wrapperTypes[typeof(MouseEvent).Name] = typeof(ScriptableMouseEvent);
      wrapperTypes[typeof(MutationEvent).Name] = typeof(ScriptableMutationEvent);
      wrapperTypes[typeof(IUiEvent).Name] = typeof(ScriptableUiEvent);
      wrapperTypes[typeof(IMouseEvent).Name] = typeof(ScriptableMouseEvent);
      wrapperTypes[typeof(IMutationEvent).Name] = typeof(ScriptableMutationEvent);
    
      // SMIL Types
      //TODO wrapperTypes[typeof(ElementTimeControl).Name] = typeof(ScriptableElementTimeControl);
      //TODO wrapperTypes[typeof(TimeEvent).Name] = typeof(ScriptableTimeEvent);

      // StyleSheets Types
      wrapperTypes[typeof(StyleSheet).Name] = typeof(ScriptableStyleSheet);
      wrapperTypes[typeof(StyleSheetList).Name] = typeof(ScriptableStyleSheetList);
      wrapperTypes[typeof(MediaList).Name] = typeof(ScriptableMediaList);
      //TODO wrapperTypes[typeof(LinkStyle).Name] = typeof(ScriptableLinkStyle);
      //TODO wrapperTypes[typeof(DocumentStyle).Name] = typeof(ScriptableDocumentStyle);

      // SVG Types
      wrapperTypes[typeof(SvgElement).Name] = typeof(ScriptableSvgElement);
      wrapperTypes[typeof(SvgAnimatedBoolean).Name] = typeof(ScriptableSvgAnimatedBoolean);
      wrapperTypes[typeof(SvgAnimatedString).Name] = typeof(ScriptableSvgAnimatedString);
      wrapperTypes[typeof(SvgStringList).Name] = typeof(ScriptableSvgStringList);
      wrapperTypes[typeof(SvgAnimatedEnumeration).Name] = typeof(ScriptableSvgAnimatedEnumeration);
      //TODO wrapperTypes[typeof(SvgAnimatedInteger).Name] = typeof(ScriptableSvgAnimatedInteger);
      wrapperTypes[typeof(SvgNumber).Name] = typeof(ScriptableSvgNumber);
      wrapperTypes[typeof(SvgAnimatedNumber).Name] = typeof(ScriptableSvgAnimatedNumber);
      wrapperTypes[typeof(SvgNumberList).Name] = typeof(ScriptableSvgNumberList);
      wrapperTypes[typeof(SvgAnimatedNumberList).Name] = typeof(ScriptableSvgAnimatedNumberList);
      wrapperTypes[typeof(SvgLength).Name] = typeof(ScriptableSvgLength);
      wrapperTypes[typeof(SvgAnimatedLength).Name] = typeof(ScriptableSvgAnimatedLength);
      wrapperTypes[typeof(SvgLengthList).Name] = typeof(ScriptableSvgLengthList);
      wrapperTypes[typeof(SvgAnimatedLengthList).Name] = typeof(ScriptableSvgAnimatedLengthList);
      wrapperTypes[typeof(SvgAngle).Name] = typeof(ScriptableSvgAngle);
      wrapperTypes[typeof(SvgAnimatedAngle).Name] = typeof(ScriptableSvgAnimatedAngle);
      wrapperTypes[typeof(SvgColor).Name] = typeof(ScriptableSvgColor);
      //TODO wrapperTypes[typeof(SvgIccColor).Name] = typeof(ScriptableSvgIccColor);
      wrapperTypes[typeof(SvgRect).Name] = typeof(ScriptableSvgRect);
      wrapperTypes[typeof(SvgAnimatedRect).Name] = typeof(ScriptableSvgAnimatedRect);
      //No Type information wrapperTypes[typeof(SvgUnitTypes).Name] = typeof(ScriptableSvgUnitTypes);
      wrapperTypes[typeof(SvgStyleableElement).Name] = typeof(ScriptableSvgStylable);
      //TODO wrapperTypes[typeof(SvgLocatable).Name] = typeof(ScriptableSvgLocatable);
      wrapperTypes[typeof(SvgTransformableElement).Name] = typeof(ScriptableSvgTransformable);
      wrapperTypes[typeof(SvgTests).Name] = typeof(ScriptableSvgTests);
      //TODO wrapperTypes[typeof(SvgLangSpace).Name] = typeof(ScriptableSvgLangSpace);
      wrapperTypes[typeof(SvgExternalResourcesRequired).Name] = typeof(ScriptableSvgExternalResourcesRequired);
      wrapperTypes[typeof(SvgFitToViewBox).Name] = typeof(ScriptableSvgFitToViewBox);
      wrapperTypes[typeof(SvgZoomAndPan).Name] = typeof(ScriptableSvgZoomAndPan);
      wrapperTypes[typeof(SvgViewSpec).Name] = typeof(ScriptableSvgViewSpec);
      wrapperTypes[typeof(SvgURIReference).Name] = typeof(ScriptableSvgUriReference);
      //No Type information wrapperTypes[typeof(SvgCssRule).Name] = typeof(ScriptableSvgCssRule);
      //No Type information wrapperTypes[typeof(SvgRenderingIntent).Name] = typeof(ScriptableSvgRenderingIntent);
      wrapperTypes[typeof(SvgDocument).Name] = typeof(ScriptableSvgDocument);
      wrapperTypes[typeof(SvgSvgElement).Name] = typeof(ScriptableSvgSvgElement);
      wrapperTypes[typeof(SvgGElement).Name] = typeof(ScriptableSvgGElement);
      wrapperTypes[typeof(SvgDefsElement).Name] = typeof(ScriptableSvgDefsElement);
      wrapperTypes[typeof(SvgDescElement).Name] = typeof(ScriptableSvgDescElement);
      wrapperTypes[typeof(SvgTitleElement).Name] = typeof(ScriptableSvgTitleElement);
      wrapperTypes[typeof(SvgSymbolElement).Name] = typeof(ScriptableSvgSymbolElement);
      wrapperTypes[typeof(SvgUseElement).Name] = typeof(ScriptableSvgUseElement);
      wrapperTypes[typeof(SvgElementInstance).Name] = typeof(ScriptableSvgElementInstance);
      wrapperTypes[typeof(SvgElementInstanceList).Name] = typeof(ScriptableSvgElementInstanceList);
      wrapperTypes[typeof(SvgImageElement).Name] = typeof(ScriptableSvgImageElement);
      wrapperTypes[typeof(SvgSwitchElement).Name] = typeof(ScriptableSvgSwitchElement);
      //TODO wrapperTypes[typeof(GetSvgDocument).Name] = typeof(ScriptableGetSvgDocument);
      //TODO wrapperTypes[typeof(SvgStyleElement).Name] = typeof(ScriptableSvgStyleElement);
      wrapperTypes[typeof(SvgPoint).Name] = typeof(ScriptableSvgPoint);
      wrapperTypes[typeof(SvgPointList).Name] = typeof(ScriptableSvgPointList);
      wrapperTypes[typeof(SvgMatrix).Name] = typeof(ScriptableSvgMatrix);
      wrapperTypes[typeof(SvgTransform).Name] = typeof(ScriptableSvgTransform);
      wrapperTypes[typeof(SvgTransformList).Name] = typeof(ScriptableSvgTransformList);
      wrapperTypes[typeof(SvgAnimatedTransformList).Name] = typeof(ScriptableSvgAnimatedTransformList);
      wrapperTypes[typeof(SvgPreserveAspectRatio).Name] = typeof(ScriptableSvgPreserveAspectRatio);
      wrapperTypes[typeof(SvgAnimatedPreserveAspectRatio).Name] = typeof(ScriptableSvgAnimatedPreserveAspectRatio);
      wrapperTypes[typeof(SvgPathSeg).Name] = typeof(ScriptableSvgPathSeg);
      wrapperTypes[typeof(SvgPathSegClosePath).Name] = typeof(ScriptableSvgPathSegClosePath);
      wrapperTypes[typeof(SvgPathSegMovetoAbs).Name] = typeof(ScriptableSvgPathSegMovetoAbs);
      wrapperTypes[typeof(SvgPathSegMovetoRel).Name] = typeof(ScriptableSvgPathSegMovetoRel);
      wrapperTypes[typeof(SvgPathSegLinetoAbs).Name] = typeof(ScriptableSvgPathSegLinetoAbs);
      wrapperTypes[typeof(SvgPathSegLinetoRel).Name] = typeof(ScriptableSvgPathSegLinetoRel);
      wrapperTypes[typeof(SvgPathSegCurvetoCubicAbs).Name] = typeof(ScriptableSvgPathSegCurvetoCubicAbs);
      wrapperTypes[typeof(SvgPathSegCurvetoCubicRel).Name] = typeof(ScriptableSvgPathSegCurvetoCubicRel);
      wrapperTypes[typeof(SvgPathSegCurvetoQuadraticAbs).Name] = typeof(ScriptableSvgPathSegCurvetoQuadraticAbs);
      wrapperTypes[typeof(SvgPathSegCurvetoQuadraticRel).Name] = typeof(ScriptableSvgPathSegCurvetoQuadraticRel);
      wrapperTypes[typeof(SvgPathSegArcAbs).Name] = typeof(ScriptableSvgPathSegArcAbs);
      wrapperTypes[typeof(SvgPathSegArcRel).Name] = typeof(ScriptableSvgPathSegArcRel);
      wrapperTypes[typeof(SvgPathSegLinetoHorizontalAbs).Name] = typeof(ScriptableSvgPathSegLinetoHorizontalAbs);
      wrapperTypes[typeof(SvgPathSegLinetoHorizontalRel).Name] = typeof(ScriptableSvgPathSegLinetoHorizontalRel);
      wrapperTypes[typeof(SvgPathSegLinetoVerticalAbs).Name] = typeof(ScriptableSvgPathSegLinetoVerticalAbs);
      wrapperTypes[typeof(SvgPathSegLinetoVerticalRel).Name] = typeof(ScriptableSvgPathSegLinetoVerticalRel);
      wrapperTypes[typeof(SvgPathSegCurvetoCubicSmoothAbs).Name] = typeof(ScriptableSvgPathSegCurvetoCubicSmoothAbs);
      wrapperTypes[typeof(SvgPathSegCurvetoCubicSmoothRel).Name] = typeof(ScriptableSvgPathSegCurvetoCubicSmoothRel);
      wrapperTypes[typeof(SvgPathSegCurvetoQuadraticSmoothAbs).Name] = typeof(ScriptableSvgPathSegCurvetoQuadraticSmoothAbs);
      wrapperTypes[typeof(SvgPathSegCurvetoQuadraticSmoothRel).Name] = typeof(ScriptableSvgPathSegCurvetoQuadraticSmoothRel);
      wrapperTypes[typeof(SvgPathSegList).Name] = typeof(ScriptableSvgPathSegList);
      //TODO wrapperTypes[typeof(SvgAnimatedPathData).Name] = typeof(ScriptableSvgAnimatedPathData);
      wrapperTypes[typeof(SvgPathElement).Name] = typeof(ScriptableSvgPathElement);
      wrapperTypes[typeof(SvgRectElement).Name] = typeof(ScriptableSvgRectElement);
      wrapperTypes[typeof(SvgCircleElement).Name] = typeof(ScriptableSvgCircleElement);
      wrapperTypes[typeof(SvgEllipseElement).Name] = typeof(ScriptableSvgEllipseElement);
      wrapperTypes[typeof(SvgLineElement).Name] = typeof(ScriptableSvgLineElement);
      //TODO wrapperTypes[typeof(SvgAnimatedPoints).Name] = typeof(ScriptableSvgAnimatedPoints);
      wrapperTypes[typeof(SvgPolylineElement).Name] = typeof(ScriptableSvgPolylineElement);
      wrapperTypes[typeof(SvgPolygonElement).Name] = typeof(ScriptableSvgPolygonElement);
      wrapperTypes[typeof(SvgTextContentElement).Name] = typeof(ScriptableSvgTextContentElement);
      wrapperTypes[typeof(SvgTextPositioningElement).Name] = typeof(ScriptableSvgTextPositioningElement);
      wrapperTypes[typeof(SvgTextElement).Name] = typeof(ScriptableSvgTextElement);
      wrapperTypes[typeof(SvgTSpanElement).Name] = typeof(ScriptableSvgTSpanElement);
      wrapperTypes[typeof(SvgTRefElement).Name] = typeof(ScriptableSvgTRefElement);
      //TODO wrapperTypes[typeof(SvgTextPathElement).Name] = typeof(ScriptableSvgTextPathElement);
      //TODO wrapperTypes[typeof(SvgAltGlyphElement).Name] = typeof(ScriptableSvgAltGlyphElement);
      //TODO wrapperTypes[typeof(SvgAltGlyphDefElement).Name] = typeof(ScriptableSvgAltGlyphDefElement);
      //TODO wrapperTypes[typeof(SvgAltGlyphItemElement).Name] = typeof(ScriptableSvgAltGlyphItemElement);
      //TODO wrapperTypes[typeof(SvgGlyphRefElement).Name] = typeof(ScriptableSvgGlyphRefElement);
      wrapperTypes[typeof(SvgPaint).Name] = typeof(ScriptableSvgPaint);
      wrapperTypes[typeof(SvgMarkerElement).Name] = typeof(ScriptableSvgMarkerElement);
      //TODO wrapperTypes[typeof(SvgColorProfileElement).Name] = typeof(ScriptableSvgColorProfileElement);
      //TODO wrapperTypes[typeof(SvgColorProfileRule).Name] = typeof(ScriptableSvgColorProfileRule);
      wrapperTypes[typeof(SvgGradientElement).Name] = typeof(ScriptableSvgGradientElement);
      wrapperTypes[typeof(SvgLinearGradientElement).Name] = typeof(ScriptableSvgLinearGradientElement);
      wrapperTypes[typeof(SvgRadialGradientElement).Name] = typeof(ScriptableSvgRadialGradientElement);
      wrapperTypes[typeof(SvgStopElement).Name] = typeof(ScriptableSvgStopElement);
      wrapperTypes[typeof(SvgPatternElement).Name] = typeof(ScriptableSvgPatternElement);
      wrapperTypes[typeof(SvgClipPathElement).Name] = typeof(ScriptableSvgClipPathElement);
      wrapperTypes[typeof(SvgMaskElement).Name] = typeof(ScriptableSvgMaskElement);
      wrapperTypes[typeof(SvgFilterElement).Name] = typeof(ScriptableSvgFilterElement);
      //TODO wrapperTypes[typeof(SvgFilterPrimitiveStandardAttributes).Name] = typeof(ScriptableSvgFilterPrimitiveStandardAttributes);
      //TODO wrapperTypes[typeof(SvgFEBlendElement).Name] = typeof(ScriptableSvgFEBlendElement);
      //TODO wrapperTypes[typeof(SvgFEColorMatrixElement).Name] = typeof(ScriptableSvgFEColorMatrixElement);
      //TODO wrapperTypes[typeof(SvgFEComponentTransferElement).Name] = typeof(ScriptableSvgFEComponentTransferElement);
      //TODO wrapperTypes[typeof(SvgComponentTransferFunctionElement).Name] = typeof(ScriptableSvgComponentTransferFunctionElement);
      //TODO wrapperTypes[typeof(SvgFEFuncRElement).Name] = typeof(ScriptableSvgFEFuncRElement);
      //TODO wrapperTypes[typeof(SvgFEFuncGElement).Name] = typeof(ScriptableSvgFEFuncGElement);
      //TODO wrapperTypes[typeof(SvgFEFuncBElement).Name] = typeof(ScriptableSvgFEFuncBElement);
      //TODO wrapperTypes[typeof(SvgFEFuncAElement).Name] = typeof(ScriptableSvgFEFuncAElement);
      //TODO wrapperTypes[typeof(SvgFECompositeElement).Name] = typeof(ScriptableSvgFECompositeElement);
      //TODO wrapperTypes[typeof(SvgFEConvolveMatrixElement).Name] = typeof(ScriptableSvgFEConvolveMatrixElement);
      //TODO wrapperTypes[typeof(SvgFEDiffuseLightingElement).Name] = typeof(ScriptableSvgFEDiffuseLightingElement);
      //TODO wrapperTypes[typeof(SvgFEDistantLightElement).Name] = typeof(ScriptableSvgFEDistantLightElement);
      //TODO wrapperTypes[typeof(SvgFEPointLightElement).Name] = typeof(ScriptableSvgFEPointLightElement);
      //TODO wrapperTypes[typeof(SvgFESpotLightElement).Name] = typeof(ScriptableSvgFESpotLightElement);
      //TODO wrapperTypes[typeof(SvgFEDisplacementMapElement).Name] = typeof(ScriptableSvgFEDisplacementMapElement);
      //TODO wrapperTypes[typeof(SvgFEFloodElement).Name] = typeof(ScriptableSvgFEFloodElement);
      //TODO wrapperTypes[typeof(SvgFEGaussianBlurElement).Name] = typeof(ScriptableSvgFEGaussianBlurElement);
      //TODO wrapperTypes[typeof(SvgFEImageElement).Name] = typeof(ScriptableSvgFEImageElement);
      //TODO wrapperTypes[typeof(SvgFEMergeElement).Name] = typeof(ScriptableSvgFEMergeElement);
      //TODO wrapperTypes[typeof(SvgFEMergeNodeElement).Name] = typeof(ScriptableSvgFEMergeNodeElement);
      //TODO wrapperTypes[typeof(SvgFEMorphologyElement).Name] = typeof(ScriptableSvgFEMorphologyElement);
      //TODO wrapperTypes[typeof(SvgFEOffsetElement).Name] = typeof(ScriptableSvgFEOffsetElement);
      //TODO wrapperTypes[typeof(SvgFESpecularLightingElement).Name] = typeof(ScriptableSvgFESpecularLightingElement);
      //TODO wrapperTypes[typeof(SvgFETileElement).Name] = typeof(ScriptableSvgFETileElement);
      //TODO wrapperTypes[typeof(SvgFETurbulenceElement).Name] = typeof(ScriptableSvgFETurbulenceElement);
      //TODO wrapperTypes[typeof(SvgCursorElement).Name] = typeof(ScriptableSvgCursorElement);
      //TODO wrapperTypes[typeof(SvgAElement).Name] = typeof(ScriptableSvgAElement);
      //TODO wrapperTypes[typeof(SvgViewElement).Name] = typeof(ScriptableSvgViewElement);
      wrapperTypes[typeof(SvgScriptElement).Name] = typeof(ScriptableSvgScriptElement);
      //TODO wrapperTypes[typeof(SvgEvent).Name] = typeof(ScriptableSvgEvent);
      //TODO wrapperTypes[typeof(SvgZoomEvent).Name] = typeof(ScriptableSvgZoomEvent);
      //TODO wrapperTypes[typeof(SvgAnimationElement).Name] = typeof(ScriptableSvgAnimationElement);
      //TODO wrapperTypes[typeof(SvgAnimateElement).Name] = typeof(ScriptableSvgAnimateElement);
      //TODO wrapperTypes[typeof(SvgSetElement).Name] = typeof(ScriptableSvgSetElement);
      //TODO wrapperTypes[typeof(SvgAnimateMotionElement).Name] = typeof(ScriptableSvgAnimateMotionElement);
      //TODO wrapperTypes[typeof(SvgMPathElement).Name] = typeof(ScriptableSvgMPathElement);
      //TODO wrapperTypes[typeof(SvgAnimateColorElement).Name] = typeof(ScriptableSvgAnimateColorElement);
      //TODO wrapperTypes[typeof(SvgAnimateTransformElement).Name] = typeof(ScriptableSvgAnimateTransformElement);
      //TODO wrapperTypes[typeof(SvgFontElement).Name] = typeof(ScriptableSvgFontElement);
      //TODO wrapperTypes[typeof(SvgGlyphElement).Name] = typeof(ScriptableSvgGlyphElement);
      //TODO wrapperTypes[typeof(SvgMissingGlyphElement).Name] = typeof(ScriptableSvgMissingGlyphElement);
      //TODO wrapperTypes[typeof(SvgHKernElement).Name] = typeof(ScriptableSvgHKernElement);
      //TODO wrapperTypes[typeof(SvgVKernElement).Name] = typeof(ScriptableSvgVKernElement);
      //TODO wrapperTypes[typeof(SvgFontFaceElement).Name] = typeof(ScriptableSvgFontFaceElement);
      //TODO wrapperTypes[typeof(SvgFontFaceSrcElement).Name] = typeof(ScriptableSvgFontFaceSrcElement);
      //TODO wrapperTypes[typeof(SvgFontFaceUriElement).Name] = typeof(ScriptableSvgFontFaceUriElement);
      //TODO wrapperTypes[typeof(SvgFontFaceFormatElement).Name] = typeof(ScriptableSvgFontFaceFormatElement);
      //TODO wrapperTypes[typeof(SvgFontFaceNameElement).Name] = typeof(ScriptableSvgFontFaceNameElement);
      //TODO wrapperTypes[typeof(SvgDefinitionSrcElement).Name] = typeof(ScriptableSvgDefinitionSrcElement);
      wrapperTypes[typeof(SvgMetadataElement).Name] = typeof(ScriptableSvgMetadataElement);
      //TODO wrapperTypes[typeof(SvgForeignObjectElement).Name] = typeof(ScriptableSvgForeignObjectElement);

      // Views Types
      //TODO wrapperTypes[typeof(AbstractView).Name] = typeof(ScriptableAbstractView);
      //TODO wrapperTypes[typeof(DocumentView).Name] = typeof(ScriptableDocumentView);

      // Window Types
      wrapperTypes[typeof(SvgWindow).Name] = typeof(ScriptableSvgWindow);

    }

    public override bool Equals(Object obj) 
    {
      if (obj == null) 
        return false;

      return obj is ScriptableObject && this.baseObject == ((ScriptableObject)obj).baseObject;
    }

    public override int GetHashCode() 
    {
      if (baseObject == null)
        return 0;

      return baseObject.GetHashCode();
    }

    public static bool operator ==(ScriptableObject x, ScriptableObject y) 
    {
      if ((object)x == null || (object)y == null)
        return false;

      return x.baseObject == y.baseObject;
    }

    public static bool operator !=(ScriptableObject x, ScriptableObject y) 
    {
      return !(x == y);
    }  
  }
}
