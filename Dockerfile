FROM mcr.microsoft.com/dotnet/sdk:6.0.202 AS build
WORKDIR /app

# Copie e restaure os arquivos do projeto
COPY *.csproj .
RUN dotnet restore


RUN dotnet add package MySql.Data

# Copie todo o código e construa o projeto
COPY . .

CMD [ "dotnet", "run" ]