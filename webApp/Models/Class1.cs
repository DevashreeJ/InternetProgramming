using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public class Admin
    {
        [Required(ErrorMessage = "Username required")]
        [DisplayName("Username")]
        public string name { get; set; }


        [Required(ErrorMessage = "Password Required")]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
    
}