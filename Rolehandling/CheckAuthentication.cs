using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolehandling
{
    public class CheckAuthentication
    {
        public bool IsUserAuthorized(string controller, string action, string userName)
        {
            //ToDo: get user's role (based on the userName, maybe from the DB?)
            RoleSpecifications usersRole = RoleSpecifications.Admin;

            // get required role from the Matrix (this will fail if we haven't registered the requested controller/action combination
            RoleSpecifications requiredRole = SecurityMatrix.Matrix.First(x => x.Controller == controller && x.Action == action).MinimumRoleNeeded;

            return usersRole >= requiredRole;
        }

    }
}
