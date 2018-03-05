using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rolehandling
{
    public static class SecurityMatrix
    {
        public static ICollection<AccessSpecifications> Matrix { get; set; }

        /// <summary>
        /// Initializes the security matrix
        /// </summary>
        public static void Initialize()
        {
            Matrix = new List<AccessSpecifications>()
            {

                new AccessSpecifications()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.HOME_ADMIN_PAGE,
                    MinimumRoleNeeded = RoleSpecifications.Admin
                },
                 new AccessSpecifications()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.ADMIN_LOGIN_PAGE,
                    MinimumRoleNeeded = RoleSpecifications.Admin
                },
                new AccessSpecifications()
                {
                     Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.APP_CREATION_ADMIN_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin
                },
                new AccessSpecifications()
                {
                     Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.APP_ACTIVATION_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin
                },
                new AccessSpecifications()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.APP_DEACTIVATION_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin
                },



                new AccessSpecifications()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.USER_ACTIVATION_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin
                },



                new AccessSpecifications()
                {
                     Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.USER_DEACTIVATION_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin
                },
                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.SHOW_APPS_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin

                },
                 new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.ERROR_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.None

                },
                  new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.ADDING_OWNER_TO_APP,
                    MinimumRoleNeeded =  RoleSpecifications.Admin

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.HOME_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.None

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.REGISTER_USER,
                    MinimumRoleNeeded =  RoleSpecifications.User

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.SHOW_APPS_TO_USERS,
                    MinimumRoleNeeded =  RoleSpecifications.User

                },

                 new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.SHOW_USERS_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.Admin

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.SUCCESS_PAGE,
                    MinimumRoleNeeded =  RoleSpecifications.None

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.VIEW_LOG,
                    MinimumRoleNeeded =  RoleSpecifications.User

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.VIEW_SEARCHED_LOG,
                    MinimumRoleNeeded =  RoleSpecifications.User

                },

                new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.USER_LOGIN,
                    MinimumRoleNeeded =  RoleSpecifications.User

                },
                  new AccessSpecifications    ()
                {
                    Controller = Websidedetails.CONTROLLER,
                    Action = Websidedetails.SEARCH_LOGS,
                    MinimumRoleNeeded =  RoleSpecifications.User

                }
            };
        }
    }
}
