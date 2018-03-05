using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace temporary.Models
{
    public class UserClass
    {
        [Display(Name = "Username")]
        [Required(ErrorMessage = "Please enter the username")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter the password")]
        public string password { get; set; }
    }
}