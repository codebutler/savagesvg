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
		/// Implementation wrapper for IScriptableSvgElement
		/// </summary>
		public class ScriptableSvgElement : ScriptableElement, IScriptableSvgElement
		{
			public ScriptableSvgElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgElement
			public string id
			{
				get { return ((ISvgElement)baseObject).Id;  }
				set { ((ISvgElement)baseObject).Id = value; }
			}

			public string xmlbase
			{
				get { return ((XmlElement)baseObject).BaseURI;  }
				set { ((XmlElement)baseObject).SetAttribute("xml:base", value); }
			}

			public IScriptableSvgSvgElement ownerSVGElement
			{
				get { object result = ((ISvgElement)baseObject).OwnerSvgElement; return (result != null) ? (IScriptableSvgSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement viewportElement
			{
				get { object result = ((ISvgElement)baseObject).ViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedBoolean
		/// </summary>
		public class ScriptableSvgAnimatedBoolean : ScriptableObject, IScriptableSvgAnimatedBoolean
		{
			public ScriptableSvgAnimatedBoolean(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedBoolean
			public bool baseVal
			{
				get { return ((ISvgAnimatedBoolean)baseObject).BaseVal;  }
				set { ((ISvgAnimatedBoolean)baseObject).BaseVal = value; }
			}

			public bool animVal
			{
				get { return ((ISvgAnimatedBoolean)baseObject).AnimVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedString
		/// </summary>
		public class ScriptableSvgAnimatedString : ScriptableObject, IScriptableSvgAnimatedString
		{
			public ScriptableSvgAnimatedString(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedString
			public string baseVal
			{
				get { return ((ISvgAnimatedString)baseObject).BaseVal;  }
				set { ((ISvgAnimatedString)baseObject).BaseVal = value; }
			}

			public string animVal
			{
				get { return ((ISvgAnimatedString)baseObject).AnimVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgStringList
		/// </summary>
		public class ScriptableSvgStringList : ScriptableObject, IScriptableSvgStringList
		{
			public ScriptableSvgStringList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStringList
			public void clear()
			{
				((ISvgStringList)baseObject).Clear();
			}

			public string initialize(string newItem)
			{
				return ((ISvgStringList)baseObject).Initialize(newItem);
			}

			public string getItem(ulong index)
			{
				return ((ISvgStringList)baseObject).GetItem((uint)index);
			}

			public string insertItemBefore(string newItem, ulong index)
			{
				return ((ISvgStringList)baseObject).InsertItemBefore(newItem, (uint)index);
			}

			public string replaceItem(string newItem, ulong index)
			{
				return ((ISvgStringList)baseObject).ReplaceItem(newItem, (uint)index);
			}

			public string removeItem(ulong index)
			{
				return ((ISvgStringList)baseObject).RemoveItem((uint)index);
			}

			public string appendItem(string newItem)
			{
				return ((ISvgStringList)baseObject).AppendItem(newItem);
			}
			#endregion

			#region Properties - IScriptableSvgStringList
			public ulong numberOfItems
			{
				get { return ((ISvgStringList)baseObject).NumberOfItems;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedEnumeration
		/// </summary>
		public class ScriptableSvgAnimatedEnumeration : ScriptableObject, IScriptableSvgAnimatedEnumeration
		{
			public ScriptableSvgAnimatedEnumeration(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedEnumeration
			public ushort baseVal
			{
				get { return ((ISvgAnimatedEnumeration)baseObject).BaseVal;  }
				set { ((ISvgAnimatedEnumeration)baseObject).BaseVal = value; }
			}

			public ushort animVal
			{
				get { return ((ISvgAnimatedEnumeration)baseObject).AnimVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedInteger
		/// </summary>
		public class ScriptableSvgAnimatedInteger : ScriptableObject, IScriptableSvgAnimatedInteger
		{
			public ScriptableSvgAnimatedInteger(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedInteger
			public long baseVal
			{
				get { return ((ISvgAnimatedInteger)baseObject).BaseVal;  }
				set { ((ISvgAnimatedInteger)baseObject).BaseVal = value; }
			}

			public long animVal
			{
				get { return ((ISvgAnimatedInteger)baseObject).AnimVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgNumber
		/// </summary>
		public class ScriptableSvgNumber : ScriptableObject, IScriptableSvgNumber
		{
			public ScriptableSvgNumber(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgNumber
			public float value
			{
				get { return ((ISvgNumber)baseObject).Value;  }
				set { ((ISvgNumber)baseObject).Value = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedNumber
		/// </summary>
		public class ScriptableSvgAnimatedNumber : ScriptableObject, IScriptableSvgAnimatedNumber
		{
			public ScriptableSvgAnimatedNumber(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedNumber
			public float baseVal
			{
				get { return (float)((ISvgAnimatedNumber)baseObject).BaseVal;  }
				set { ((ISvgAnimatedNumber)baseObject).BaseVal = value; }
			}

			public float animVal
			{
				get { return (float)((ISvgAnimatedNumber)baseObject).AnimVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgNumberList
		/// </summary>
		public class ScriptableSvgNumberList : ScriptableObject, IScriptableSvgNumberList
		{
			public ScriptableSvgNumberList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgNumberList
			public void clear()
			{
				((ISvgNumberList)baseObject).Clear();
			}

			public IScriptableSvgNumber initialize(IScriptableSvgNumber newItem)
			{
				object result = ((ISvgNumberList)baseObject).Initialize(((ISvgNumber)((ScriptableSvgNumber)newItem).baseObject));
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgNumber getItem(ulong index)
			{
				object result = ((ISvgNumberList)baseObject).GetItem((uint)index);
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgNumber insertItemBefore(IScriptableSvgNumber newItem, ulong index)
			{
				object result = ((ISvgNumberList)baseObject).InsertItemBefore(((ISvgNumber)((ScriptableSvgNumber)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgNumber replaceItem(IScriptableSvgNumber newItem, ulong index)
			{
				object result = ((ISvgNumberList)baseObject).ReplaceItem(((ISvgNumber)((ScriptableSvgNumber)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgNumber removeItem(ulong index)
			{
				object result = ((ISvgNumberList)baseObject).RemoveItem((uint)index);
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgNumber appendItem(IScriptableSvgNumber newItem)
			{
				object result = ((ISvgNumberList)baseObject).AppendItem(((ISvgNumber)((ScriptableSvgNumber)newItem).baseObject));
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgNumberList
			public ulong numberOfItems
			{
				get { return ((ISvgNumberList)baseObject).NumberOfItems;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedNumberList
		/// </summary>
		public class ScriptableSvgAnimatedNumberList : ScriptableObject, IScriptableSvgAnimatedNumberList
		{
			public ScriptableSvgAnimatedNumberList(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedNumberList
			public IScriptableSvgNumberList baseVal
			{
				get { object result = ((ISvgAnimatedNumberList)baseObject).BaseVal; return (result != null) ? (IScriptableSvgNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgNumberList animVal
			{
				get { object result = ((ISvgAnimatedNumberList)baseObject).AnimVal; return (result != null) ? (IScriptableSvgNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgLength
		/// </summary>
		public class ScriptableSvgLength : ScriptableObject, IScriptableSvgLength
		{
			const ushort SVG_LENGTHTYPE_UNKNOWN    = 0;
			const ushort SVG_LENGTHTYPE_NUMBER     = 1;
			const ushort SVG_LENGTHTYPE_PERCENTAGE = 2;
			const ushort SVG_LENGTHTYPE_EMS        = 3;
			const ushort SVG_LENGTHTYPE_EXS        = 4;
			const ushort SVG_LENGTHTYPE_PX         = 5;
			const ushort SVG_LENGTHTYPE_CM         = 6;
			const ushort SVG_LENGTHTYPE_MM         = 7;
			const ushort SVG_LENGTHTYPE_IN         = 8;
			const ushort SVG_LENGTHTYPE_PT         = 9;
			const ushort SVG_LENGTHTYPE_PC         = 10;

			public ScriptableSvgLength(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgLength
			public void newValueSpecifiedUnits(ushort unitType, float valueInSpecifiedUnits)
			{
				((ISvgLength)baseObject).NewValueSpecifiedUnits((SvgLengthType)unitType, valueInSpecifiedUnits);
			}

			public void convertToSpecifiedUnits(ushort unitType)
			{
				((ISvgLength)baseObject).ConvertToSpecifiedUnits((SvgLengthType)unitType);
			}
			#endregion

			#region Properties - IScriptableSvgLength
			public ushort unitType
			{
				get { return (ushort)((ISvgLength)baseObject).UnitType;  }
			}

			public float value
			{
				get { return (float)((ISvgLength)baseObject).Value;  }
				set { ((ISvgLength)baseObject).Value = value; }
			}

			public float valueInSpecifiedUnits
			{
				get { return (float)((ISvgLength)baseObject).ValueInSpecifiedUnits;  }
				set { ((ISvgLength)baseObject).ValueInSpecifiedUnits = value; }
			}

			public string valueAsString
			{
				get { return ((ISvgLength)baseObject).ValueAsString;  }
				set { ((ISvgLength)baseObject).ValueAsString = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedLength
		/// </summary>
		public class ScriptableSvgAnimatedLength : ScriptableObject, IScriptableSvgAnimatedLength
		{
			public ScriptableSvgAnimatedLength(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedLength
			public IScriptableSvgLength baseVal
			{
				get { object result = ((ISvgAnimatedLength)baseObject).BaseVal; return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgLength animVal
			{
				get { object result = ((ISvgAnimatedLength)baseObject).AnimVal; return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgLengthList
		/// </summary>
		public class ScriptableSvgLengthList : ScriptableObject, IScriptableSvgLengthList
		{
			public ScriptableSvgLengthList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgLengthList
			public void clear()
			{
				((ISvgLengthList)baseObject).Clear();
			}

			public IScriptableSvgLength initialize(IScriptableSvgLength newItem)
			{
				object result = ((ISvgLengthList)baseObject).Initialize(((ISvgLength)((ScriptableSvgLength)newItem).baseObject));
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgLength getItem(ulong index)
			{
				object result = ((ISvgLengthList)baseObject).GetItem((uint)index);
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgLength insertItemBefore(IScriptableSvgLength newItem, ulong index)
			{
				object result = ((ISvgLengthList)baseObject).InsertItemBefore(((ISvgLength)((ScriptableSvgLength)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgLength replaceItem(IScriptableSvgLength newItem, ulong index)
			{
				object result = ((ISvgLengthList)baseObject).ReplaceItem(((ISvgLength)((ScriptableSvgLength)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgLength removeItem(ulong index)
			{
				object result = ((ISvgLengthList)baseObject).RemoveItem((uint)index);
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgLength appendItem(IScriptableSvgLength newItem)
			{
				object result = ((ISvgLengthList)baseObject).AppendItem(((ISvgLength)((ScriptableSvgLength)newItem).baseObject));
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgLengthList
			public ulong numberOfItems
			{
				get { return ((ISvgLengthList)baseObject).NumberOfItems;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedLengthList
		/// </summary>
		public class ScriptableSvgAnimatedLengthList : ScriptableObject, IScriptableSvgAnimatedLengthList
		{
			public ScriptableSvgAnimatedLengthList(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedLengthList
			public IScriptableSvgLengthList baseVal
			{
				get { object result = ((ISvgAnimatedLengthList)baseObject).BaseVal; return (result != null) ? (IScriptableSvgLengthList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgLengthList animVal
			{
				get { object result = ((ISvgAnimatedLengthList)baseObject).AnimVal; return (result != null) ? (IScriptableSvgLengthList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAngle
		/// </summary>
		public class ScriptableSvgAngle : ScriptableObject, IScriptableSvgAngle
		{
			const ushort SVG_ANGLETYPE_UNKNOWN     = 0;
			const ushort SVG_ANGLETYPE_UNSPECIFIED = 1;
			const ushort SVG_ANGLETYPE_DEG         = 2;
			const ushort SVG_ANGLETYPE_RAD         = 3;
			const ushort SVG_ANGLETYPE_GRAD        = 4;

			public ScriptableSvgAngle(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgAngle
			public void newValueSpecifiedUnits(ushort unitType, float valueInSpecifiedUnits)
			{
				((ISvgAngle)baseObject).NewValueSpecifiedUnits((SvgAngleType)unitType, valueInSpecifiedUnits);
			}

			public void convertToSpecifiedUnits(ushort unitType)
			{
				((ISvgAngle)baseObject).ConvertToSpecifiedUnits((SvgAngleType)unitType);
			}
			#endregion

			#region Properties - IScriptableSvgAngle
			public ushort unitType
			{
				get { return (ushort)((ISvgAngle)baseObject).UnitType;  }
			}

			public float value
			{
				get { return (float)((ISvgAngle)baseObject).Value;  }
				set { ((ISvgAngle)baseObject).Value = value; }
			}

			public float valueInSpecifiedUnits
			{
				get { return (float)((ISvgAngle)baseObject).ValueInSpecifiedUnits;  }
				set { ((ISvgAngle)baseObject).ValueInSpecifiedUnits = value; }
			}

			public string valueAsString
			{
				get { return ((ISvgAngle)baseObject).ValueAsString;  }
				set { ((ISvgAngle)baseObject).ValueAsString = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedAngle
		/// </summary>
		public class ScriptableSvgAnimatedAngle : ScriptableObject, IScriptableSvgAnimatedAngle
		{
			public ScriptableSvgAnimatedAngle(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedAngle
			public IScriptableSvgAngle baseVal
			{
				get { object result = ((ISvgAnimatedAngle)baseObject).BaseVal; return (result != null) ? (IScriptableSvgAngle)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAngle animVal
			{
				get { object result = ((ISvgAnimatedAngle)baseObject).AnimVal; return (result != null) ? (IScriptableSvgAngle)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgColor
		/// </summary>
		public class ScriptableSvgColor : ScriptableCssValue, IScriptableSvgColor
		{
			const ushort SVG_COLORTYPE_UNKNOWN           = 0;
			const ushort SVG_COLORTYPE_RGBCOLOR          = 1;
			const ushort SVG_COLORTYPE_RGBCOLOR_ICCCOLOR = 2;
			const ushort SVG_COLORTYPE_CURRENTCOLOR      = 3;

			public ScriptableSvgColor(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgColor
			public void setRGBColor(string rgbColor)
			{
				((ISvgColor)baseObject).SetRgbColor(rgbColor);
			}

			public void setRGBColorICCColor(string rgbColor, string iccColor)
			{
				((ISvgColor)baseObject).SetRgbColorIccColor(rgbColor, iccColor);
			}

			public void setColor(ushort colorType, string rgbColor, string iccColor)
			{
				((ISvgColor)baseObject).SetColor((SvgColorType)colorType, rgbColor, iccColor);
			}
			#endregion

			#region Properties - IScriptableSvgColor
			public ushort colorType
			{
				get { return (ushort)((ISvgColor)baseObject).ColorType;  }
			}

			public IScriptableRgbColor rgbColor
			{
				get { object result = ((ISvgColor)baseObject).RgbColor; return (result != null) ? (IScriptableRgbColor)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgIccColor iccColor
			{
				get { object result = ((ISvgColor)baseObject).IccColor; return (result != null) ? (IScriptableSvgIccColor)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgIccColor
		/// </summary>
		public class ScriptableSvgIccColor : ScriptableObject, IScriptableSvgIccColor
		{
			public ScriptableSvgIccColor(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgIccColor
			public string colorProfile
			{
				get { return ((ISvgIccColor)baseObject).ColorProfile;  }
				set { ((ISvgIccColor)baseObject).ColorProfile = value; }
			}

			public IScriptableSvgNumberList colors
			{
				get { object result = ((ISvgIccColor)baseObject).Colors; return (result != null) ? (IScriptableSvgNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgRect
		/// </summary>
		public class ScriptableSvgRect : ScriptableObject, IScriptableSvgRect
		{
			public ScriptableSvgRect(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgRect
			public float x
			{
				get { return (float)((ISvgRect)baseObject).X;  }
				set { ((ISvgRect)baseObject).X = value; }
			}

			public float y
			{
				get { return (float)((ISvgRect)baseObject).Y;  }
				set { ((ISvgRect)baseObject).Y = value; }
			}

			public float width
			{
				get { return (float)((ISvgRect)baseObject).Width;  }
				set { ((ISvgRect)baseObject).Width = value; }
			}

			public float height
			{
				get { return (float)((ISvgRect)baseObject).Height;  }
				set { ((ISvgRect)baseObject).Height = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedRect
		/// </summary>
		public class ScriptableSvgAnimatedRect : ScriptableObject, IScriptableSvgAnimatedRect
		{
			public ScriptableSvgAnimatedRect(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedRect
			public IScriptableSvgRect baseVal
			{
				get { object result = ((ISvgAnimatedRect)baseObject).BaseVal; return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgRect animVal
			{
				get { object result = ((ISvgAnimatedRect)baseObject).AnimVal; return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgUnitTypes
		/// </summary>
		public class ScriptableSvgUnitTypes : ScriptableObject, IScriptableSvgUnitTypes
		{
			const ushort SVG_UNIT_TYPE_UNKNOWN           = 0;
			const ushort SVG_UNIT_TYPE_USERSPACEONUSE    = 1;
			const ushort SVG_UNIT_TYPE_OBJECTBOUNDINGBOX = 2;

			public ScriptableSvgUnitTypes(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgStylable
		/// </summary>
		public class ScriptableSvgStylable : ScriptableObject, IScriptableSvgStylable
		{
			public ScriptableSvgStylable(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgLocatable
		/// </summary>
		public class ScriptableSvgLocatable : ScriptableObject, IScriptableSvgLocatable
		{
			public ScriptableSvgLocatable(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTransformable
		/// </summary>
		public class ScriptableSvgTransformable : ScriptableSvgLocatable, IScriptableSvgTransformable
		{
			public ScriptableSvgTransformable(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTests
		/// </summary>
		public class ScriptableSvgTests : ScriptableObject, IScriptableSvgTests
		{
			public ScriptableSvgTests(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgLangSpace
		/// </summary>
		public class ScriptableSvgLangSpace : ScriptableObject, IScriptableSvgLangSpace
		{
			public ScriptableSvgLangSpace(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgExternalResourcesRequired
		/// </summary>
		public class ScriptableSvgExternalResourcesRequired : ScriptableObject, IScriptableSvgExternalResourcesRequired
		{
			public ScriptableSvgExternalResourcesRequired(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFitToViewBox
		/// </summary>
		public class ScriptableSvgFitToViewBox : ScriptableObject, IScriptableSvgFitToViewBox
		{
			public ScriptableSvgFitToViewBox(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgZoomAndPan
		/// </summary>
		public class ScriptableSvgZoomAndPan : ScriptableObject, IScriptableSvgZoomAndPan
		{
			const ushort SVG_ZOOMANDPAN_UNKNOWN   = 0;
			const ushort SVG_ZOOMANDPAN_DISABLE = 1;
			const ushort SVG_ZOOMANDPAN_MAGNIFY = 2;

			public ScriptableSvgZoomAndPan(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgZoomAndPan
			public ushort zoomAndPan
			{
				get { return (ushort)((ISvgZoomAndPan)baseObject).ZoomAndPan;  }
				set { ((ISvgZoomAndPan)baseObject).ZoomAndPan = (SvgZoomAndPanType)value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgViewSpec
		/// </summary>
		public class ScriptableSvgViewSpec : ScriptableSvgZoomAndPan, IScriptableSvgViewSpec, IScriptableSvgFitToViewBox
		{
			public ScriptableSvgViewSpec(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgViewSpec
			public IScriptableSvgTransformList transform
			{
				get { object result = ((ISvgViewSpec)baseObject).Transform; return (result != null) ? (IScriptableSvgTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement viewTarget
			{
				get { object result = ((ISvgViewSpec)baseObject).ViewTarget; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public string viewBoxString
			{
				get { return ((ISvgViewSpec)baseObject).ViewBoxString;  }
			}

			public string preserveAspectRatioString
			{
				get { return ((ISvgViewSpec)baseObject).PreserveAspectRatioString;  }
			}

			public string transformString
			{
				get { return ((ISvgViewSpec)baseObject).TransformString;  }
			}

			public string viewTargetString
			{
				get { return ((ISvgViewSpec)baseObject).ViewTargetString;  }
			}

			#endregion

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgUriReference
		/// </summary>
		public class ScriptableSvgUriReference : ScriptableObject, IScriptableSvgUriReference
		{
			public ScriptableSvgUriReference(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgCssRule
		/// </summary>
		public class ScriptableSvgCssRule : ScriptableCssRule, IScriptableSvgCssRule
		{
			const ushort COLOR_PROFILE_RULE = 7;

			public ScriptableSvgCssRule(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgRenderingIntent
		/// </summary>
		public class ScriptableSvgRenderingIntent : ScriptableObject, IScriptableSvgRenderingIntent
		{
			const ushort RENDERING_INTENT_UNKNOWN               = 0;
			const ushort RENDERING_INTENT_AUTO                  = 1;
			const ushort RENDERING_INTENT_PERCEPTUAL            = 2;
			const ushort RENDERING_INTENT_RELATIVE_COLORIMETRIC = 3;
			const ushort RENDERING_INTENT_SATURATION            = 4;
			const ushort RENDERING_INTENT_ABSOLUTE_COLORIMETRIC = 5;

			public ScriptableSvgRenderingIntent(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgDocument
		/// </summary>
		public class ScriptableSvgDocument : ScriptableDocument, IScriptableSvgDocument, IScriptableDocumentEvent
		{
			public ScriptableSvgDocument(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableDocumentEvent
			public IScriptableEvent createEvent(string eventType)
			{
				object result = ((IDocumentEvent)baseObject).CreateEvent(eventType);
				return (result != null) ? (IScriptableEvent)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgDocument
			public string title
			{
				get { return ((ISvgDocument)baseObject).Title;  }
			}

			public string referrer
			{
				get { return ((ISvgDocument)baseObject).Referrer;  }
			}

			public string domain
			{
				get { return ((ISvgDocument)baseObject).Domain;  }
			}

			public string URL
			{
				get { return ((ISvgDocument)baseObject).Url;  }
			}

			public IScriptableSvgSvgElement rootElement
			{
				get { object result = ((ISvgDocument)baseObject).RootElement; return (result != null) ? (IScriptableSvgSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgSvgElement
		/// </summary>
		public class ScriptableSvgSvgElement : ScriptableSvgElement, IScriptableSvgSvgElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgLocatable, IScriptableSvgFitToViewBox, IScriptableSvgZoomAndPan, IScriptableEventTarget, IScriptableDocumentEvent, IScriptableViewCss, IScriptableDocumentCss
		{
			public ScriptableSvgSvgElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgSvgElement
			public ulong suspendRedraw(ulong max_wait_milliseconds)
			{
				return (ulong)((ISvgSvgElement)baseObject).SuspendRedraw((int)max_wait_milliseconds);
			}

			public void unsuspendRedraw(ulong suspend_handle_id)
			{
				((ISvgSvgElement)baseObject).UnsuspendRedraw((int)suspend_handle_id);
			}

			public void unsuspendRedrawAll()
			{
				((ISvgSvgElement)baseObject).UnsuspendRedrawAll();
			}

			public void forceRedraw()
			{
				((ISvgSvgElement)baseObject).ForceRedraw();
			}

			public void pauseAnimations()
			{
				((ISvgSvgElement)baseObject).PauseAnimations();
			}

			public void unpauseAnimations()
			{
				((ISvgSvgElement)baseObject).UnpauseAnimations();
			}

			public bool animationsPaused()
			{
				return ((ISvgSvgElement)baseObject).AnimationsPaused();
			}

			public float getCurrentTime()
			{
				return ((ISvgSvgElement)baseObject).CurrentTime;
			}

			public void setCurrentTime(float seconds)
			{
				((ISvgSvgElement)baseObject).CurrentTime = seconds;
			}

			public IScriptableNodeList getIntersectionList(IScriptableSvgRect rect, IScriptableSvgElement referenceElement)
			{
				object result = ((ISvgSvgElement)baseObject).GetIntersectionList(((ISvgRect)((ScriptableSvgRect)rect).baseObject), ((ISvgElement)((ScriptableSvgElement)referenceElement).baseObject));
				return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableNodeList getEnclosureList(IScriptableSvgRect rect, IScriptableSvgElement referenceElement)
			{
				object result = ((ISvgSvgElement)baseObject).GetEnclosureList(((ISvgRect)((ScriptableSvgRect)rect).baseObject), ((ISvgElement)((ScriptableSvgElement)referenceElement).baseObject));
				return (result != null) ? (IScriptableNodeList)ScriptableObject.CreateWrapper(result) : null;
			}

			public bool checkIntersection(IScriptableSvgElement element, IScriptableSvgRect rect)
			{
				return ((ISvgSvgElement)baseObject).CheckIntersection(((ISvgElement)((ScriptableSvgElement)element).baseObject), ((ISvgRect)((ScriptableSvgRect)rect).baseObject));
			}

			public bool checkEnclosure(IScriptableSvgElement element, IScriptableSvgRect rect)
			{
				return ((ISvgSvgElement)baseObject).CheckEnclosure(((ISvgElement)((ScriptableSvgElement)element).baseObject), ((ISvgRect)((ScriptableSvgRect)rect).baseObject));
			}

			public void deselectAll()
			{
				((ISvgSvgElement)baseObject).DeselectAll();
			}

			public IScriptableSvgNumber createSVGNumber()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgNumber();
				return (result != null) ? (IScriptableSvgNumber)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgLength createSVGLength()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgLength();
				return (result != null) ? (IScriptableSvgLength)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgAngle createSVGAngle()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgAngle();
				return (result != null) ? (IScriptableSvgAngle)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint createSVGPoint()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgPoint();
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix createSVGMatrix()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgMatrix();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgRect createSVGRect()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgRect();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform createSVGTransform()
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgTransform();
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform createSVGTransformFromMatrix(IScriptableSvgMatrix matrix)
			{
				object result = ((ISvgSvgElement)baseObject).CreateSvgTransformFromMatrix(((ISvgMatrix)((ScriptableSvgMatrix)matrix).baseObject));
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableElement getElementById(string elementId)
			{
				object result = ((ISvgSvgElement)baseObject).GetElementById(elementId);
				return (result != null) ? (IScriptableElement)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

			public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Methods - IScriptableDocumentEvent
			public IScriptableEvent createEvent(string eventType)
			{
				object result = ((IDocumentEvent)baseObject).CreateEvent(eventType);
				return (result != null) ? (IScriptableEvent)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableViewCss
			public IScriptableCssStyleDeclaration getComputedStyle(IScriptableElement elt, string pseudoElt)
			{
				object result = ((IViewCss)baseObject).GetComputedStyle(((XmlElement)((ScriptableElement)elt).baseObject), pseudoElt);
				return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableDocumentCss
			public IScriptableCssStyleDeclaration getOverrideStyle(IScriptableElement elt, string pseudoElt)
			{
				object result = ((IDocumentCss)baseObject).GetOverrideStyle(((XmlElement)((ScriptableElement)elt).baseObject), pseudoElt);
				return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgSvgElement
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgSvgElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgSvgElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgSvgElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgSvgElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public string contentScriptType
			{
				get { return ((ISvgSvgElement)baseObject).ContentScriptType;  }
				set { ((ISvgSvgElement)baseObject).ContentScriptType = value; }
			}

			public string contentStyleType
			{
				get { return ((ISvgSvgElement)baseObject).ContentStyleType;  }
				set { ((ISvgSvgElement)baseObject).ContentStyleType = value; }
			}

			public IScriptableSvgRect viewport
			{
				get { object result = ((ISvgSvgElement)baseObject).Viewport; return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public float pixelUnitToMillimeterX
			{
				get { return ((ISvgSvgElement)baseObject).PixelUnitToMillimeterX;  }
			}

			public float pixelUnitToMillimeterY
			{
				get { return ((ISvgSvgElement)baseObject).PixelUnitToMillimeterY;  }
			}

			public float screenPixelToMillimeterX
			{
				get { return ((ISvgSvgElement)baseObject).ScreenPixelToMillimeterX;  }
			}

			public float screenPixelToMillimeterY
			{
				get { return ((ISvgSvgElement)baseObject).ScreenPixelToMillimeterY;  }
			}

			public bool useCurrentView
			{
				get { return ((ISvgSvgElement)baseObject).UseCurrentView;  }
				set { ((ISvgSvgElement)baseObject).UseCurrentView = value; }
			}

			public IScriptableSvgViewSpec currentView
			{
				get { object result = ((ISvgSvgElement)baseObject).CurrentView; return (result != null) ? (IScriptableSvgViewSpec)ScriptableObject.CreateWrapper(result) : null; }
			}

			public float currentScale
			{
				get { return ((ISvgSvgElement)baseObject).CurrentScale;  }
				set { ((ISvgSvgElement)baseObject).CurrentScale = value; }
			}

			public IScriptableSvgPoint currentTranslate
			{
				get { object result = ((ISvgSvgElement)baseObject).CurrentTranslate; return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgZoomAndPan
			public ushort zoomAndPan
			{
				get { return (ushort)((ISvgZoomAndPan)baseObject).ZoomAndPan;  }
				set { ((ISvgZoomAndPan)baseObject).ZoomAndPan = (SvgZoomAndPanType)value; }
			}

			#endregion

			#region Properties - IScriptableAbstractView
			public IScriptableDocumentView document
			{
				get { object result = ((IAbstractView)baseObject).Document; return (result != null) ? (IScriptableDocumentView)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableDocumentStyle
			public IScriptableStyleSheetList styleSheets
			{
				get { object result = ((IDocumentStyle)baseObject).StyleSheets; return (result != null) ? (IScriptableStyleSheetList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgGElement
		/// </summary>
		public class ScriptableSvgGElement : ScriptableSvgElement, IScriptableSvgGElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgGElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgDefsElement
		/// </summary>
		public class ScriptableSvgDefsElement : ScriptableSvgElement, IScriptableSvgDefsElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgDefsElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgDescElement
		/// </summary>
		public class ScriptableSvgDescElement : ScriptableSvgElement, IScriptableSvgDescElement, IScriptableSvgLangSpace, IScriptableSvgStylable
		{
			public ScriptableSvgDescElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTitleElement
		/// </summary>
		public class ScriptableSvgTitleElement : ScriptableSvgElement, IScriptableSvgTitleElement, IScriptableSvgLangSpace, IScriptableSvgStylable
		{
			public ScriptableSvgTitleElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgSymbolElement
		/// </summary>
		public class ScriptableSvgSymbolElement : ScriptableSvgElement, IScriptableSvgSymbolElement, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgFitToViewBox, IScriptableEventTarget
		{
			public ScriptableSvgSymbolElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgUseElement
		/// </summary>
		public class ScriptableSvgUseElement : ScriptableSvgElement, IScriptableSvgUseElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgUseElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgUseElement
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgUseElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgUseElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgUseElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgUseElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance instanceRoot
			{
				get { object result = ((ISvgUseElement)baseObject).InstanceRoot; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance animatedInstanceRoot
			{
				get { object result = ((ISvgUseElement)baseObject).AnimatedInstanceRoot; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgElementInstance
		/// </summary>
		public class ScriptableSvgElementInstance : ScriptableEventTarget, IScriptableSvgElementInstance
		{
			public ScriptableSvgElementInstance(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgElementInstance
			public IScriptableSvgElement correspondingElement
			{
				get { object result = ((ISvgElementInstance)baseObject).CorrespondingElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgUseElement correspondingUseElement
			{
				get { object result = ((ISvgElementInstance)baseObject).CorrespondingUseElement; return (result != null) ? (IScriptableSvgUseElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance parentNode
			{
				get { object result = ((ISvgElementInstance)baseObject).ParentNode; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstanceList childNodes
			{
				get { object result = ((ISvgElementInstance)baseObject).ChildNodes; return (result != null) ? (IScriptableSvgElementInstanceList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance firstChild
			{
				get { object result = ((ISvgElementInstance)baseObject).FirstChild; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance lastChild
			{
				get { object result = ((ISvgElementInstance)baseObject).LastChild; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance previousSibling
			{
				get { object result = ((ISvgElementInstance)baseObject).PreviousSibling; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElementInstance nextSibling
			{
				get { object result = ((ISvgElementInstance)baseObject).NextSibling; return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgElementInstanceList
		/// </summary>
		public class ScriptableSvgElementInstanceList : ScriptableObject, IScriptableSvgElementInstanceList
		{
			public ScriptableSvgElementInstanceList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgElementInstanceList
			public IScriptableSvgElementInstance item(ulong index)
			{
				object result = ((ISvgElementInstanceList)baseObject).Item(index);
				return (result != null) ? (IScriptableSvgElementInstance)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgElementInstanceList
			public ulong length
			{
				get { return ((ISvgElementInstanceList)baseObject).Length;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgImageElement
		/// </summary>
		public class ScriptableSvgImageElement : ScriptableSvgElement, IScriptableSvgImageElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgImageElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgImageElement
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgImageElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgImageElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgImageElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgImageElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgImageElement)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgSwitchElement
		/// </summary>
		public class ScriptableSvgSwitchElement : ScriptableSvgElement, IScriptableSvgSwitchElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgSwitchElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableGetSvgDocument
		/// </summary>
		public class ScriptableGetSvgDocument : ScriptableObject, IScriptableGetSvgDocument
		{
			public ScriptableGetSvgDocument(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableGetSvgDocument
			public IScriptableSvgDocument getSVGDocument()
			{
				throw new NotImplementedException(); 
        //object result = ((IGetSvgDocument)baseObject).GetSvgDocument();
				//return (result != null) ? (IScriptableSvgDocument)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgStyleElement
		/// </summary>
		public class ScriptableSvgStyleElement : ScriptableSvgElement, IScriptableSvgStyleElement
		{
			public ScriptableSvgStyleElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgStyleElement
			public string xmlspace
			{
				get { throw new NotImplementedException(); }//return ((ISvgStyleElement)baseObject).XmlSpace;  }
				set { throw new NotImplementedException(); }//((ISvgStyleElement)baseObject).XmlSpace = value; }
			}

			public string type
			{
				get { throw new NotImplementedException(); }//return ((ISvgStyleElement)baseObject).Type;  }
				set { throw new NotImplementedException(); }//((ISvgStyleElement)baseObject).Type = value; }
			}

			public string media
			{
				get { throw new NotImplementedException(); }//return ((ISvgStyleElement)baseObject).Media;  }
				set { throw new NotImplementedException(); }//((ISvgStyleElement)baseObject).Media = value; }
			}

			public string title
			{
				get { throw new NotImplementedException(); }//return ((ISvgStyleElement)baseObject).Title;  }
				set { throw new NotImplementedException(); }//((ISvgStyleElement)baseObject).Title = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPoint
		/// </summary>
		public class ScriptableSvgPoint : ScriptableObject, IScriptableSvgPoint
		{
			public ScriptableSvgPoint(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgPoint
			public IScriptableSvgPoint matrixTransform(IScriptableSvgMatrix matrix)
			{
				object result = ((ISvgPoint)baseObject).MatrixTransform(((ISvgMatrix)((ScriptableSvgMatrix)matrix).baseObject));
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgPoint
			public float x
			{
				get { return ((ISvgPoint)baseObject).X;  }
				set { ((ISvgPoint)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPoint)baseObject).Y;  }
				set { ((ISvgPoint)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPointList
		/// </summary>
		public class ScriptableSvgPointList : ScriptableObject, IScriptableSvgPointList
		{
			public ScriptableSvgPointList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgPointList
			public void clear()
			{
				((ISvgPointList)baseObject).Clear();
			}

			public IScriptableSvgPoint initialize(IScriptableSvgPoint newItem)
			{
				object result = ((ISvgPointList)baseObject).Initialize(((ISvgPoint)((ScriptableSvgPoint)newItem).baseObject));
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint getItem(ulong index)
			{
				object result = ((ISvgPointList)baseObject).GetItem((uint)index);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint insertItemBefore(IScriptableSvgPoint newItem, ulong index)
			{
				object result = ((ISvgPointList)baseObject).InsertItemBefore(((ISvgPoint)((ScriptableSvgPoint)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint replaceItem(IScriptableSvgPoint newItem, ulong index)
			{
				object result = ((ISvgPointList)baseObject).ReplaceItem(((ISvgPoint)((ScriptableSvgPoint)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint removeItem(ulong index)
			{
				object result = ((ISvgPointList)baseObject).RemoveItem((uint)index);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint appendItem(IScriptableSvgPoint newItem)
			{
				object result = ((ISvgPointList)baseObject).AppendItem(((ISvgPoint)((ScriptableSvgPoint)newItem).baseObject));
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgPointList
			public ulong numberOfItems
			{
				get { return ((ISvgPointList)baseObject).NumberOfItems;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgMatrix
		/// </summary>
		public class ScriptableSvgMatrix : ScriptableObject, IScriptableSvgMatrix
		{
			public ScriptableSvgMatrix(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgMatrix
			public IScriptableSvgMatrix multiply(IScriptableSvgMatrix secondMatrix)
			{
				object result = ((ISvgMatrix)baseObject).Multiply(((ISvgMatrix)((ScriptableSvgMatrix)secondMatrix).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix inverse()
			{
				object result = ((ISvgMatrix)baseObject).Inverse();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix translate(float x, float y)
			{
				object result = ((ISvgMatrix)baseObject).Translate(x, y);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix scale(float scaleFactor)
			{
				object result = ((ISvgMatrix)baseObject).Scale(scaleFactor);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix scaleNonUniform(float scaleFactorX, float scaleFactorY)
			{
				object result = ((ISvgMatrix)baseObject).ScaleNonUniform(scaleFactorX, scaleFactorY);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix rotate(float angle)
			{
				object result = ((ISvgMatrix)baseObject).Rotate(angle);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix rotateFromVector(float x, float y)
			{
				object result = ((ISvgMatrix)baseObject).RotateFromVector(x, y);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix flipX()
			{
				object result = ((ISvgMatrix)baseObject).FlipX();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix flipY()
			{
				object result = ((ISvgMatrix)baseObject).FlipY();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix skewX(float angle)
			{
				object result = ((ISvgMatrix)baseObject).SkewX(angle);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix skewY(float angle)
			{
				object result = ((ISvgMatrix)baseObject).SkewY(angle);
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgMatrix
			public float a
			{
				get { return ((ISvgMatrix)baseObject).A;  }
				set { ((ISvgMatrix)baseObject).A = value; }
			}

			public float b
			{
				get { return ((ISvgMatrix)baseObject).B;  }
				set { ((ISvgMatrix)baseObject).B = value; }
			}

			public float c
			{
				get { return ((ISvgMatrix)baseObject).C;  }
				set { ((ISvgMatrix)baseObject).C = value; }
			}

			public float d
			{
				get { return ((ISvgMatrix)baseObject).D;  }
				set { ((ISvgMatrix)baseObject).D = value; }
			}

			public float e
			{
				get { return ((ISvgMatrix)baseObject).E;  }
				set { ((ISvgMatrix)baseObject).E = value; }
			}

			public float f
			{
				get { return ((ISvgMatrix)baseObject).F;  }
				set { ((ISvgMatrix)baseObject).F = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTransform
		/// </summary>
		public class ScriptableSvgTransform : ScriptableObject, IScriptableSvgTransform
		{
			const ushort SVG_TRANSFORM_UNKNOWN   = 0;
			const ushort SVG_TRANSFORM_MATRIX    = 1;
			const ushort SVG_TRANSFORM_TRANSLATE = 2;
			const ushort SVG_TRANSFORM_SCALE     = 3;
			const ushort SVG_TRANSFORM_ROTATE    = 4;
			const ushort SVG_TRANSFORM_SKEWX     = 5;
			const ushort SVG_TRANSFORM_SKEWY     = 6;

			public ScriptableSvgTransform(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTransform
			public void setMatrix(IScriptableSvgMatrix matrix)
			{
				((ISvgTransform)baseObject).SetMatrix(((ISvgMatrix)((ScriptableSvgMatrix)matrix).baseObject));
			}

			public void setTranslate(float tx, float ty)
			{
				((ISvgTransform)baseObject).SetTranslate(tx, ty);
			}

			public void setScale(float sx, float sy)
			{
				((ISvgTransform)baseObject).SetScale(sx, sy);
			}

			public void setRotate(float angle, float cx, float cy)
			{
				((ISvgTransform)baseObject).SetRotate(angle, cx, cy);
			}

			public void setSkewX(float angle)
			{
				((ISvgTransform)baseObject).SetSkewX(angle);
			}

			public void setSkewY(float angle)
			{
				((ISvgTransform)baseObject).SetSkewY(angle);
			}
			#endregion

			#region Properties - IScriptableSvgTransform
			public ushort type
			{
				get { return (ushort)((ISvgTransform)baseObject).Type;  }
			}

			public IScriptableSvgMatrix matrix
			{
				get { object result = ((ISvgTransform)baseObject).Matrix; return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null; }
			}

			public float angle
			{
				get { return (float)((ISvgTransform)baseObject).Angle;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTransformList
		/// </summary>
		public class ScriptableSvgTransformList : ScriptableObject, IScriptableSvgTransformList
		{
			public ScriptableSvgTransformList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTransformList
			public void clear()
			{
				((ISvgTransformList)baseObject).Clear();
			}

			public IScriptableSvgTransform initialize(IScriptableSvgTransform newItem)
			{
				object result = ((ISvgTransformList)baseObject).Initialize(((ISvgTransform)((ScriptableSvgTransform)newItem).baseObject));
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform getItem(ulong index)
			{
				object result = ((ISvgTransformList)baseObject).GetItem((uint)index);
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform insertItemBefore(IScriptableSvgTransform newItem, ulong index)
			{
				object result = ((ISvgTransformList)baseObject).InsertItemBefore(((ISvgTransform)((ScriptableSvgTransform)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform replaceItem(IScriptableSvgTransform newItem, ulong index)
			{
				object result = ((ISvgTransformList)baseObject).ReplaceItem(((ISvgTransform)((ScriptableSvgTransform)newItem).baseObject), (uint)index);
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform removeItem(ulong index)
			{
				object result = ((ISvgTransformList)baseObject).RemoveItem((uint)index);
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform appendItem(IScriptableSvgTransform newItem)
			{
				object result = ((ISvgTransformList)baseObject).AppendItem(((ISvgTransform)((ScriptableSvgTransform)newItem).baseObject));
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform createSVGTransformFromMatrix(IScriptableSvgMatrix matrix)
			{
				object result = ((ISvgTransformList)baseObject).CreateSvgTransformFromMatrix(((ISvgMatrix)((ScriptableSvgMatrix)matrix).baseObject));
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgTransform consolidate()
			{
				object result = ((ISvgTransformList)baseObject).Consolidate();
				return (result != null) ? (IScriptableSvgTransform)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgTransformList
			public ulong numberOfItems
			{
				get { return ((ISvgTransformList)baseObject).NumberOfItems;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedTransformList
		/// </summary>
		public class ScriptableSvgAnimatedTransformList : ScriptableObject, IScriptableSvgAnimatedTransformList
		{
			public ScriptableSvgAnimatedTransformList(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedTransformList
			public IScriptableSvgTransformList baseVal
			{
				get { object result = ((ISvgAnimatedTransformList)baseObject).BaseVal; return (result != null) ? (IScriptableSvgTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgTransformList animVal
			{
				get { object result = ((ISvgAnimatedTransformList)baseObject).AnimVal; return (result != null) ? (IScriptableSvgTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPreserveAspectRatio
		/// </summary>
		public class ScriptableSvgPreserveAspectRatio : ScriptableObject, IScriptableSvgPreserveAspectRatio
		{
			const ushort SVG_PRESERVEASPECTRATIO_UNKNOWN   = 0;
			const ushort SVG_PRESERVEASPECTRATIO_NONE     = 1;
			const ushort SVG_PRESERVEASPECTRATIO_XMINYMIN = 2;
			const ushort SVG_PRESERVEASPECTRATIO_XMIDYMIN = 3;
			const ushort SVG_PRESERVEASPECTRATIO_XMAXYMIN = 4;
			const ushort SVG_PRESERVEASPECTRATIO_XMINYMID = 5;
			const ushort SVG_PRESERVEASPECTRATIO_XMIDYMID = 6;
			const ushort SVG_PRESERVEASPECTRATIO_XMAXYMID = 7;
			const ushort SVG_PRESERVEASPECTRATIO_XMINYMAX = 8;
			const ushort SVG_PRESERVEASPECTRATIO_XMIDYMAX = 9;
			const ushort SVG_PRESERVEASPECTRATIO_XMAXYMAX = 10;
			const ushort SVG_MEETORSLICE_UNKNOWN   = 0;
			const ushort SVG_MEETORSLICE_MEET  = 1;
			const ushort SVG_MEETORSLICE_SLICE = 2;

			public ScriptableSvgPreserveAspectRatio(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPreserveAspectRatio
			public ushort align
			{
				get { return (ushort)((ISvgPreserveAspectRatio)baseObject).Align;  }
				set { ((ISvgPreserveAspectRatio)baseObject).Align = (SvgPreserveAspectRatioType)value; }
			}

			public ushort meetOrSlice
			{
				get { return (ushort)((ISvgPreserveAspectRatio)baseObject).MeetOrSlice;  }
				set { ((ISvgPreserveAspectRatio)baseObject).MeetOrSlice = (SvgMeetOrSlice)value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedPreserveAspectRatio
		/// </summary>
		public class ScriptableSvgAnimatedPreserveAspectRatio : ScriptableObject, IScriptableSvgAnimatedPreserveAspectRatio
		{
			public ScriptableSvgAnimatedPreserveAspectRatio(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedPreserveAspectRatio
			public IScriptableSvgPreserveAspectRatio baseVal
			{
				get { object result = ((ISvgAnimatedPreserveAspectRatio)baseObject).BaseVal; return (result != null) ? (IScriptableSvgPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPreserveAspectRatio animVal
			{
				get { object result = ((ISvgAnimatedPreserveAspectRatio)baseObject).AnimVal; return (result != null) ? (IScriptableSvgPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSeg
		/// </summary>
		public class ScriptableSvgPathSeg : ScriptableObject, IScriptableSvgPathSeg
		{
			const ushort PATHSEG_UNKNOWN                      = 0;
			const ushort PATHSEG_CLOSEPATH                    = 1;
			const ushort PATHSEG_MOVETO_ABS                   = 2;
			const ushort PATHSEG_MOVETO_REL                   = 3;
			const ushort PATHSEG_LINETO_ABS                   = 4;
			const ushort PATHSEG_LINETO_REL                   = 5;
			const ushort PATHSEG_CURVETO_CUBIC_ABS            = 6;
			const ushort PATHSEG_CURVETO_CUBIC_REL            = 7;
			const ushort PATHSEG_CURVETO_QUADRATIC_ABS        = 8;
			const ushort PATHSEG_CURVETO_QUADRATIC_REL        = 9;
			const ushort PATHSEG_ARC_ABS                      = 10;
			const ushort PATHSEG_ARC_REL                      = 11;
			const ushort PATHSEG_LINETO_HORIZONTAL_ABS        = 12;
			const ushort PATHSEG_LINETO_HORIZONTAL_REL        = 13;
			const ushort PATHSEG_LINETO_VERTICAL_ABS          = 14;
			const ushort PATHSEG_LINETO_VERTICAL_REL          = 15;
			const ushort PATHSEG_CURVETO_CUBIC_SMOOTH_ABS     = 16;
			const ushort PATHSEG_CURVETO_CUBIC_SMOOTH_REL     = 17;
			const ushort PATHSEG_CURVETO_QUADRATIC_SMOOTH_ABS = 18;
			const ushort PATHSEG_CURVETO_QUADRATIC_SMOOTH_REL = 19;

			public ScriptableSvgPathSeg(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSeg
			public ushort pathSegType
			{
				get { return (ushort)((ISvgPathSeg)baseObject).PathSegType;  }
			}

			public string pathSegTypeAsLetter
			{
				get { return ((ISvgPathSeg)baseObject).PathSegTypeAsLetter;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegClosePath
		/// </summary>
		public class ScriptableSvgPathSegClosePath : ScriptableSvgPathSeg, IScriptableSvgPathSegClosePath
		{
			public ScriptableSvgPathSegClosePath(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegMovetoAbs
		/// </summary>
		public class ScriptableSvgPathSegMovetoAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegMovetoAbs
		{
			public ScriptableSvgPathSegMovetoAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegMovetoAbs
			public float x
			{
				get { return ((ISvgPathSegMovetoAbs)baseObject).X;  }
				set { ((ISvgPathSegMovetoAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegMovetoAbs)baseObject).Y;  }
				set { ((ISvgPathSegMovetoAbs)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegMovetoRel
		/// </summary>
		public class ScriptableSvgPathSegMovetoRel : ScriptableSvgPathSeg, IScriptableSvgPathSegMovetoRel
		{
			public ScriptableSvgPathSegMovetoRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegMovetoRel
			public float x
			{
				get { return ((ISvgPathSegMovetoRel)baseObject).X;  }
				set { ((ISvgPathSegMovetoRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegMovetoRel)baseObject).Y;  }
				set { ((ISvgPathSegMovetoRel)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegLinetoAbs
		/// </summary>
		public class ScriptableSvgPathSegLinetoAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegLinetoAbs
		{
			public ScriptableSvgPathSegLinetoAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegLinetoAbs
			public float x
			{
				get { return ((ISvgPathSegLinetoAbs)baseObject).X;  }
				set { ((ISvgPathSegLinetoAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegLinetoAbs)baseObject).Y;  }
				set { ((ISvgPathSegLinetoAbs)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegLinetoRel
		/// </summary>
		public class ScriptableSvgPathSegLinetoRel : ScriptableSvgPathSeg, IScriptableSvgPathSegLinetoRel
		{
			public ScriptableSvgPathSegLinetoRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegLinetoRel
			public float x
			{
				get { return ((ISvgPathSegLinetoRel)baseObject).X;  }
				set { ((ISvgPathSegLinetoRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegLinetoRel)baseObject).Y;  }
				set { ((ISvgPathSegLinetoRel)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoCubicAbs
		/// </summary>
		public class ScriptableSvgPathSegCurvetoCubicAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoCubicAbs
		{
			public ScriptableSvgPathSegCurvetoCubicAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoCubicAbs
			public float x
			{
				get { return ((ISvgPathSegCurvetoCubicAbs)baseObject).X;  }
				set { ((ISvgPathSegCurvetoCubicAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoCubicAbs)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoCubicAbs)baseObject).Y = value; }
			}

			public float x1
			{
				get { return ((ISvgPathSegCurvetoCubicAbs)baseObject).X1;  }
				set { ((ISvgPathSegCurvetoCubicAbs)baseObject).X1 = value; }
			}

			public float y1
			{
				get { return ((ISvgPathSegCurvetoCubicAbs)baseObject).Y1;  }
				set { ((ISvgPathSegCurvetoCubicAbs)baseObject).Y1 = value; }
			}

			public float x2
			{
				get { return ((ISvgPathSegCurvetoCubicAbs)baseObject).X2;  }
				set { ((ISvgPathSegCurvetoCubicAbs)baseObject).X2 = value; }
			}

			public float y2
			{
				get { return ((ISvgPathSegCurvetoCubicAbs)baseObject).Y2;  }
				set { ((ISvgPathSegCurvetoCubicAbs)baseObject).Y2 = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoCubicRel
		/// </summary>
		public class ScriptableSvgPathSegCurvetoCubicRel : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoCubicRel
		{
			public ScriptableSvgPathSegCurvetoCubicRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoCubicRel
			public float x
			{
				get { return ((ISvgPathSegCurvetoCubicRel)baseObject).X;  }
				set { ((ISvgPathSegCurvetoCubicRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoCubicRel)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoCubicRel)baseObject).Y = value; }
			}

			public float x1
			{
				get { return ((ISvgPathSegCurvetoCubicRel)baseObject).X1;  }
				set { ((ISvgPathSegCurvetoCubicRel)baseObject).X1 = value; }
			}

			public float y1
			{
				get { return ((ISvgPathSegCurvetoCubicRel)baseObject).Y1;  }
				set { ((ISvgPathSegCurvetoCubicRel)baseObject).Y1 = value; }
			}

			public float x2
			{
				get { return ((ISvgPathSegCurvetoCubicRel)baseObject).X2;  }
				set { ((ISvgPathSegCurvetoCubicRel)baseObject).X2 = value; }
			}

			public float y2
			{
				get { return ((ISvgPathSegCurvetoCubicRel)baseObject).Y2;  }
				set { ((ISvgPathSegCurvetoCubicRel)baseObject).Y2 = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoQuadraticAbs
		/// </summary>
		public class ScriptableSvgPathSegCurvetoQuadraticAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoQuadraticAbs
		{
			public ScriptableSvgPathSegCurvetoQuadraticAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoQuadraticAbs
			public float x
			{
				get { return ((ISvgPathSegCurvetoQuadraticAbs)baseObject).X;  }
				set { ((ISvgPathSegCurvetoQuadraticAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoQuadraticAbs)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoQuadraticAbs)baseObject).Y = value; }
			}

			public float x1
			{
				get { return ((ISvgPathSegCurvetoQuadraticAbs)baseObject).X1;  }
				set { ((ISvgPathSegCurvetoQuadraticAbs)baseObject).X1 = value; }
			}

			public float y1
			{
				get { return ((ISvgPathSegCurvetoQuadraticAbs)baseObject).Y1;  }
				set { ((ISvgPathSegCurvetoQuadraticAbs)baseObject).Y1 = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoQuadraticRel
		/// </summary>
		public class ScriptableSvgPathSegCurvetoQuadraticRel : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoQuadraticRel
		{
			public ScriptableSvgPathSegCurvetoQuadraticRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoQuadraticRel
			public float x
			{
				get { return ((ISvgPathSegCurvetoQuadraticRel)baseObject).X;  }
				set { ((ISvgPathSegCurvetoQuadraticRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoQuadraticRel)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoQuadraticRel)baseObject).Y = value; }
			}

			public float x1
			{
				get { return ((ISvgPathSegCurvetoQuadraticRel)baseObject).X1;  }
				set { ((ISvgPathSegCurvetoQuadraticRel)baseObject).X1 = value; }
			}

			public float y1
			{
				get { return ((ISvgPathSegCurvetoQuadraticRel)baseObject).Y1;  }
				set { ((ISvgPathSegCurvetoQuadraticRel)baseObject).Y1 = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegArcAbs
		/// </summary>
		public class ScriptableSvgPathSegArcAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegArcAbs
		{
			public ScriptableSvgPathSegArcAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegArcAbs
			public float x
			{
				get { return ((ISvgPathSegArcAbs)baseObject).X;  }
				set { ((ISvgPathSegArcAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegArcAbs)baseObject).Y;  }
				set { ((ISvgPathSegArcAbs)baseObject).Y = value; }
			}

			public float r1
			{
				get { return ((ISvgPathSegArcAbs)baseObject).R1;  }
				set { ((ISvgPathSegArcAbs)baseObject).R1 = value; }
			}

			public float r2
			{
				get { return ((ISvgPathSegArcAbs)baseObject).R2;  }
				set { ((ISvgPathSegArcAbs)baseObject).R2 = value; }
			}

			public float angle
			{
				get { return ((ISvgPathSegArcAbs)baseObject).Angle;  }
				set { ((ISvgPathSegArcAbs)baseObject).Angle = value; }
			}

			public bool largeArcFlag
			{
				get { return ((ISvgPathSegArcAbs)baseObject).LargeArcFlag;  }
				set { ((ISvgPathSegArcAbs)baseObject).LargeArcFlag = value; }
			}

			public bool sweepFlag
			{
				get { return ((ISvgPathSegArcAbs)baseObject).SweepFlag;  }
				set { ((ISvgPathSegArcAbs)baseObject).SweepFlag = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegArcRel
		/// </summary>
		public class ScriptableSvgPathSegArcRel : ScriptableSvgPathSeg, IScriptableSvgPathSegArcRel
		{
			public ScriptableSvgPathSegArcRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegArcRel
			public float x
			{
				get { return ((ISvgPathSegArcRel)baseObject).X;  }
				set { ((ISvgPathSegArcRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegArcRel)baseObject).Y;  }
				set { ((ISvgPathSegArcRel)baseObject).Y = value; }
			}

			public float r1
			{
				get { return ((ISvgPathSegArcRel)baseObject).R1;  }
				set { ((ISvgPathSegArcRel)baseObject).R1 = value; }
			}

			public float r2
			{
				get { return ((ISvgPathSegArcRel)baseObject).R2;  }
				set { ((ISvgPathSegArcRel)baseObject).R2 = value; }
			}

			public float angle
			{
				get { return ((ISvgPathSegArcRel)baseObject).Angle;  }
				set { ((ISvgPathSegArcRel)baseObject).Angle = value; }
			}

			public bool largeArcFlag
			{
				get { return ((ISvgPathSegArcRel)baseObject).LargeArcFlag;  }
				set { ((ISvgPathSegArcRel)baseObject).LargeArcFlag = value; }
			}

			public bool sweepFlag
			{
				get { return ((ISvgPathSegArcRel)baseObject).SweepFlag;  }
				set { ((ISvgPathSegArcRel)baseObject).SweepFlag = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegLinetoHorizontalAbs
		/// </summary>
		public class ScriptableSvgPathSegLinetoHorizontalAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegLinetoHorizontalAbs
		{
			public ScriptableSvgPathSegLinetoHorizontalAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegLinetoHorizontalAbs
			public float x
			{
				get { return ((ISvgPathSegLinetoHorizontalAbs)baseObject).X;  }
				set { ((ISvgPathSegLinetoHorizontalAbs)baseObject).X = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegLinetoHorizontalRel
		/// </summary>
		public class ScriptableSvgPathSegLinetoHorizontalRel : ScriptableSvgPathSeg, IScriptableSvgPathSegLinetoHorizontalRel
		{
			public ScriptableSvgPathSegLinetoHorizontalRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegLinetoHorizontalRel
			public float x
			{
				get { return ((ISvgPathSegLinetoHorizontalRel)baseObject).X;  }
				set { ((ISvgPathSegLinetoHorizontalRel)baseObject).X = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegLinetoVerticalAbs
		/// </summary>
		public class ScriptableSvgPathSegLinetoVerticalAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegLinetoVerticalAbs
		{
			public ScriptableSvgPathSegLinetoVerticalAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegLinetoVerticalAbs
			public float y
			{
				get { return ((ISvgPathSegLinetoVerticalAbs)baseObject).Y;  }
				set { ((ISvgPathSegLinetoVerticalAbs)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegLinetoVerticalRel
		/// </summary>
		public class ScriptableSvgPathSegLinetoVerticalRel : ScriptableSvgPathSeg, IScriptableSvgPathSegLinetoVerticalRel
		{
			public ScriptableSvgPathSegLinetoVerticalRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegLinetoVerticalRel
			public float y
			{
				get { return ((ISvgPathSegLinetoVerticalRel)baseObject).Y;  }
				set { ((ISvgPathSegLinetoVerticalRel)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoCubicSmoothAbs
		/// </summary>
		public class ScriptableSvgPathSegCurvetoCubicSmoothAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoCubicSmoothAbs
		{
			public ScriptableSvgPathSegCurvetoCubicSmoothAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoCubicSmoothAbs
			public float x
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).X;  }
				set { ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).Y = value; }
			}

			public float x2
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).X2;  }
				set { ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).X2 = value; }
			}

			public float y2
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).Y2;  }
				set { ((ISvgPathSegCurvetoCubicSmoothAbs)baseObject).Y2 = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoCubicSmoothRel
		/// </summary>
		public class ScriptableSvgPathSegCurvetoCubicSmoothRel : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoCubicSmoothRel
		{
			public ScriptableSvgPathSegCurvetoCubicSmoothRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoCubicSmoothRel
			public float x
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).X;  }
				set { ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).Y = value; }
			}

			public float x2
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).X2;  }
				set { ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).X2 = value; }
			}

			public float y2
			{
				get { return ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).Y2;  }
				set { ((ISvgPathSegCurvetoCubicSmoothRel)baseObject).Y2 = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoQuadraticSmoothAbs
		/// </summary>
		public class ScriptableSvgPathSegCurvetoQuadraticSmoothAbs : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoQuadraticSmoothAbs
		{
			public ScriptableSvgPathSegCurvetoQuadraticSmoothAbs(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoQuadraticSmoothAbs
			public float x
			{
				get { return ((ISvgPathSegCurvetoQuadraticSmoothAbs)baseObject).X;  }
				set { ((ISvgPathSegCurvetoQuadraticSmoothAbs)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoQuadraticSmoothAbs)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoQuadraticSmoothAbs)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegCurvetoQuadraticSmoothRel
		/// </summary>
		public class ScriptableSvgPathSegCurvetoQuadraticSmoothRel : ScriptableSvgPathSeg, IScriptableSvgPathSegCurvetoQuadraticSmoothRel
		{
			public ScriptableSvgPathSegCurvetoQuadraticSmoothRel(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgPathSegCurvetoQuadraticSmoothRel
			public float x
			{
				get { return ((ISvgPathSegCurvetoQuadraticSmoothRel)baseObject).X;  }
				set { ((ISvgPathSegCurvetoQuadraticSmoothRel)baseObject).X = value; }
			}

			public float y
			{
				get { return ((ISvgPathSegCurvetoQuadraticSmoothRel)baseObject).Y;  }
				set { ((ISvgPathSegCurvetoQuadraticSmoothRel)baseObject).Y = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathSegList
		/// </summary>
		public class ScriptableSvgPathSegList : ScriptableObject, IScriptableSvgPathSegList
		{
			public ScriptableSvgPathSegList(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgPathSegList
			public void clear()
			{
				((ISvgPathSegList)baseObject).Clear();
			}

			public IScriptableSvgPathSeg initialize(IScriptableSvgPathSeg newItem)
			{
				object result = ((ISvgPathSegList)baseObject).Initialize(((ISvgPathSeg)((ScriptableSvgPathSeg)newItem).baseObject));
				return (result != null) ? (IScriptableSvgPathSeg)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSeg getItem(ulong index)
			{
				object result = ((ISvgPathSegList)baseObject).GetItem((int)index);
				return (result != null) ? (IScriptableSvgPathSeg)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSeg insertItemBefore(IScriptableSvgPathSeg newItem, ulong index)
			{
				object result = ((ISvgPathSegList)baseObject).InsertItemBefore(((ISvgPathSeg)((ScriptableSvgPathSeg)newItem).baseObject), (int)index);
				return (result != null) ? (IScriptableSvgPathSeg)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSeg replaceItem(IScriptableSvgPathSeg newItem, ulong index)
			{
				object result = ((ISvgPathSegList)baseObject).ReplaceItem(((ISvgPathSeg)((ScriptableSvgPathSeg)newItem).baseObject), (int)index);
				return (result != null) ? (IScriptableSvgPathSeg)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSeg removeItem(ulong index)
			{
				object result = ((ISvgPathSegList)baseObject).RemoveItem((int)index);
				return (result != null) ? (IScriptableSvgPathSeg)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSeg appendItem(IScriptableSvgPathSeg newItem)
			{
				object result = ((ISvgPathSegList)baseObject).AppendItem(((ISvgPathSeg)((ScriptableSvgPathSeg)newItem).baseObject));
				return (result != null) ? (IScriptableSvgPathSeg)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgPathSegList
			public ulong numberOfItems
			{
				get { return (ulong)((ISvgPathSegList)baseObject).NumberOfItems;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedPathData
		/// </summary>
		public class ScriptableSvgAnimatedPathData : ScriptableObject, IScriptableSvgAnimatedPathData
		{
			public ScriptableSvgAnimatedPathData(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedPathData
			public IScriptableSvgPathSegList pathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).PathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPathSegList normalizedPathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).NormalizedPathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPathSegList animatedPathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).AnimatedPathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPathSegList animatedNormalizedPathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).AnimatedNormalizedPathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPathElement
		/// </summary>
		public class ScriptableSvgPathElement : ScriptableSvgElement, IScriptableSvgPathElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget, IScriptableSvgAnimatedPathData
		{
			public ScriptableSvgPathElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgPathElement
			public float getTotalLength()
			{
				return ((ISvgPathElement)baseObject).GetTotalLength();
			}

			public IScriptableSvgPoint getPointAtLength(float distance)
			{
				object result = ((ISvgPathElement)baseObject).GetPointAtLength(distance);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public ulong getPathSegAtLength(float distance)
			{
				return (ulong)((ISvgPathElement)baseObject).GetPathSegAtLength(distance);
			}

			public IScriptableSvgPathSegClosePath createSVGPathSegClosePath()
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegClosePath();
				return (result != null) ? (IScriptableSvgPathSegClosePath)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegMovetoAbs createSVGPathSegMovetoAbs(float x, float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegMovetoAbs(x, y);
				return (result != null) ? (IScriptableSvgPathSegMovetoAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegMovetoRel createSVGPathSegMovetoRel(float x, float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegMovetoRel(x, y);
				return (result != null) ? (IScriptableSvgPathSegMovetoRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegLinetoAbs createSVGPathSegLinetoAbs(float x, float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegLinetoAbs(x, y);
				return (result != null) ? (IScriptableSvgPathSegLinetoAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegLinetoRel createSVGPathSegLinetoRel(float x, float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegLinetoRel(x, y);
				return (result != null) ? (IScriptableSvgPathSegLinetoRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoCubicAbs createSVGPathSegCurvetoCubicAbs(float x, float y, float x1, float y1, float x2, float y2)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoCubicAbs(x, y, x1, y1, x2, y2);
				return (result != null) ? (IScriptableSvgPathSegCurvetoCubicAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoCubicRel createSVGPathSegCurvetoCubicRel(float x, float y, float x1, float y1, float x2, float y2)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoCubicRel(x, y, x1, y1, x2, y2);
				return (result != null) ? (IScriptableSvgPathSegCurvetoCubicRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoQuadraticAbs createSVGPathSegCurvetoQuadraticAbs(float x, float y, float x1, float y1)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoQuadraticAbs(x, y, x1, y1);
				return (result != null) ? (IScriptableSvgPathSegCurvetoQuadraticAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoQuadraticRel createSVGPathSegCurvetoQuadraticRel(float x, float y, float x1, float y1)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoQuadraticRel(x, y, x1, y1);
				return (result != null) ? (IScriptableSvgPathSegCurvetoQuadraticRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegArcAbs createSVGPathSegArcAbs(float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegArcAbs(x, y, r1, r2, angle, largeArcFlag, sweepFlag);
				return (result != null) ? (IScriptableSvgPathSegArcAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegArcRel createSVGPathSegArcRel(float x, float y, float r1, float r2, float angle, bool largeArcFlag, bool sweepFlag)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegArcRel(x, y, r1, r2, angle, largeArcFlag, sweepFlag);
				return (result != null) ? (IScriptableSvgPathSegArcRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegLinetoHorizontalAbs createSVGPathSegLinetoHorizontalAbs(float x)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegLinetoHorizontalAbs(x);
				return (result != null) ? (IScriptableSvgPathSegLinetoHorizontalAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegLinetoHorizontalRel createSVGPathSegLinetoHorizontalRel(float x)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegLinetoHorizontalRel(x);
				return (result != null) ? (IScriptableSvgPathSegLinetoHorizontalRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegLinetoVerticalAbs createSVGPathSegLinetoVerticalAbs(float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegLinetoVerticalAbs(y);
				return (result != null) ? (IScriptableSvgPathSegLinetoVerticalAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegLinetoVerticalRel createSVGPathSegLinetoVerticalRel(float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegLinetoVerticalRel(y);
				return (result != null) ? (IScriptableSvgPathSegLinetoVerticalRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoCubicSmoothAbs createSVGPathSegCurvetoCubicSmoothAbs(float x, float y, float x2, float y2)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoCubicSmoothAbs(x, y, x2, y2);
				return (result != null) ? (IScriptableSvgPathSegCurvetoCubicSmoothAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoCubicSmoothRel createSVGPathSegCurvetoCubicSmoothRel(float x, float y, float x2, float y2)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoCubicSmoothRel(x, y, x2, y2);
				return (result != null) ? (IScriptableSvgPathSegCurvetoCubicSmoothRel)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoQuadraticSmoothAbs createSVGPathSegCurvetoQuadraticSmoothAbs(float x, float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoQuadraticSmoothAbs(x, y);
				return (result != null) ? (IScriptableSvgPathSegCurvetoQuadraticSmoothAbs)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPathSegCurvetoQuadraticSmoothRel createSVGPathSegCurvetoQuadraticSmoothRel(float x, float y)
			{
				object result = ((ISvgPathElement)baseObject).CreateSvgPathSegCurvetoQuadraticSmoothRel(x, y);
				return (result != null) ? (IScriptableSvgPathSegCurvetoQuadraticSmoothRel)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgPathElement
			public IScriptableSvgAnimatedNumber pathLength
			{
				get { object result = ((ISvgPathElement)baseObject).PathLength; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgAnimatedPathData
			public IScriptableSvgPathSegList pathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).PathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPathSegList normalizedPathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).NormalizedPathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPathSegList animatedPathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).AnimatedPathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPathSegList animatedNormalizedPathSegList
			{
				get { object result = ((ISvgAnimatedPathData)baseObject).AnimatedNormalizedPathSegList; return (result != null) ? (IScriptableSvgPathSegList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgRectElement
		/// </summary>
		public class ScriptableSvgRectElement : ScriptableSvgElement, IScriptableSvgRectElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgRectElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
			public void addEventListener(string type, object listener, bool useCapture)
			{
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
			}

			public void removeEventListener(string type, object listener, bool useCapture)
			{
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
			}

			public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgRectElement
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgRectElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgRectElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgRectElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgRectElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength rx
			{
				get { object result = ((ISvgRectElement)baseObject).Rx; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength ry
			{
				get { object result = ((ISvgRectElement)baseObject).Ry; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgCircleElement
		/// </summary>
		public class ScriptableSvgCircleElement : ScriptableSvgElement, IScriptableSvgCircleElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgCircleElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgCircleElement
			public IScriptableSvgAnimatedLength cx
			{
				get { object result = ((ISvgCircleElement)baseObject).Cx; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength cy
			{
				get { object result = ((ISvgCircleElement)baseObject).Cy; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength r
			{
				get { object result = ((ISvgCircleElement)baseObject).R; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgEllipseElement
		/// </summary>
		public class ScriptableSvgEllipseElement : ScriptableSvgElement, IScriptableSvgEllipseElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgEllipseElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgEllipseElement
			public IScriptableSvgAnimatedLength cx
			{
				get { object result = ((ISvgEllipseElement)baseObject).Cx; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength cy
			{
				get { object result = ((ISvgEllipseElement)baseObject).Cy; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength rx
			{
				get { object result = ((ISvgEllipseElement)baseObject).Rx; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength ry
			{
				get { object result = ((ISvgEllipseElement)baseObject).Ry; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgLineElement
		/// </summary>
		public class ScriptableSvgLineElement : ScriptableSvgElement, IScriptableSvgLineElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgLineElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgLineElement
			public IScriptableSvgAnimatedLength x1
			{
				get { object result = ((ISvgLineElement)baseObject).X1; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y1
			{
				get { object result = ((ISvgLineElement)baseObject).Y1; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength x2
			{
				get { object result = ((ISvgLineElement)baseObject).X2; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y2
			{
				get { object result = ((ISvgLineElement)baseObject).Y2; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimatedPoints
		/// </summary>
		public class ScriptableSvgAnimatedPoints : ScriptableObject, IScriptableSvgAnimatedPoints
		{
			public ScriptableSvgAnimatedPoints(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAnimatedPoints
			public IScriptableSvgPointList points
			{
				get { object result = ((ISvgAnimatedPoints)baseObject).Points; return (result != null) ? (IScriptableSvgPointList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPointList animatedPoints
			{
				get { object result = ((ISvgAnimatedPoints)baseObject).AnimatedPoints; return (result != null) ? (IScriptableSvgPointList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPolylineElement
		/// </summary>
		public class ScriptableSvgPolylineElement : ScriptableSvgElement, IScriptableSvgPolylineElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget, IScriptableSvgAnimatedPoints
		{
			public ScriptableSvgPolylineElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgAnimatedPoints
			public IScriptableSvgPointList points
			{
				get { object result = ((ISvgAnimatedPoints)baseObject).Points; return (result != null) ? (IScriptableSvgPointList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPointList animatedPoints
			{
				get { object result = ((ISvgAnimatedPoints)baseObject).AnimatedPoints; return (result != null) ? (IScriptableSvgPointList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPolygonElement
		/// </summary>
		public class ScriptableSvgPolygonElement : ScriptableSvgElement, IScriptableSvgPolygonElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget, IScriptableSvgAnimatedPoints
		{
			public ScriptableSvgPolygonElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgAnimatedPoints
			public IScriptableSvgPointList points
			{
				get { object result = ((ISvgAnimatedPoints)baseObject).Points; return (result != null) ? (IScriptableSvgPointList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgPointList animatedPoints
			{
				get { object result = ((ISvgAnimatedPoints)baseObject).AnimatedPoints; return (result != null) ? (IScriptableSvgPointList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTextContentElement
		/// </summary>
		public class ScriptableSvgTextContentElement : ScriptableSvgElement, IScriptableSvgTextContentElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableEventTarget
		{
			const ushort LENGTHADJUST_UNKNOWN   = 0;
			const ushort LENGTHADJUST_SPACING     = 1;
			const ushort LENGTHADJUST_SPACINGANDGLYPHS     = 2;

			public ScriptableSvgTextContentElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTextContentElement
			public long getNumberOfChars()
			{
				return ((ISvgTextContentElement)baseObject).GetNumberOfChars();
			}

			public float getComputedTextLength()
			{
				return ((ISvgTextContentElement)baseObject).GetComputedTextLength();
			}

			public float getSubStringLength(ulong charnum, ulong nchars)
			{
				return ((ISvgTextContentElement)baseObject).GetSubStringLength((long)charnum, (long)nchars);
			}

			public IScriptableSvgPoint getStartPositionOfChar(ulong charnum)
			{
				object result = ((ISvgTextContentElement)baseObject).GetStartPositionOfChar((long)charnum);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgPoint getEndPositionOfChar(ulong charnum)
			{
				object result = ((ISvgTextContentElement)baseObject).GetEndPositionOfChar((long)charnum);
				return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgRect getExtentOfChar(ulong charnum)
			{
				object result = ((ISvgTextContentElement)baseObject).GetExtentOfChar((long)charnum);
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public float getRotationOfChar(ulong charnum)
			{
				return ((ISvgTextContentElement)baseObject).GetRotationOfChar((long)charnum);
			}

			public long getCharNumAtPosition(IScriptableSvgPoint point)
			{
				return ((ISvgTextContentElement)baseObject).GetCharNumAtPosition(((ISvgPoint)((ScriptableSvgPoint)point).baseObject));
			}

			public void selectSubString(ulong charnum, ulong nchars)
			{
				((ISvgTextContentElement)baseObject).SelectSubString((long)charnum, (long)nchars);
			}
			#endregion

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgTextContentElement
			public IScriptableSvgAnimatedLength textLength
			{
				get { object result = ((ISvgTextContentElement)baseObject).TextLength; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration lengthAdjust
			{
				get { object result = ((ISvgTextContentElement)baseObject).LengthAdjust; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTextPositioningElement
		/// </summary>
		public class ScriptableSvgTextPositioningElement : ScriptableSvgTextContentElement, IScriptableSvgTextPositioningElement
		{
			public ScriptableSvgTextPositioningElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgTextPositioningElement
			public IScriptableSvgAnimatedLengthList x
			{
				get { object result = ((ISvgTextPositioningElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLengthList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLengthList y
			{
				get { object result = ((ISvgTextPositioningElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLengthList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLengthList dx
			{
				get { object result = ((ISvgTextPositioningElement)baseObject).Dx; return (result != null) ? (IScriptableSvgAnimatedLengthList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLengthList dy
			{
				get { object result = ((ISvgTextPositioningElement)baseObject).Dy; return (result != null) ? (IScriptableSvgAnimatedLengthList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumberList rotate
			{
				get { object result = ((ISvgTextPositioningElement)baseObject).Rotate; return (result != null) ? (IScriptableSvgAnimatedNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTextElement
		/// </summary>
		public class ScriptableSvgTextElement : ScriptableSvgTextPositioningElement, IScriptableSvgTextElement, IScriptableSvgTransformable
		{
			public ScriptableSvgTextElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTSpanElement
		/// </summary>
		public class ScriptableSvgTSpanElement : ScriptableSvgTextPositioningElement, IScriptableSvgTSpanElement
		{
			public ScriptableSvgTSpanElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTRefElement
		/// </summary>
		public class ScriptableSvgTRefElement : ScriptableSvgTextPositioningElement, IScriptableSvgTRefElement, IScriptableSvgUriReference
		{
			public ScriptableSvgTRefElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgTextPathElement
		/// </summary>
		public class ScriptableSvgTextPathElement : ScriptableSvgTextContentElement, IScriptableSvgTextPathElement, IScriptableSvgUriReference
		{
			const ushort TEXTPATH_METHODTYPE_UNKNOWN   = 0;
			const ushort TEXTPATH_METHODTYPE_ALIGN     = 1;
			const ushort TEXTPATH_METHODTYPE_STRETCH     = 2;
			const ushort TEXTPATH_SPACINGTYPE_UNKNOWN   = 0;
			const ushort TEXTPATH_SPACINGTYPE_AUTO     = 1;
			const ushort TEXTPATH_SPACINGTYPE_EXACT     = 2;

			public ScriptableSvgTextPathElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgTextPathElement
			public IScriptableSvgAnimatedLength startOffset
			{
				get { object result = ((ISvgTextPathElement)baseObject).StartOffset; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration method
			{
				get { object result = ((ISvgTextPathElement)baseObject).Method; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration spacing
			{
				get { object result = ((ISvgTextPathElement)baseObject).Spacing; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAltGlyphElement
		/// </summary>
		public class ScriptableSvgAltGlyphElement : ScriptableSvgTextPositioningElement, IScriptableSvgAltGlyphElement, IScriptableSvgUriReference
		{
			public ScriptableSvgAltGlyphElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgAltGlyphElement
			public string glyphRef
			{
				get { throw new NotImplementedException(); }//return ((ISvgAltGlyphElement)baseObject).GlyphRef;  }
				set { throw new NotImplementedException(); }//((ISvgAltGlyphElement)baseObject).GlyphRef = value; }
			}

			public string format
			{
				get { throw new NotImplementedException(); }//return ((ISvgAltGlyphElement)baseObject).Format;  }
				set { throw new NotImplementedException(); }//((ISvgAltGlyphElement)baseObject).Format = value; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAltGlyphDefElement
		/// </summary>
		public class ScriptableSvgAltGlyphDefElement : ScriptableSvgElement, IScriptableSvgAltGlyphDefElement
		{
			public ScriptableSvgAltGlyphDefElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAltGlyphItemElement
		/// </summary>
		public class ScriptableSvgAltGlyphItemElement : ScriptableSvgElement, IScriptableSvgAltGlyphItemElement
		{
			public ScriptableSvgAltGlyphItemElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgGlyphRefElement
		/// </summary>
		public class ScriptableSvgGlyphRefElement : ScriptableSvgElement, IScriptableSvgGlyphRefElement, IScriptableSvgUriReference, IScriptableSvgStylable
		{
			public ScriptableSvgGlyphRefElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgGlyphRefElement
			public string glyphRef
			{
				get { throw new NotImplementedException(); }//return ((ISvgGlyphRefElement)baseObject).GlyphRef;  }
				set { throw new NotImplementedException(); }//((ISvgGlyphRefElement)baseObject).GlyphRef = value; }
			}

			public string format
			{
				get { throw new NotImplementedException(); }//return ((ISvgGlyphRefElement)baseObject).Format;  }
				set { throw new NotImplementedException(); }//((ISvgGlyphRefElement)baseObject).Format = value; }
			}

			public float x
			{
				get { throw new NotImplementedException(); }//return ((ISvgGlyphRefElement)baseObject).X;  }
				set { throw new NotImplementedException(); }//((ISvgGlyphRefElement)baseObject).X = value; }
			}

			public float y
			{
				get { throw new NotImplementedException(); }//return ((ISvgGlyphRefElement)baseObject).Y;  }
				set { throw new NotImplementedException(); }//((ISvgGlyphRefElement)baseObject).Y = value; }
			}

			public float dx
			{
				get { throw new NotImplementedException(); }//return ((ISvgGlyphRefElement)baseObject).Dx;  }
				set { throw new NotImplementedException(); }//((ISvgGlyphRefElement)baseObject).Dx = value; }
			}

			public float dy
			{
				get { throw new NotImplementedException(); }//return ((ISvgGlyphRefElement)baseObject).Dy;  }
				set { throw new NotImplementedException(); }//((ISvgGlyphRefElement)baseObject).Dy = value; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPaint
		/// </summary>
		public class ScriptableSvgPaint : ScriptableSvgColor, IScriptableSvgPaint
		{
			const ushort SVG_PAINTTYPE_UNKNOWN               = 0;
			const ushort SVG_PAINTTYPE_RGBCOLOR              = 1;
			const ushort SVG_PAINTTYPE_RGBCOLOR_ICCCOLOR     = 2;
			const ushort SVG_PAINTTYPE_NONE                  = 101;
			const ushort SVG_PAINTTYPE_CURRENTCOLOR          = 102;
			const ushort SVG_PAINTTYPE_URI_NONE              = 103;
			const ushort SVG_PAINTTYPE_URI_CURRENTCOLOR      = 104;
			const ushort SVG_PAINTTYPE_URI_RGBCOLOR          = 105;
			const ushort SVG_PAINTTYPE_URI_RGBCOLOR_ICCCOLOR = 106;
			const ushort SVG_PAINTTYPE_URI                   = 107;

			public ScriptableSvgPaint(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgPaint
			public void setUri(string uri)
			{
				((ISvgPaint)baseObject).SetUri(uri);
			}

			public void setPaint(ushort paintType, string uri, string rgbColor, string iccColor)
			{
				((ISvgPaint)baseObject).SetPaint((SvgPaintType)paintType, uri, rgbColor, iccColor);
			}
			#endregion

			#region Properties - IScriptableSvgPaint
			public ushort paintType
			{
				get { return (ushort)((ISvgPaint)baseObject).PaintType;  }
			}

			public string uri
			{
				get { return ((ISvgPaint)baseObject).Uri;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgMarkerElement
		/// </summary>
		public class ScriptableSvgMarkerElement : ScriptableSvgElement, IScriptableSvgMarkerElement, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgFitToViewBox
		{
			const ushort SVG_MARKERUNITS_UNKNOWN        = 0;
			const ushort SVG_MARKERUNITS_USERSPACEONUSE = 1;
			const ushort SVG_MARKERUNITS_STROKEWIDTH    = 2;
			const ushort SVG_MARKER_ORIENT_UNKNOWN      = 0;
			const ushort SVG_MARKER_ORIENT_AUTO         = 1;
			const ushort SVG_MARKER_ORIENT_ANGLE        = 2;

			public ScriptableSvgMarkerElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgMarkerElement
			public void setOrientToAuto()
			{
				((ISvgMarkerElement)baseObject).SetOrientToAuto();
			}

			public void setOrientToAngle(IScriptableSvgAngle angle)
			{
				((ISvgMarkerElement)baseObject).SetOrientToAngle(((ISvgAngle)((ScriptableSvgAngle)angle).baseObject));
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgMarkerElement
			public IScriptableSvgAnimatedLength refX
			{
				get { object result = ((ISvgMarkerElement)baseObject).RefX; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength refY
			{
				get { object result = ((ISvgMarkerElement)baseObject).RefY; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration markerUnits
			{
				get { object result = ((ISvgMarkerElement)baseObject).MarkerUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength markerWidth
			{
				get { object result = ((ISvgMarkerElement)baseObject).MarkerWidth; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength markerHeight
			{
				get { object result = ((ISvgMarkerElement)baseObject).MarkerHeight; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration orientType
			{
				get { object result = ((ISvgMarkerElement)baseObject).OrientType; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedAngle orientAngle
			{
				get { object result = ((ISvgMarkerElement)baseObject).OrientAngle; return (result != null) ? (IScriptableSvgAnimatedAngle)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgColorProfileElement
		/// </summary>
		public class ScriptableSvgColorProfileElement : ScriptableSvgElement, IScriptableSvgColorProfileElement, IScriptableSvgUriReference, IScriptableSvgRenderingIntent
		{
			public ScriptableSvgColorProfileElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgColorProfileElement
			public string local
			{
				get { throw new NotImplementedException(); }//return ((ISvgColorProfileElement)baseObject).Local;  }
				set { throw new NotImplementedException(); }//((ISvgColorProfileElement)baseObject).Local = value; }
			}

			public string name
			{
				get { throw new NotImplementedException(); }//return ((ISvgColorProfileElement)baseObject).Name;  }
				set { throw new NotImplementedException(); }//((ISvgColorProfileElement)baseObject).Name = value; }
			}

			public ushort renderingIntent
			{
				get { throw new NotImplementedException(); }//return ((ISvgColorProfileElement)baseObject).RenderingIntent;  }
				set { throw new NotImplementedException(); }//((ISvgColorProfileElement)baseObject).RenderingIntent = value; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgColorProfileRule
		/// </summary>
		public class ScriptableSvgColorProfileRule : ScriptableSvgCssRule, IScriptableSvgColorProfileRule, IScriptableSvgRenderingIntent
		{
			public ScriptableSvgColorProfileRule(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgColorProfileRule
			public string src
			{
				get { throw new NotImplementedException(); }//return ((ISvgColorProfileRule)baseObject).Src;  }
				set { throw new NotImplementedException(); }//((ISvgColorProfileRule)baseObject).Src = value; }
			}

			public string name
			{
				get { throw new NotImplementedException(); }//return ((ISvgColorProfileRule)baseObject).Name;  }
				set { throw new NotImplementedException(); }//((ISvgColorProfileRule)baseObject).Name = value; }
			}

			public ushort renderingIntent
			{
				get { throw new NotImplementedException(); }//return ((ISvgColorProfileRule)baseObject).RenderingIntent;  }
				set { throw new NotImplementedException(); }//((ISvgColorProfileRule)baseObject).RenderingIntent = value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgGradientElement
		/// </summary>
		public class ScriptableSvgGradientElement : ScriptableSvgElement, IScriptableSvgGradientElement, IScriptableSvgUriReference, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgUnitTypes
		{
			const ushort SVG_SPREADMETHOD_UNKNOWN = 0;
			const ushort SVG_SPREADMETHOD_PAD     = 1;
			const ushort SVG_SPREADMETHOD_REFLECT = 2;
			const ushort SVG_SPREADMETHOD_REPEAT  = 3;

			public ScriptableSvgGradientElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgGradientElement
			public IScriptableSvgAnimatedEnumeration gradientUnits
			{
				get { object result = ((ISvgGradientElement)baseObject).GradientUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedTransformList gradientTransform
			{
				get { object result = ((ISvgGradientElement)baseObject).GradientTransform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration spreadMethod
			{
				get { object result = ((ISvgGradientElement)baseObject).SpreadMethod; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgLinearGradientElement
		/// </summary>
		public class ScriptableSvgLinearGradientElement : ScriptableSvgGradientElement, IScriptableSvgLinearGradientElement
		{
			public ScriptableSvgLinearGradientElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgLinearGradientElement
			public IScriptableSvgAnimatedLength x1
			{
				get { object result = ((ISvgLinearGradientElement)baseObject).X1; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y1
			{
				get { object result = ((ISvgLinearGradientElement)baseObject).Y1; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength x2
			{
				get { object result = ((ISvgLinearGradientElement)baseObject).X2; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y2
			{
				get { object result = ((ISvgLinearGradientElement)baseObject).Y2; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgRadialGradientElement
		/// </summary>
		public class ScriptableSvgRadialGradientElement : ScriptableSvgGradientElement, IScriptableSvgRadialGradientElement
		{
			public ScriptableSvgRadialGradientElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgRadialGradientElement
			public IScriptableSvgAnimatedLength cx
			{
				get { object result = ((ISvgRadialGradientElement)baseObject).Cx; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength cy
			{
				get { object result = ((ISvgRadialGradientElement)baseObject).Cy; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength r
			{
				get { object result = ((ISvgRadialGradientElement)baseObject).R; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength fx
			{
				get { object result = ((ISvgRadialGradientElement)baseObject).Fx; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength fy
			{
				get { object result = ((ISvgRadialGradientElement)baseObject).Fy; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgStopElement
		/// </summary>
		public class ScriptableSvgStopElement : ScriptableSvgElement, IScriptableSvgStopElement, IScriptableSvgStylable
		{
			public ScriptableSvgStopElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgStopElement
			public IScriptableSvgAnimatedNumber offset
			{
				get { object result = ((ISvgStopElement)baseObject).Offset; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgPatternElement
		/// </summary>
		public class ScriptableSvgPatternElement : ScriptableSvgElement, IScriptableSvgPatternElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgFitToViewBox, IScriptableSvgUnitTypes
		{
			public ScriptableSvgPatternElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgPatternElement
			public IScriptableSvgAnimatedEnumeration patternUnits
			{
				get { object result = ((ISvgPatternElement)baseObject).PatternUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration patternContentUnits
			{
				get { object result = ((ISvgPatternElement)baseObject).PatternContentUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedTransformList patternTransform
			{
				get { object result = ((ISvgPatternElement)baseObject).PatternTransform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgPatternElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgPatternElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgPatternElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgPatternElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgClipPathElement
		/// </summary>
		public class ScriptableSvgClipPathElement : ScriptableSvgElement, IScriptableSvgClipPathElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableSvgUnitTypes
		{
			public ScriptableSvgClipPathElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgClipPathElement
			public IScriptableSvgAnimatedEnumeration clipPathUnits
			{
				get { object result = ((ISvgClipPathElement)baseObject).ClipPathUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgMaskElement
		/// </summary>
		public class ScriptableSvgMaskElement : ScriptableSvgElement, IScriptableSvgMaskElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgUnitTypes
		{
			public ScriptableSvgMaskElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgMaskElement
			public IScriptableSvgAnimatedEnumeration maskUnits
			{
				get { object result = ((ISvgMaskElement)baseObject).MaskUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration maskContentUnits
			{
				get { object result = ((ISvgMaskElement)baseObject).MaskContentUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgMaskElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgMaskElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgMaskElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgMaskElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFilterElement
		/// </summary>
		public class ScriptableSvgFilterElement : ScriptableSvgElement, IScriptableSvgFilterElement, IScriptableSvgUriReference, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgUnitTypes
		{
			public ScriptableSvgFilterElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgFilterElement
			public void setFilterRes(ulong filterResX, ulong filterResY)
			{
				((ISvgFilterElement)baseObject).SetFilterRes(filterResX, filterResY);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFilterElement
			public IScriptableSvgAnimatedEnumeration filterUnits
			{
				get { object result = ((ISvgFilterElement)baseObject).FilterUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration primitiveUnits
			{
				get { object result = ((ISvgFilterElement)baseObject).PrimitiveUnits; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedInteger filterResX
			{
				get { object result = ((ISvgFilterElement)baseObject).FilterResX; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedInteger filterResY
			{
				get { object result = ((ISvgFilterElement)baseObject).FilterResY; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFilterPrimitiveStandardAttributes
		/// </summary>
		public class ScriptableSvgFilterPrimitiveStandardAttributes : ScriptableSvgStylable, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFilterPrimitiveStandardAttributes(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEBlendElement
		/// </summary>
		public class ScriptableSvgFEBlendElement : ScriptableSvgElement, IScriptableSvgFEBlendElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_FEBLEND_MODE_UNKNOWN  = 0;
			const ushort SVG_FEBLEND_MODE_NORMAL   = 1;
			const ushort SVG_FEBLEND_MODE_MULTIPLY = 2;
			const ushort SVG_FEBLEND_MODE_SCREEN   = 3;
			const ushort SVG_FEBLEND_MODE_DARKEN   = 4;
			const ushort SVG_FEBLEND_MODE_LIGHTEN  = 5;

			public ScriptableSvgFEBlendElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEBlendElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEBlendElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString in2
			{
				get { object result = ((ISvgFEBlendElement)baseObject).In2; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration mode
			{
				get { object result = ((ISvgFEBlendElement)baseObject).Mode; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEColorMatrixElement
		/// </summary>
		public class ScriptableSvgFEColorMatrixElement : ScriptableSvgElement, IScriptableSvgFEColorMatrixElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_FECOLORMATRIX_TYPE_UNKNOWN          = 0;
			const ushort SVG_FECOLORMATRIX_TYPE_MATRIX           = 1;
			const ushort SVG_FECOLORMATRIX_TYPE_SATURATE         = 2;
			const ushort SVG_FECOLORMATRIX_TYPE_HUEROTATE        = 3;
			const ushort SVG_FECOLORMATRIX_TYPE_LUMINANCETOALPHA = 4;

			public ScriptableSvgFEColorMatrixElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEColorMatrixElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEColorMatrixElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration type
			{
				get { object result = ((ISvgFEColorMatrixElement)baseObject).Type; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumberList values
			{
				get { object result = ((ISvgFEColorMatrixElement)baseObject).Values; return (result != null) ? (IScriptableSvgAnimatedNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEComponentTransferElement
		/// </summary>
		public class ScriptableSvgFEComponentTransferElement : ScriptableSvgElement, IScriptableSvgFEComponentTransferElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEComponentTransferElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEComponentTransferElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEComponentTransferElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgComponentTransferFunctionElement
		/// </summary>
		public class ScriptableSvgComponentTransferFunctionElement : ScriptableSvgElement, IScriptableSvgComponentTransferFunctionElement
		{
			const ushort SVG_FECOMPONENTTRANSFER_TYPE_UNKNOWN  = 0;
			const ushort SVG_FECOMPONENTTRANSFER_TYPE_IDENTITY = 1;
			const ushort SVG_FECOMPONENTTRANSFER_TYPE_TABLE    = 2;
			const ushort SVG_FECOMPONENTTRANSFER_TYPE_DISCRETE    = 3;
			const ushort SVG_FECOMPONENTTRANSFER_TYPE_LINEAR   = 4;
			const ushort SVG_FECOMPONENTTRANSFER_TYPE_GAMMA    = 5;

			public ScriptableSvgComponentTransferFunctionElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgComponentTransferFunctionElement
			public IScriptableSvgAnimatedEnumeration type
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).Type; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumberList tableValues
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).TableValues; return (result != null) ? (IScriptableSvgAnimatedNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber slope
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).Slope; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber intercept
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).Intercept; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber amplitude
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).Amplitude; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber exponent
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).Exponent; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber offset
			{
				get { object result = ((ISvgComponentTransferFunctionElement)baseObject).Offset; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEFuncRElement
		/// </summary>
		public class ScriptableSvgFEFuncRElement : ScriptableSvgComponentTransferFunctionElement, IScriptableSvgFEFuncRElement
		{
			public ScriptableSvgFEFuncRElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEFuncGElement
		/// </summary>
		public class ScriptableSvgFEFuncGElement : ScriptableSvgComponentTransferFunctionElement, IScriptableSvgFEFuncGElement
		{
			public ScriptableSvgFEFuncGElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEFuncBElement
		/// </summary>
		public class ScriptableSvgFEFuncBElement : ScriptableSvgComponentTransferFunctionElement, IScriptableSvgFEFuncBElement
		{
			public ScriptableSvgFEFuncBElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEFuncAElement
		/// </summary>
		public class ScriptableSvgFEFuncAElement : ScriptableSvgComponentTransferFunctionElement, IScriptableSvgFEFuncAElement
		{
			public ScriptableSvgFEFuncAElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFECompositeElement
		/// </summary>
		public class ScriptableSvgFECompositeElement : ScriptableSvgElement, IScriptableSvgFECompositeElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_FECOMPOSITE_operator__UNKNOWN    = 0;
			const ushort SVG_FECOMPOSITE_operator__OVER       = 1;
			const ushort SVG_FECOMPOSITE_operator__IN         = 2;
			const ushort SVG_FECOMPOSITE_operator__OUT        = 3;
			const ushort SVG_FECOMPOSITE_operator__ATOP       = 4;
			const ushort SVG_FECOMPOSITE_operator__XOR        = 5;
			const ushort SVG_FECOMPOSITE_operator__ARITHMETIC = 6;

			public ScriptableSvgFECompositeElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFECompositeElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFECompositeElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString in2
			{
				get { object result = ((ISvgFECompositeElement)baseObject).In2; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration operator_
			{
				get { object result = ((ISvgFECompositeElement)baseObject).Operator; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber k1
			{
				get { object result = ((ISvgFECompositeElement)baseObject).K1; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber k2
			{
				get { object result = ((ISvgFECompositeElement)baseObject).K2; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber k3
			{
				get { object result = ((ISvgFECompositeElement)baseObject).K3; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber k4
			{
				get { object result = ((ISvgFECompositeElement)baseObject).K4; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEConvolveMatrixElement
		/// </summary>
		public class ScriptableSvgFEConvolveMatrixElement : ScriptableSvgElement, IScriptableSvgFEConvolveMatrixElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_EDGEMODE_UNKNOWN   = 0;
			const ushort SVG_EDGEMODE_DUPLICATE = 1;
			const ushort SVG_EDGEMODE_WRAP      = 2;
			const ushort SVG_EDGEMODE_NONE      = 3;

			public ScriptableSvgFEConvolveMatrixElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEConvolveMatrixElement
			public IScriptableSvgAnimatedInteger orderX
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).OrderX; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedInteger orderY
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).OrderY; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumberList kernelMatrix
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).KernelMatrix; return (result != null) ? (IScriptableSvgAnimatedNumberList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber divisor
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).Divisor; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber bias
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).Bias; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedInteger targetX
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).TargetX; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedInteger targetY
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).TargetY; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration edgeMode
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).EdgeMode; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength kernelUnitLengthX
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).KernelUnitLengthX; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength kernelUnitLengthY
			{
				get { object result = ((ISvgFEConvolveMatrixElement)baseObject).KernelUnitLengthY; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public bool preserveAlpha
			{
				get { return ((ISvgFEConvolveMatrixElement)baseObject).PreserveAlpha;  }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEDiffuseLightingElement
		/// </summary>
		public class ScriptableSvgFEDiffuseLightingElement : ScriptableSvgElement, IScriptableSvgFEDiffuseLightingElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEDiffuseLightingElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEDiffuseLightingElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEDiffuseLightingElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber surfaceScale
			{
				get { object result = ((ISvgFEDiffuseLightingElement)baseObject).SurfaceScale; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber diffuseConstant
			{
				get { object result = ((ISvgFEDiffuseLightingElement)baseObject).DiffuseConstant; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEDistantLightElement
		/// </summary>
		public class ScriptableSvgFEDistantLightElement : ScriptableSvgElement, IScriptableSvgFEDistantLightElement
		{
			public ScriptableSvgFEDistantLightElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgFEDistantLightElement
			public IScriptableSvgAnimatedNumber azimuth
			{
				get { object result = ((ISvgFEDistantLightElement)baseObject).Azimuth; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber elevation
			{
				get { object result = ((ISvgFEDistantLightElement)baseObject).Elevation; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEPointLightElement
		/// </summary>
		public class ScriptableSvgFEPointLightElement : ScriptableSvgElement, IScriptableSvgFEPointLightElement
		{
			public ScriptableSvgFEPointLightElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgFEPointLightElement
			public IScriptableSvgAnimatedNumber x
			{
				get { object result = ((ISvgFEPointLightElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber y
			{
				get { object result = ((ISvgFEPointLightElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber z
			{
				get { object result = ((ISvgFEPointLightElement)baseObject).Z; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFESpotLightElement
		/// </summary>
		public class ScriptableSvgFESpotLightElement : ScriptableSvgElement, IScriptableSvgFESpotLightElement
		{
			public ScriptableSvgFESpotLightElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgFESpotLightElement
			public IScriptableSvgAnimatedNumber x
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber y
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber z
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).Z; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber pointsAtX
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).PointsAtX; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber pointsAtY
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).PointsAtY; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber pointsAtZ
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).PointsAtZ; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber specularExponent
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).SpecularExponent; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber limitingConeAngle
			{
				get { object result = ((ISvgFESpotLightElement)baseObject).LimitingConeAngle; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEDisplacementMapElement
		/// </summary>
		public class ScriptableSvgFEDisplacementMapElement : ScriptableSvgElement, IScriptableSvgFEDisplacementMapElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_CHANNEL_UNKNOWN = 0;
			const ushort SVG_CHANNEL_R       = 1;
			const ushort SVG_CHANNEL_G       = 2;
			const ushort SVG_CHANNEL_B       = 3;
			const ushort SVG_CHANNEL_A       = 4;

			public ScriptableSvgFEDisplacementMapElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEDisplacementMapElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEDisplacementMapElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString in2
			{
				get { object result = ((ISvgFEDisplacementMapElement)baseObject).In2; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber scale
			{
				get { object result = ((ISvgFEDisplacementMapElement)baseObject).Scale; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration xChannelSelector
			{
				get { object result = ((ISvgFEDisplacementMapElement)baseObject).XChannelSelector; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration yChannelSelector
			{
				get { object result = ((ISvgFEDisplacementMapElement)baseObject).YChannelSelector; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEFloodElement
		/// </summary>
		public class ScriptableSvgFEFloodElement : ScriptableSvgElement, IScriptableSvgFEFloodElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEFloodElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEFloodElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEFloodElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEGaussianBlurElement
		/// </summary>
		public class ScriptableSvgFEGaussianBlurElement : ScriptableSvgElement, IScriptableSvgFEGaussianBlurElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEGaussianBlurElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgFEGaussianBlurElement
			public void setStdDeviation(float stdDeviationX, float stdDeviationY)
			{
				((ISvgFEGaussianBlurElement)baseObject).SetStdDeviation(stdDeviationX, stdDeviationY);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEGaussianBlurElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEGaussianBlurElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber stdDeviationX
			{
				get { object result = ((ISvgFEGaussianBlurElement)baseObject).StdDeviationX; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber stdDeviationY
			{
				get { object result = ((ISvgFEGaussianBlurElement)baseObject).StdDeviationY; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEImageElement
		/// </summary>
		public class ScriptableSvgFEImageElement : ScriptableSvgElement, IScriptableSvgFEImageElement, IScriptableSvgUriReference, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEImageElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEMergeElement
		/// </summary>
		public class ScriptableSvgFEMergeElement : ScriptableSvgElement, IScriptableSvgFEMergeElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEMergeElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEMergeNodeElement
		/// </summary>
		public class ScriptableSvgFEMergeNodeElement : ScriptableSvgElement, IScriptableSvgFEMergeNodeElement
		{
			public ScriptableSvgFEMergeNodeElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgFEMergeNodeElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEMergeNodeElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEMorphologyElement
		/// </summary>
		public class ScriptableSvgFEMorphologyElement : ScriptableSvgElement, IScriptableSvgFEMorphologyElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_MORPHOLOGY_operator__UNKNOWN = 0;
			const ushort SVG_MORPHOLOGY_operator__ERODE   = 1;
			const ushort SVG_MORPHOLOGY_operator__DILATE  = 2;

			public ScriptableSvgFEMorphologyElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEMorphologyElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEMorphologyElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration operator_
			{
				get { object result = ((ISvgFEMorphologyElement)baseObject).Operator; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength radiusX
			{
				get { object result = ((ISvgFEMorphologyElement)baseObject).RadiusX; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength radiusY
			{
				get { object result = ((ISvgFEMorphologyElement)baseObject).RadiusY; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFEOffsetElement
		/// </summary>
		public class ScriptableSvgFEOffsetElement : ScriptableSvgElement, IScriptableSvgFEOffsetElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFEOffsetElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFEOffsetElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFEOffsetElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber dx
			{
				get { object result = ((ISvgFEOffsetElement)baseObject).Dx; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber dy
			{
				get { object result = ((ISvgFEOffsetElement)baseObject).Dy; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFESpecularLightingElement
		/// </summary>
		public class ScriptableSvgFESpecularLightingElement : ScriptableSvgElement, IScriptableSvgFESpecularLightingElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFESpecularLightingElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFESpecularLightingElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFESpecularLightingElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber surfaceScale
			{
				get { object result = ((ISvgFESpecularLightingElement)baseObject).SurfaceScale; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber specularConstant
			{
				get { object result = ((ISvgFESpecularLightingElement)baseObject).SpecularConstant; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber specularExponent
			{
				get { object result = ((ISvgFESpecularLightingElement)baseObject).SpecularExponent; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFETileElement
		/// </summary>
		public class ScriptableSvgFETileElement : ScriptableSvgElement, IScriptableSvgFETileElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			public ScriptableSvgFETileElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFETileElement
			public IScriptableSvgAnimatedString in1
			{
				get { object result = ((ISvgFETileElement)baseObject).In1; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFETurbulenceElement
		/// </summary>
		public class ScriptableSvgFETurbulenceElement : ScriptableSvgElement, IScriptableSvgFETurbulenceElement, IScriptableSvgFilterPrimitiveStandardAttributes
		{
			const ushort SVG_TURBULENCE_TYPE_UNKNOWN      = 0;
			const ushort SVG_TURBULENCE_TYPE_FRACTALNOISE = 1;
			const ushort SVG_TURBULENCE_TYPE_TURBULENCE   = 2;
			const ushort SVG_STITCHTYPE_UNKNOWN  = 0;
			const ushort SVG_STITCHTYPE_STITCH   = 1;
			const ushort SVG_STITCHTYPE_NOSTITCH = 2;

			public ScriptableSvgFETurbulenceElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgFETurbulenceElement
			public IScriptableSvgAnimatedNumber baseFrequencyX
			{
				get { object result = ((ISvgFETurbulenceElement)baseObject).BaseFrequencyX; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber baseFrequencyY
			{
				get { object result = ((ISvgFETurbulenceElement)baseObject).BaseFrequencyY; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedInteger numOctaves
			{
				get { object result = ((ISvgFETurbulenceElement)baseObject).NumOctaves; return (result != null) ? (IScriptableSvgAnimatedInteger)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedNumber seed
			{
				get { object result = ((ISvgFETurbulenceElement)baseObject).Seed; return (result != null) ? (IScriptableSvgAnimatedNumber)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration stitchTiles
			{
				get { object result = ((ISvgFETurbulenceElement)baseObject).StitchTiles; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedEnumeration type
			{
				get { object result = ((ISvgFETurbulenceElement)baseObject).Type; return (result != null) ? (IScriptableSvgAnimatedEnumeration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgFilterPrimitiveStandardAttributes
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedString result
			{
				get { object result = ((ISvgFilterPrimitiveStandardAttributes)baseObject).Result; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgCursorElement
		/// </summary>
		public class ScriptableSvgCursorElement : ScriptableSvgElement, IScriptableSvgCursorElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgExternalResourcesRequired
		{
			public ScriptableSvgCursorElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Properties - IScriptableSvgCursorElement
			public IScriptableSvgAnimatedLength x
			{
				get { object result = ((ISvgCursorElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { object result = ((ISvgCursorElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAElement
		/// </summary>
		public class ScriptableSvgAElement : ScriptableSvgElement, IScriptableSvgAElement, IScriptableSvgUriReference, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgAElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgAElement
			public IScriptableSvgAnimatedString target
			{
				get { object result = ((ISvgAElement)baseObject).Target; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgViewElement
		/// </summary>
		public class ScriptableSvgViewElement : ScriptableSvgElement, IScriptableSvgViewElement, IScriptableSvgExternalResourcesRequired, IScriptableSvgFitToViewBox, IScriptableSvgZoomAndPan
		{
			public ScriptableSvgViewElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgViewElement
			public IScriptableSvgStringList viewTarget
			{
				get { object result = ((ISvgViewElement)baseObject).ViewTarget; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgFitToViewBox
			public IScriptableSvgAnimatedRect viewBox
			{
				get { object result = ((ISvgFitToViewBox)baseObject).ViewBox; return (result != null) ? (IScriptableSvgAnimatedRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedPreserveAspectRatio preserveAspectRatio
			{
				get { object result = ((ISvgFitToViewBox)baseObject).PreserveAspectRatio; return (result != null) ? (IScriptableSvgAnimatedPreserveAspectRatio)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgZoomAndPan
			public ushort zoomAndPan
			{
				get { return (ushort)((ISvgZoomAndPan)baseObject).ZoomAndPan;  }
				set { ((ISvgZoomAndPan)baseObject).ZoomAndPan = (SvgZoomAndPanType)value; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgScriptElement
		/// </summary>
		public class ScriptableSvgScriptElement : ScriptableSvgElement, IScriptableSvgScriptElement, IScriptableSvgUriReference, IScriptableSvgExternalResourcesRequired
		{
			public ScriptableSvgScriptElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgScriptElement
			public string type
			{
				get { return ((ISvgScriptElement)baseObject).Type;  }
				set { ((ISvgScriptElement)baseObject).Type = value; }
			}

			#endregion

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgEvent
		/// </summary>
		public class ScriptableSvgEvent : ScriptableEvent, IScriptableSvgEvent
		{
			public ScriptableSvgEvent(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgZoomEvent
		/// </summary>
		public class ScriptableSvgZoomEvent : ScriptableUiEvent, IScriptableSvgZoomEvent
		{
			public ScriptableSvgZoomEvent(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgZoomEvent
			public IScriptableSvgRect zoomRectScreen
			{
				get { throw new NotImplementedException(); }//object result = ((ISvgZoomEvent)baseObject).ZoomRectScreen; return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null; }
			}

			public float previousScale
			{
				get { throw new NotImplementedException(); }//return ((ISvgZoomEvent)baseObject).PreviousScale;  }
			}

			public IScriptableSvgPoint previousTranslate
			{
        get { throw new NotImplementedException(); }//object result = ((ISvgZoomEvent)baseObject).PreviousTranslate; return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null; }
			}

			public float newScale
			{
				get { throw new NotImplementedException(); }//return ((ISvgZoomEvent)baseObject).NewScale;  }
			}

			public IScriptableSvgPoint newTranslate
			{
        get { throw new NotImplementedException(); }//object result = ((ISvgZoomEvent)baseObject).NewTranslate; return (result != null) ? (IScriptableSvgPoint)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimationElement
		/// </summary>
		public class ScriptableSvgAnimationElement : ScriptableSvgElement, IScriptableSvgAnimationElement, IScriptableSvgTests, IScriptableSvgExternalResourcesRequired, IScriptableElementTimeControl, IScriptableEventTarget
		{
			public ScriptableSvgAnimationElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgAnimationElement
			public float getStartTime()
			{
				throw new NotImplementedException(); //return ((ISvgAnimationElement)baseObject).GetStartTime();
			}

			public float getCurrentTime()
			{
				throw new NotImplementedException(); //return ((ISvgAnimationElement)baseObject).GetCurrentTime();
			}

			public float getSimpleDuration()
			{
				throw new NotImplementedException(); //return ((ISvgAnimationElement)baseObject).GetSimpleDuration();
			}
			#endregion

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableElementTimeControl
			public void beginElement()
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).BeginElement();
			}

			public void beginElementAt(float offset)
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).BeginElementAt(offset);
			}

			public void endElement()
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).EndElement();
			}

			public void endElementAt(float offset)
			{
				throw new NotImplementedException(); //((IElementTimeControl)baseObject).EndElementAt(offset);
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgAnimationElement
			public IScriptableSvgElement targetElement
			{
        get { throw new NotImplementedException(); } //object result = ((ISvgAnimationElement)baseObject).TargetElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimateElement
		/// </summary>
		public class ScriptableSvgAnimateElement : ScriptableSvgAnimationElement, IScriptableSvgAnimateElement
		{
			public ScriptableSvgAnimateElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgSetElement
		/// </summary>
		public class ScriptableSvgSetElement : ScriptableSvgAnimationElement, IScriptableSvgSetElement
		{
			public ScriptableSvgSetElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimateMotionElement
		/// </summary>
		public class ScriptableSvgAnimateMotionElement : ScriptableSvgAnimationElement, IScriptableSvgAnimateMotionElement
		{
			public ScriptableSvgAnimateMotionElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgMPathElement
		/// </summary>
		public class ScriptableSvgMPathElement : ScriptableSvgElement, IScriptableSvgMPathElement, IScriptableSvgUriReference, IScriptableSvgExternalResourcesRequired
		{
			public ScriptableSvgMPathElement(object baseObject) : base (baseObject) { }

			#region Properties - IScriptableSvgUriReference
			public IScriptableSvgAnimatedString href
			{
				get { object result = ((ISvgURIReference)baseObject).Href; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimateColorElement
		/// </summary>
		public class ScriptableSvgAnimateColorElement : ScriptableSvgAnimationElement, IScriptableSvgAnimateColorElement
		{
			public ScriptableSvgAnimateColorElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgAnimateTransformElement
		/// </summary>
		public class ScriptableSvgAnimateTransformElement : ScriptableSvgAnimationElement, IScriptableSvgAnimateTransformElement
		{
			public ScriptableSvgAnimateTransformElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFontElement
		/// </summary>
		public class ScriptableSvgFontElement : ScriptableSvgElement, IScriptableSvgFontElement, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable
		{
			public ScriptableSvgFontElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgGlyphElement
		/// </summary>
		public class ScriptableSvgGlyphElement : ScriptableSvgElement, IScriptableSvgGlyphElement, IScriptableSvgStylable
		{
			public ScriptableSvgGlyphElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgMissingGlyphElement
		/// </summary>
		public class ScriptableSvgMissingGlyphElement : ScriptableSvgElement, IScriptableSvgMissingGlyphElement, IScriptableSvgStylable
		{
			public ScriptableSvgMissingGlyphElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgHKernElement
		/// </summary>
		public class ScriptableSvgHKernElement : ScriptableSvgElement, IScriptableSvgHKernElement
		{
			public ScriptableSvgHKernElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgVKernElement
		/// </summary>
		public class ScriptableSvgVKernElement : ScriptableSvgElement, IScriptableSvgVKernElement
		{
			public ScriptableSvgVKernElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFontFaceElement
		/// </summary>
		public class ScriptableSvgFontFaceElement : ScriptableSvgElement, IScriptableSvgFontFaceElement
		{
			public ScriptableSvgFontFaceElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFontFaceSrcElement
		/// </summary>
		public class ScriptableSvgFontFaceSrcElement : ScriptableSvgElement, IScriptableSvgFontFaceSrcElement
		{
			public ScriptableSvgFontFaceSrcElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFontFaceUriElement
		/// </summary>
		public class ScriptableSvgFontFaceUriElement : ScriptableSvgElement, IScriptableSvgFontFaceUriElement
		{
			public ScriptableSvgFontFaceUriElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFontFaceFormatElement
		/// </summary>
		public class ScriptableSvgFontFaceFormatElement : ScriptableSvgElement, IScriptableSvgFontFaceFormatElement
		{
			public ScriptableSvgFontFaceFormatElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgFontFaceNameElement
		/// </summary>
		public class ScriptableSvgFontFaceNameElement : ScriptableSvgElement, IScriptableSvgFontFaceNameElement
		{
			public ScriptableSvgFontFaceNameElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgDefinitionSrcElement
		/// </summary>
		public class ScriptableSvgDefinitionSrcElement : ScriptableSvgElement, IScriptableSvgDefinitionSrcElement
		{
			public ScriptableSvgDefinitionSrcElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgMetadataElement
		/// </summary>
		public class ScriptableSvgMetadataElement : ScriptableSvgElement, IScriptableSvgMetadataElement
		{
			public ScriptableSvgMetadataElement(object baseObject) : base (baseObject) { }
		}

		/// <summary>
		/// Implementation wrapper for IScriptableSvgForeignObjectElement
		/// </summary>
		public class ScriptableSvgForeignObjectElement : ScriptableSvgElement, IScriptableSvgForeignObjectElement, IScriptableSvgTests, IScriptableSvgLangSpace, IScriptableSvgExternalResourcesRequired, IScriptableSvgStylable, IScriptableSvgTransformable, IScriptableEventTarget
		{
			public ScriptableSvgForeignObjectElement(object baseObject) : base (baseObject) { }

			#region Methods - IScriptableSvgTests
			public bool hasExtension(string extension)
			{
				return ((ISvgTests)baseObject).HasExtension(extension);
			}
			#endregion

			#region Methods - IScriptableSvgStylable
			public IScriptableCssValue getPresentationAttribute(string name)
			{
				object result = ((ISvgStylable)baseObject).GetPresentationAttribute(name);
				return (result != null) ? (IScriptableCssValue)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableSvgLocatable
			public IScriptableSvgRect getBBox()
			{
				object result = ((ISvgLocatable)baseObject).GetBBox();
				return (result != null) ? (IScriptableSvgRect)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getScreenCTM()
			{
				object result = ((ISvgLocatable)baseObject).GetScreenCTM();
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}

			public IScriptableSvgMatrix getTransformToElement(IScriptableSvgElement element)
			{
				object result = ((ISvgLocatable)baseObject).GetTransformToElement(((ISvgElement)((ScriptableSvgElement)element).baseObject));
				return (result != null) ? (IScriptableSvgMatrix)ScriptableObject.CreateWrapper(result) : null;
			}
			#endregion

			#region Methods - IScriptableEventTarget
      public void addEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).AddEventListener(type, new EventListener(mon.EventHandler), useCapture);
        } 
      }

      public void removeEventListener(string type, object listener, bool useCapture)
      {
        if (listener is Microsoft.JScript.Closure) 
        {
          ClosureEventMonitor mon = ClosureEventMonitor.CreateMonitor((Microsoft.JScript.Closure)listener);
          ((IEventTarget)baseObject).RemoveEventListener(type, new EventListener(mon.EventHandler), useCapture);
        }                 
      }

      public bool dispatchEvent(IScriptableEvent evt)
			{
				return ((IEventTarget)baseObject).DispatchEvent(((IEvent)((ScriptableEvent)evt).baseObject));
			}
			#endregion

			#region Properties - IScriptableSvgForeignObjectElement
			public IScriptableSvgAnimatedLength x
			{
				get { throw new NotImplementedException(); }//object result = ((ISvgForeignObjectElement)baseObject).X; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength y
			{
				get { throw new NotImplementedException(); }//object result = ((ISvgForeignObjectElement)baseObject).Y; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength width
			{
				get { throw new NotImplementedException(); }//object result = ((ISvgForeignObjectElement)baseObject).Width; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgAnimatedLength height
			{
				get { throw new NotImplementedException(); }//object result = ((ISvgForeignObjectElement)baseObject).Height; return (result != null) ? (IScriptableSvgAnimatedLength)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTests
			public IScriptableSvgStringList requiredFeatures
			{
				get { object result = ((ISvgTests)baseObject).RequiredFeatures; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList requiredExtensions
			{
				get { object result = ((ISvgTests)baseObject).RequiredExtensions; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgStringList systemLanguage
			{
				get { object result = ((ISvgTests)baseObject).SystemLanguage; return (result != null) ? (IScriptableSvgStringList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLangSpace
			public string xmllang
			{
				get { return ((ISvgLangSpace)baseObject).XmlLang;  }
				set { ((ISvgLangSpace)baseObject).XmlLang = value; }
			}

			public string xmlspace
			{
				get { return ((ISvgLangSpace)baseObject).XmlSpace;  }
				set { ((ISvgLangSpace)baseObject).XmlSpace = value; }
			}

			#endregion

			#region Properties - IScriptableSvgExternalResourcesRequired
			public bool externalResourcesRequired
			{
				get { return ((ISvgExternalResourcesRequired)baseObject).ExternalResourcesRequired.BaseVal;  }
			}

			#endregion

			#region Properties - IScriptableSvgStylable
			public IScriptableSvgAnimatedString className
			{
				get { object result = ((ISvgStylable)baseObject).ClassName; return (result != null) ? (IScriptableSvgAnimatedString)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableCssStyleDeclaration style
			{
				get { object result = ((ISvgStylable)baseObject).Style; return (result != null) ? (IScriptableCssStyleDeclaration)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgTransformable
			public IScriptableSvgAnimatedTransformList transform
			{
				get { object result = ((ISvgTransformable)baseObject).Transform; return (result != null) ? (IScriptableSvgAnimatedTransformList)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion

			#region Properties - IScriptableSvgLocatable
			public IScriptableSvgElement nearestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).NearestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			public IScriptableSvgElement farthestViewportElement
			{
				get { object result = ((ISvgLocatable)baseObject).FarthestViewportElement; return (result != null) ? (IScriptableSvgElement)ScriptableObject.CreateWrapper(result) : null; }
			}

			#endregion
		}

}
  
