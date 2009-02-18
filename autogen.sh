
# checking for automake 1.9+
am_version=`automake --version | cut -f 4 -d ' ' | head -n 1`
if [ `expr match "$am_version" '1\.9'` -ne 3 ]; then
	echo "**Error**: automake 1.9+ required.";
	exit 1;
fi

# checking for aclocal 1.9+
al_version=`aclocal --version | cut -f 4 -d ' ' | head -n 1`
if [ `expr match "$al_version" '1\.9'` -ne 3 ]; then
	echo "**Error**: aclocal 1.9+ required.";
	exit 1;
fi

echo "Running aclocal $ACLOCAL_FLAGS ..."
aclocal $ACLOCAL_GLAGS || {
  echo
  echo "**Error**: aclocal failed. This may mean that you have not"
  echo "installed all of the packages you need, or you may need to"
  echo "set ACLOCAL_FLAGS to include \"-I \$prefix/share/aclocal\""
  echo "for the prefix where you installed the packages whose"
  echo "macros were not found"
  exit 1
}

echo "Running automake --gnu $am_opt ..."
automake --add-missing --gnu $am_opt ||
	{ echo "**Error**: automake failed."; exit 1; }

echo "running autoconf ..."
WANT_AUTOCONF=2.5 autoconf || {
  echo "**Error**: autoconf failed."; exit 1; }

conf_flags="--enable-maintainer-mode --enable-compile-warnings"

if test x$NOCONFIGURE = x; then
  echo Running $srcdir/configure $conf_flags "$@" ...
  ./configure $conf_flags "$@" \
  && echo Now type \`make\' to compile $PKG_NAME || exit 1
else
  echo Skipping configure process.
fi
