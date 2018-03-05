using System;
using System.Collections.Generic;
using System.Linq;
using ExecutableProj;
using Tempdata;
using System.Web;
using System.Web.Mvc;
using Rolehandling;
using log4net;

namespace temporary.Controllers
{
    using System.Data.Entity;
    using temporary.Models;
    public class ProjectController : BaseController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        List<ApplicationDisplay> applistAdmin = new List<ApplicationDisplay>();

        public ActionResult HomePage()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserLogin()
        {
            Session["userId"] = "Hello User";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult UserLogin(UserLoginPageReq userCreds)
        {
            try
            {
                bool truthval;
                OperationsOnDatabase odb = new OperationsOnDatabase();
                PasswordEncryption pe = new PasswordEncryption();
                truthval = pe.AuthenticateUser(userCreds.name, userCreds.password);
                if (truthval == true)
                {
                    TempData["userdata"] = userCreds;
                    return RedirectToAction("ShowAppsToUsers");
                }
                return RedirectToAction("ErrorLogin");
            }
            catch (Exception e)
            {
                log.Error("UserLogin class in project controller" + e.Message);
                return RedirectToAction("ErrorLogin");
            }
        }

        public ActionResult AdminPage()
        {
            return View();
        }

        public ActionResult ErrorLogin()
        {
            return View();
        }


        public ActionResult ShowApps()
        {
            try
            {
                DatabaseModel dbm = new DatabaseModel();
                List<Application> apps = dbm.Applications.ToList();
                foreach (var temp in apps)
                {
                    ApplicationDisplay appdisp = new ApplicationDisplay();
                    appdisp.ApplicationId = temp.ApplicationId;
                    appdisp.ApplicationName = temp.ApplicationName;
                    appdisp.ApplicationOwners = new List<string>();
                    foreach (var owner in temp.IndividualsApplication)
                    {
                        appdisp.ApplicationOwners.Add(owner.FirstName);
                    }
                    applistAdmin.Add(appdisp);
                }
                return View(applistAdmin);
            }
            catch (Exception e)
            {
                log.Error("ShowApps class in project controller" + e.Message);
                return RedirectToAction("ErrorLogin");
            }
        }

        [HttpGet]
        public ActionResult AdminNew()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult AdminNew(Admin ad)
        {
            try
            {
                bool truthval = false;
                OperationsOnDatabase odb = new OperationsOnDatabase();
                PasswordEncryption pe = new PasswordEncryption();
                truthval = pe.AuthenticateAdmin(ad.name, ad.password);
                if (truthval == true)
                    return RedirectToAction("AdminPage");
                return RedirectToAction("ErrorLogin");
            }
            catch (Exception e)
            {
                log.Error("Conditions for a user not satisfied." + e.Message);
                return RedirectToAction("ErrorLogin");
                throw e;
            }
        }


        public ActionResult ShowAppsToUsers()
        {
            try
            {
                UserLoginPageReq userdets = TempData["userdata"] as UserLoginPageReq;
                var userName = userdets.name;
                DatabaseModel db = new DatabaseModel();
                DisplayFunctionalities df = new DisplayFunctionalities();
                List<Application> apps = df.ShowApplicationsOwnedByUser(userName);
                ShowAppsToSpecificUser sa = new ShowAppsToSpecificUser();
                IndividualEntity ie = new IndividualEntity();
                sa.ApplicationOwned = new List<string>();
                List<IndividualEntity> users = new List<IndividualEntity>();
                users = db.Person.ToList();
                ie = users.Find(x => x.Username == userName);
                sa.firstNameOfTheUser = ie.FirstName;
                foreach (var temp in apps)
                {
                    sa.ApplicationOwned.Add(temp.ApplicationName);
                }
                return View(sa);
            }
            catch (Exception e)
            {
                log.Error("Problem in show apps to users function " + e.Message);
                throw new Exception(e.Message);
            }
        }

        public ActionResult ShowUsers()
        {
            try
            {
                DatabaseModel dm = new DatabaseModel();
                List<IndividualEntity> listOfPeople = new List<IndividualEntity>();
                listOfPeople = dm.Person.ToList();
                List<IndividualEntity> listOfUsers = new List<IndividualEntity>();
                foreach (var person in listOfPeople)
                {
                    if (person.UserStatus != "NA")
                    {
                        listOfUsers.Add(person);
                    }
                }
                return View(listOfUsers);
            }
            catch (Exception e)
            {
                log.Error("Problem in ShowUsers class" + e.Message);
                return View("ErrorLogin");
            }

        }

        public ActionResult successPage()
        {
            return View();
        }



        [HttpGet]
        public ActionResult RegisterUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegisterUser(UserRegistrationModel userInfo)
        {
            try
            {            
                    OperationsOnDatabase.RegisterUser(userInfo.FirstName, userInfo.LastName, userInfo.PhoneNumber, userInfo.EmailID, userInfo.Username, userInfo.Password);
                    return RedirectToAction("successPage");
             
            }
            catch(Exception e)
            {
                log.Error("Register User class in project controller" +e.Message);
                return View("ErrorLogin");
            }
        }

        [HttpGet]
        public ActionResult CreateApplication()
        {
            try
            {
                List<string> usernames = new List<string>();
                DatabaseModel dbm = new DatabaseModel();
                CreateAppSettingModel cm = new CreateAppSettingModel();

                foreach (var temp in dbm.Person.ToList())
                {
                    if (temp.UserStatus == "Active")
                        usernames.Add(temp.Username);
                }
                cm.Usernames = new SelectList(usernames);
                return View(cm);
            }
            catch (Exception e)
            {                
                log.Error("Error Create Application class in project controller" + e.Message);
                throw new Exception(e.Message);
            }           
        }

        [HttpPost]
        public ActionResult CreateApplication(CreateAppSettingModel cm)
        {
            try
            {
                OperationsOnDatabase db = new OperationsOnDatabase();
                db.CreateApplication(cm.ApplicationName, cm.SelectedUserName);
                return RedirectToAction("successPage");
            }
            catch (Exception)
            {

                throw;
            }        
        }


        [HttpGet]
        public ActionResult AddOwnerToExistingApp()
        {
            
            List<string> appdetails = new List<string>();
            List<string> usernames = new List<string>();
            DatabaseModel dbm = new DatabaseModel();
            AddOwnerListModel alm = new AddOwnerListModel();
            foreach (var app in dbm.Applications.ToList())
            {
                appdetails.Add(app.ApplicationName);
            }
            foreach (var temp in dbm.Person.ToList())
            {
                if(temp.UserStatus=="Active")
                usernames.Add(temp.Username);
            }
            alm.Applications = new SelectList(appdetails);
            alm.Usernames = new SelectList(usernames);
            return View(alm);
          
        }

        [HttpPost]
        public ActionResult AddOwnerToExistingApp(AddOwnerListModel am)
        {

            if (ModelState.IsValid)
            {
                OperationsOnDatabase db = new OperationsOnDatabase();
                db.AddOwnerToExistingApplication(am.selectedApplication, am.selectedUsername);
                return RedirectToAction("successPage");
            }
            return RedirectToAction("ErrorLogin");
        }

        [HttpGet]
        public ActionResult DeactivateAUser()
        {
            DatabaseModel dbm = new DatabaseModel();
            DeactivateUserModel dm = new DeactivateUserModel();
            List<string> usernames = new List<string>();
            foreach (var person in dbm.Person.ToList())
            {
                if (person.UserStatus == "Active")
                    usernames.Add(person.Username);
            }
            dm.Usernames = new SelectList(usernames);
            return View(dm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DeactivateAUser(DeactivateUserModel userDetails)
        {          
            try
            {
                OperationsOnDatabase odb = new OperationsOnDatabase();
                odb.DeactivateUser(userDetails.SelectedUserName);
                return RedirectToAction("successPage");
            }
            catch (Exception e)
            {
                log.Error("Prolem while deactivating the user" + e.Message);
                return View("ErrorLogin");
            }               
        }

        [HttpGet]
        public ActionResult ActivateAUser()
        {
            DatabaseModel dbm = new DatabaseModel();
            DeactivateUserModel dm = new DeactivateUserModel();
            List<string> usernames = new List<string>();
            foreach (var person in dbm.Person.ToList())
            {
                if (person.UserStatus == "Inactive")
                    usernames.Add(person.Username);
            }
            dm.Usernames = new SelectList(usernames);
            return View(dm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult ActivateAUser(DeactivateUserModel userDetails)
        {
            try
            {
                OperationsOnDatabase odb = new OperationsOnDatabase();
                odb.ActivateUser(userDetails.SelectedUserName);
                return RedirectToAction("successPage");
            }
            catch (Exception e)
            {
                log.Error("Prolem while deactivating the user" + e.Message);
                return View("ErrorLogin");
            }
        }
        [HttpGet]
        public ActionResult ActivateAnApplication()
        {
            DatabaseModel dbm = new DatabaseModel();
            ApplicationActivationModel am = new ApplicationActivationModel();
            List<string> applications = new List<string>();
            foreach (var app in dbm.Applications.ToList())
            {
                if (app.ApplicationStatus == "Inactive")
                    applications.Add(app.ApplicationName);
            }
            am.Applications = new SelectList(applications);
            return View(am);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult ActivateAnApplication(ApplicationActivationModel appDetails)
        {
            
            try
            {
                OperationsOnDatabase odb = new OperationsOnDatabase();
                odb.ActivateApplication(appDetails.SelectedApplication);
                return RedirectToAction("successPage");
            }
            catch (Exception e)
            {
                log.Error("Problem while activating the application" + e.Message);
                return View("ErrorLogin");
            }
        }

        [HttpGet]
        public ActionResult DeactivateAnApplication()
        {
            try
            {
                DatabaseModel dbm = new DatabaseModel();
                ApplicationActivationModel am = new ApplicationActivationModel();
                List<string> applications = new List<string>();
                foreach (var app in dbm.Applications.ToList())
                {
                    if (app.ApplicationStatus == "Active")
                        applications.Add(app.ApplicationName);
                }
                am.Applications = new SelectList(applications);
                return View(am);
            }
            catch (Exception e)
            {

                log.Error("Problem while deactivating the application" + e.Message);
                return View("ErrorLogin");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult DeactivateAnApplication(ApplicationActivationModel appDetails)
        {

            try
            {
                OperationsOnDatabase odb = new OperationsOnDatabase();
                odb.DeactivateApplication(appDetails.SelectedApplication);
                return RedirectToAction("successPage");
            }
            catch (Exception e)
            {
                log.Error("Problem while deactivating the application" + e.Message);
                return View("ErrorLogin");
            }
        }

        [HttpGet]
        public ActionResult SearchLogs()
        {
            DatabaseModel dbm = new DatabaseModel();
            SearchLogsModel logmodel = new SearchLogsModel();
            List<int> Loglevels = new List<int>();
            for(int i=1; i<5; i++)
            {
                Loglevels.Add(i);
            }
            logmodel.LoglevelList = new SelectList(Loglevels);
            return View(logmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public ActionResult SearchLogs(SearchLogsModel logmodel)
        {
            try
            {
                OperationsOnDatabase odb = new OperationsOnDatabase();
                ICollection<Errorlogs> errorlist;
                List<Errorlogs> errorlistfromlogview = new List<Errorlogs>();
                errorlistfromlogview = TempData["OwnersLogs"] as List<Errorlogs>;
                errorlist = odb.SearchLogs(logmodel.loglevel,errorlistfromlogview);
                TempData["Searchederrors"] = errorlist;
                return RedirectToAction("ViewSearchedLog");
                
            }
            catch (Exception e)
            {
                log.Error("Prolem while deactivating the user" + e.Message);
                return View("ErrorLogin");
            }
        }

        [HttpGet]
        public ActionResult ViewLog(string appname)
        {
            OperationsOnDatabase odb = new OperationsOnDatabase();
            ICollection<Errorlogs> errorlogs;
            errorlogs = odb.ViewLogs(appname);
            TempData["OwnersLogs"] = errorlogs;
            return View(errorlogs);
        }

        [HttpGet]
        public ActionResult ViewSearchedLog()
        {
            var errors = TempData["Searchederrors"] as List<Errorlogs>;
            return View(errors);
        }

    }
}