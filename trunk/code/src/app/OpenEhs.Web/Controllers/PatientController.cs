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

        public ActionResult CreatePatient() {
            return View();
        }

        public ActionResult SearchPatients() {
            return View();
        }

        public ActionResult ViewPatients() {
            return View();
        }
    }
}
