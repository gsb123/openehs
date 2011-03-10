using System.Web.Mvc;

namespace OpenEhs.Web.Controllers {
    public class HelpController : Controller {
        //
        // GET: /Help/

        public ActionResult Index() {
            return View();
        }

        public ActionResult PatientSearch() {
            return View();
        }

        public ActionResult PatientCreation() {
            return View();
        }

        public ActionResult PatientResources() {
            return View();
        }

        public ActionResult BillingSearch() {
            return View();
        }

    }
}
