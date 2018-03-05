using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class ApplicationDisplay
    {
        [Required]
        [Display(Description = "Application Id")]
        public int ApplicationId { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Description = "Application Name")]
        public string ApplicationName { get; set; }

        public ICollection<string> ApplicationOwners { get; set; }
    }
}