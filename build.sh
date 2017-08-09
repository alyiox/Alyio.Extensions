#!/usr/bin/env bash

# exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactFolder
fi

dotnet restore

PROJECT_NAME="Alyio.Extensions"
TEST_PROJECT_NAME="Alyio.Extensions.Tests"

dotnet test ./test/$TEST_PROJECT_NAME -c Release -f netcoreapp1.1

# dotnet build ./test/$TEST_PROJECT_NAME -c Release -f net451

# mono \  
# ./test/$TEST_PROJECT_NAME/bin/Release/net451/*/dotnet-test-xunit.exe \
# ./test/$TEST_PROJECT_NAME/bin/Release/net451/*/$TEST_PROJECT_NAME.dll

revision=${TRAVIS_JOB_ID:=1}  
revision=$(printf "%04d" $revision) 

# dotnet pack ./src/$PROJECT_NAME -c Release -o ./$artifactsFolder --version-suffix=$revision 
