
# Use the official Microsoft .NET SDK image as a base image for building
FROM mcr.microsoft.com/dotnet/sdk:9.0 

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY Charcillaries.Core/Charcillaries.Core.csproj  ./Charcillaries.Core/
COPY Charcillaries.Web/Charcillaries.Web.csproj  ./Charcillaries.Web/

RUN cd Charcillaries.Core && dotnet restore
RUN cd Charcillaries.Web  && dotnet restore

# Copy the rest of the source code
COPY . ./

# Build the application
RUN cd Charcillaries.Web && dotnet publish -c Release -o out


# Build the runtime image
WORKDIR Charcillaries.Web/out


ENV ASPNETCORE_URLS="http://+:80"
ENV ASPNETCORE_ENVIRONMENT=deployment_dev


# Set the entry point for the application
ENTRYPOINT ["dotnet", "Charcillaries.Web.dll"]
