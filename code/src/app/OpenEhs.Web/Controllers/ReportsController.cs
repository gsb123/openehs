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

        public ActionResult DailyWardReport()
        {
            return View();
        }

        public ActionResult PatientReport()
        {
            return View();
        }

    }
}
