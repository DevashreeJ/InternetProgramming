using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temporary.Models
{
    public class CreateAppSettingModel
    {
        [Required]
        [StringLength(1000)]
        [DisplayName("Application Name")]
        public string ApplicationName { get; set; }

        public string SelectedUserName { get; set; }
        public IEnumerable<SelectListItem> Usernames { get; set; }
    }
}