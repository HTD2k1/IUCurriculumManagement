#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CurriculumService/CurriculumService.csproj", "CurriculumService/"]
RUN dotnet restore "CurriculumService/CurriculumService.csproj"
COPY . .
WORKDIR "/src/CurriculumService"
RUN dotnet build "CurriculumService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CurriculumService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CurriculumService.dll"]

FROM rabbitmq:3.11.11-management
# Enable RabbitMQ plugins
RUN rabbitmq-plugins enable --offline rabbitmq_management rabbitmq_management_agent rabbitmq_federation_management

# Create queues
RUN rabbitmqadmin declare queue name=curriculum-created durable=true
RUN rabbitmqadmin declare queue name=curriculum-accepted durable=true
RUN rabbitmqadmin declare queue name=curriculum-declined durable=true