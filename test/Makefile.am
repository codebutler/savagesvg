BINDIR		= $(top_builddir)/build/
ASSEMBLY_NAME	= SharpVectorsUnitTests.dll 
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_NAME)

MCS_FLAGS 	= -unsafe

FILES = \
	AssemblyInfo.cs \
	SharpVectors/Dom/Events/EventTests.cs \
	SharpVectors/Dom/StyleSheets/MediaListTests.cs \
	SharpVectors/Dom/Svg/CssPropertyProfileTests.cs \
	SharpVectors/Dom/Svg/CssSelectorsTests.cs \
	SharpVectors/Dom/Svg/SvgWindowTest.cs \
	SharpVectors/Dom/Svg/Util.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgAngleTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgElementTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgLengthListTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgLengthTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgListTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgMatrixTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgNumberListTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgNumberTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgPointListTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgPointTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgStringListTests.cs \
	SharpVectors/Dom/Svg/Basic\ types/SvgTransformListTests.cs \
	SharpVectors/Dom/Svg/Color/SvgColorTests.cs \
	SharpVectors/Dom/Svg/Document\ structure/SvgDocumentTests.cs \
	SharpVectors/Dom/Svg/Document\ structure/SvgImageElementTests.cs \
	SharpVectors/Dom/Svg/Document\ structure/SvgStyleableElementTests.cs \
	SharpVectors/Dom/Svg/Document\ structure/SvgTransformableElementTests.cs \
	SharpVectors/Dom/Svg/Document\ structure/SvgUseElementTests.cs \
	SharpVectors/Dom/Svg/Gradients\ and\ Patterns/SvgGradientElementTests.cs \
	SharpVectors/Dom/Svg/Gradients\ and\ Patterns/SvgLinearGradientElementTests.cs \
	SharpVectors/Dom/Svg/Gradients\ and\ Patterns/SvgPatternElementTests.cs \
	SharpVectors/Dom/Svg/Gradients\ and\ Patterns/SvgRadialGradientElementTests.cs \
	SharpVectors/Dom/Svg/Metadata/SvgMetadataElementTests.cs \
	SharpVectors/Dom/Svg/Paint/SvgPaintTests.cs \
	SharpVectors/Dom/Svg/Paths/SvgPathSegListTests.cs \
	SharpVectors/Net/DataWebRequestTests.cs \
	SharpVectors/Net/ExtendedHttpWebRequestTests.cs \
	SharpVectors/Renderer/Gdi/BitmapComparator.cs \
	SharpVectors/Renderer/Gdi/CompareUtil.cs \
	SharpVectors/Renderer/Gdi/GdiRendererTests.cs \
	SharpVectors/Renderer/Gdi/Dynamics/StyleChange.cs \
	SharpVectors/Renderer/Gdi/Paint/GdiSvgPaintTests.cs \
	SharpVectors/Css/CssTests.cs \
	SharpVectors/Css/InheritanceTests.cs \
	SharpVectors/Css/TestUtil.cs \
	./SharpVectorUtil/SharpVectors/Polynomials/PolynomialTests.cs \
	./SharpVectorUtil/SharpVectors/Polynomials/SqrtPolynomialTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoQuadraticAbsTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoQuadraticRelTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurveToCubicTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoQuadraticTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoQuadraticSmoothAbsTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoCubicAbsTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoQuadraticSmoothRelTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoCubicRelTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoCubicSmoothAbsTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Paths/SvgPathSegCurvetoCubicSmoothRelTests.cs \
	./SharpVectorObjectModel/SharpVectors/Dom/Svg/Document\ Structure/SvgImageElementTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssPrimitiveRgbValueTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/RgbColorTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssStyleDeclarationTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/XPathSelectorTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssTestsTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssPrimitiveLengthValueTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/InheritanceTestsTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssValueTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssXmlElementTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssPrimitiveAngleValueTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/RectTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/CssCollectedStyleDeclarationTests.cs \
	./SharpVectorCss/SharpVectors/Dom/Css/TestUtilTests.cs \
	./SharpVectorDom/SharpVectors/Dom/Events/EventTests.cs \
	./SharpVectorDom/SharpVectors/Dom/Events/MutationEventTests.cs \
	./SharpVectorDom/SharpVectors/Dom/ElementTests.cs \
	./SharpVectorRenderingEngine/SharpVectors/Renderer/Gdi/GdiRendererTests.cs

REFERENCES = \
	-lib:$(BINDIR)				\
	-r:System.Drawing.dll			\
	-r:SharpVectorObjectModel.dll		\
	-r:SharpVectorCss.dll			\
	-r:SharpVectorBindings.dll 		\
	-r:SharpVectorDom.dll 			\
	-r:SharpVectorRenderingEngine.dll	\
	-r:SharpVectorScripting.dll 		\
	-r:SharpVectorUtil.dll 			\
	$(NUNIT_LIBS)

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) $(MCS_FLAGS) -debug -out:$@ -target:library $(REFERENCES) $(FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
