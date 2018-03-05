using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace temporary.Controllers
{
    /*using System.Collections.Generic;
    using System.Web.Mvc;*/
    using temporary.Models;
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult HomePage()
        {
            return View();
        }
        public ActionResult UserLogin()
        {
            return View();
        }
        public ActionResult AdminPage()
        {
            return View();
        }
        public ActionResult ErrorLogin()
        {
            return View();
        }

        [HttpGet]
        public ActionResult applicationInfo()
     
        {
            return View();
        }

        [HttpPost]
        public ActionResult applicationInfo(ApplicationManager app)

        {
            if (ModelState.IsValid)
            {
                ApplicationHandler application = new ApplicationHandler(); 
                application.AddApp(app);
                return RedirectToAction("successPage");
            }
            return View(app);
        }

        public ActionResult ShowApps()
        {
            ApplicationHandler application = new ApplicationHandler();
            ICollection<ApplicationManager> data = application.GetAllApps();

            return View(data);

        }

       
        [HttpGet]
        public ActionResult DeleteApp()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteApp(FormCollection form)
        {
            int num = Convert.ToInt32(form["applicationId"].ToString());

            if (ModelState.IsValid)
            {
            
                ApplicationHandler application = new ApplicationHandler();
                ICollection<ApplicationManager> data = application.GetAllApps();
                ApplicationManager appManager = new ApplicationManager();
                appManager = data.Single(x => x.applicationId == num);
                data.Remove(appManager);
                return RedirectToAction("successPage");
            }
            return RedirectToAction("ErrorLogin");
        }

        [HttpGet]
        public ActionResult AddUserPage()
        {
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken()]

        public ActionResult AddUserPage(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                UserDataHandler dataHandler = new UserDataHandler();
                dataHandler.AddUser(user);
               return RedirectToAction("successPage");
            }
            return View(user);
        }
        
        /* public ActionResult AdminPage(Admin a)
         {
             return View();
         }*/

        [HttpGet]
        public ActionResult AdminNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult AdminNew(Admin ad)
        {

            if (ad.name == "admin" && ad.password == "fghijk")
            {
                return RedirectToAction("AdminPage");
            }
            else

                return RedirectToAction("ErrorLogin");
        }
        [HttpGet]
        public ActionResult UserLoginPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UserLoginPage(UserRegistration user)
        {
            
            UserDataHandler dh = new UserDataHandler();
            ICollection<UserRegistration> userData = dh.GetAllUsers();         
            if (ModelState.IsValid)
            {
                if (userData.Any(x => x.password == user.password) && userData.Any(x=>x.name==user.name))
                    {
               //     dataHandler.AddUser(user);
                    return RedirectToAction("successPage");
                }
                return RedirectToAction("ErrorLogin");
            }
            return RedirectToAction("ErrorLogin");
        }

        public ActionResult EditUser()
        {
            return View();
        }


        [HttpGet]
        public ActionResult UserRegistrationPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditUser(UserRegistration newUser)
        {
            if (ModelState.IsValid)
            {
                UserDataHandler dataSource = new UserDataHandler();
                dataSource.EditUser(newUser);
                return RedirectToAction("successPage");
            }
            return RedirectToAction("ErrorLogin");
        }

        [HttpPost]
        public ActionResult UserRegistrationPage(UserRegistration newUser)
        {
            if (ModelState.IsValid)
            {
                UserDataHandler dataSource = new UserDataHandler();
                dataSource.AddUser(newUser);
                return RedirectToAction("successPage");
            }
            return RedirectToAction("ErrorLogin");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(UserRegistration user)
        {
            if (ModelState.IsValid)
            {
                UserDataHandler dataSource = new UserDataHandler();
                dataSource.EditPassword(user);
                return RedirectToAction("successPage");
            }
            return RedirectToAction("ErrorLogin");
        }


        public ActionResult ShowUsers()
        {
            UserDataHandler dataSource = new UserDataHandler();
            ICollection<UserRegistration> data = dataSource.GetAllUsers();

            return View(data);
         
        }

        public ActionResult successPage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteUserPage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUserPage(FormCollection form)
        {
            int num = Convert.ToInt32(form["registerNumber"].ToString());

            if (ModelState.IsValid)
            {
                UserDataHandler datahandler = new UserDataHandler();
                ICollection<UserRegistration> data = datahandler.GetAllUsers();
                UserRegistration reg = new UserRegistration();
                reg = data.Single(x => x.regnumber == num);
                data.Remove(reg);
                return RedirectToAction("successPage");
            }
            return RedirectToAction("ErrorLogin");
        }

    }
}