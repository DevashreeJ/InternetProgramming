using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    [Table("LoginDetails")]
    public class LoginDetails
    {
        [Key]
        [ForeignKey("IndividualEntity")]
        [Required]
        public int IndividualId { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Passsword { get; set; }
        public virtual ICollection<IndividualEntity> IndividualEntity { get; set; }
    }
}