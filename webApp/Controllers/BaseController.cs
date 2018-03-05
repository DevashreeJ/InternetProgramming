using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rolehandling;
using log4net;

namespace temporary.Controllers
{
    public class BaseController : Controller
    {
        #region Properties & Controller

        #region String constants

        protected static string DETAILED_UNAUTHORIZED_ERROR = "User {0} attempted to access {1}/{2}.";
        protected static string USER_UNAUTHORIZED_ERROR = "You are not authorized for the specified page.";

        #endregion

        /// <summary>
        /// Authentication class
        /// </summary>
        private CheckAuthentication authentication { get; set; }

        /// <summary>
        /// Base Controller
        /// </summary>
        public BaseController()
        {
            this.authentication = new CheckAuthentication();
        }

        #endregion

        #region Overrides of events

        /// <summary>
        /// Executes before the action executes, so we can set stuff up, make sure we are okay with them running the action
        /// </summary>
        /// <param name="filterContext">Context</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //ToDo: setup a stop watch..

            // gather data
            string controller = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string action = filterContext.ActionDescriptor.ActionName;
            string userName = (string)HttpContext.Session["userId"];

            // authenticate user
            if (!this.authentication.IsUserAuthorized(controller, action, userName))
            {
                //Throw an exception
                TempData["errorMessage"] = USER_UNAUTHORIZED_ERROR;
                throw new UnauthorizedAccessException(string.Format(DETAILED_UNAUTHORIZED_ERROR, userName, controller, action));
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        /// Executes after the action has finished, cleanup work..
        /// </summary>
        /// <param name="filterContext"></param>
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            //ToDo: log the time it took to load for performance

            //Optional -> do other checks

            base.OnActionExecuted(filterContext);
        }

        /// <summary>
        /// If an unhandled exception was thrown in the controller, this will execute, so we can (but don't have to)
        /// handle it.
        /// </summary>
        /// <param name="filterContext">Context</param>
        protected override void OnException(ExceptionContext filterContext)
        {
            // Blow out the session
            Session.Clear();

            // Log the error
            string errorMessage = filterContext.Exception.Message;
            //ToDo: log the error

            //Redirect user to the error page    
            filterContext.ExceptionHandled = true;
            filterContext.Result = RedirectToAction(Websidedetails.ERROR_PAGE, Websidedetails.CONTROLLER);

            base.OnException(filterContext);
        }

        #endregion
    }
}