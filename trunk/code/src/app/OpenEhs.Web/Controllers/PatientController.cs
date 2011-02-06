using System.Web.Mvc;
using OpenEhs.Data;

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

        public ActionResult Details(int id)
        {
            var patient = new PatientRepository().Get(id);
            return View(patient);
        }
    }
}
