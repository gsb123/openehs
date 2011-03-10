using System.Web.Mvc;

namespace OpenEhs.Web.Controllers
{
    [Authorize(Roles="Administrators, OPDAdministrators")]
    public class ReportsController : Controller
    {
        //
        // GET: /Reports/

        public ActionResult Index()
        {
            return View();
        }

    }
}
