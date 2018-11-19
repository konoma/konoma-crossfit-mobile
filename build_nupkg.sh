#!/bin/sh

set -e

LIBRARY_NAME="Konoma.CrossFit"

rm -rf dist/
rm -rf $LIBRARY_NAME/bin/
rm -rf $LIBRARY_NAME.Droid/bin/
rm -rf $LIBRARY_NAME.iOS/bin/

msbuild $LIBRARY_NAME/$LIBRARY_NAME.csproj /property:Configuration=Release &&
msbuild $LIBRARY_NAME.Droid/$LIBRARY_NAME.Droid.csproj /property:Configuration=Release &&
msbuild $LIBRARY_NAME.iOS/$LIBRARY_NAME.iOS.csproj /property:Configuration=Release

nuget pack $LIBRARY_NAME.nuspec -OutputDirectory dist/

open dist/