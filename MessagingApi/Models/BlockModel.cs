using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessagingApi.Models
{
    public class BlockModel
    {
        public string blockFromUsername { get; set; }

        public string blockToUsername { get; set; }

        public bool isBlocked { get; set; }
    }
}
