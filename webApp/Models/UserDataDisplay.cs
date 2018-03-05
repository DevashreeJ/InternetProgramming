using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class UserDataDisplay
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailID { get; set; }

        public string PhoneNumber
        {
            get; set;
        }

        public virtual ICollection<ApplicationDetails> ApplicationsMapped { get; set; }

    }
}