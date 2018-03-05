using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace temporary.Models
{
    public class UserLoginPageReq
    {
        [Required(ErrorMessage = "Username required")]
        [DisplayName("Username")]
        public string name { get; set; }
        
        [Required(ErrorMessage = "Password Required")]
        [DataType(DataType.Password)]
        [DisplayName("Password")]
        public string password { get; set; }
    }
}