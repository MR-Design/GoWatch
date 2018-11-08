using GoWatch.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoWatch.Models
{
    public class Fan
    {

        [Key]
        public int FanID { get; set; }
        public string FavoriteTeam { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

    
        public string CardholderName { get; set; }

        public int CreditCardNumber { get; set; }

        public int CCV { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? ExpirationDate { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}
