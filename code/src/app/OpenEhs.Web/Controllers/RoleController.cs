using System.Web.Mvc;

namespace OpenEhs.Web.Controllers
{
    [Authorize(Roles="Administrators")]
    public class RoleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
