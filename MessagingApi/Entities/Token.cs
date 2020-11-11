using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Entities
{
    public class Token
    {
        public int Id { get; set; }

        public string UserToken { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
