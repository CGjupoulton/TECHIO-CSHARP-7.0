#!/bin/bash

echo 'TECHIO> message --channel "Progress ⌛" "Restore in progress..."'
dotnet restore > /dev/null
echo 'TECHIO> message --channel "Progress ⌛" "Restore done."'

echo 'TECHIO> message --channel "Progress ⌛" "Build started, please wait..."'
dotnet build > build.txt

if dotnet Tools/consoleParser.dll build.txt; then
	echo 'TECHIO> message --channel "Progress ⌛" "Build successful."'
	dotnet run --no-build
else
	echo 'TECHIO> message --channel "Progress ⌛" "Build failed."'
	echo "TECHIO> success false";
fi