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

        [Display(Name = "Event Place")]
        public string EventsPlace { get; set; }

        public bool EventType { get; set;}

        [DataType(DataType.DateTime)]
        DateTime? DateTime { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Display(Name = "Home Team")]
        public string HomeTeam { get; set; }

        [Display(Name = "Away Team")]
        public string AwayTeam { get; set; }

        [DataType(DataType.Text)]
        public string Rules { get; set; }

        [DataType(DataType.Currency)]
        public double Price { get; set; }
        //public long? Price { get; set; }

        [Display(Name = "Rate Event")]
        public int RateEvent { get; set; }
    }
}
