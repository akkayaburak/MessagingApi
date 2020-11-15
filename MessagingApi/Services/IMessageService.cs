using MessagingApi.Entities;
using System.Collections.Generic;

namespace MessagingApi.Services
{
    public interface IMessageService
    {
        Message Save(Message message);
        IEnumerable<Message> GetMessagesBySenderId(int senderId);
    }
}
