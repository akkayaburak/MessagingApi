using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Entities
{
    public class Block
    {
        public int Id { get; set; }

        public User BlockBy { get; set; }
        public int BlockById { get; set; }

        public User BlockTo { get; set; }
        public int BlockToId { get; set; }

        public bool IsBlocked { get; set; }
    }
}
