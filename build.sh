#!/usr/bin/env sh

# dotnet publish -r linux-arm64 -p:NativeLib=Static -c Release -o ./publish
dotnet publish src/Native --use-current-runtime -c Release
dotnet pack src/Library -c Release -o ./packages
dotnet nuget locals -c global-packages
dotnet build src/Console
