BINDIR		= $(top_builddir)/build/
ASSEMBLY_DLL	= SharpVectorDom.dll 
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_DLL)

FILES = \
	AssemblyInfo.cs \
	SharpVectors/Dom/Attribute.cs \
	SharpVectors/Dom/CDataSection.cs \
	SharpVectors/Dom/Comment.cs \
	SharpVectors/Dom/Conversion.cs \
	SharpVectors/Dom/Declaration.cs \
	SharpVectors/Dom/Document.cs \
	SharpVectors/Dom/DocumentFragment.cs \
	SharpVectors/Dom/DocumentType.cs \
	SharpVectors/Dom/DomImplementation.cs \
	SharpVectors/Dom/Element.cs \
	SharpVectors/Dom/EntityReference.cs \
	SharpVectors/Dom/NodeListAdapter.cs \
	SharpVectors/Dom/ProcessingInstruction.cs \
	SharpVectors/Dom/SignificantWhitespace.cs \
	SharpVectors/Dom/Text.cs \
	SharpVectors/Dom/Whitespace.cs \
	SharpVectors/Dom/Events/Event.cs \
	SharpVectors/Dom/Events/EventClasses.cs \
	SharpVectors/Dom/Events/EventListenerMap.cs \
	SharpVectors/Dom/Events/EventListenerMapEntry.cs \
	SharpVectors/Dom/Events/EventTarget.cs \
	SharpVectors/Dom/Events/EventType.cs \
	SharpVectors/Dom/Events/IEventTargetSupports.cs \
	SharpVectors/Dom/Events/KeyboardEvent.cs \
	SharpVectors/Dom/Events/MouseEvent.cs \
	SharpVectors/Dom/Events/MutationEvent.cs \
	SharpVectors/Dom/Events/MutationNameEvent.cs \
	SharpVectors/Dom/Events/TextEvent.cs \
	SharpVectors/Dom/Events/UiEvent.cs

REFERENCES = \
	-lib:$(BINDIR) \
	-r:System.Xml.dll \
	-r:SharpVectorUtil.dll \
	-r:SharpVectorBindings.dll

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ -target:library $(REFERENCES) $(FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
