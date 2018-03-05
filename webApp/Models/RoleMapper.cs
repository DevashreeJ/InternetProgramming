using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    [Table("RoleMapper")]
    public class RoleMapper
    {
        [Key]
        [Required]
        public int MappingId { get; set; }

        [Required]
        [ForeignKey("RoleOfAnIndividual")]
        public int RoleId { get; set; }

        [Required]
        [ForeignKey("IndividualEntity")]
        public int IndividualId { get; set; }


        public virtual ApplicationMapper ApplicationMapper { get; set; }
        public virtual ICollection<ApplicationDetails> ApplicationDetails { get; set; } //if person is admin
        public virtual ICollection<RoleOfAnIndividual> RoleOfAnIndividual { get; set; } //one individual can be an admin as well as user.
        public virtual ICollection<IndividualEntity> IndividualEntity { get; set; }

    }
}