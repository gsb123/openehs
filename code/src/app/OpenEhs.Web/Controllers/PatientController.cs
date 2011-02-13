using System.Web.Mvc;
using OpenEhs.Data;
using System;

namespace OpenEhs.Web.Controllers {
    public class PatientController : Controller {

        // GET: /Patient/
        public ActionResult Index() {
            var patients = new PatientRepository().GetAll();

            return View(patients);
        }

        public ActionResult Create() {
            return View();
        }

        public ActionResult Details(int id) {
            var patient = new PatientRepository().Get(id);

            return View(patient);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public JsonResult EditAllergy() {
            try {
                int patientID = int.Parse(Request.Form["patientID"]);
                int allergyID = int.Parse(Request.Form["allergyID"]);
                string allergyName = Request.Form["allergyName"];

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientID);
                patient.Allergies[allergyID].Name = allergyName;

                UnitOfWork.CurrentSession.Flush();

                return Json(new {
                    error = "false",
                    status = "Added allergy successfully",
                    errorMessage = ""
                });
            } catch (Exception e) {
                return Json(new {
                    error = "false",
                    status = "Unable to add allergy successfully",
                    errorMessage = e.Message
                });
            }
        }
    }
}
