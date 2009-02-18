using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;
using System.Xml;



namespace SharpVectors.Dom.Svg
{
	public enum SvgLengthAdjust
	{
		Unknown   = 0,
		Spacing     = 1,
		SpacingAndGlyphs     = 2
	}


	/// <summary>
	/// Summary description for SvgTextContentElement.
	/// </summary>
	public class SvgTextContentElement : SvgTransformableElement, ISharpGDIPath, ISvgTextContentElement, IGraphicsElement
	{
		internal SvgTextContentElement(string prefix, string localname, string ns, SvgDocument doc) : base(prefix, localname, ns, doc) 
		{
			svgExternalResourcesRequired = new SvgExternalResourcesRequired(this);
			svgTests = new SvgTests(this);
		}

		#region Implementation of ISvgExternalResourcesRequired
		private SvgExternalResourcesRequired svgExternalResourcesRequired;
		public ISvgAnimatedBoolean ExternalResourcesRequired
		{
			get
			{
				return svgExternalResourcesRequired.ExternalResourcesRequired;
			}
		}
		#endregion

		#region Implementation of ISvgTests
		private SvgTests svgTests;
		public ISvgStringList RequiredFeatures
		{
			get { return svgTests.RequiredFeatures; }
		}

		public ISvgStringList RequiredExtensions
		{
			get { return svgTests.RequiredExtensions; }
		}

		public ISvgStringList SystemLanguage
		{
			get { return svgTests.SystemLanguage; }
		}

		public bool HasExtension(string extension)
		{
			return svgTests.HasExtension(extension);
		}
        #endregion

		public ISvgAnimatedLength TextLength
		{
			get{throw new NotImplementedException();}
		}
		public ISvgAnimatedEnumeration LengthAdjust
		{
			get{throw new NotImplementedException();}
		}

		protected string TrimText(string val)
		{
			Regex tabNewline = new Regex(@"[\n\f\t]");
			if(this.XmlSpace != "preserve") val = val.Replace("\n", String.Empty);
			val = tabNewline.Replace(val, " ");

			if(this.XmlSpace == "preserve") return val;
			else return val.Trim();
		}

		public virtual string GetText(XmlNode child)
		{
			return this.TrimText(child.Value);
		}

		protected SvgTextElement OwnerTextElement
		{
			get
			{
				XmlNode node = (XmlNode) this;
				while(node != null)
				{
					if(node is SvgTextElement) return (SvgTextElement) node;
					node = node.ParentNode;
				}
				return null;
			}
		}

		public void Invalidate()
		{
      CssInvalidate();
			gp = null;
      renderingNode = null;
		}

    #region Update handling		
    public override void HandleAttributeChange(XmlAttribute attribute)
    {
      if(attribute.NamespaceURI.Length == 0)
      {
        // This list may be too long to be useful...
        switch(attribute.LocalName)
        {
          // Additional attributes
          case "x":
          case "y":
          case "dx":
          case "dy":
          case "rotate":
          case "textLength":
          case "lengthAdjust":
            // Text.attrib
          case "writing-mode": 
            // TextContent.attrib
          case "alignment-baseline": 
          case "baseline-shift": 
          case "direction": 
          case "dominant-baseline": 
          case "glyph-orientation-horizontal": 
          case "glyph-orientation-vertical": 
          case "kerning": 
          case "letter-spacing": 
          case "text-anchor": 
          case "text-decoration": 
          case "unicode-bidi": 
          case "word-spacing":
            // Font.attrib
          case "font-family": 
          case "font-size": 
          case "font-size-adjust": 
          case "font-stretch": 
          case "font-style": 
          case "font-variant": 
          case "font-weight":
          // textPath
          case "startOffset":
          case "method":
          case "spacing":
            // Color.attrib, Paint.attrib 
          case "color":
          case "fill":
          case "fill-rule":
          case "stroke": 
          case "stroke-dasharray": 
          case "stroke-dashoffset": 
          case "stroke-linecap": 
          case "stroke-linejoin": 
          case "stroke-miterlimit": 
          case "stroke-width": 
            // Opacity.attrib
          case "opacity": 
          case "stroke-opacity": 
          case "fill-opacity": 
            // Graphics.attrib
          case "display": 
          case "image-rendering": 
          case "shape-rendering": 
          case "text-rendering": 
          case "visibility":
            Invalidate();
            return;
          case "transform":
            Invalidate();
            break;
        }
      
        base.HandleAttributeChange(attribute);
      } 
      else if (attribute.Name == "xml:preserve" || attribute.Name == "xlink:href")
      {
        // xml:preserve and xlink:href changes may affect the actual text content
        Invalidate();
      }
    }

    public override void ElementChange(Object src, XmlNodeChangedEventArgs args)
    {
      Invalidate();

      base.ElementChange(src, args);
    }
    #endregion

		protected GraphicsPath gp = null;
		public virtual GraphicsPath GetGraphicsPath()
		{
			if(gp == null)
			{
				this.OwnerTextElement.GetGraphicsPath();
			}

			return gp;
		}

		protected void AddGraphicsPath(ref PointF ctp, string text)
		{
      if(text.Length == 0)
        return;
      
      float emSize = _getComputedFontSize();
			FontFamily family = _getGDIFontFamily(emSize);
			int style = _getGDIStyle();
			StringFormat sf = _getGDIStringFormat();

			GraphicsPath gp2 = new GraphicsPath();
			gp2.StartFigure();

			float xCorrection = 0;
			if(sf.Alignment == StringAlignment.Near) xCorrection = emSize * 1 /6;
			else if(sf.Alignment == StringAlignment.Far) xCorrection = -emSize * 1 /6;
			
			float yCorrection = (float)(family.GetCellAscent(FontStyle.Regular)) / (float)(family.GetEmHeight(FontStyle.Regular)) * emSize;

			// TODO: font property

			PointF p = new PointF(ctp.X-xCorrection, ctp.Y - yCorrection);

			gp2.AddString(text, family, style, emSize, p, sf);
			if(!gp2.GetBounds().IsEmpty)
			{
				float bboxWidth = gp2.GetBounds().Width;
				if(sf.Alignment == StringAlignment.Center) bboxWidth /= 2;
				else if(sf.Alignment == StringAlignment.Far) bboxWidth = 0;

				ctp.X += bboxWidth + emSize/4;
			}

			gp.AddPath(gp2, false);
			gp2.Dispose();
		}

		protected virtual void GetGraphicsPath(ref PointF ctp)
		{
			gp = new GraphicsPath();

			if(this is SvgTextPositioningElement)
			{
				SvgTextPositioningElement tpElm = (SvgTextPositioningElement) this;
				ctp = this.GetCurrentTextPosition(tpElm, ctp);
			}
			string sBaselineShift = GetPropertyValue("baseline-shift").Trim();
			double shiftBy = 0;

			if(sBaselineShift.Length > 0)
			{
				SvgTextElement textElement = this as SvgTextElement;
				if(textElement == null)
				{
					textElement = (SvgTextElement)this.SelectSingleNode("ancestor::svg:text", this.OwnerDocument.NamespaceManager);
				}

				float textFontSize = textElement._getComputedFontSize();
				if(sBaselineShift.EndsWith("%"))
				{
					shiftBy = SvgNumber.ParseToFloat(sBaselineShift.Substring(0, sBaselineShift.Length-1)) / 100 * textFontSize;
				}
				else if(sBaselineShift == "sub")
				{
					shiftBy = -0.6F * textFontSize;
				}
				else if(sBaselineShift == "super")
				{
					shiftBy = 0.6F * textFontSize;
				}
				else if(sBaselineShift == "baseline")
				{
					shiftBy = 0;
				}
				else
				{
					shiftBy = SvgNumber.ParseToFloat(sBaselineShift);
				}
            }
			

			foreach(XmlNode child in this.ChildNodes)
			{
				gp.StartFigure();
				if(child.NodeType == XmlNodeType.Text)
				{
					ctp.Y -= (float)shiftBy;
					this.AddGraphicsPath(ref ctp, GetText(child));
					ctp.Y += (float)shiftBy;
				}
				else if(child is SvgTRefElement)
				{
					SvgTRefElement trChild = (SvgTRefElement) child;
					trChild.GetGraphicsPath(ref ctp);
				}
				else if(child is SvgTextContentElement)
				{
					SvgTextContentElement tcChild = (SvgTextContentElement) child;
					tcChild.GetGraphicsPath(ref ctp);
				}
			}
		}

		protected PointF GetCurrentTextPosition(SvgTextPositioningElement posElement, PointF p)
		{
			if(posElement.X.AnimVal.NumberOfItems>0)
			{
				p.X = (float)posElement.X.AnimVal.GetItem(0).Value;
			}
			if(posElement.Y.AnimVal.NumberOfItems>0)
			{
				p.Y = (float)posElement.Y.AnimVal.GetItem(0).Value;
			}
			if(posElement.Dx.AnimVal.NumberOfItems>0)
			{
				p.X += (float)posElement.Dx.AnimVal.GetItem(0).Value;
			}
			if(posElement.Dy.AnimVal.NumberOfItems>0)
			{
				p.Y += (float)posElement.Dy.AnimVal.GetItem(0).Value;
			}
			return p;
		}

		private int _getGDIStyle()
		{
			int style = (int)FontStyle.Regular;
			string fontWeight = GetPropertyValue("font-weight");
			if(fontWeight == "bold" || fontWeight == "bolder" || fontWeight == "600" || fontWeight == "700" || fontWeight == "800" || fontWeight == "900")
			{
				style = style | (int)FontStyle.Bold;
			}

			if(GetPropertyValue("font-style")=="italic")
			{
				style = style | (int)FontStyle.Italic;
			}

            string textDeco = GetPropertyValue("text-decoration");
			if(textDeco=="line-through")
			{
				style = style | (int)FontStyle.Strikeout;
			}
			else if(textDeco=="underline")
			{
				style = style | (int)FontStyle.Underline;
			}
			return style;
		}

		private FontFamily _getGDIFontFamily(float fontSize)
		{
			string fontFamily = GetPropertyValue("font-family");
			string[] fontNames = fontNames = fontFamily.Split(new char[1]{','});

			FontFamily family;

			foreach(string fn in fontNames)
			{
				try
				{
					string fontName = fn.Trim(new char[]{' ', '\'', '"'});

					if(fontName == "serif") family = FontFamily.GenericSerif;
					else if(fontName == "sans-serif") family = FontFamily.GenericSansSerif;
					else if(fontName == "monospace") family = FontFamily.GenericMonospace;
					else family = new FontFamily(fontName);		// Font(,fontSize).FontFamily;	
					
					return family;
				}
				catch
				{
				}
			}

			// no known font-family was found => default to arial
			return new FontFamily("Arial");
		}

		private StringFormat _getGDIStringFormat()
		{
			StringFormat sf = new StringFormat();
			
			bool doAlign = true;
			if(this is SvgTSpanElement || this is SvgTRefElement)
			{
				SvgTextPositioningElement posElement = (SvgTextPositioningElement) this;
				if(posElement.X.AnimVal.NumberOfItems == 0) doAlign = false;
			}

			if(doAlign)
			{
				string anchor = GetPropertyValue("text-anchor");
				if(anchor == "middle") sf.Alignment = StringAlignment.Center;
				if(anchor == "end") sf.Alignment = StringAlignment.Far;
			}

			string dir = GetPropertyValue("direction");
			if(dir == "rtl")
			{
				if(sf.Alignment == StringAlignment.Far)sf.Alignment = StringAlignment.Near;
				else if(sf.Alignment == StringAlignment.Near)sf.Alignment = StringAlignment.Far;
				sf.FormatFlags = StringFormatFlags.DirectionRightToLeft;
			}

			dir = GetPropertyValue("writing-mode");
			if(dir == "tb")
			{
				sf.FormatFlags = sf.FormatFlags | StringFormatFlags.DirectionVertical;
			}

			sf.FormatFlags = sf.FormatFlags | StringFormatFlags.MeasureTrailingSpaces;


			return sf;
		}

		private float _getComputedFontSize()
		{
			string str = GetPropertyValue("font-size");
			float fontSize = 12;
			if(str.EndsWith("%"))
			{
				// percentage of inherited value
			}
			else if(new Regex(@"^\d").IsMatch(str))
			{
				// svg length
				fontSize = (float)new SvgLength(this, "font-size", SvgLengthDirection.Viewport, str, "10px").Value;
			}
			else if(str == "larger")
			{
			}
			else if(str == "smaller")
			{

			}
			else
			{
				// check for absolute value
			}

			return fontSize;
		}


		public long GetNumberOfChars (  )
		{
			return this.InnerText.Length;
		}

		public float GetComputedTextLength ()
		{
			throw new NotImplementedException();
		}

		public float GetSubStringLength (long charnum, long nchars )
		{
			throw new NotImplementedException();
			//raises( DOMException );
		}

		public ISvgPoint GetStartPositionOfChar (long charnum )
		{
			throw new NotImplementedException();
			//raises( DOMException );
		}

		public ISvgPoint GetEndPositionOfChar (long charnum )
		{
			throw new NotImplementedException();
			//raises( DOMException );
		}

		public ISvgRect GetExtentOfChar (long charnum )
		{
			throw new NotImplementedException();
			//raises( DOMException );
		}
		public float GetRotationOfChar (long charnum )
		{
			throw new NotImplementedException();
			//raises( DOMException );
		}
		public long GetCharNumAtPosition (ISvgPoint point )
		{
			throw new NotImplementedException();
		}
		public void SelectSubString (long charnum, long nchars )
		{
			throw new NotImplementedException();
			//raises( DOMException );
		}
	}
}
