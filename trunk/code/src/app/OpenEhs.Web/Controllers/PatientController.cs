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


        public JsonResult AddAllergy() {
            try {
                int patientId = int.Parse(Request.Form["patientID"]);
                string allergyName = Request.Form["allergyName"];

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientId);
                Allergy allergy = new Allergy();
                allergy.Name= allergyName;
                patient.Allergies.Add(allergy);

                return Json(new {
                    error = "false",
                    status = "Added allergy: " + allergyName + " successfully",
                    allergy = allergy
                });
            } catch (Exception e) {
                return Json(new {
                    error = "true",
                    status = "Unable to add allergy successfully",
                    errorMessage = e.Message
                });
            }
        }


        public JsonResult RemoveAllergy() {
            try {
                int patientId = int.Parse(Request.Form["patientID"]);
                int allergyId = int.Parse(Request.Form["allergyID"]);

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientId);
                string name = "";
                bool found = false;
                foreach (var allergy in patient.Allergies) {
                    if (allergyId == allergy.Id) {
                        found = true;
                        name = allergy.Name;
                        patient.Allergies.Remove(allergy);
                        break;
                    }
                }

                UnitOfWork.CurrentSession.Flush();
                if (found) {
                    return Json(new {
                        error = "false",
                        status = "Removed allergy: " + name + " successfully"
                    });
                } else {
                    return Json(new {
                        error = "true",
                        status = "Allergy not found, please refresh the page and try again",
                        errorMessage = "Allergy with id: " + allergyId + " not found"
                    });
                }
            } catch (Exception e) {
                return Json(new {
                    error = "true",
                    status = "Unable to remove allergy",
                    errorMessage = e.Message
                });
            }
        }

        public JsonResult AddVital() {
            try {
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
                    error = "false",
                    status = "Successfully added vital."
                });
            } catch (Exception e) {
                return Json(new {
                    error = "true",
                    status = e.Message
                });
            }
        }
    }
}
