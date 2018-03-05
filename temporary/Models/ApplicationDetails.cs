using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    [Table("ApplicationDetails")]
    public class ApplicationDetails
    {
        [Key]
        [Required]
        public int ApplicationId { get; set; }

        [Required]
        [ForeignKey("RoleMapper")]
        public int MappingId { get; set; }

        [Required]
        [StringLength(1000)]
        public string ApplicationName { get; set; }

        public virtual ApplicationMapper ApplicationMapper { get; set; }
        public virtual ErrorLogger ErrorLogger { get; set; }
        public virtual ICollection<RoleMapper> RoleMapper { get; set; }

    }
}