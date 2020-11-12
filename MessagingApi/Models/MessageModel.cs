using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Models
{
    public class MessageModel
    {
        public string Username { get; set; }

        public string ReceiverUsername { get; set; }

        public string Token { get; set; }

        public string Context { get; set; }
    }
}
