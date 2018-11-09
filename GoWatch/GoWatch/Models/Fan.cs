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

        [Display(Name = "Favorite Team")]
        public string FavoriteTeam { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        public string Address { get; set; }

        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [Display(Name = "Card holder Name")]
        public string CardholderName { get; set; }

        [Display(Name = "Credit Card Number")]
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
