using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{

    public class ApplicationDetails
    {
        
        [Required]
        [StringLength(1000)]
        [DisplayName("Application Name")]
        public string ApplicationName { get; set; }

        [Required]
        [DisplayName("Username")]
        public string User { get; set; }
   
    }
}