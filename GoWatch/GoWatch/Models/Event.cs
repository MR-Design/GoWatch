using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        

        public bool EventType { get; set;}

        [DataType(DataType.DateTime)]
        DateTime DateTime { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        public string HomeTeam { get; set; }


        public string AwayTeam { get; set; }

        [DataType(DataType.Text)]
        public string Rules { get; set; }

        [DataType(DataType.Currency)]
        public int Price { get; set; }

        public int RateEvent { get; set; }
    }
}
