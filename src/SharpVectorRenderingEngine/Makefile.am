BINDIR		= $(top_builddir)/build/
ASSEMBLY_DLL	= SharpVectorRenderingEngine.dll 
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_DLL)

FILES = \
	AssemblyInfo.cs \
	SharpVectors/Renderer/Gdi/GdiRenderer.cs \
	SharpVectors/Renderer/Gdi/GraphicsNode.cs \
	SharpVectors/Renderer/Gdi/GraphicsPathGraphicsNode.cs \
	SharpVectors/Renderer/Gdi/GraphicsWrapper.cs \
	SharpVectors/Renderer/Gdi/SvgElementGraphicsNode.cs \
	SharpVectors/Renderer/Gdi/SvgImageElementGraphicsNode.cs \
	SharpVectors/Renderer/Gdi/SvgMarkerGraphicsNode.cs \
	SharpVectors/Renderer/Gdi/Paint/GdiSvgColor.cs \
	SharpVectors/Renderer/Gdi/Paint/GdiSvgPaint.cs \
	SharpVectors/Renderer/Gdi/Paint/GradientPaintServer.cs \
	SharpVectors/Renderer/Gdi/Paint/PaintServer.cs \
	SharpVectors/Renderer/Gdi/Paint/PatternPaintServer.cs

REFERENCES = \
	-lib:$(BINDIR) \
	-r:System.Drawing.dll \
	-r:System.Drawing.Design.dll \
	-r:SharpVectorCss.dll \
	-r:SharpVectorObjectModel.dll \
	-r:SharpVectorUtil.dll \
	-r:SharpVectorBindings.dll \
	-r:SharpVectorDom.dll

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ -target:library $(REFERENCES) $(FILES)


CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
