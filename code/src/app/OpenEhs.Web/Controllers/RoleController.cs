using System.Web.Mvc;

namespace OpenEhs.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
