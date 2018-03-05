using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class UserRegistration
    {
        [Required]
        public int regnumber { get; set; }
        [Required(ErrorMessage = "Name required")]
        public string name { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password required")]
        public string password { get; set; }
       
    }
}