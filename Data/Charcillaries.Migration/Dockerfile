FROM mcr.microsoft.com/dotnet/sdk:9.0 

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY Charcillaries.Migration.csproj  ./

RUN dotnet restore

# Copy the rest of the source code
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Build the runtime image
WORKDIR out

ENTRYPOINT ["dotnet", "Charcillaries.Migration.dll", "--env", "deployment_dev", "--up"]
