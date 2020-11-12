using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Models
{
    public class MessageSaveModel
    {
        public MessageSaveModel(int senderId, int receiverId, string context)
        {
            SenderId = senderId;
            ReceiverId = receiverId;
            Context = context;
        }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public string Context { get; set; }
    }
}
