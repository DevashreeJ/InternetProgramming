using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temporary.Models
{
    public class DeactivateUserModel
    {
        public string SelectedUserName { get; set; }
        public IEnumerable<SelectListItem> Usernames { get; set; }
    }
}