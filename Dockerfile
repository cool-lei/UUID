FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY CodingTest/CodingTest.csproj ./CodingTest/CodingTest.csproj 
COPY CodingTest.UnitTest/CodingTest.UnitTest.csproj ./CodingTest.UnitTest/CodingTest.UnitTest.csproj
RUN dotnet restore

# copy everything else and build
COPY . ./
RUN dotnet test CodingTest.UnitTest -c Release 
RUN dotnet publish CodingTest.UnitTest -c Release -o /app/out

# build runtime image
FROM mcr.microsoft.com/dotnet/sdk:5.0 
WORKDIR /app
COPY --from=build-env /app/out ./
ENTRYPOINT ["dotnet", "test", " CodingTest.UnitTest.dll"]
