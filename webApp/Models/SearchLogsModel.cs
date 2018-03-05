using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temporary.Models
{
    public class SearchLogsModel
    {
        public int loglevel { get; set; }
        public IEnumerable<SelectListItem> LoglevelList { get; set; }
    }
}