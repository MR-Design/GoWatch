using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class EventType
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Event")]
        public int Id {get; set;}

        public Event Event { get; set; }


        public bool isPublic { get; set; }
    }
}
