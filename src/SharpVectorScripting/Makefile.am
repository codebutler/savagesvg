BINDIR		= $(top_builddir)/build/
ASSEMBLY_DLL	= SharpVectorScripting.dll 
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_DLL)

FILES = \
	AssemblyInfo.cs \
	SharpVectors/Scripting/ClosureEventMonitor.cs \
	SharpVectors/Scripting/JScriptEngine.cs \
	SharpVectors/Scripting/ScriptEngine.cs \
	SharpVectors/Scripting/ScriptEventMonitor.cs \
	SharpVectors/Scripting/ScriptTimerMonitor.cs \
	SharpVectors/Scripting/VsaScriptEngine.cs \
	SharpVectors/Scripting/Wrapping/Css.cs \
	SharpVectors/Scripting/Wrapping/CssWrapper.cs \
	SharpVectors/Scripting/Wrapping/Dom.cs \
	SharpVectors/Scripting/Wrapping/DomWrapper.cs \
	SharpVectors/Scripting/Wrapping/Events.cs \
	SharpVectors/Scripting/Wrapping/EventsWrapper.cs \
	SharpVectors/Scripting/Wrapping/ScriptWrapper.cs \
	SharpVectors/Scripting/Wrapping/Smil.cs \
	SharpVectors/Scripting/Wrapping/SmilWrapper.cs \
	SharpVectors/Scripting/Wrapping/StyleSheets.cs \
	SharpVectors/Scripting/Wrapping/StyleSheetsWrapper.cs \
	SharpVectors/Scripting/Wrapping/Svg.cs \
	SharpVectors/Scripting/Wrapping/SvgWrapper.cs \
	SharpVectors/Scripting/Wrapping/Views.cs \
	SharpVectors/Scripting/Wrapping/ViewsWrapper.cs \
	SharpVectors/Scripting/Wrapping/Window.cs \
	SharpVectors/Scripting/Wrapping/WindowWrapper.cs

REFERENCES = \
	-lib:$(BINDIR) \
	-r:Microsoft.JScript.dll \
	-r:Microsoft.Vsa.dll \
	-r:SharpVectorBindings.dll \
	-r:SharpVectorUtil.dll \
	-r:SharpVectorCss.dll \
	-r:SharpVectorDom.dll \
	-r:SharpVectorObjectModel.dll
	
all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ -target:library $(REFERENCES) $(FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
