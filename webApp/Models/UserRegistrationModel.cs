using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class UserRegistrationModel
    {
        
        [Required(ErrorMessage = "Required Field")]
        [StringLength(30)]
        [DisplayName("First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(30)]
        [DisplayName("Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(30)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]
        [DisplayName("Email id")]
        public string EmailID { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(10)]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "Please enter a valid Phone Number")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required Field")]
        [StringLength(30)]
        [DisplayName("Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password")]
        [StringLength(10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}