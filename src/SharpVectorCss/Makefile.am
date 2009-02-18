BINDIR		= $(top_builddir)/build/
ASSEMBLY_DLL	= SharpVectorCss.dll 
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_DLL)

FILES = \
	AssemblyInfo.cs \
	SharpVectors/Dom/Css/CssAbsPrimitiveLengthValue.cs \
	SharpVectors/Dom/Css/CssAbsPrimitiveValue.cs \
	SharpVectors/Dom/Css/CssAbsValue.cs \
	SharpVectors/Dom/Css/CssCharsetRule.cs \
	SharpVectors/Dom/Css/CssCollectedProperty.cs \
	SharpVectors/Dom/Css/CssCollectedStyleDeclaration.cs \
	SharpVectors/Dom/Css/CssFontFaceRule.cs \
	SharpVectors/Dom/Css/CssImportRule.cs \
	SharpVectors/Dom/Css/CssMediaRule.cs \
	SharpVectors/Dom/Css/CssNumber.cs \
	SharpVectors/Dom/Css/CssPageRule.cs \
	SharpVectors/Dom/Css/CssPrimitiveAngleValue.cs \
	SharpVectors/Dom/Css/CssPrimitiveColorValue.cs \
	SharpVectors/Dom/Css/CssPrimitiveLengthValue.cs \
	SharpVectors/Dom/Css/CssPrimitiveRgbValue.cs \
	SharpVectors/Dom/Css/CssPrimitiveValue.cs \
	SharpVectors/Dom/Css/CssPropertyProfile.cs \
	SharpVectors/Dom/Css/CssRule.cs \
	SharpVectors/Dom/Css/CssRuleList.cs \
	SharpVectors/Dom/Css/CssStyleDeclaration.cs \
	SharpVectors/Dom/Css/CssStyleRule.cs \
	SharpVectors/Dom/Css/CssStyleSheet.cs \
	SharpVectors/Dom/Css/CssStyleSheetType.cs \
	SharpVectors/Dom/Css/CssUnknownRule.cs \
	SharpVectors/Dom/Css/CssValue.cs \
	SharpVectors/Dom/Css/CssXmlDocument.cs \
	SharpVectors/Dom/Css/CssXmlElement.cs \
	SharpVectors/Dom/Css/Rect.cs \
	SharpVectors/Dom/Css/RgbColor.cs \
	SharpVectors/Dom/Css/SharpCssStyle.cs \
	SharpVectors/Dom/Css/XPathSelector.cs \
	SharpVectors/Dom/Stylesheets/MediaList.cs \
	SharpVectors/Dom/Stylesheets/StyleSheet.cs \
	SharpVectors/Dom/Stylesheets/StyleSheetList.cs

REFERENCES= \
	-lib:$(BINDIR) \
	-r:System.Drawing \
	-r:SharpVectorUtil.dll \
	-r:SharpVectorBindings.dll \
	-r:SharpVectorDom.dll

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ -target:library $(REFERENCES) $(FILES)


CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
