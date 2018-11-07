using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class FriendRequest
    {
        public int FriendRequestID { get; set; }
        [ForeignKey("Fan")]
        public int FanID { get; set; }  
        public Fan Fan { get; set; }

        public string StatusRequest { get; set; }
    }
}
