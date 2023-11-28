# Use the official .NET 8 SDK image as a base image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the solution file and restore dependencies
COPY ["InfiniteDays.sln", "."]
COPY ["src/ui/ui.csproj", "src/ui/"]
COPY ["src/app/app.csproj", "src/app/"]
COPY ["src/models/models.csproj", "src/models/"]
COPY ["src/lib/lib.csproj", "src/lib/"]

RUN dotnet restore "src/ui/ui.csproj"
RUN dotnet restore "src/app/app.csproj"
RUN dotnet restore "src/lib/lib.csproj"
RUN dotnet restore "src/models/models.csproj"

# Copy the application files to the container
COPY . .

# Build the application
RUN dotnet publish -c Release -o out

# Use a lighter-weight runtime image for the final image
FROM mcr.microsoft.com/dotnet/runtime:8.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the build image to the runtime image
COPY --from=build /app/out .

# Specify the entry point for the application
ENTRYPOINT ["dotnet", "ui.dll"]
