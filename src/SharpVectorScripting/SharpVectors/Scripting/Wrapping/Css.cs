using System;


namespace SharpVectors.Scripting
{

	/// <summary>
	/// IScriptableCssRuleList
	/// </summary>
	public interface IScriptableCssRuleList
	{
		IScriptableCssRule item(ulong index);
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableCssRule
	/// </summary>
	public interface IScriptableCssRule
	{
		ushort type { get; }
		string cssText { get; set; }
		IScriptableCssStyleSheet parentStyleSheet { get; }
		IScriptableCssRule parentRule { get; }
	}

	/// <summary>
	/// IScriptableCssStyleRule
	/// </summary>
	public interface IScriptableCssStyleRule : IScriptableCssRule
	{
		string selectorText { get; set; }
		IScriptableCssStyleDeclaration style { get; }
	}

	/// <summary>
	/// IScriptableCssMediaRule
	/// </summary>
	public interface IScriptableCssMediaRule : IScriptableCssRule
	{
		ulong insertRule(string rule, ulong index);
		void deleteRule(ulong index);
		IScriptableMediaList media { get; }
		IScriptableCssRuleList cssRules { get; }
	}

	/// <summary>
	/// IScriptableCssFontFaceRule
	/// </summary>
	public interface IScriptableCssFontFaceRule : IScriptableCssRule
	{
		IScriptableCssStyleDeclaration style { get; }
	}

	/// <summary>
	/// IScriptableCssPageRule
	/// </summary>
	public interface IScriptableCssPageRule : IScriptableCssRule
	{
		string selectorText { get; set; }
		IScriptableCssStyleDeclaration style { get; }
	}

	/// <summary>
	/// IScriptableCssImportRule
	/// </summary>
	public interface IScriptableCssImportRule : IScriptableCssRule
	{
		string href { get; }
		IScriptableMediaList media { get; }
		IScriptableCssStyleSheet styleSheet { get; }
	}

	/// <summary>
	/// IScriptableCssCharsetRule
	/// </summary>
	public interface IScriptableCssCharsetRule : IScriptableCssRule
	{
		string encoding { get; set; }
	}

	/// <summary>
	/// IScriptableCssUnknownRule
	/// </summary>
	public interface IScriptableCssUnknownRule : IScriptableCssRule
	{
	}

	/// <summary>
	/// IScriptableCssStyleDeclaration
	/// </summary>
	public interface IScriptableCssStyleDeclaration
	{
		string getPropertyValue(string propertyName);
		IScriptableCssValue getPropertyCSSValue(string propertyName);
		string removeProperty(string propertyName);
		string getPropertyPriority(string propertyName);
		void setProperty(string propertyName, string value, string priority);
		string item(ulong index);
		string cssText { get; set; }
		ulong length { get; }
		IScriptableCssRule parentRule { get; }
	}

	/// <summary>
	/// IScriptableCssValue
	/// </summary>
	public interface IScriptableCssValue
	{
		string cssText { get; set; }
		ushort cssValueType { get; }
	}

	/// <summary>
	/// IScriptableCssPrimitiveValue
	/// </summary>
	public interface IScriptableCssPrimitiveValue : IScriptableCssValue
	{
		void setFloatValue(ushort unitType, float floatValue);
		float getFloatValue(ushort unitType);
		void setStringValue(ushort stringType, string stringValue);
		string getStringValue();
		IScriptableCounter getCounterValue();
		IScriptableRect getRectValue();
		IScriptableRgbColor getRGBColorValue();
		ushort primitiveType { get; }
	}

	/// <summary>
	/// IScriptableCssValueList
	/// </summary>
	public interface IScriptableCssValueList : IScriptableCssValue
	{
		IScriptableCssValue item(ulong index);
		ulong length { get; }
	}

	/// <summary>
	/// IScriptableRgbColor
	/// </summary>
	public interface IScriptableRgbColor
	{
		IScriptableCssPrimitiveValue red { get; }
		IScriptableCssPrimitiveValue green { get; }
		IScriptableCssPrimitiveValue blue { get; }
	}

	/// <summary>
	/// IScriptableRect
	/// </summary>
	public interface IScriptableRect
	{
		IScriptableCssPrimitiveValue top { get; }
		IScriptableCssPrimitiveValue right { get; }
		IScriptableCssPrimitiveValue bottom { get; }
		IScriptableCssPrimitiveValue left { get; }
	}

	/// <summary>
	/// IScriptableCounter
	/// </summary>
	public interface IScriptableCounter
	{
		string identifier { get; }
		string listStyle { get; }
		string separator { get; }
	}

	/// <summary>
	/// IScriptableElementCssInlineStyle
	/// </summary>
	public interface IScriptableElementCssInlineStyle
	{
		IScriptableCssStyleDeclaration style { get; }
	}

	/// <summary>
	/// IScriptableCss2Properties
	/// </summary>
	public interface IScriptableCss2Properties
	{
		string azimuth { get; set; }
		string background { get; set; }
		string backgroundAttachment { get; set; }
		string backgroundColor { get; set; }
		string backgroundImage { get; set; }
		string backgroundPosition { get; set; }
		string backgroundRepeat { get; set; }
		string border { get; set; }
		string borderCollapse { get; set; }
		string borderColor { get; set; }
		string borderSpacing { get; set; }
		string borderStyle { get; set; }
		string borderTop { get; set; }
		string borderRight { get; set; }
		string borderBottom { get; set; }
		string borderLeft { get; set; }
		string borderTopColor { get; set; }
		string borderRightColor { get; set; }
		string borderBottomColor { get; set; }
		string borderLeftColor { get; set; }
		string borderTopStyle { get; set; }
		string borderRightStyle { get; set; }
		string borderBottomStyle { get; set; }
		string borderLeftStyle { get; set; }
		string borderTopWidth { get; set; }
		string borderRightWidth { get; set; }
		string borderBottomWidth { get; set; }
		string borderLeftWidth { get; set; }
		string borderWidth { get; set; }
		string bottom { get; set; }
		string captionSide { get; set; }
		string clear { get; set; }
		string clip { get; set; }
		string color { get; set; }
		string content { get; set; }
		string counterIncrement { get; set; }
		string counterReset { get; set; }
		string cue { get; set; }
		string cueAfter { get; set; }
		string cueBefore { get; set; }
		string cursor { get; set; }
		string direction { get; set; }
		string display { get; set; }
		string elevation { get; set; }
		string emptyCells { get; set; }
		string cssFloat { get; set; }
		string font { get; set; }
		string fontFamily { get; set; }
		string fontSize { get; set; }
		string fontSizeAdjust { get; set; }
		string fontStretch { get; set; }
		string fontStyle { get; set; }
		string fontVariant { get; set; }
		string fontWeight { get; set; }
		string height { get; set; }
		string left { get; set; }
		string letterSpacing { get; set; }
		string lineHeight { get; set; }
		string listStyle { get; set; }
		string listStyleImage { get; set; }
		string listStylePosition { get; set; }
		string listStyleType { get; set; }
		string margin { get; set; }
		string marginTop { get; set; }
		string marginRight { get; set; }
		string marginBottom { get; set; }
		string marginLeft { get; set; }
		string markerOffset { get; set; }
		string marks { get; set; }
		string maxHeight { get; set; }
		string maxWidth { get; set; }
		string minHeight { get; set; }
		string minWidth { get; set; }
		string orphans { get; set; }
		string outline { get; set; }
		string outlineColor { get; set; }
		string outlineStyle { get; set; }
		string outlineWidth { get; set; }
		string overflow { get; set; }
		string padding { get; set; }
		string paddingTop { get; set; }
		string paddingRight { get; set; }
		string paddingBottom { get; set; }
		string paddingLeft { get; set; }
		string page { get; set; }
		string pageBreakAfter { get; set; }
		string pageBreakBefore { get; set; }
		string pageBreakInside { get; set; }
		string pause { get; set; }
		string pauseAfter { get; set; }
		string pauseBefore { get; set; }
		string pitch { get; set; }
		string pitchRange { get; set; }
		string playDuring { get; set; }
		string position { get; set; }
		string quotes { get; set; }
		string richness { get; set; }
		string right { get; set; }
		string size { get; set; }
		string speak { get; set; }
		string speakHeader { get; set; }
		string speakNumeral { get; set; }
		string speakPunctuation { get; set; }
		string speechRate { get; set; }
		string stress { get; set; }
		string tableLayout { get; set; }
		string textAlign { get; set; }
		string textDecoration { get; set; }
		string textIndent { get; set; }
		string textShadow { get; set; }
		string textTransform { get; set; }
		string top { get; set; }
		string unicodeBidi { get; set; }
		string verticalAlign { get; set; }
		string visibility { get; set; }
		string voiceFamily { get; set; }
		string volume { get; set; }
		string whiteSpace { get; set; }
		string widows { get; set; }
		string width { get; set; }
		string wordSpacing { get; set; }
		string zIndex { get; set; }
	}

	/// <summary>
	/// IScriptableCssStyleSheet
	/// </summary>
	public interface IScriptableCssStyleSheet : IScriptableStyleSheet
	{
		ulong insertRule(string rule, ulong index);
		void deleteRule(ulong index);
		IScriptableCssRule ownerRule { get; }
		IScriptableCssRuleList cssRules { get; }
	}

	/// <summary>
	/// IScriptableViewCss
	/// </summary>
	public interface IScriptableViewCss : IScriptableAbstractView
	{
		IScriptableCssStyleDeclaration getComputedStyle(IScriptableElement elt, string pseudoElt);
	}

	/// <summary>
	/// IScriptableDocumentCss
	/// </summary>
	public interface IScriptableDocumentCss : IScriptableDocumentStyle
	{
		IScriptableCssStyleDeclaration getOverrideStyle(IScriptableElement elt, string pseudoElt);
	}

	/// <summary>
	/// IScriptableDomImplementationCss
	/// </summary>
	public interface IScriptableDomImplementationCss : IScriptableDomImplementation
	{
		IScriptableCssStyleSheet createCSSStyleSheet(string title, string media);
	}

}
  