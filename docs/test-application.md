# Running the Application

This document provides instructions on how to test the Infinite Days Challenge app locally and using Docker Compose.

## Prerequisites

Before running the application, ensure you have the following prerequisites installed:

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) for building and running the .NET 8 application.
- [Docker](https://www.docker.com/get-started) for running the application in a Docker container.

## Testing Locally

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/dotnetcameroon/Infinite-Days.git
   cd Infinite-Days
   ```

2. **Build and Run the Application:**
    ```bash
    dotnet test
    ```

## Running with Docker Compose

1. **Clone the Repository:**
   ```bash
   git clone https://github.com/dotnetcameroon/Infinite-Days.git
   cd Infinite-Days
   ```

2. **Run the Application with Docker Compose:**
    ```bash
    docker-compose -f docker-compose.test.yml up
    ```
