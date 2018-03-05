using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolehandling
{
    public class AccessSpecifications
    {
        public string Action { get; set; }

        /// <summary>
        /// Controller
        /// </summary>
        public string Controller { get; set; }

        /// <summary>
        /// Minimum needed role
        /// </summary>
        public RoleSpecifications MinimumRoleNeeded { get; set; }
    }
}
