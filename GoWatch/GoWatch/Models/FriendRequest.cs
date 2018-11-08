using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class FriendRequest
    {   
        [Key]
        public int FriendRequestID { get; set; }

        [ForeignKey("Fan")]
        public int FanID { get; set; }
        public virtual Fan Fan { get; set; }

        [ForeignKey("Friend")]
        public int FriendID { get; set; }
        public virtual Fan Friend { get; set; }

        public string StatusRequest { get; set; }
    }
}
