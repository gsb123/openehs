using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenEhs.Web.Controllers {
    public class PatientController : Controller {
        //
        // GET: /Patient/

        public ActionResult Index() {
            return View();
        }

        public ActionResult NewPatient() {
            return View();
        }

        public ActionResult SearchPatients() {
            return View();
        }

    }
}
