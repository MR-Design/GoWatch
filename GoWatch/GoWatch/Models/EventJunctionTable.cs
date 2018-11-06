using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class EventJunctionTable
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Fan")]
        public string FanUsername { get; set; }

        public Fan Fan { get; set; }

        [ForeignKey("EventCreator")]
        public int EventID { get; set; }

        public Event EventCreator { get; set; }
    }
}
