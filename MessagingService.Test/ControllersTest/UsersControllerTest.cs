using AutoMapper;
using MessagingApi.Controllers;
using MessagingApi.Helpers;
using MessagingApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MessagingService.Test.ControllersTest
{
    public class UsersControllerTest : SqlServerServicesTest
    {
        public Mock<IUserService> userServiceMock = new Mock<IUserService>();
        public Mock<IBlockService> blockServiceMock = new Mock<IBlockService>();
        public Mock<IMapper> mapperMock = new Mock<IMapper>();
        public Mock<IOptions<AppSettings>> appSettings;
        public Mock<ILogger<UsersController>> loggerMock = new Mock<ILogger<UsersController>>();
        public Mock<ITokenService> tokenMock = new Mock<ITokenService>();
        public UsersControllerTest() : base(
            new DbContextOptionsBuilder<DataContext>()
         .UseSqlServer("Data Source=(localdb);Database=MessagingServiceTest;Trusted_Connection=True;")
         .Options)
        {
        }

        [Fact]
        public void Can_Authenticate()
        {
            //var controller = new UsersController(userServiceMock.Object, mapperMock.Object, appSettings.Object, loggerMock.Object, tokenMock.Object, blockServiceMock.Object);

            
        }
    }
}
