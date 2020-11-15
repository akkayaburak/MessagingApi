namespace MessagingApi.Entities
{
    public class Message
    {
        public int Id{ get; set; }

        public string Context { get; set; }

        public User Sender { get; set; }
        public int SenderId { get; set; }

        public User Receiver { get; set; }

        public int ReceiverId { get; set; }
    }
}
