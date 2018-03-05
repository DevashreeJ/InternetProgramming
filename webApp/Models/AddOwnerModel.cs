using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class AddOwnerModel
    {
        
        [Required]
        [Display(Description = "Application Name: ")]
        public string ApplicationName { get; set; }

        [Required]
        [Display(Description = "Owner Id")]
        public int OwnerId { get; set; }

    }
}