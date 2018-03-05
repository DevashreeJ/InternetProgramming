using System.Web.Mvc;

namespace BasicRestApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "jQuery Consumption Demo";

            return View();
        }
    }
}
