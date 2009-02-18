AC_INIT([SavageSVG], 0.1, [savagesvg@savage-project.org])
AC_PREREQ(2.53)
AC_CANONICAL_SYSTEM
AM_INIT_AUTOMAKE([1.9 tar-ustar])
AM_MAINTAINER_MODE
AC_PROG_INSTALL

dnl pkg-config
AC_PATH_PROG(PKG_CONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
	AC_MSG_ERROR([You need to install pkg-config])
fi

dnl C# compiler
AC_PATH_PROG(CSC,  csc,  no)
AC_PATH_PROG(MCS,  mcs, no)
AC_PATH_PROG(MONO, mono, no)

CS="C#"
if test "x$CSC" = "xno" -a "x$MCS" = "xno"  ; then
	dnl AC_MSG_ERROR([You need to install a C# compiler])
	AC_MSG_ERROR([No $CS compiler found])
fi

if test "x$MCS" = "xno" ; then
	MCS=$CSC
fi

if test "x$MONO" = "xno"; then
	AC_MSG_ERROR([No mono runtime found])
fi

dnl library dependencies
GTKSHARP_REQUIRED_VERSION=2.8.2
LIBGDIPLUS_REQUIRED_VERSION=1.1.13.6
MONO_CAIRO_REQUIRED_VERSION=1.1.13
NUNIT_REQUIRED_VERSION=2.2.0

PKG_CHECK_MODULES(GTK_SHARP, gtk-sharp-2.0 >= $GTKSHARP_REQUIRED_VERSION)
AC_SUBST(GTK_SHARP_LIBS)

PKG_CHECK_MODULES(GTK_DOTNET, gtk-dotnet-2.0 >= $GTKSHARP_REQUIRED_VERSION)
AC_SUBST(GTK_DOTNET_LIBS)

PKG_CHECK_MODULES(GNOME_SHARP, gnome-sharp-2.0 >= $GTKSHARP_REQUIRED_VERSION)
AC_SUBST(GNOME_SHARP_LIBS)

PKG_CHECK_MODULES(GLADE_SHARP, glade-sharp-2.0 >= $GTKSHARP_REQUIRED_VERSION)
AC_SUBST(GLADE_SHARP_LIBS)

PKG_CHECK_MODULES(MONO_CAIRO, mono-cairo >= $MONO_CAIRO_REQUIRED_VERSION)
AC_SUBST(MONO_CAIRO_LIBS)

PKG_CHECK_MODULES(LIBGDIPLUS, libgdiplus >= $LIBGDIPLUS_REQUIRED_VERSION)

PKG_CHECK_MODULES(NUNIT, nunit >= $NUNIT_REQUIRED_VERSION)
AC_SUBST(NUNIT_LIBS)

CSC_FLAGS=""

AC_SUBST(MCS)
AC_SUBST(CSC_FLAGS)

AC_OUTPUT([
Makefile
src/Makefile
src/SharpVectorBindings/Makefile
src/SharpVectorCss/Makefile
src/SharpVectorDom/Makefile
src/SharpVectorObjectModel/Makefile
src/SharpVectorRenderingEngine/Makefile
src/SharpVectorScripting/Makefile
src/SharpVectorUtil/Makefile
src/SharpVectorPerfTest/Makefile
src/SharpVectorGtkViewer/Makefile
test/Makefile
])

echo "
SavageSVG-$VERSION

    Install Prefix:    ${prefix}
    Mono C# Compiler:  ${MCS}
    Mono Runtime:      ${MONO}

"
