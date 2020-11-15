using MessagingApi.Entities;
using MessagingApi.Helpers;
using Microsoft.EntityFrameworkCore;
using System;

namespace MessagingService.Test
{
    public class SqlServerServicesTest
    {
        protected DbContextOptions<DataContext> ContextOptions { get; }
        public SqlServerServicesTest(DbContextOptions<DataContext> contextOptions)
        {
            ContextOptions = contextOptions;
            Seed();
        }

        private void Seed()
        {
            using(var context = new DataContext(ContextOptions))
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var one = new User
                {
                    Username = "furkangurel",
                    FirstName = "Furkan",
                    LastName = "Gurel"
                };
                byte[] passwordHash = new byte[20];
                byte[] passwordSalt = new byte[20];
                Random random = new Random();
                random.NextBytes(passwordHash);
                one.PasswordHash = passwordHash;

                random.NextBytes(passwordSalt);
                one.PasswordSalt = passwordSalt;


                var two = new User
                {
                    Username = "akkayaberat",
                    FirstName = "Berat",
                    LastName = "Akkaya"
                };

                random.NextBytes(passwordHash);
                two.PasswordHash = passwordHash;

                random.NextBytes(passwordSalt);
                two.PasswordSalt = passwordSalt;

                var three = new User
                {
                    Username = "lalealper",
                    FirstName = "Alper",
                    LastName = "Lale"
                };

                random.NextBytes(passwordHash);
                three.PasswordHash = passwordHash;

                random.NextBytes(passwordSalt);
                three.PasswordSalt = passwordSalt;

                context.AddRange(one, two, three);
                context.SaveChanges();
            }
        }
     
    }
}
