using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class GuestList
    {
        public int GuestListID { get; set; }

        [ForeignKey("Fan")]
        public int FanID { get; set; }
        public Fan Fan { get; set; }

        [ForeignKey("Event")]
        public int EventID { get; set; }
        public Event Event { get; set; }

        public bool Going { get; set; }
        public bool Arrived { get; set; }
        public int RateEvent { get; set; }




    }
}
