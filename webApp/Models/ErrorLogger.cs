using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    
    public class ErrorLogger
    {
        
        [Required]

        public int IndividualId { get; set; }

        [Required]
        public string EmailID { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

       // public virtual ICollection<IndividualEntity> IndividualEntity { get; set; }
    }
}