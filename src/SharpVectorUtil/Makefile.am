BINDIR		= $(top_builddir)/build/
ASSEMBLY_DLL	= SharpVectorUtil.dll 
ASSEMBLY	= $(BINDIR)/$(ASSEMBLY_DLL)

FILES = \
	AssemblyInfo.cs \
	SharpVectors/ApplicationContext.cs \
	SharpVectors/Collections/TypeDictionary.cs \
	SharpVectors/Dom/DomException.cs \
	SharpVectors/Dom/DomExceptionType.cs \
	SharpVectors/Net/CacheInfo.cs \
	SharpVectors/Net/DataWebRequest.cs \
	SharpVectors/Net/DataWebResponse.cs \
	SharpVectors/Net/ExtendedHttpWebRequest.cs \
	SharpVectors/Net/ExtendedHttpWebResponse.cs \
	SharpVectors/Net/ICacheManager.cs \
	SharpVectors/Net/NoCacheManager.cs \
	SharpVectors/Net/WinAppCacheManager.cs \
	SharpVectors/Polynomials/Polynomial.cs \
	SharpVectors/Polynomials/SqrtPolynomial.cs \
	SharpVectors/Text/StringUtil.cs \
	SharpVectors/Xml/LocalDtdXmlUrlResolver.cs

REFERENCES = \
	-lib:$(top_builddir)/build \
	-r:ICSharpCode.SharpZipLib \
	-r:System.Web
	
all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(BINDIR)
	$(MCS) -debug -out:$@ -target:library $(REFERENCES) $(FILES)


CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
