#!/usr/bin/env sh

# dotnet publish -r linux-arm64 -p:NativeLib=Static -c Release -o ./publish
dotnet publish src/Native -p:NativeLib=Shared --self-contained -c Release -o ./publish
dotnet publish src/Console -c Release -o ./publish
