using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace temporary.Models
{
    public class ApplicationHandler
    {
        private static List <ApplicationManager> applist;
        public ApplicationHandler()
        {
            if (applist == null)
            {
                applist = new List<ApplicationManager>()
                {
                    new ApplicationManager()
                    {
                        applicationId = 1,
                        applicationName = "abc.com"
                    },
                     new ApplicationManager()
                    {
                         applicationId = 2,
                         applicationName = "xyz.com"
                     }

                };
            }
        }

        public bool AddApp(ApplicationManager newApp)
        {
            bool result = false;

            if (!applist.Any(x => x.applicationId == newApp.applicationId))
            {
                applist.Add(newApp);
                result = true;
            }

            return result;
        }
        public bool DeleteApp(ApplicationManager appName)
        {

            bool result = false;

            if (applist.Any(x => x.applicationId == appName.applicationId))
            {
                applist.Remove(appName);
                result = true;
            }

            return result;
        }

        public ICollection<ApplicationManager> GetAllApps()
        {
            return applist;
        }

        public ApplicationManager GetAppById(int num)
        {
            ApplicationManager app = new ApplicationManager();

            if (applist.Any(x => x.applicationId == num))
            {
                app = applist.Single(x => x.applicationId == num);
            }
            return app;

        }
    }
}