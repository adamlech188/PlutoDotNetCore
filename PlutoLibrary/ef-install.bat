REM Adding Package Entity Framework for MSSQL
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version=3.1.3
dotnet add package Microsoft.Extensions.Configuration.Json --version=3.1.3
dotnet add package Microsoft.EntityFrameworkCore.Design --version=3.1.3
dotnet ef migrations add CreatePlutoFirstDb
dotnet ef database update -v