using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Helpers
{
    public class SqlServerDataContext : DataContext
    {
        public SqlServerDataContext(IConfiguration configuration) : base(configuration)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("MessagingServiceDatabase"));
        }
    }
}
