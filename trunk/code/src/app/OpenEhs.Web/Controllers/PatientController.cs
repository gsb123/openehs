using System.Web.Mvc;

namespace OpenEhs.Web.Controllers {
    public class PatientController : Controller {
        //
        // GET: /Patient/
        public ActionResult Index() 
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
