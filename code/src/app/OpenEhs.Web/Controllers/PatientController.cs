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

        [HttpPost]
        public ActionResult RemoveAllergy() {
            try {
                int patientID = int.Parse(Request.Form["patientID"]);
                int allergyIndex = int.Parse(Request.Form["allergyID"]);

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientID);
                //patient.Allergies[allergyIndex];

                UnitOfWork.CurrentSession.Flush();

                return Json(new {
                    error = "false",
                    status = "Added allergy successfully",
                    errorMessage = ""
                });
            } catch (Exception e) {
                return Json(new {
                    error = "true",
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
                vitals.Height = int.Parse(Request.Form["height"]);
                vitals.Weight = int.Parse(Request.Form["weight"]);
                BloodPressure bp = new BloodPressure();
                bp.Diastolic = int.Parse(Request.Form["BpDiastolic"]);
                bp.Systolic = int.Parse(Request.Form["BpSystolic"]);
                vitals.BloodPressure = bp;
                vitals.HeartRate = int.Parse(Request.Form["HeartRate"]);
                vitals.IsActive = true;
                vitals.RespiratoryRate = int.Parse(Request.Form["RespiratoryRate"]);
                vitals.Temperature = int.Parse(Request.Form["Temperature"]);
                VitalsType vt = new VitalsType();
                vitals.Type = vt;
                vitals.Time = DateTime.Now;
                vitals.PatientCheckIn = patient.PatientCheckIns[0];
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
