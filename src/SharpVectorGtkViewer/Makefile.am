BINDIR		= $(top_builddir)/build/
ASSEMBLY_NAME	= SharpVectorGtkViewer.exe
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_NAME)

FILES = \	
	GtkSharpVectorViewer.cs \
	SvgImageWidget.cs
	
	
REFERENCES = \
	-lib:$(BINDIR) \
	-r:System.Drawing.dll \
	-r:SharpVectorCss.dll \
	-r:SharpVectorUtil.dll \ 
	-r:SharpVectorBindings.dll \ 
	-r:SharpVectorDom.dll \
	-r:SharpVectorRenderingEngine.dll \
	-r:SharpVectorScripting.dll \
	-r:SharpVectorObjectModel.dll \
	$(GTK_SHARP_LIBS) \
	$(GTK_DOTNET_LIBS) \
	$(GLADE_SHARP_LIBS)

RESOURCES = \
	-resource:svg-viewer.glade \
	-resource:w3ctests.txt
	
all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ $(REFERENCES) $(RESOURCES) $(FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
