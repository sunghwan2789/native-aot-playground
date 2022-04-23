#!/usr/bin/env sh

# dotnet publish -r linux-arm64 -p:NativeLib=Static -c Release -o ./publish
dotnet publish src/Native -p:PublishProfile=NativeProfile --self-contained -c Release
dotnet pack src/Library -c Release -o ./packages
dotnet publish src/Console --self-contained -c Release -o ./publish
