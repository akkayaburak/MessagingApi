using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Models
{
    public class MessageShowModel
    {
        public MessageShowModel(string context, string senderUserName, int receiverUserId)
        {
            Context = context;
            SenderUsername = senderUserName;
            ReceiverUserId = receiverUserId;
        }

        public string Context { get; set; }

        public string SenderUsername { get; set; }

        public int ReceiverUserId{ get; set; }
    }
}
