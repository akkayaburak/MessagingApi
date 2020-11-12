using MessagingApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Services
{
    public interface IMessageService
    {
        Message Save(Message message);
        IEnumerable<Message> GetMessagesBySenderId(int senderId);
    }
}
