using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    [Table("IndividualEntity")]   
    public class IndividualEntity
    {
        [Key]
        [Required]
        public int IndividualId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ContactInfo ContactInfo { get; set; }
        public virtual LoginDetails LoginDetails { get; set; }
        public virtual RoleMapper RoleMapper { get; set; }
    }
}