using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Entities
{
    public class Message
    {
        public int Id{ get; set; }

        public int FromId { get; set; }

        public int ToId { get; set; }

        public string Context { get; set; }

        public User user;
    }
}
