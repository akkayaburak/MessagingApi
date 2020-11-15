using MessagingApi.Entities;
using MessagingApi.Helpers;
using MessagingApi.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MessagingService.Test
{
    public class SqlServerBlockServiceTest : SqlServerServicesTest
    {
        public SqlServerBlockServiceTest() : base(
        new DbContextOptionsBuilder<DataContext>()
        .UseSqlServer("Data Source=DESKTOP-PSJOJTP\\SQLEXPRESS;Database=MessagingServiceTest;Trusted_Connection=True;")
        .Options)
        {
        }

        [Fact]
        public void Can_Block()
        {
            //safe
        }

        [Fact]
        public void Can_IsBlocked()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new BlockService(context);
                var block = new Block
                {
                    BlockById = 1,
                    BlockToId = 1,
                    IsBlocked = true
                };

                Assert.Throws<AppException>(() => service.IsBlocked(block.BlockById, block.BlockToId));

                var block1 = new Block
                {
                    BlockById = 1,
                    BlockToId = 2,
                    IsBlocked = true
                };

                Assert.False(service.IsBlocked(block1.BlockById, block1.BlockToId));
            }
        }
    }
}
