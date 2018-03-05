using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Admin
    {
        [Required(ErrorMessage = "Username required")]
        public string name { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

    }
    
}