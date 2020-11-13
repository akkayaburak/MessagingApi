using MessagingApi.Entities;
using MessagingApi.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace MessagingApi.Services
{
    public class MessageService : IMessageService
    {
        private DataContext _context;

        public MessageService(DataContext context)
        {
            _context = context;
        }
        public Message Save(Message message)
        {
            if (string.IsNullOrEmpty(message.Context))
            {
                throw new AppException("Message can not be empty.");
            }
            if(!_context.Users.Any(x => x.Id == message.ReceiverId))
            {
                throw new AppException("Receiver user could not be found.");
            }
            _context.Messages.Add(message);
            _context.SaveChanges();
            return message;
        }

        public IEnumerable<Message> GetMessagesBySenderId (int senderId)
        {
            return _context.Messages;
        }
    }
}
