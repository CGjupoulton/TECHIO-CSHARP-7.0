#!/bin/bash

echo 'TECHIO> message --channel "Progress ⌛" "Build started, please wait..."'
dotnet build > build.txt

if dotnet Tools/consoleParser.dll build.txt; then
	echo 'TECHIO> message --channel "Progress ⌛" "Build successful."'
	echo 'TECHIO> message --channel "Progress ⌛" "Tests started, please wait..."'
	dotnet test --no-build -l="trx;LogFileName=test.txt" -r="./" --filter="FullyQualifiedName=$@" > /dev/null
	if dotnet Tools/testParser.dll test.txt; then
		echo 'TECHIO> message --channel "Progress ⌛" "Tests successful..."'
	else
		echo 'TECHIO> message --channel "Progress ⌛" "Tests failed."'
	fi	
else
	echo 'TECHIO> message --channel "Progress ⌛" "Build failed."'
	echo "TECHIO> success false";
fi



