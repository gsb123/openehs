using System.Web.Mvc;

namespace OpenEhs.Web.Controllers 
{
    [Authorize]
    public class HomeController : Controller 
    {
        public ActionResult Index() 
        {
            ViewBag.Message = "Oops";

            return View();
        }
    }
}
