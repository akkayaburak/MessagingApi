using MessagingApi.Entities;
using MessagingApi.Helpers;
using MessagingApi.Services;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace MessagingService.Test
{
    public class SqlServerMessageServiceTest : UsersControllerTest
    {
        public SqlServerMessageServiceTest() : base(
         new DbContextOptionsBuilder<DataContext>()
         .UseSqlServer("Data Source=DESKTOP-PSJOJTP\\SQLEXPRESS;Database=MessagingServiceTest;Trusted_Connection=True;")
         .Options)
        {
        }

        [Fact]
        public void Can_Save_Message()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new MessageService(context);
                Message message = new Message
                {
                    Context = "sgs",
                    SenderId = 1,
                    ReceiverId = 2,
                };
                Assert.NotNull(service.Save(message));

            }
        }

        [Fact]
        public void Can_Not_Save_Message()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new MessageService(context);
                Message message = new Message
                {
                    Context = "",
                    SenderId = 1,
                    ReceiverId = 2,
                };
                Assert.Throws<AppException>(() => service.Save(message));

                Message message1 = new Message
                {
                    Context = "sggdg",
                    SenderId = 1,
                    ReceiverId = 3000000
                };
                Assert.Throws<AppException>(() => service.Save(message1));

                Message message2 = new Message
                {
                    Context = "sggdg",
                    SenderId = 30000000,
                    ReceiverId = 1
                };
                Assert.Throws<AppException>(() => service.Save(message2));
            }
        }

        [Fact]
        public void Can_GetMessagesBySenderId()
        {
            using (var context = new DataContext(ContextOptions))
            {
                var service = new MessageService(context);

                Assert.Throws<AppException>(() => service.GetMessagesBySenderId(355555));
                Assert.NotNull(service.GetMessagesBySenderId(1));
            }
        }
    }
}
