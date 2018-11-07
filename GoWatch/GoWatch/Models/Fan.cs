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

        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        public string CardholderName { get; set; }

        [DataType(DataType.CreditCard)]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "Insert the 3 digit code on the back of your card")]
        public int CCV { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Add the expiration date shown at the bottom of your card")]
        public int ExpirationDate { get; set; }

        public double RoutingNumber { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }


        public IEnumerable<ApplicationUser> ApplicationUsers { get; set; }
    }
}
