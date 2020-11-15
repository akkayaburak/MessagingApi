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

You need to add your own `connectionString` for Serilog and `MessagingServiceDatabase` for the API in `appsettings.json` file.

Then, in `MessagingService.Test` project, there is a `SqlServerUsersServiceTest.cs` file. You need to add your own connection string in that file too.

After that, run!

## Documentation

[Postman Documenter](https://documenter.getpostman.com/view/12158072/TVep97qr)

## Why Not Docker?

This project constructed in Windows 10 Home. Some privileges are not in Home, but it was OK. Docker Desktop requires a Oracle VM for running. I created a default host in Oracle VM but it doesn't run. I needed the change some security settings on my PC. I couldn't and Windows didn't exactly tell me why. Then I found a solution that requires to go to BIOS. I couldn't found the needed settings on there too. Maybe there is a solution, but It wasn't enough time.

Maybe some day!