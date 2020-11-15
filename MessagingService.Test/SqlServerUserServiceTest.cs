using MessagingApi.Entities;
using MessagingApi.Helpers;
using MessagingApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MessagingService.Test
{
    public class SqlServerUserServiceTest : UsersControllerTest
    {
        public SqlServerUserServiceTest() : base(
            new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer("Data Source=DESKTOP-PSJOJTP\\SQLEXPRESS;Database=MessagingServiceTest;Trusted_Connection=True;")
            .Options)
        {

        }

        [Fact]
        public void FindByUserName_ShouldThrowException_WhenUsernameIsEmpty()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new UserService(context);
                Assert.Throws<AppException>(() => service.FindByUserName("sahineda"));

            }
        }

        [Fact]
        public void Can_Get_Users()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new UserService(context);

                var users = service.GetAll();

                //Assert.Equal(3, users.ToArray().Length);
                Assert.Equal("furkangurel", users.First().Username);

            }
        }
        [Fact] public void Can_GetUserById()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new UserService(context);

                var user = service.GetById(2);

                Assert.Equal(2, user.Id);
                Assert.Equal("akkayaberat", user.Username);
                Assert.Equal("Berat", user.FirstName);
                Assert.Equal("Akkaya", user.LastName);

            }
        }
        [Fact]
        public void Can_Add_User()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new UserService(context);
                User user = new User
                {
                    Username = "akkayaberat"
                };
                Assert.Throws<AppException>( () => service.Create(user, ""));
                Assert.Throws<AppException>(() => service.Create(user, "dgdg43"));
            }
        }
        [Fact]
        public void Can_Authenticate()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new UserService(context);
                var user = service.GetById(1);
                Assert.Null(service.Authenticate("", "dffd"));
                Assert.Null(service.Authenticate("sdfds", ""));
                Assert.Null(service.Authenticate(user.Username, "dssdg"));
            }
        }

    }
}
