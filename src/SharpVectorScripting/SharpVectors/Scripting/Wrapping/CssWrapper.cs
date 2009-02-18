using System;
using SharpVectors.Dom;
using SharpVectors.Dom.Css;
using SharpVectors.Dom.Events;
using SharpVectors.Dom.Stylesheets;
using SharpVectors.Dom.Svg;
using SharpVectors.Dom.Views;
using System.Xml;


namespace SharpVectors.Scripting
{

		/// <summary>
		/// Implementation wrapper for IScriptableCssRuleList
		/// </summary>
		public class ScriptableCssRuleList : ScriptableObject, IScriptableCssRuleList
		{
			public ScriptableCssRuleList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableCssRuleList
			public IScriptableCssRule item(ulong index)
			{
				object result = ((ICssRuleList)baseObject)[index];
				return (result != null) ? (IScriptableCssRule)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableCssRuleList
			public ulong length
			{
				get { return ((ICssRuleList)baseObject).Length;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssRule
		/// </summary>
		public class ScriptableCssRule : ScriptableObject, IScriptableCssRule
		{
			const ushort UNKNOWN_RULE                   = 0;
			const ushort STYLE_RULE                     = 1;
			const ushort CHARSET_RULE                   = 2;
			const ushort IMPORT_RULE                    = 3;
			const ushort MEDIA_RULE                     = 4;
			const ushort FONT_FACE_RULE                 = 5;
			const ushort PAGE_RULE                      = 6;

			public ScriptableCssRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssRule
			public ushort type
			{
				get { return (ushort)((ICssRule)baseObject).Type;  }
			}

			public string cssText
			{
				get { return ((ICssRule)baseObject).CssText;  }
				set { ((ICssRule)baseObject).CssText = value; }
			}

			public IScriptableCssStyleSheet parentStyleSheet
			{
				get { object result = ((ICssRule)baseObject).ParentStyleSheet; return (result != null) ? (IScriptableCssStyleSheet)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssRule parentRule
			{
				get { object result = ((ICssRule)baseObject).ParentRule; return (result != null) ? (IScriptableCssRule)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssStyleRule
		/// </summary>
		public class ScriptableCssStyleRule : ScriptableCssRule, IScriptableCssStyleRule
		{
			public ScriptableCssStyleRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssStyleRule
			public string selectorText
			{
				get { return ((ICssStyleRule)baseObject).SelectorText;  }
				set { ((ICssStyleRule)baseObject).SelectorText = value; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ICssStyleRule)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssMediaRule
		/// </summary>
		public class ScriptableCssMediaRule : ScriptableCssRule, IScriptableCssMediaRule
		{
			public ScriptableCssMediaRule(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableCssMediaRule
			public ulong insertRule(string rule, ulong index)
			{
				return ((ICssMediaRule)baseObject).InsertRule(rule, index);
			}

			public void deleteRule(ulong index)
			{
				((ICssMediaRule)baseObject).DeleteRule(index);
			}
			#endregion

			#region Properties - IScriptableCssMediaRule
			public IScriptableMediaList media
			{
				get { object result = ((ICssMediaRule)baseObject).Media; return (result != null) ? (IScriptableMediaList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssRuleList cssRules
			{
				get { object result = ((ICssMediaRule)baseObject).CssRules; return (result != null) ? (IScriptableCssRuleList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssFontFaceRule
		/// </summary>
		public class ScriptableCssFontFaceRule : ScriptableCssRule, IScriptableCssFontFaceRule
		{
			public ScriptableCssFontFaceRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssFontFaceRule
			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ICssFontFaceRule)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssPageRule
		/// </summary>
		public class ScriptableCssPageRule : ScriptableCssRule, IScriptableCssPageRule
		{
			public ScriptableCssPageRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssPageRule
			public string selectorText
			{
				get { return ((ICssPageRule)baseObject).SelectorText;  }
				set { ((ICssPageRule)baseObject).SelectorText = value; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ICssPageRule)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssImportRule
		/// </summary>
		public class ScriptableCssImportRule : ScriptableCssRule, IScriptableCssImportRule
		{
			public ScriptableCssImportRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssImportRule
			public string href
			{
				get { return ((ICssImportRule)baseObject).Href;  }
			}

			public IScriptableMediaList media
			{
				get { object result = ((ICssImportRule)baseObject).Media; return (result != null) ? (IScriptableMediaList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleSheet styleSheet
			{
				get { object result = ((ICssImportRule)baseObject).StyleSheet; return (result != null) ? (IScriptableCssStyleSheet)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssCharsetRule
		/// </summary>
		public class ScriptableCssCharsetRule : ScriptableCssRule, IScriptableCssCharsetRule
		{
			public ScriptableCssCharsetRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssCharsetRule
			public string encoding
			{
				get { return ((ICssCharsetRule)baseObject).Encoding;  }
				set { ((ICssCharsetRule)baseObject).Encoding = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssUnknownRule
		/// </summary>
		public class ScriptableCssUnknownRule : ScriptableCssRule, IScriptableCssUnknownRule
		{
			public ScriptableCssUnknownRule(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssStyleDeclaration
		/// </summary>
		public class ScriptableCssStyleDeclaration : ScriptableObject, IScriptableCssStyleDeclaration
		{
			public ScriptableCssStyleDeclaration(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableCssStyleDeclaration
			public string getPropertyValue(string propertyName)
			{
				return ((ICssStyleDeclaration)baseObject).GetPropertyValue(propertyName);
			}

			public IScriptableCssValue getPropertyCSSValue(string propertyName)
			{
				object result = ((ICssStyleDeclaration)baseObject).GetPropertyCssValue(propertyName);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}

			public string removeProperty(string propertyName)
			{
				return ((ICssStyleDeclaration)baseObject).RemoveProperty(propertyName);
			}

			public string getPropertyPriority(string propertyName)
			{
				return ((ICssStyleDeclaration)baseObject).GetPropertyPriority(propertyName);
			}

			public void setProperty(string propertyName, string value, string priority)
			{
				((ICssStyleDeclaration)baseObject).SetProperty(propertyName, value, priority);
			}

			public string item(ulong index)
			{
				return ((ICssStyleDeclaration)baseObject)[index];
			}
			#endregion

			#region Properties - IScriptableCssStyleDeclaration
			public string cssText
			{
				get { return ((ICssStyleDeclaration)baseObject).CssText;  }
				set { ((ICssStyleDeclaration)baseObject).CssText = value; }
			}

			public ulong length
			{
				get { return ((ICssStyleDeclaration)baseObject).Length;  }
			}

			public IScriptableCssRule parentRule
			{
				get { object result = ((ICssStyleDeclaration)baseObject).ParentRule; return (result != null) ? (IScriptableCssRule)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssValue
		/// </summary>
		public class ScriptableCssValue : ScriptableObject, IScriptableCssValue
		{
			const ushort CSS_INHERIT                    = 0;
			const ushort CSS_PRIMITIVE_VALUE            = 1;
			const ushort CSS_VALUE_LIST                 = 2;
			const ushort CSS_CUSTOM                     = 3;

			public ScriptableCssValue(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCssValue
			public string cssText
			{
				get { return ((ICssValue)baseObject).CssText;  }
				set { ((ICssValue)baseObject).CssText = value; }
			}

			public ushort cssValueType
			{
				get { return (ushort)((ICssValue)baseObject).CssValueType;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssPrimitiveValue
		/// </summary>
		public class ScriptableCssPrimitiveValue : ScriptableCssValue, IScriptableCssPrimitiveValue
		{
			const ushort CSS_UNKNOWN                    = 0;
			const ushort CSS_NUMBER                     = 1;
			const ushort CSS_PERCENTAGE                 = 2;
			const ushort CSS_EMS                        = 3;
			const ushort CSS_EXS                        = 4;
			const ushort CSS_PX                         = 5;
			const ushort CSS_CM                         = 6;
			const ushort CSS_MM                         = 7;
			const ushort CSS_IN                         = 8;
			const ushort CSS_PT                         = 9;
			const ushort CSS_PC                         = 10;
			const ushort CSS_DEG                        = 11;
			const ushort CSS_RAD                        = 12;
			const ushort CSS_GRAD                       = 13;
			const ushort CSS_MS                         = 14;
			const ushort CSS_S                          = 15;
			const ushort CSS_HZ                         = 16;
			const ushort CSS_KHZ                        = 17;
			const ushort CSS_DIMENSION                  = 18;
			const ushort CSS_STRING                     = 19;
			const ushort CSS_URI                        = 20;
			const ushort CSS_IDENT                      = 21;
			const ushort CSS_ATTR                       = 22;
			const ushort CSS_COUNTER                    = 23;
			const ushort CSS_RECT                       = 24;
			const ushort CSS_RGBCOLOR                   = 25;

			public ScriptableCssPrimitiveValue(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableCssPrimitiveValue
			public void setFloatValue(ushort unitType, float floatValue)
			{
				((ICssPrimitiveValue)baseObject).SetFloatValue((CssPrimitiveType)unitType, floatValue);
			}

			public float getFloatValue(ushort unitType)
			{
				return (float)((ICssPrimitiveValue)baseObject).GetFloatValue((CssPrimitiveType)unitType);
			}

			public void setStringValue(ushort stringType, string stringValue)
			{
				((ICssPrimitiveValue)baseObject).SetStringValue((CssPrimitiveType)stringType, stringValue);
			}

			public string getStringValue()
			{
				return ((ICssPrimitiveValue)baseObject).GetStringValue();
			}

			public IScriptableCounter getCounterValue()
			{
				object result = ((ICssPrimitiveValue)baseObject).GetCounterValue();
				return (result != null) ? (IScriptableCounter)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableRect getRectValue()
			{
				object result = ((ICssPrimitiveValue)baseObject).GetRectValue();
				return (result != null) ? (IScriptableRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableRgbColor getRGBColorValue()
			{
				object result = ((ICssPrimitiveValue)baseObject).GetRgbColorValue();
				return (result != null) ? (IScriptableRgbColor)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableCssPrimitiveValue
			public ushort primitiveType
			{
				get { return (ushort)((ICssPrimitiveValue)baseObject).PrimitiveType;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCssValueList
		/// </summary>
		public class ScriptableCssValueList : ScriptableCssValue, IScriptableCssValueList
		{
			public ScriptableCssValueList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableCssValueList
			public IScriptableCssValue item(ulong index)
			{
				object result = ((ICssValueList)baseObject)[index];
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableCssValueList
			public ulong length
			{
				get { return ((ICssValueList)baseObject).Length;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableRgbColor
		/// </summary>
		public class ScriptableRgbColor : ScriptableObject, IScriptableRgbColor
		{
			public ScriptableRgbColor(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableRgbColor
			public IScriptableCssPrimitiveValue red
			{
				get { object result = ((IRgbColor)baseObject).Red; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssPrimitiveValue green
			{
				get { object result = ((IRgbColor)baseObject).Green; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssPrimitiveValue blue
			{
				get { object result = ((IRgbColor)baseObject).Blue; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableRect
		/// </summary>
		public class ScriptableRect : ScriptableObject, IScriptableRect
		{
			public ScriptableRect(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableRect
			public IScriptableCssPrimitiveValue top
			{
				get { object result = ((IRect)baseObject).Top; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssPrimitiveValue right
			{
				get { object result = ((IRect)baseObject).Right; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssPrimitiveValue bottom
			{
				get { object result = ((IRect)baseObject).Bottom; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssPrimitiveValue left
			{
				get { object result = ((IRect)baseObject).Left; return (result != null) ? (IScriptableCssPrimitiveValue)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableCounter
		/// </summary>
		public class ScriptableCounter : ScriptableObject, IScriptableCounter
		{
			public ScriptableCounter(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCounter
			public string identifier
			{
				get { return ((ICounter)baseObject).Identifier;  }
			}

			public string listStyle
			{
				get { return ((ICounter)baseObject).ListStyle;  }
			}

			public string separator
			{
				get { return ((ICounter)baseObject).Separator;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableElementCssInlineStyle
		/// </summary>
		public class ScriptableElementCssInlineStyle : ScriptableObject, IScriptableElementCssInlineStyle
		{
			public ScriptableElementCssInlineStyle(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableElementCssInlineStyle
			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((IElementCssInlineStyle)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/*
    /// <summary>
		/// Implementation wrapper for IScriptableCss2Properties
		/// </summary>
		public class ScriptableCss2Properties : ScriptableObject, IScriptableCss2Properties
		{
			public ScriptableCss2Properties(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableCss2Properties
			public string azimuth
			{
				get { return ((ICss2Properties)baseObject).Azimuth;  }
				set { ((ICss2Properties)baseObject).Azimuth = value; }
			}

			public string background
			{
				get { return ((ICss2Properties)baseObject).Background;  }
				set { ((ICss2Properties)baseObject).Background = value; }
			}

			public string backgroundAttachment
			{
				get { return ((ICss2Properties)baseObject).BackgroundAttachment;  }
				set { ((ICss2Properties)baseObject).BackgroundAttachment = value; }
			}

			public string backgroundColor
			{
				get { return ((ICss2Properties)baseObject).BackgroundColor;  }
				set { ((ICss2Properties)baseObject).BackgroundColor = value; }
			}

			public string backgroundImage
			{
				get { return ((ICss2Properties)baseObject).BackgroundImage;  }
				set { ((ICss2Properties)baseObject).BackgroundImage = value; }
			}

			public string backgroundPosition
			{
				get { return ((ICss2Properties)baseObject).BackgroundPosition;  }
				set { ((ICss2Properties)baseObject).BackgroundPosition = value; }
			}

			public string backgroundRepeat
			{
				get { return ((ICss2Properties)baseObject).BackgroundRepeat;  }
				set { ((ICss2Properties)baseObject).BackgroundRepeat = value; }
			}

			public string border
			{
				get { return ((ICss2Properties)baseObject).Border;  }
				set { ((ICss2Properties)baseObject).Border = value; }
			}

			public string borderCollapse
			{
				get { return ((ICss2Properties)baseObject).BorderCollapse;  }
				set { ((ICss2Properties)baseObject).BorderCollapse = value; }
			}

			public string borderColor
			{
				get { return ((ICss2Properties)baseObject).BorderColor;  }
				set { ((ICss2Properties)baseObject).BorderColor = value; }
			}

			public string borderSpacing
			{
				get { return ((ICss2Properties)baseObject).BorderSpacing;  }
				set { ((ICss2Properties)baseObject).BorderSpacing = value; }
			}

			public string borderStyle
			{
				get { return ((ICss2Properties)baseObject).BorderStyle;  }
				set { ((ICss2Properties)baseObject).BorderStyle = value; }
			}

			public string borderTop
			{
				get { return ((ICss2Properties)baseObject).BorderTop;  }
				set { ((ICss2Properties)baseObject).BorderTop = value; }
			}

			public string borderRight
			{
				get { return ((ICss2Properties)baseObject).BorderRight;  }
				set { ((ICss2Properties)baseObject).BorderRight = value; }
			}

			public string borderBottom
			{
				get { return ((ICss2Properties)baseObject).BorderBottom;  }
				set { ((ICss2Properties)baseObject).BorderBottom = value; }
			}

			public string borderLeft
			{
				get { return ((ICss2Properties)baseObject).BorderLeft;  }
				set { ((ICss2Properties)baseObject).BorderLeft = value; }
			}

			public string borderTopColor
			{
				get { return ((ICss2Properties)baseObject).BorderTopColor;  }
				set { ((ICss2Properties)baseObject).BorderTopColor = value; }
			}

			public string borderRightColor
			{
				get { return ((ICss2Properties)baseObject).BorderRightColor;  }
				set { ((ICss2Properties)baseObject).BorderRightColor = value; }
			}

			public string borderBottomColor
			{
				get { return ((ICss2Properties)baseObject).BorderBottomColor;  }
				set { ((ICss2Properties)baseObject).BorderBottomColor = value; }
			}

			public string borderLeftColor
			{
				get { return ((ICss2Properties)baseObject).BorderLeftColor;  }
				set { ((ICss2Properties)baseObject).BorderLeftColor = value; }
			}

			public string borderTopStyle
			{
				get { return ((ICss2Properties)baseObject).BorderTopStyle;  }
				set { ((ICss2Properties)baseObject).BorderTopStyle = value; }
			}

			public string borderRightStyle
			{
				get { return ((ICss2Properties)baseObject).BorderRightStyle;  }
				set { ((ICss2Properties)baseObject).BorderRightStyle = value; }
			}

			public string borderBottomStyle
			{
				get { return ((ICss2Properties)baseObject).BorderBottomStyle;  }
				set { ((ICss2Properties)baseObject).BorderBottomStyle = value; }
			}

			public string borderLeftStyle
			{
				get { return ((ICss2Properties)baseObject).BorderLeftStyle;  }
				set { ((ICss2Properties)baseObject).BorderLeftStyle = value; }
			}

			public string borderTopWidth
			{
				get { return ((ICss2Properties)baseObject).BorderTopWidth;  }
				set { ((ICss2Properties)baseObject).BorderTopWidth = value; }
			}

			public string borderRightWidth
			{
				get { return ((ICss2Properties)baseObject).BorderRightWidth;  }
				set { ((ICss2Properties)baseObject).BorderRightWidth = value; }
			}

			public string borderBottomWidth
			{
				get { return ((ICss2Properties)baseObject).BorderBottomWidth;  }
				set { ((ICss2Properties)baseObject).BorderBottomWidth = value; }
			}

			public string borderLeftWidth
			{
				get { return ((ICss2Properties)baseObject).BorderLeftWidth;  }
				set { ((ICss2Properties)baseObject).BorderLeftWidth = value; }
			}

			public string borderWidth
			{
				get { return ((ICss2Properties)baseObject).BorderWidth;  }
				set { ((ICss2Properties)baseObject).BorderWidth = value; }
			}

			public string bottom
			{
				get { return ((ICss2Properties)baseObject).Bottom;  }
				set { ((ICss2Properties)baseObject).Bottom = value; }
			}

			public string captionSide
			{
				get { return ((ICss2Properties)baseObject).CaptionSide;  }
				set { ((ICss2Properties)baseObject).CaptionSide = value; }
			}

			public string clear
			{
				get { return ((ICss2Properties)baseObject).Clear;  }
				set { ((ICss2Properties)baseObject).Clear = value; }
			}

			public string clip
			{
				get { return ((ICss2Properties)baseObject).Clip;  }
				set { ((ICss2Properties)baseObject).Clip = value; }
			}

			public string color
			{
				get { return ((ICss2Properties)baseObject).Color;  }
				set { ((ICss2Properties)baseObject).Color = value; }
			}

			public string content
			{
				get { return ((ICss2Properties)baseObject).Content;  }
				set { ((ICss2Properties)baseObject).Content = value; }
			}

			public string counterIncrement
			{
				get { return ((ICss2Properties)baseObject).CounterIncrement;  }
				set { ((ICss2Properties)baseObject).CounterIncrement = value; }
			}

			public string counterReset
			{
				get { return ((ICss2Properties)baseObject).CounterReset;  }
				set { ((ICss2Properties)baseObject).CounterReset = value; }
			}

			public string cue
			{
				get { return ((ICss2Properties)baseObject).Cue;  }
				set { ((ICss2Properties)baseObject).Cue = value; }
			}

			public string cueAfter
			{
				get { return ((ICss2Properties)baseObject).CueAfter;  }
				set { ((ICss2Properties)baseObject).CueAfter = value; }
			}

			public string cueBefore
			{
				get { return ((ICss2Properties)baseObject).CueBefore;  }
				set { ((ICss2Properties)baseObject).CueBefore = value; }
			}

			public string cursor
			{
				get { return ((ICss2Properties)baseObject).Cursor;  }
				set { ((ICss2Properties)baseObject).Cursor = value; }
			}

			public string direction
			{
				get { return ((ICss2Properties)baseObject).Direction;  }
				set { ((ICss2Properties)baseObject).Direction = value; }
			}

			public string display
			{
				get { return ((ICss2Properties)baseObject).Display;  }
				set { ((ICss2Properties)baseObject).Display = value; }
			}

			public string elevation
			{
				get { return ((ICss2Properties)baseObject).Elevation;  }
				set { ((ICss2Properties)baseObject).Elevation = value; }
			}

			public string emptyCells
			{
				get { return ((ICss2Properties)baseObject).EmptyCells;  }
				set { ((ICss2Properties)baseObject).EmptyCells = value; }
			}

			public string cssFloat
			{
				get { return ((ICss2Properties)baseObject).CssFloat;  }
				set { ((ICss2Properties)baseObject).CssFloat = value; }
			}

			public string font
			{
				get { return ((ICss2Properties)baseObject).Font;  }
				set { ((ICss2Properties)baseObject).Font = value; }
			}

			public string fontFamily
			{
				get { return ((ICss2Properties)baseObject).FontFamily;  }
				set { ((ICss2Properties)baseObject).FontFamily = value; }
			}

			public string fontSize
			{
				get { return ((ICss2Properties)baseObject).FontSize;  }
				set { ((ICss2Properties)baseObject).FontSize = value; }
			}

			public string fontSizeAdjust
			{
				get { return ((ICss2Properties)baseObject).FontSizeAdjust;  }
				set { ((ICss2Properties)baseObject).FontSizeAdjust = value; }
			}

			public string fontStretch
			{
				get { return ((ICss2Properties)baseObject).FontStretch;  }
				set { ((ICss2Properties)baseObject).FontStretch = value; }
			}

			public string fontStyle
			{
				get { return ((ICss2Properties)baseObject).FontStyle;  }
				set { ((ICss2Properties)baseObject).FontStyle = value; }
			}

			public string fontVariant
			{
				get { return ((ICss2Properties)baseObject).FontVariant;  }
				set { ((ICss2Properties)baseObject).FontVariant = value; }
			}

			public string fontWeight
			{
				get { return ((ICss2Properties)baseObject).FontWeight;  }
				set { ((ICss2Properties)baseObject).FontWeight = value; }
			}

			public string height
			{
				get { return ((ICss2Properties)baseObject).Height;  }
				set { ((ICss2Properties)baseObject).Height = value; }
			}

			public string left
			{
				get { return ((ICss2Properties)baseObject).Left;  }
				set { ((ICss2Properties)baseObject).Left = value; }
			}

			public string letterSpacing
			{
				get { return ((ICss2Properties)baseObject).LetterSpacing;  }
				set { ((ICss2Properties)baseObject).LetterSpacing = value; }
			}

			public string lineHeight
			{
				get { return ((ICss2Properties)baseObject).LineHeight;  }
				set { ((ICss2Properties)baseObject).LineHeight = value; }
			}

			public string listStyle
			{
				get { return ((ICss2Properties)baseObject).ListStyle;  }
				set { ((ICss2Properties)baseObject).ListStyle = value; }
			}

			public string listStyleImage
			{
				get { return ((ICss2Properties)baseObject).ListStyleImage;  }
				set { ((ICss2Properties)baseObject).ListStyleImage = value; }
			}

			public string listStylePosition
			{
				get { return ((ICss2Properties)baseObject).ListStylePosition;  }
				set { ((ICss2Properties)baseObject).ListStylePosition = value; }
			}

			public string listStyleType
			{
				get { return ((ICss2Properties)baseObject).ListStyleType;  }
				set { ((ICss2Properties)baseObject).ListStyleType = value; }
			}

			public string margin
			{
				get { return ((ICss2Properties)baseObject).Margin;  }
				set { ((ICss2Properties)baseObject).Margin = value; }
			}

			public string marginTop
			{
				get { return ((ICss2Properties)baseObject).MarginTop;  }
				set { ((ICss2Properties)baseObject).MarginTop = value; }
			}

			public string marginRight
			{
				get { return ((ICss2Properties)baseObject).MarginRight;  }
				set { ((ICss2Properties)baseObject).MarginRight = value; }
			}

			public string marginBottom
			{
				get { return ((ICss2Properties)baseObject).MarginBottom;  }
				set { ((ICss2Properties)baseObject).MarginBottom = value; }
			}

			public string marginLeft
			{
				get { return ((ICss2Properties)baseObject).MarginLeft;  }
				set { ((ICss2Properties)baseObject).MarginLeft = value; }
			}

			public string markerOffset
			{
				get { return ((ICss2Properties)baseObject).MarkerOffset;  }
				set { ((ICss2Properties)baseObject).MarkerOffset = value; }
			}

			public string marks
			{
				get { return ((ICss2Properties)baseObject).Marks;  }
				set { ((ICss2Properties)baseObject).Marks = value; }
			}

			public string maxHeight
			{
				get { return ((ICss2Properties)baseObject).MaxHeight;  }
				set { ((ICss2Properties)baseObject).MaxHeight = value; }
			}

			public string maxWidth
			{
				get { return ((ICss2Properties)baseObject).MaxWidth;  }
				set { ((ICss2Properties)baseObject).MaxWidth = value; }
			}

			public string minHeight
			{
				get { return ((ICss2Properties)baseObject).MinHeight;  }
				set { ((ICss2Properties)baseObject).MinHeight = value; }
			}

			public string minWidth
			{
				get { return ((ICss2Properties)baseObject).MinWidth;  }
				set { ((ICss2Properties)baseObject).MinWidth = value; }
			}

			public string orphans
			{
				get { return ((ICss2Properties)baseObject).Orphans;  }
				set { ((ICss2Properties)baseObject).Orphans = value; }
			}

			public string outline
			{
				get { return ((ICss2Properties)baseObject).Outline;  }
				set { ((ICss2Properties)baseObject).Outline = value; }
			}

			public string outlineColor
			{
				get { return ((ICss2Properties)baseObject).OutlineColor;  }
				set { ((ICss2Properties)baseObject).OutlineColor = value; }
			}

			public string outlineStyle
			{
				get { return ((ICss2Properties)baseObject).OutlineStyle;  }
				set { ((ICss2Properties)baseObject).OutlineStyle = value; }
			}

			public string outlineWidth
			{
				get { return ((ICss2Properties)baseObject).OutlineWidth;  }
				set { ((ICss2Properties)baseObject).OutlineWidth = value; }
			}

			public string overflow
			{
				get { return ((ICss2Properties)baseObject).Overflow;  }
				set { ((ICss2Properties)baseObject).Overflow = value; }
			}

			public string padding
			{
				get { return ((ICss2Properties)baseObject).Padding;  }
				set { ((ICss2Properties)baseObject).Padding = value; }
			}

			public string paddingTop
			{
				get { return ((ICss2Properties)baseObject).PaddingTop;  }
				set { ((ICss2Properties)baseObject).PaddingTop = value; }
			}

			public string paddingRight
			{
				get { return ((ICss2Properties)baseObject).PaddingRight;  }
				set { ((ICss2Properties)baseObject).PaddingRight = value; }
			}

			public string paddingBottom
			{
				get { return ((ICss2Properties)baseObject).PaddingBottom;  }
				set { ((ICss2Properties)baseObject).PaddingBottom = value; }
			}

			public string paddingLeft
			{
				get { return ((ICss2Properties)baseObject).PaddingLeft;  }
				set { ((ICss2Properties)baseObject).PaddingLeft = value; }
			}

			public string page
			{
				get { return ((ICss2Properties)baseObject).Page;  }
				set { ((ICss2Properties)baseObject).Page = value; }
			}

			public string pageBreakAfter
			{
				get { return ((ICss2Properties)baseObject).PageBreakAfter;  }
				set { ((ICss2Properties)baseObject).PageBreakAfter = value; }
			}

			public string pageBreakBefore
			{
				get { return ((ICss2Properties)baseObject).PageBreakBefore;  }
				set { ((ICss2Properties)baseObject).PageBreakBefore = value; }
			}

			public string pageBreakInside
			{
				get { return ((ICss2Properties)baseObject).PageBreakInside;  }
				set { ((ICss2Properties)baseObject).PageBreakInside = value; }
			}

			public string pause
			{
				get { return ((ICss2Properties)baseObject).Pause;  }
				set { ((ICss2Properties)baseObject).Pause = value; }
			}

			public string pauseAfter
			{
				get { return ((ICss2Properties)baseObject).PauseAfter;  }
				set { ((ICss2Properties)baseObject).PauseAfter = value; }
			}

			public string pauseBefore
			{
				get { return ((ICss2Properties)baseObject).PauseBefore;  }
				set { ((ICss2Properties)baseObject).PauseBefore = value; }
			}

			public string pitch
			{
				get { return ((ICss2Properties)baseObject).Pitch;  }
				set { ((ICss2Properties)baseObject).Pitch = value; }
			}

			public string pitchRange
			{
				get { return ((ICss2Properties)baseObject).PitchRange;  }
				set { ((ICss2Properties)baseObject).PitchRange = value; }
			}

			public string playDuring
			{
				get { return ((ICss2Properties)baseObject).PlayDuring;  }
				set { ((ICss2Properties)baseObject).PlayDuring = value; }
			}

			public string position
			{
				get { return ((ICss2Properties)baseObject).Position;  }
				set { ((ICss2Properties)baseObject).Position = value; }
			}

			public string quotes
			{
				get { return ((ICss2Properties)baseObject).Quotes;  }
				set { ((ICss2Properties)baseObject).Quotes = value; }
			}

			public string richness
			{
				get { return ((ICss2Properties)baseObject).Richness;  }
				set { ((ICss2Properties)baseObject).Richness = value; }
			}

			public string right
			{
				get { return ((ICss2Properties)baseObject).Right;  }
				set { ((ICss2Properties)baseObject).Right = value; }
			}

			public string size
			{
				get { return ((ICss2Properties)baseObject).Size;  }
				set { ((ICss2Properties)baseObject).Size = value; }
			}

			public string speak
			{
				get { return ((ICss2Properties)baseObject).Speak;  }
				set { ((ICss2Properties)baseObject).Speak = value; }
			}

			public string speakHeader
			{
				get { return ((ICss2Properties)baseObject).SpeakHeader;  }
				set { ((ICss2Properties)baseObject).SpeakHeader = value; }
			}

			public string speakNumeral
			{
				get { return ((ICss2Properties)baseObject).SpeakNumeral;  }
				set { ((ICss2Properties)baseObject).SpeakNumeral = value; }
			}

			public string speakPunctuation
			{
				get { return ((ICss2Properties)baseObject).SpeakPunctuation;  }
				set { ((ICss2Properties)baseObject).SpeakPunctuation = value; }
			}

			public string speechRate
			{
				get { return ((ICss2Properties)baseObject).SpeechRate;  }
				set { ((ICss2Properties)baseObject).SpeechRate = value; }
			}

			public string stress
			{
				get { return ((ICss2Properties)baseObject).Stress;  }
				set { ((ICss2Properties)baseObject).Stress = value; }
			}

			public string tableLayout
			{
				get { return ((ICss2Properties)baseObject).TableLayout;  }
				set { ((ICss2Properties)baseObject).TableLayout = value; }
			}

			public string textAlign
			{
				get { return ((ICss2Properties)baseObject).TextAlign;  }
				set { ((ICss2Properties)baseObject).TextAlign = value; }
			}

			public string textDecoration
			{
				get { return ((ICss2Properties)baseObject).TextDecoration;  }
				set { ((ICss2Properties)baseObject).TextDecoration = value; }
			}

			public string textIndent
			{
				get { return ((ICss2Properties)baseObject).TextIndent;  }
				set { ((ICss2Properties)baseObject).TextIndent = value; }
			}

			public string textShadow
			{
				get { return ((ICss2Properties)baseObject).TextShadow;  }
				set { ((ICss2Properties)baseObject).TextShadow = value; }
			}

			public string textTransform
			{
				get { return ((ICss2Properties)baseObject).TextTransform;  }
				set { ((ICss2Properties)baseObject).TextTransform = value; }
			}

			public string top
			{
				get { return ((ICss2Properties)baseObject).Top;  }
				set { ((ICss2Properties)baseObject).Top = value; }
			}

			public string unicodeBidi
			{
				get { return ((ICss2Properties)baseObject).UnicodeBidi;  }
				set { ((ICss2Properties)baseObject).UnicodeBidi = value; }
			}

			public string verticalAlign
			{
				get { return ((ICss2Properties)baseObject).VerticalAlign;  }
				set { ((ICss2Properties)baseObject).VerticalAlign = value; }
			}

			public string visibility
			{
				get { return ((ICss2Properties)baseObject).Visibility;  }
				set { ((ICss2Properties)baseObject).Visibility = value; }
			}

			public string voiceFamily
			{
				get { return ((ICss2Properties)baseObject).VoiceFamily;  }
				set { ((ICss2Properties)baseObject).VoiceFamily = value; }
			}

			public string volume
			{
				get { return ((ICss2Properties)baseObject).Volume;  }
				set { ((ICss2Properties)baseObject).Volume = value; }
			}

			public string whiteSpace
			{
				get { return ((ICss2Properties)baseObject).WhiteSpace;  }
				set { ((ICss2Properties)baseObject).WhiteSpace = value; }
			}

			public string widows
			{
				get { return ((ICss2Properties)baseObject).Widows;  }
				set { ((ICss2Properties)baseObject).Widows = value; }
			}

			public string width
			{
				get { return ((ICss2Properties)baseObject).Width;  }
				set { ((ICss2Properties)baseObject).Width = value; }
			}

			public string wordSpacing
			{
				get { return ((ICss2Properties)baseObject).WordSpacing;  }
				set { ((ICss2Properties)baseObject).WordSpacing = value; }
			}

			public string zIndex
			{
				get { return ((ICss2Properties)baseObject).ZIndex;  }
				set { ((ICss2Properties)baseObject).ZIndex = value; }
			}

			#endregion
		}
    */

		/// <summary>
		/// Implementation wrapper for IScriptableCssStyleSheet
		/// </summary>
		public class ScriptableCssStyleSheet : ScriptableStyleSheet, IScriptableCssStyleSheet
		{
			public ScriptableCssStyleSheet(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableCssStyleSheet
			public ulong insertRule(string rule, ulong index)
			{
				return ((ICssStyleSheet)baseObject).InsertRule(rule, index);
			}

			public void deleteRule(ulong index)
			{
				((ICssStyleSheet)baseObject).DeleteRule(index);
			}
			#endregion

			#region Properties - IScriptableCssStyleSheet
			public IScriptableCssRule ownerRule
			{
				get { object result = ((ICssStyleSheet)baseObject).OwnerRule; return (result != null) ? (IScriptableCssRule)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssRuleList cssRules
			{
				get { object result = ((ICssStyleSheet)baseObject).CssRules; return (result != null) ? (IScriptableCssRuleList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableViewCss
		/// </summary>
		public class ScriptableViewCss : ScriptableAbstractView, IScriptableViewCss
		{
			public ScriptableViewCss(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableViewCss
			public IScriptableCssStyleDeclaration getComputedStyle(IScriptableElement elt, string pseudoElt)
			{
				object result = ((IViewCss)baseObject).GetComputedStyle(((XmlElement)((ScriptableElement)elt).baseObject), pseudoElt);
				return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDocumentCss
		/// </summary>
		public class ScriptableDocumentCss : ScriptableDocumentStyle, IScriptableDocumentCss
		{
			public ScriptableDocumentCss(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableDocumentCss
			public IScriptableCssStyleDeclaration getOverrideStyle(IScriptableElement elt, string pseudoElt)
			{
				object result = ((IDocumentCss)baseObject).GetOverrideStyle(((XmlElement)((ScriptableElement)elt).baseObject), pseudoElt);
				return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableDomImplementationCss
		/// </summary>
		public class ScriptableDomImplementationCss : ScriptableDomImplementation, IScriptableDomImplementationCss
		{
			public ScriptableDomImplementationCss(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableDomImplementationCss
			public IScriptableCssStyleSheet createCSSStyleSheet(string title, string media)
			{
				object result = ((IDomImplementationCss)baseObject).CreateCssStyleSheet(title, media);
				return (result != null) ? (IScriptableCssStyleSheet)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

}
  
