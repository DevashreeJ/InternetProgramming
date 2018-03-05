using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temporary.Models
{
    public class AddOwnerListModel
    {
        public IEnumerable<SelectListItem> Applications { get; set; }
        public IEnumerable<SelectListItem> Usernames { get; set; }
        public string selectedApplication { get; set; }
        public string selectedUsername { get; set; }

    }
}