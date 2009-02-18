using System;


namespace SharpVectors.Scripting
{

	/// <summary>
	/// IScriptableSvgElement
	/// </summary>
	public interface IScriptableSvgElement : IScriptableElement
	{
		string id { get; set; }
		string xmlbase { get; set; }
		IScriptableSvgSvgElement ownerSVGElement { get; }
		IScriptableSvgElement viewportElement { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedBoolean
	/// </summary>
	public interface IScriptableSvgAnimatedBoolean
	{
		bool baseVal { get; set; }
		bool animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedString
	/// </summary>
	public interface IScriptableSvgAnimatedString
	{
		string baseVal { get; set; }
		string animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgStringList
	/// </summary>
	public interface IScriptableSvgStringList
	{
		void clear();
		string initialize(string newItem);
		string getItem(ulong index);
		string insertItemBefore(string newItem, ulong index);
		string replaceItem(string newItem, ulong index);
		string removeItem(ulong index);
		string appendItem(string newItem);
		ulong numberOfItems { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedEnumeration
	/// </summary>
	public interface IScriptableSvgAnimatedEnumeration
	{
		ushort baseVal { get; set; }
		ushort animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedInteger
	/// </summary>
	public interface IScriptableSvgAnimatedInteger
	{
		long baseVal { get; set; }
		long animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgNumber
	/// </summary>
	public interface IScriptableSvgNumber
	{
		float value { get; set; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedNumber
	/// </summary>
	public interface IScriptableSvgAnimatedNumber
	{
		float baseVal { get; set; }
		float animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgNumberList
	/// </summary>
	public interface IScriptableSvgNumberList
	{
		void clear();
		IScriptableSvgNumber initialize(IScriptableSvgNumber newItem);
		IScriptableSvgNumber getItem(ulong index);
		IScriptableSvgNumber insertItemBefore(IScriptableSvgNumber newItem, ulong index);
		IScriptableSvgNumber replaceItem(IScriptableSvgNumber newItem, ulong index);
		IScriptableSvgNumber removeItem(ulong index);
		IScriptableSvgNumber appendItem(IScriptableSvgNumber newItem);
		ulong numberOfItems { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedNumberList
	/// </summary>
	public interface IScriptableSvgAnimatedNumberList
	{
		IScriptableSvgNumberList baseVal { get; }
		IScriptableSvgNumberList animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgLength
	/// </summary>
	public interface IScriptableSvgLength
	{
		void newValueSpecifiedUnits(ushort unitType, float valueInSpecifiedUnits);
		void convertToSpecifiedUnits(ushort unitType);
		ushort unitType { get; }
		float value { get; set; }
		float valueInSpecifiedUnits { get; set; }
		string valueAsString { get; set; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedLength
	/// </summary>
	public interface IScriptableSvgAnimatedLength
	{
		IScriptableSvgLength baseVal { get; }
		IScriptableSvgLength animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgLengthList
	/// </summary>
	public interface IScriptableSvgLengthList
	{
		void clear();
		IScriptableSvgLength initialize(IScriptableSvgLength newItem);
		IScriptableSvgLength getItem(ulong index);
		IScriptableSvgLength insertItemBefore(IScriptableSvgLength newItem, ulong index);
		IScriptableSvgLength replaceItem(IScriptableSvgLength newItem, ulong index);
		IScriptableSvgLength removeItem(ulong index);
		IScriptableSvgLength appendItem(IScriptableSvgLength newItem);
		ulong numberOfItems { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedLengthList
	/// </summary>
	public interface IScriptableSvgAnimatedLengthList
	{
		IScriptableSvgLengthList baseVal { get; }
		IScriptableSvgLengthList animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgAngle
	/// </summary>
	public interface IScriptableSvgAngle
	{
		void newValueSpecifiedUnits(ushort unitType, float valueInSpecifiedUnits);
		void convertToSpecifiedUnits(ushort unitType);
		ushort unitType { get; }
		float value { get; set; }
		float valueInSpecifiedUnits { get; set; }
		string valueAsString { get; set; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedAngle
	/// </summary>
	public interface IScriptableSvgAnimatedAngle
	{
		IScriptableSvgAngle baseVal { get; }
		IScriptableSvgAngle animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgColor
	/// </summary>
	public interface IScriptableSvgColor : IScriptableCssValue
	{
		void setRGBColor(string rgbColor);
		void setRGBColorICCColor(string rgbColor, string iccColor);
		void setColor(ushort colorType, string rgbColor, string iccColor);
		ushort colorType { get; }
		IScriptableRgbColor rgbColor { get; }
		IScriptableSvgIccColor iccColor { get; }
	}

	/// <summary>
	/// IScriptableSvgIccColor
	/// </summary>
	public interface IScriptableSvgIccColor
	{
		string colorProfile { get; set; }
		IScriptableSvgNumberList colors { get; }
	}

	/// <summary>
	/// IScriptableSvgRect
	/// </summary>
	public interface IScriptableSvgRect
	{
		float x { get; set; }
		float y { get; set; }
		float width { get; set; }
		float height { get; set; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedRect
	/// </summary>
	public interface IScriptableSvgAnimatedRect
	{
		IScriptableSvgRect baseVal { get; }
		IScriptableSvgRect animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgUnitTypes
	/// </summary>
	public interface IScriptableSvgUnitTypes
	{
	}

	/// <summary>
	/// IScriptableSvgStylable
	/// </summary>
	public interface IScriptableSvgStylable
	{
		IScriptableCssValue getPresentationAttribute(string name);
		IScriptableSvgAnimatedString className { get; }
		IScriptableCssStyleDeclaration style { get; }
	}

	/// <summary>
	/// IScriptableSvgLocatable
	/// </summary>
	public interface IScriptableSvgLocatable
	{
		IScriptableSvgRect getBBox();
		IScriptableSvgMatrix getCTM();
		IScriptableSvgMatrix getScreenCTM();
		IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element);
		IScriptableSvgElement nearestViewportElement { get; }
		IScriptableSvgElement farthestViewportElement { get; }
	}

	/// <summary>
	/// IScriptableSvgTransformable
	/// </summary>
	public interface IScriptableSvgTransformable : IScriptableSvgLocatable
	{
		IScriptableSvgAnimatedTransformList transform { get; }
	}

	/// <summary>
	/// IScriptableSvgTests
	/// </summary>
	public interface IScriptableSvgTests
	{
		bool hasExtension(string extension);
		IScriptableSvgStringList requiredFeatures { get; }
		IScriptableSvgStringList requiredExtensions { get; }
		IScriptableSvgStringList systemLanguage { get; }
	}

	/// <summary>
	/// IScriptableSvgLangSpace
	/// </summary>
	public interface IScriptableSvgLangSpace
	{
		string xmllang { get; set; }
		string xmlspace { get; set; }
	}

	/// <summary>
	/// IScriptableSvgExternalResourcesRequired
	/// </summary>
	public interface IScriptableSvgExternalResourcesRequired
	{
		bool externalResourcesRequired { get; }
	}

	/// <summary>
	/// IScriptableSvgFitToViewBox
	/// </summary>
	public interface IScriptableSvgFitToViewBox
	{
		IScriptableSvgAnimatedRect viewBox { get; }
		IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio { get; }
	}

	/// <summary>
	/// IScriptableSvgZoomAndPan
	/// </summary>
	public interface IScriptableSvgZoomAndPan
	{
		ushort zoomAndPan { get; set; }
	}

	/// <summary>
	/// IScriptableSvgViewSpec
	/// </summary>
	public interface IScriptableSvgViewSpec : IScriptableSvgZoomAndPan, IScriptableSvgFitToViewBox
	{
		IScriptableSvgTransformList transform { get; }
		IScriptableSvgElement viewTarget { get; }
		string viewBoxString { get; }
		string preserveAspectRatioString { get; }
		string transformString { get; }
		string viewTargetString { get; }
	}

	/// <summary>
	/// IScriptableSvgUriReference
	/// </summary>
	public interface IScriptableSvgUriReference
	{
		IScriptableSvgAnimatedString href { get; }
	}

	/// <summary>
	/// IScriptableSvgCssRule
	/// </summary>
	public interface IScriptableSvgCssRule : IScriptableCssRule
	{
	}

	/// <summary>
	/// IScriptableSvgRenderingIntent
	/// </summary>
	public interface IScriptableSvgRenderingIntent
	{
	}

	/// <summary>
	/// IScriptableSvgDocument
	/// </summary>
	public interface IScriptableSvgDocument : IScriptableDocument, IScriptableDocumentEvent
	{
		string title { get; }
		string referrer { get; }
		string domain { get; }
		string URL { get; }
		IScriptableSvgSvgElement rootElement { get; }
	}

	/// <summary>
	/// IScriptableSvgSvgElement
	/// </summary>
	public interface IScriptableSvgSvgElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgLocatable, IScriptableSvgFitToViewBox, IScriptableSvgZoomAndPan, IScriptableEventTarget, IScriptableDocumentEvent, IScriptableViewCss, IScriptableDocumentCss
	{
		ulong suspendRedraw(ulong max_wait_milliseconds);
		void unsuspendRedraw(ulong suspend_handle_id);
		void unsuspendRedrawAll();
		void forceRedraw();
		void pauseAnimations();
		void unpauseAnimations();
		bool animationsPaused();
		float getCurrentTime();
		void setCurrentTime(float seconds);
		IScriptableNodeList getIntersectionList(IScriptableSvgRect rect, IScriptableSvgElement referenceElement);
		IScriptableNodeList getEnclosureList(IScriptableSvgRect rect, IScriptableSvgElement referenceElement);
		bool checkIntersection(IScriptableSvgElement element, IScriptableSvgRect rect);
		bool checkEnclosure(IScriptableSvgElement element, IScriptableSvgRect rect);
		void deselectAll();
		IScriptableSvgNumber createSVGNumber();
		IScriptableSvgLength createSVGLength();
		IScriptableSvgAngle createSVGAngle();
		IScriptableSvgPoint createSVGPoint();
		IScriptableSvgMatrix createSVGMatrix();
		IScriptableSvgRect createSVGRect();
		IScriptableSvgTransform createSVGTransform();
		IScriptableSvgTransform createSVGTransformFromMatrix(IScriptableSvgMatrix matrix);
		IScriptableElement getElementById(string elementId);
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
		string contentScriptType { get; set; }
		string contentStyleType { get; set; }
		IScriptableSvgRect viewport { get; }
		float pixelUnitToMillimeterX { get; }
		float pixelUnitToMillimeterY { get; }
		float screenPixelToMillimeterX { get; }
		float screenPixelToMillimeterY { get; }
		bool useCurrentView { get; set; }
		IScriptableSvgViewSpec currentView { get; }
		float currentScale { get; set; }
		IScriptableSvgPoint currentTranslate { get; }
	}

	/// <summary>
	/// IScriptableSvgGElement
	/// </summary>
	public interface IScriptableSvgGElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
	}

	/// <summary>
	/// IScriptableSvgDefsElement
	/// </summary>
	public interface IScriptableSvgDefsElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
	}

	/// <summary>
	/// IScriptableSvgDescElement
	/// </summary>
	public interface IScriptableSvgDescElement : IScriptableSvgElement, IScriptableSvgLangSpace, IScriptableSvgStylable
	{
	}

	/// <summary>
	/// IScriptableSvgTitleElement
	/// </summary>
	public interface IScriptableSvgTitleElement : IScriptableSvgElement, IScriptableSvgLangSpace, IScriptableSvgStylable
	{
	}

	/// <summary>
	/// IScriptableSvgSymbolElement
	/// </summary>
	public interface IScriptableSvgSymbolElement : IScriptableSvgElement, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgFitToViewBox, IScriptableEventTarget
	{
	}

	/// <summary>
	/// IScriptableSvgUseElement
	/// </summary>
	public interface IScriptableSvgUseElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
		IScriptableSvgElementInstance instanceRoot { get; }
		IScriptableSvgElementInstance animatedInstanceRoot { get; }
	}

	/// <summary>
	/// IScriptableSvgElementInstance
	/// </summary>
	public interface IScriptableSvgElementInstance : IScriptableEventTarget
	{
		IScriptableSvgElement correspondingElement { get; }
		IScriptableSvgUseElement correspondingUseElement { get; }
		IScriptableSvgElementInstance parentNode { get; }
		IScriptableSvgElementInstanceList childNodes { get; }
		IScriptableSvgElementInstance firstChild { get; }
		IScriptableSvgElementInstance lastChild { get; }
		IScriptableSvgElementInstance previousSibling { get; }
		IScriptableSvgElementInstance nextSibling { get; }
	}

	/// <summary>
	/// IScriptableSvgElementInstanceList
	/// </summary>
	public interface IScriptableSvgElementInstanceList
	{
		IScriptableSvgElementInstance item(ulong index);
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableSvgImageElement
	/// </summary>
	public interface IScriptableSvgImageElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
		IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio { get; }
	}

	/// <summary>
	/// IScriptableSvgSwitchElement
	/// </summary>
	public interface IScriptableSvgSwitchElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
	}

	/// <summary>
	/// IScriptableGetSvgDocument
	/// </summary>
	public interface IScriptableGetSvgDocument
	{
		IScriptableSvgDocument getSVGDocument();
	}

	/// <summary>
	/// IScriptableSvgStyleElement
	/// </summary>
	public interface IScriptableSvgStyleElement : IScriptableSvgElement
	{
		string xmlspace { get; set; }
		string type { get; set; }
		string media { get; set; }
		string title { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPoint
	/// </summary>
	public interface IScriptableSvgPoint
	{
		IScriptableSvgPoint matrixTransform(IScriptableSvgMatrix matrix);
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPointList
	/// </summary>
	public interface IScriptableSvgPointList
	{
		void clear();
		IScriptableSvgPoint initialize(IScriptableSvgPoint newItem);
		IScriptableSvgPoint getItem(ulong index);
		IScriptableSvgPoint insertItemBefore(IScriptableSvgPoint newItem, ulong index);
		IScriptableSvgPoint replaceItem(IScriptableSvgPoint newItem, ulong index);
		IScriptableSvgPoint removeItem(ulong index);
		IScriptableSvgPoint appendItem(IScriptableSvgPoint newItem);
		ulong numberOfItems { get; }
	}

	/// <summary>
	/// IScriptableSvgMatrix
	/// </summary>
	public interface IScriptableSvgMatrix
	{
		IScriptableSvgMatrix multiply(IScriptableSvgMatrix secondMatrix);
		IScriptableSvgMatrix inverse();
		IScriptableSvgMatrix translate(float x, float y);
		IScriptableSvgMatrix scale(float scaleFactor);
		IScriptableSvgMatrix scaleNonUniform(float scaleFactorX, float scaleFactorY);
		IScriptableSvgMatrix rotate(float angle);
		IScriptableSvgMatrix rotateFromVector(float x, float y);
		IScriptableSvgMatrix flipX();
		IScriptableSvgMatrix flipY();
		IScriptableSvgMatrix skewX(float angle);
		IScriptableSvgMatrix skewY(float angle);
		float a { get; set; }
		float b { get; set; }
		float c { get; set; }
		float d { get; set; }
		float e { get; set; }
		float f { get; set; }
	}

	/// <summary>
	/// IScriptableSvgTransform
	/// </summary>
	public interface IScriptableSvgTransform
	{
		void setMatrix(IScriptableSvgMatrix matrix);
		void setTranslate(float tx, float ty);
		void setScale(float sx, float sy);
		void setRotate(float angle, float cx, float cy);
		void setSkewX(float angle);
		void setSkewY(float angle);
		ushort type { get; }
		IScriptableSvgMatrix matrix { get; }
		float angle { get; }
	}

	/// <summary>
	/// IScriptableSvgTransformList
	/// </summary>
	public interface IScriptableSvgTransformList
	{
		void clear();
		IScriptableSvgTransform initialize(IScriptableSvgTransform newItem);
		IScriptableSvgTransform getItem(ulong index);
		IScriptableSvgTransform insertItemBefore(IScriptableSvgTransform newItem, ulong index);
		IScriptableSvgTransform replaceItem(IScriptableSvgTransform newItem, ulong index);
		IScriptableSvgTransform removeItem(ulong index);
		IScriptableSvgTransform appendItem(IScriptableSvgTransform newItem);
		IScriptableSvgTransform createSVGTransformFromMatrix(IScriptableSvgMatrix matrix);
		IScriptableSvgTransform consolidate();
		ulong numberOfItems { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedTransformList
	/// </summary>
	public interface IScriptableSvgAnimatedTransformList
	{
		IScriptableSvgTransformList baseVal { get; }
		IScriptableSvgTransformList animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgPreserveAspectRatio
	/// </summary>
	public interface IScriptableSvgPreserveAspectRatio
	{
		ushort align { get; set; }
		ushort meetOrSlice { get; set; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedPreserveAspectRatio
	/// </summary>
	public interface IScriptableSvgAnimatedPreserveAspectRatio
	{
		IScriptableSvgPreserveAspectRatio baseVal { get; }
		IScriptableSvgPreserveAspectRatio animVal { get; }
	}

	/// <summary>
	/// IScriptableSvgPathSeg
	/// </summary>
	public interface IScriptableSvgPathSeg
	{
		ushort pathSegType { get; }
		string pathSegTypeAsLetter { get; }
	}

	/// <summary>
	/// IScriptableSvgPathSegClosePath
	/// </summary>
	public interface IScriptableSvgPathSegClosePath : IScriptableSvgPathSeg
	{
	}

	/// <summary>
	/// IScriptableSvgPathSegMovetoAbs
	/// </summary>
	public interface IScriptableSvgPathSegMovetoAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegMovetoRel
	/// </summary>
	public interface IScriptableSvgPathSegMovetoRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegLinetoAbs
	/// </summary>
	public interface IScriptableSvgPathSegLinetoAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegLinetoRel
	/// </summary>
	public interface IScriptableSvgPathSegLinetoRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoCubicAbs
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoCubicAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float x1 { get; set; }
		float y1 { get; set; }
		float x2 { get; set; }
		float y2 { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoCubicRel
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoCubicRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float x1 { get; set; }
		float y1 { get; set; }
		float x2 { get; set; }
		float y2 { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoQuadraticAbs
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoQuadraticAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float x1 { get; set; }
		float y1 { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoQuadraticRel
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoQuadraticRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float x1 { get; set; }
		float y1 { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegArcAbs
	/// </summary>
	public interface IScriptableSvgPathSegArcAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float r1 { get; set; }
		float r2 { get; set; }
		float angle { get; set; }
		bool largeArcFlag { get; set; }
		bool sweepFlag { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegArcRel
	/// </summary>
	public interface IScriptableSvgPathSegArcRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float r1 { get; set; }
		float r2 { get; set; }
		float angle { get; set; }
		bool largeArcFlag { get; set; }
		bool sweepFlag { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegLinetoHorizontalAbs
	/// </summary>
	public interface IScriptableSvgPathSegLinetoHorizontalAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegLinetoHorizontalRel
	/// </summary>
	public interface IScriptableSvgPathSegLinetoHorizontalRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegLinetoVerticalAbs
	/// </summary>
	public interface IScriptableSvgPathSegLinetoVerticalAbs : IScriptableSvgPathSeg
	{
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegLinetoVerticalRel
	/// </summary>
	public interface IScriptableSvgPathSegLinetoVerticalRel : IScriptableSvgPathSeg
	{
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoCubicSmoothAbs
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoCubicSmoothAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float x2 { get; set; }
		float y2 { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoCubicSmoothRel
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoCubicSmoothRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
		float x2 { get; set; }
		float y2 { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoQuadraticSmoothAbs
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoQuadraticSmoothAbs : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegCurvetoQuadraticSmoothRel
	/// </summary>
	public interface IScriptableSvgPathSegCurvetoQuadraticSmoothRel : IScriptableSvgPathSeg
	{
		float x { get; set; }
		float y { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPathSegList
	/// </summary>
	public interface IScriptableSvgPathSegList
	{
		void clear();
		IScriptableSvgPathSeg initialize(IScriptableSvgPathSeg newItem);
		IScriptableSvgPathSeg getItem(ulong index);
		IScriptableSvgPathSeg insertItemBefore(IScriptableSvgPathSeg newItem, ulong index);
		IScriptableSvgPathSeg replaceItem(IScriptableSvgPathSeg newItem, ulong index);
		IScriptableSvgPathSeg removeItem(ulong index);
		IScriptableSvgPathSeg appendItem(IScriptableSvgPathSeg newItem);
		ulong numberOfItems { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedPathData
	/// </summary>
	public interface IScriptableSvgAnimatedPathData
	{
		IScriptableSvgPathSegList pathSegList { get; }
		IScriptableSvgPathSegList normalizedPathSegList { get; }
		IScriptableSvgPathSegList animatedPathSegList { get; }
		IScriptableSvgPathSegList animatedNormalizedPathSegList { get; }
	}

	/// <summary>
	/// IScriptableSvgPathElement
	/// </summary>
	public interface IScriptableSvgPathElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget, IScriptableSvgAnimatedPathData
	{
		float getTotalLength();
		IScriptableSvgPoint getPointAtLength(float distance);
		ulong getPathSegAtLength(float distance);
		IScriptableSvgPathSegClosePath createSVGPathSegClosePath();
		IScriptableSvgPathSegMovetoAbs createSVGPathSegMovetoAbs(float x, float y);
		IScriptableSvgPathSegMovetoRel createSVGPathSegMovetoRel(float x, float y);
		IScriptableSvgPathSegLinetoAbs createSVGPathSegLinetoAbs(float x, float y);
		IScriptableSvgPathSegLinetoRel createSVGPathSegLinetoRel(float x, float y);
		IScriptableSvgPathSegCurvetoCubicAbs createSVGPathSegCurvetoCubicAbs(float x, float y, float x1, float y1, float x2, float y2);
		IScriptableSvgPathSegCurvetoCubicRel createSVGPathSegCurvetoCubicRel(float x, float y, float x1, float y1, float x2, float y2);
		IScriptableSvgPathSegCurvetoQuadraticAbs createSVGPathSegCurvetoQuadraticAbs(float x, float y, float x1, float y1);
		IScriptableSvgPathSegCurvetoQuadraticRel createSVGPathSegCurvetoQuadraticRel(float x, float y, float x1, float y1);
		IScriptableSvgPathSegArcAbs createSVGPathSegArcAbs(float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag);
		IScriptableSvgPathSegArcRel createSVGPathSegArcRel(float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag);
		IScriptableSvgPathSegLinetoHorizontalAbs createSVGPathSegLinetoHorizontalAbs(float x);
		IScriptableSvgPathSegLinetoHorizontalRel createSVGPathSegLinetoHorizontalRel(float x);
		IScriptableSvgPathSegLinetoVerticalAbs createSVGPathSegLinetoVerticalAbs(float y);
		IScriptableSvgPathSegLinetoVerticalRel createSVGPathSegLinetoVerticalRel(float y);
		IScriptableSvgPathSegCurvetoCubicSmoothAbs createSVGPathSegCurvetoCubicSmoothAbs(float x, float y, float x2, float y2);
		IScriptableSvgPathSegCurvetoCubicSmoothRel createSVGPathSegCurvetoCubicSmoothRel(float x, float y, float x2, float y2);
		IScriptableSvgPathSegCurvetoQuadraticSmoothAbs createSVGPathSegCurvetoQuadraticSmoothAbs(float x, float y);
		IScriptableSvgPathSegCurvetoQuadraticSmoothRel createSVGPathSegCurvetoQuadraticSmoothRel(float x, float y);
		IScriptableSvgAnimatedNumber pathLength { get; }
	}

	/// <summary>
	/// IScriptableSvgRectElement
	/// </summary>
	public interface IScriptableSvgRectElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
		IScriptableSvgAnimatedLength rx { get; }
		IScriptableSvgAnimatedLength ry { get; }
	}

	/// <summary>
	/// IScriptableSvgCircleElement
	/// </summary>
	public interface IScriptableSvgCircleElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength cx { get; }
		IScriptableSvgAnimatedLength cy { get; }
		IScriptableSvgAnimatedLength r { get; }
	}

	/// <summary>
	/// IScriptableSvgEllipseElement
	/// </summary>
	public interface IScriptableSvgEllipseElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength cx { get; }
		IScriptableSvgAnimatedLength cy { get; }
		IScriptableSvgAnimatedLength rx { get; }
		IScriptableSvgAnimatedLength ry { get; }
	}

	/// <summary>
	/// IScriptableSvgLineElement
	/// </summary>
	public interface IScriptableSvgLineElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength x1 { get; }
		IScriptableSvgAnimatedLength y1 { get; }
		IScriptableSvgAnimatedLength x2 { get; }
		IScriptableSvgAnimatedLength y2 { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimatedPoints
	/// </summary>
	public interface IScriptableSvgAnimatedPoints
	{
		IScriptableSvgPointList points { get; }
		IScriptableSvgPointList animatedPoints { get; }
	}

	/// <summary>
	/// IScriptableSvgPolylineElement
	/// </summary>
	public interface IScriptableSvgPolylineElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget, IScriptableSvgAnimatedPoints
	{
	}

	/// <summary>
	/// IScriptableSvgPolygonElement
	/// </summary>
	public interface IScriptableSvgPolygonElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget, IScriptableSvgAnimatedPoints
	{
	}

	/// <summary>
	/// IScriptableSvgTextContentElement
	/// </summary>
	public interface IScriptableSvgTextContentElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableEventTarget
	{
		long getNumberOfChars();
		float getComputedTextLength();
		float getSubStringLength(ulong charnum, ulong nchars);
		IScriptableSvgPoint getStartPositionOfChar(ulong charnum);
		IScriptableSvgPoint getEndPositionOfChar(ulong charnum);
		IScriptableSvgRect getExtentOfChar(ulong charnum);
		float getRotationOfChar(ulong charnum);
		long getCharNumAtPosition(IScriptableSvgPoint point);
		void selectSubString(ulong charnum, ulong nchars);
		IScriptableSvgAnimatedLength textLength { get; }
		IScriptableSvgAnimatedEnumeration lengthAdjust { get; }
	}

	/// <summary>
	/// IScriptableSvgTextPositioningElement
	/// </summary>
	public interface IScriptableSvgTextPositioningElement : IScriptableSvgTextContentElement
	{
		IScriptableSvgAnimatedLengthList x { get; }
		IScriptableSvgAnimatedLengthList y { get; }
		IScriptableSvgAnimatedLengthList dx { get; }
		IScriptableSvgAnimatedLengthList dy { get; }
		IScriptableSvgAnimatedNumberList rotate { get; }
	}

	/// <summary>
	/// IScriptableSvgTextElement
	/// </summary>
	public interface IScriptableSvgTextElement : IScriptableSvgTextPositioningElement, IScriptableSvgTransformable
	{
	}

	/// <summary>
	/// IScriptableSvgTSpanElement
	/// </summary>
	public interface IScriptableSvgTSpanElement : IScriptableSvgTextPositioningElement
	{
	}

	/// <summary>
	/// IScriptableSvgTRefElement
	/// </summary>
	public interface IScriptableSvgTRefElement : IScriptableSvgTextPositioningElement, IScriptableSvgUriReference
	{
	}

	/// <summary>
	/// IScriptableSvgTextPathElement
	/// </summary>
	public interface IScriptableSvgTextPathElement : IScriptableSvgTextContentElement, IScriptableSvgUriReference
	{
		IScriptableSvgAnimatedLength startOffset { get; }
		IScriptableSvgAnimatedEnumeration method { get; }
		IScriptableSvgAnimatedEnumeration spacing { get; }
	}

	/// <summary>
	/// IScriptableSvgAltGlyphElement
	/// </summary>
	public interface IScriptableSvgAltGlyphElement : IScriptableSvgTextPositioningElement, IScriptableSvgUriReference
	{
		string glyphRef { get; set; }
		string format { get; set; }
	}

	/// <summary>
	/// IScriptableSvgAltGlyphDefElement
	/// </summary>
	public interface IScriptableSvgAltGlyphDefElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgAltGlyphItemElement
	/// </summary>
	public interface IScriptableSvgAltGlyphItemElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgGlyphRefElement
	/// </summary>
	public interface IScriptableSvgGlyphRefElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgStylable
	{
		string glyphRef { get; set; }
		string format { get; set; }
		float x { get; set; }
		float y { get; set; }
		float dx { get; set; }
		float dy { get; set; }
	}

	/// <summary>
	/// IScriptableSvgPaint
	/// </summary>
	public interface IScriptableSvgPaint : IScriptableSvgColor
	{
		void setUri(string uri);
		void setPaint(ushort paintType, string uri, string rgbColor, string iccColor);
		ushort paintType { get; }
		string uri { get; }
	}

	/// <summary>
	/// IScriptableSvgMarkerElement
	/// </summary>
	public interface IScriptableSvgMarkerElement : IScriptableSvgElement, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgFitToViewBox
	{
		void setOrientToAuto();
		void setOrientToAngle(IScriptableSvgAngle angle);
		IScriptableSvgAnimatedLength refX { get; }
		IScriptableSvgAnimatedLength refY { get; }
		IScriptableSvgAnimatedEnumeration markerUnits { get; }
		IScriptableSvgAnimatedLength markerWidth { get; }
		IScriptableSvgAnimatedLength markerHeight { get; }
		IScriptableSvgAnimatedEnumeration orientType { get; }
		IScriptableSvgAnimatedAngle orientAngle { get; }
	}

	/// <summary>
	/// IScriptableSvgColorProfileElement
	/// </summary>
	public interface IScriptableSvgColorProfileElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgRenderingIntent
	{
		string local { get; set; }
		string name { get; set; }
		ushort renderingIntent { get; set; }
	}

	/// <summary>
	/// IScriptableSvgColorProfileRule
	/// </summary>
	public interface IScriptableSvgColorProfileRule : IScriptableSvgCssRule, IScriptableSvgRenderingIntent
	{
		string src { get; set; }
		string name { get; set; }
		ushort renderingIntent { get; set; }
	}

	/// <summary>
	/// IScriptableSvgGradientElement
	/// </summary>
	public interface IScriptableSvgGradientElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgUnitTypes
	{
		IScriptableSvgAnimatedEnumeration gradientUnits { get; }
		IScriptableSvgAnimatedTransformList gradientTransform { get; }
		IScriptableSvgAnimatedEnumeration spreadMethod { get; }
	}

	/// <summary>
	/// IScriptableSvgLinearGradientElement
	/// </summary>
	public interface IScriptableSvgLinearGradientElement : IScriptableSvgGradientElement
	{
		IScriptableSvgAnimatedLength x1 { get; }
		IScriptableSvgAnimatedLength y1 { get; }
		IScriptableSvgAnimatedLength x2 { get; }
		IScriptableSvgAnimatedLength y2 { get; }
	}

	/// <summary>
	/// IScriptableSvgRadialGradientElement
	/// </summary>
	public interface IScriptableSvgRadialGradientElement : IScriptableSvgGradientElement
	{
		IScriptableSvgAnimatedLength cx { get; }
		IScriptableSvgAnimatedLength cy { get; }
		IScriptableSvgAnimatedLength r { get; }
		IScriptableSvgAnimatedLength fx { get; }
		IScriptableSvgAnimatedLength fy { get; }
	}

	/// <summary>
	/// IScriptableSvgStopElement
	/// </summary>
	public interface IScriptableSvgStopElement : IScriptableSvgElement, IScriptableSvgStylable
	{
		IScriptableSvgAnimatedNumber offset { get; }
	}

	/// <summary>
	/// IScriptableSvgPatternElement
	/// </summary>
	public interface IScriptableSvgPatternElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgFitToViewBox, IScriptableSvgUnitTypes
	{
		IScriptableSvgAnimatedEnumeration patternUnits { get; }
		IScriptableSvgAnimatedEnumeration patternContentUnits { get; }
		IScriptableSvgAnimatedTransformList patternTransform { get; }
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
	}

	/// <summary>
	/// IScriptableSvgClipPathElement
	/// </summary>
	public interface IScriptableSvgClipPathElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableSvgUnitTypes
	{
		IScriptableSvgAnimatedEnumeration clipPathUnits { get; }
	}

	/// <summary>
	/// IScriptableSvgMaskElement
	/// </summary>
	public interface IScriptableSvgMaskElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgUnitTypes
	{
		IScriptableSvgAnimatedEnumeration maskUnits { get; }
		IScriptableSvgAnimatedEnumeration maskContentUnits { get; }
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
	}

	/// <summary>
	/// IScriptableSvgFilterElement
	/// </summary>
	public interface IScriptableSvgFilterElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgUnitTypes
	{
		void setFilterRes(ulong filterResX, ulong filterResY);
		IScriptableSvgAnimatedEnumeration filterUnits { get; }
		IScriptableSvgAnimatedEnumeration primitiveUnits { get; }
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
		IScriptableSvgAnimatedInteger filterResX { get; }
		IScriptableSvgAnimatedInteger filterResY { get; }
	}

	/// <summary>
	/// IScriptableSvgFilterPrimitiveStandardAttributes
	/// </summary>
	public interface IScriptableSvgFilterPrimitiveStandardAttributes : IScriptableSvgStylable
	{
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
		IScriptableSvgAnimatedString result { get; }
	}

	/// <summary>
	/// IScriptableSvgFEBlendElement
	/// </summary>
	public interface IScriptableSvgFEBlendElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedString in2 { get; }
		IScriptableSvgAnimatedEnumeration mode { get; }
	}

	/// <summary>
	/// IScriptableSvgFEColorMatrixElement
	/// </summary>
	public interface IScriptableSvgFEColorMatrixElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedEnumeration type { get; }
		IScriptableSvgAnimatedNumberList values { get; }
	}

	/// <summary>
	/// IScriptableSvgFEComponentTransferElement
	/// </summary>
	public interface IScriptableSvgFEComponentTransferElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
	}

	/// <summary>
	/// IScriptableSvgComponentTransferFunctionElement
	/// </summary>
	public interface IScriptableSvgComponentTransferFunctionElement : IScriptableSvgElement
	{
		IScriptableSvgAnimatedEnumeration type { get; }
		IScriptableSvgAnimatedNumberList tableValues { get; }
		IScriptableSvgAnimatedNumber slope { get; }
		IScriptableSvgAnimatedNumber intercept { get; }
		IScriptableSvgAnimatedNumber amplitude { get; }
		IScriptableSvgAnimatedNumber exponent { get; }
		IScriptableSvgAnimatedNumber offset { get; }
	}

	/// <summary>
	/// IScriptableSvgFEFuncRElement
	/// </summary>
	public interface IScriptableSvgFEFuncRElement : IScriptableSvgComponentTransferFunctionElement
	{
	}

	/// <summary>
	/// IScriptableSvgFEFuncGElement
	/// </summary>
	public interface IScriptableSvgFEFuncGElement : IScriptableSvgComponentTransferFunctionElement
	{
	}

	/// <summary>
	/// IScriptableSvgFEFuncBElement
	/// </summary>
	public interface IScriptableSvgFEFuncBElement : IScriptableSvgComponentTransferFunctionElement
	{
	}

	/// <summary>
	/// IScriptableSvgFEFuncAElement
	/// </summary>
	public interface IScriptableSvgFEFuncAElement : IScriptableSvgComponentTransferFunctionElement
	{
	}

	/// <summary>
	/// IScriptableSvgFECompositeElement
	/// </summary>
	public interface IScriptableSvgFECompositeElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedString in2 { get; }
		IScriptableSvgAnimatedEnumeration operator_ { get; }
		IScriptableSvgAnimatedNumber k1 { get; }
		IScriptableSvgAnimatedNumber k2 { get; }
		IScriptableSvgAnimatedNumber k3 { get; }
		IScriptableSvgAnimatedNumber k4 { get; }
	}

	/// <summary>
	/// IScriptableSvgFEConvolveMatrixElement
	/// </summary>
	public interface IScriptableSvgFEConvolveMatrixElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedInteger orderX { get; }
		IScriptableSvgAnimatedInteger orderY { get; }
		IScriptableSvgAnimatedNumberList kernelMatrix { get; }
		IScriptableSvgAnimatedNumber divisor { get; }
		IScriptableSvgAnimatedNumber bias { get; }
		IScriptableSvgAnimatedInteger targetX { get; }
		IScriptableSvgAnimatedInteger targetY { get; }
		IScriptableSvgAnimatedEnumeration edgeMode { get; }
		IScriptableSvgAnimatedLength kernelUnitLengthX { get; }
		IScriptableSvgAnimatedLength kernelUnitLengthY { get; }
		bool preserveAlpha { get; }
	}

	/// <summary>
	/// IScriptableSvgFEDiffuseLightingElement
	/// </summary>
	public interface IScriptableSvgFEDiffuseLightingElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedNumber surfaceScale { get; }
		IScriptableSvgAnimatedNumber diffuseConstant { get; }
	}

	/// <summary>
	/// IScriptableSvgFEDistantLightElement
	/// </summary>
	public interface IScriptableSvgFEDistantLightElement : IScriptableSvgElement
	{
		IScriptableSvgAnimatedNumber azimuth { get; }
		IScriptableSvgAnimatedNumber elevation { get; }
	}

	/// <summary>
	/// IScriptableSvgFEPointLightElement
	/// </summary>
	public interface IScriptableSvgFEPointLightElement : IScriptableSvgElement
	{
		IScriptableSvgAnimatedNumber x { get; }
		IScriptableSvgAnimatedNumber y { get; }
		IScriptableSvgAnimatedNumber z { get; }
	}

	/// <summary>
	/// IScriptableSvgFESpotLightElement
	/// </summary>
	public interface IScriptableSvgFESpotLightElement : IScriptableSvgElement
	{
		IScriptableSvgAnimatedNumber x { get; }
		IScriptableSvgAnimatedNumber y { get; }
		IScriptableSvgAnimatedNumber z { get; }
		IScriptableSvgAnimatedNumber pointsAtX { get; }
		IScriptableSvgAnimatedNumber pointsAtY { get; }
		IScriptableSvgAnimatedNumber pointsAtZ { get; }
		IScriptableSvgAnimatedNumber specularExponent { get; }
		IScriptableSvgAnimatedNumber limitingConeAngle { get; }
	}

	/// <summary>
	/// IScriptableSvgFEDisplacementMapElement
	/// </summary>
	public interface IScriptableSvgFEDisplacementMapElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedString in2 { get; }
		IScriptableSvgAnimatedNumber scale { get; }
		IScriptableSvgAnimatedEnumeration xChannelSelector { get; }
		IScriptableSvgAnimatedEnumeration yChannelSelector { get; }
	}

	/// <summary>
	/// IScriptableSvgFEFloodElement
	/// </summary>
	public interface IScriptableSvgFEFloodElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
	}

	/// <summary>
	/// IScriptableSvgFEGaussianBlurElement
	/// </summary>
	public interface IScriptableSvgFEGaussianBlurElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		void setStdDeviation(float stdDeviationX, float stdDeviationY);
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedNumber stdDeviationX { get; }
		IScriptableSvgAnimatedNumber stdDeviationY { get; }
	}

	/// <summary>
	/// IScriptableSvgFEImageElement
	/// </summary>
	public interface IScriptableSvgFEImageElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgFilterPrimitiveStandardAttributes
	{
	}

	/// <summary>
	/// IScriptableSvgFEMergeElement
	/// </summary>
	public interface IScriptableSvgFEMergeElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
	}

	/// <summary>
	/// IScriptableSvgFEMergeNodeElement
	/// </summary>
	public interface IScriptableSvgFEMergeNodeElement : IScriptableSvgElement
	{
		IScriptableSvgAnimatedString in1 { get; }
	}

	/// <summary>
	/// IScriptableSvgFEMorphologyElement
	/// </summary>
	public interface IScriptableSvgFEMorphologyElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedEnumeration operator_ { get; }
		IScriptableSvgAnimatedLength radiusX { get; }
		IScriptableSvgAnimatedLength radiusY { get; }
	}

	/// <summary>
	/// IScriptableSvgFEOffsetElement
	/// </summary>
	public interface IScriptableSvgFEOffsetElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedNumber dx { get; }
		IScriptableSvgAnimatedNumber dy { get; }
	}

	/// <summary>
	/// IScriptableSvgFESpecularLightingElement
	/// </summary>
	public interface IScriptableSvgFESpecularLightingElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
		IScriptableSvgAnimatedNumber surfaceScale { get; }
		IScriptableSvgAnimatedNumber specularConstant { get; }
		IScriptableSvgAnimatedNumber specularExponent { get; }
	}

	/// <summary>
	/// IScriptableSvgFETileElement
	/// </summary>
	public interface IScriptableSvgFETileElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedString in1 { get; }
	}

	/// <summary>
	/// IScriptableSvgFETurbulenceElement
	/// </summary>
	public interface IScriptableSvgFETurbulenceElement : IScriptableSvgElement, IScriptableSvgFilterPrimitiveStandardAttributes
	{
		IScriptableSvgAnimatedNumber baseFrequencyX { get; }
		IScriptableSvgAnimatedNumber baseFrequencyY { get; }
		IScriptableSvgAnimatedInteger numOctaves { get; }
		IScriptableSvgAnimatedNumber seed { get; }
		IScriptableSvgAnimatedEnumeration stitchTiles { get; }
		IScriptableSvgAnimatedEnumeration type { get; }
	}

	/// <summary>
	/// IScriptableSvgCursorElement
	/// </summary>
	public interface IScriptableSvgCursorElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgExternalResourcesRequired
	{
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
	}

	/// <summary>
	/// IScriptableSvgAElement
	/// </summary>
	public interface IScriptableSvgAElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedString target { get; }
	}

	/// <summary>
	/// IScriptableSvgViewElement
	/// </summary>
	public interface IScriptableSvgViewElement : IScriptableSvgElement, IScriptableSvgExternalResourcesRequired, IScriptableSvgFitToViewBox, IScriptableSvgZoomAndPan
	{
		IScriptableSvgStringList viewTarget { get; }
	}

	/// <summary>
	/// IScriptableSvgScriptElement
	/// </summary>
	public interface IScriptableSvgScriptElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgExternalResourcesRequired
	{
		string type { get; set; }
	}

	/// <summary>
	/// IScriptableSvgEvent
	/// </summary>
	public interface IScriptableSvgEvent : IScriptableEvent
	{
	}

	/// <summary>
	/// IScriptableSvgZoomEvent
	/// </summary>
	public interface IScriptableSvgZoomEvent : IScriptableUiEvent
	{
		IScriptableSvgRect zoomRectScreen { get; }
		float previousScale { get; }
		IScriptableSvgPoint previousTranslate { get; }
		float newScale { get; }
		IScriptableSvgPoint newTranslate { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimationElement
	/// </summary>
	public interface IScriptableSvgAnimationElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgExternalResourcesRequired, IScriptableElementTimeControl, IScriptableEventTarget
	{
		float getStartTime();
		float getCurrentTime();
		float getSimpleDuration();
		IScriptableSvgElement targetElement { get; }
	}

	/// <summary>
	/// IScriptableSvgAnimateElement
	/// </summary>
	public interface IScriptableSvgAnimateElement : IScriptableSvgAnimationElement
	{
	}

	/// <summary>
	/// IScriptableSvgSetElement
	/// </summary>
	public interface IScriptableSvgSetElement : IScriptableSvgAnimationElement
	{
	}

	/// <summary>
	/// IScriptableSvgAnimateMotionElement
	/// </summary>
	public interface IScriptableSvgAnimateMotionElement : IScriptableSvgAnimationElement
	{
	}

	/// <summary>
	/// IScriptableSvgMPathElement
	/// </summary>
	public interface IScriptableSvgMPathElement : IScriptableSvgElement, IScriptableSvgUriReference, IScriptableSvgExternalResourcesRequired
	{
	}

	/// <summary>
	/// IScriptableSvgAnimateColorElement
	/// </summary>
	public interface IScriptableSvgAnimateColorElement : IScriptableSvgAnimationElement
	{
	}

	/// <summary>
	/// IScriptableSvgAnimateTransformElement
	/// </summary>
	public interface IScriptableSvgAnimateTransformElement : IScriptableSvgAnimationElement
	{
	}

	/// <summary>
	/// IScriptableSvgFontElement
	/// </summary>
	public interface IScriptableSvgFontElement : IScriptableSvgElement, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable
	{
	}

	/// <summary>
	/// IScriptableSvgGlyphElement
	/// </summary>
	public interface IScriptableSvgGlyphElement : IScriptableSvgElement, IScriptableSvgStylable
	{
	}

	/// <summary>
	/// IScriptableSvgMissingGlyphElement
	/// </summary>
	public interface IScriptableSvgMissingGlyphElement : IScriptableSvgElement, IScriptableSvgStylable
	{
	}

	/// <summary>
	/// IScriptableSvgHKernElement
	/// </summary>
	public interface IScriptableSvgHKernElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgVKernElement
	/// </summary>
	public interface IScriptableSvgVKernElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgFontFaceElement
	/// </summary>
	public interface IScriptableSvgFontFaceElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgFontFaceSrcElement
	/// </summary>
	public interface IScriptableSvgFontFaceSrcElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgFontFaceUriElement
	/// </summary>
	public interface IScriptableSvgFontFaceUriElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgFontFaceFormatElement
	/// </summary>
	public interface IScriptableSvgFontFaceFormatElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgFontFaceNameElement
	/// </summary>
	public interface IScriptableSvgFontFaceNameElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgDefinitionSrcElement
	/// </summary>
	public interface IScriptableSvgDefinitionSrcElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgMetadataElement
	/// </summary>
	public interface IScriptableSvgMetadataElement : IScriptableSvgElement
	{
	}

	/// <summary>
	/// IScriptableSvgForeignObjectElement
	/// </summary>
	public interface IScriptableSvgForeignObjectElement : IScriptableSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
	{
		IScriptableSvgAnimatedLength x { get; }
		IScriptableSvgAnimatedLength y { get; }
		IScriptableSvgAnimatedLength width { get; }
		IScriptableSvgAnimatedLength height { get; }
	}

}
  