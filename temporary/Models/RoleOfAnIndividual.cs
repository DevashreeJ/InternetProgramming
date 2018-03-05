using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    [Table("RoleOfAnIndividual")]
    public class RoleOfAnIndividual
    {           
            [Key]
            public int RoleId { get; set; }

            public string Rolename { get; set; }

            public virtual RoleMapper RoleMapper { get; set; }
      
    }
}