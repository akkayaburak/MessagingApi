using System;
using System.ComponentModel.DataAnnotations;

namespace MessagingApi.Entities
{
    public class Log
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string MessageTemplate { get; set; }

        public string Level { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }

        public string Exception { get; set; }

        public string Properties { get; set; }
    }
}
