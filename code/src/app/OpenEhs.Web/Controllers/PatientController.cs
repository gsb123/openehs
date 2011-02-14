using System.Web.Mvc;
using OpenEhs.Data;
using System;
using OpenEhs.Domain;

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

        public JsonResult AddVital()
        {
            try
            {
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                Vitals vitals = new Vitals();
                vitals.Height = 76;
                vitals.Weight = 32;
                BloodPressure bp = new BloodPressure();
                bp.Diastolic = 140;
                bp.Systolic = 70;
                vitals.BloodPressure = bp;
                vitals.HeartRate = 120;
                vitals.IsActive = true;
                vitals.RespiratoryRate = 15;
                vitals.Temperature = 37;
                VitalsType vt = new VitalsType();
                vitals.Type = vt;
                patient.PatientCheckIns[0].Vitals.Add(vitals);


                return Json(new { 
                    error="false", 
                    status="Successfully added vital."
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = e.Message
                });
            }
        }
    }
}
