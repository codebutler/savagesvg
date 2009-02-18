BINDIR		= $(top_builddir)/build/
ASSEMBLY_NAME	= SharpVectorPerfTest.exe
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_NAME)

FILES = \
	PerfTest.cs
	
REFERENCES = \
	-lib:$(BINDIR) \
	-r:SharpVectorCss.dll \
	-r:SharpVectorUtil.dll \ 
	-r:SharpVectorBindings.dll \ 
	-r:SharpVectorDom.dll \
	-r:SharpVectorRenderingEngine.dll \
	-r:SharpVectorObjectModel.dll \
	-r:System.Drawing.dll

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ $(REFERENCES) $(FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
