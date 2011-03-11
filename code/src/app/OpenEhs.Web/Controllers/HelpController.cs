using System.Web.Mvc;

namespace OpenEhs.Web.Controllers {
    public class HelpController : Controller {
        //
        // GET: /Help/

        public ActionResult Index() {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult PatientSearch()
        {
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

        public ActionResult BillingDetails()
        {
            return View();
        }

        public ActionResult PrinterSetup()
        {
            return View();
        }

        public ActionResult PrintExistingPatientBarcode()
        {
            return View();
        }

    }
}
