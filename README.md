# Messaging Service
A messaging backend service with login, authenticate and messaging between users.

## Technologies
- [ASP.NET Core 3.1](https://docs.microsoft.com/aspnet/core/introduction-to-aspnet-core?view=aspnetcore-3.1) Web API

- [Entity Framework Core](https://docs.microsoft.com/ef/core/)

- [AutoMapper](https://automapper.org/)

- [JwtBearer](https://jwt.io/introduction/)

- [Serilog](https://serilog.net/)

- [Xunit](https://xunit.net/)

## Usage

Solution has two projects. One for API and one for Test.

You need to change `connectionString` for Serilog and `MessagingServiceDatabase` for the API in `appsettings.json` file.

Then, in `MessagingService.Test` project, there is a `SqlServerUsersServiceTest.cs` file. You need to change the connection string in that file too.

After that, run!

## Documentation