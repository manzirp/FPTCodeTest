FROM microsoft/dotnet:2.1-sdk as build

ARG BUILDCONFIG=RELEASE
ARG VERSION=1.0.0

COPY FPTCodeTest.Services.csproj /build/

RUN dotnet restore ./build/FPTCodeTest.Services.csproj

COPY . ./build/
WORKDIR /build/
RUN dotnet publish ./FPTCodeTest.Services.csproj -c $BUILDCONFIG -o out /p:Version=$VERSION

FROM microsoft/dotnet:2.1-aspnetcore-runtime
WORKDIR /app

COPY --from=build /build/out .

ENTRYPOINT ["dotnet", "FPTCodeTest.Services.dll"]