using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temporary.Models
{
    public class ApplicationActivationModel
    {
        public string SelectedApplication { get; set; }
        public IEnumerable<SelectListItem> Applications { get; set; }
    }
}