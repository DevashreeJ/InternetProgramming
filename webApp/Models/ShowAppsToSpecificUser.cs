using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class ShowAppsToSpecificUser
    {
        public string firstNameOfTheUser { get; set; }

        public ICollection<string> ApplicationOwned { get; set; }
    }
}