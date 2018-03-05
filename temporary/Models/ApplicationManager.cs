using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class ApplicationManager
    {

            [Required(ErrorMessage = "Id  required")]
            public int applicationId { get; set; }
            
            [Required(ErrorMessage = "Please enter application nameas")]
            public string applicationName { get; set; }

    }
}