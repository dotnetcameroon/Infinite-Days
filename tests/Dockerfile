# Use the official .NET 8 SDK image as a base image for building
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the test project files to the container
COPY ["InfiniteDays.sln", "."]
COPY ["src/ui/ui.csproj", "src/ui/"]
COPY ["src/app/app.csproj", "src/app/"]
COPY ["src/models/models.csproj", "src/models/"]
COPY ["src/lib/lib.csproj", "src/lib/"]
COPY ["tests/ApplicationTests/ApplicationTests.csproj", "tests/ApplicationTests/"]
COPY ["tests/InfrastructureTests/InfrastructureTests.csproj", "tests/InfrastructureTests/"]

RUN dotnet restore "src/ui/ui.csproj"
RUN dotnet restore "src/app/app.csproj"
RUN dotnet restore "src/lib/lib.csproj"
RUN dotnet restore "src/models/models.csproj"
RUN dotnet restore "tests/ApplicationTests/ApplicationTests.csproj"
RUN dotnet restore "tests/ApplicationTests/InfrastructureTests.csproj"

# Restore dependencies
RUN dotnet restore

# Copy the test project files and build the test project
COPY . .
RUN dotnet build

# Use a lighter-weight runtime image for running the tests
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS testrunner

# Set the working directory inside the container
WORKDIR /app

# Copy the published test project output from the build image to the testrunner image
COPY --from=build /app/bin/Debug/netcoreapp3.1 ./

# Run the tests
CMD ["dotnet", "test", "--logger:trx"]
