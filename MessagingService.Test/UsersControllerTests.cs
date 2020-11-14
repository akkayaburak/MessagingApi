using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using AutoFixture.AutoMoq;
using MessagingApi.Entities;
using MessagingApi.Helpers;
using MessagingApi.Services;
using Moq;
using MessagingApi.Controllers;
using Microsoft.EntityFrameworkCore;

namespace MessagingService.Test
{
    public class UsersControllerTests
    {
        protected DbContextOptions<DataContext> ContextOptions { get; }
        public UsersControllerTests(DbContextOptions<DataContext> contextOptions)
        {
            ContextOptions = contextOptions;
        }

        [Fact]
        public void FindByUserName_Should_Throw_Exception_When_Password_Is_Empty()
        {
            
        }

        private void Seed()
        {
        }
    }
}
