FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY SimulasiCICD/bin/Release/net5.0/publish /app
ENTRYPOINT ["dotnet", "SimulasiCICD.dll", "--environment=Development"]

#docker build -t [nama image] .
#docker run -it --rm -p 5000:80 --name [nama container] [nama image]
