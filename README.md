# 基礎範本

```sh
dotnet ef migrations add Init --context DatabaseContext
```

```sh
dotnet tool install -g dotnet-aspnet-codegenerator

dotnet aspnet-codegenerator controller -name HomeController -outDir Controllers
dotnet aspnet-codegenerator view Index Empty -outDir Views/Home
```
