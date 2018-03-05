using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    [Table("ApplicationMapper")]
    public class ApplicationMapper
    {
        [Key]
        [Required]
        [ForeignKey("ApplicationDetails")]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("RoleMapper")]
        public int MappingId { get; set; }

        public virtual ICollection<RoleMapper> RoleMapper { get; set; }
        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; }

    }
}