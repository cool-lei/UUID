#!/bin/bash
set -eu -o pipefail

dotnet restore code/CodingTest/CodingTest.csproj
dotnet restore code/CodingTest.UnitTest/CodingTest.UnitTest.csproj
dotnet test code/CodingTest.UnitTest/CodingTest.UnitTest.csproj