using System.Linq;
using System.Web.Mvc;
using OpenEhs.Data;
using System;
using OpenEhs.Domain;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class PatientController : Controller
    {

        // GET: /Patient/
        public ActionResult Index()
        {
            var patients = new PatientRepository().GetAll();

            return View(patients);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var patientViewModel = new PatientViewModel(id);

            HttpContext.Session["CurrentPatient"] = id;

            return View(patientViewModel);
        }

        /// <summary>
        /// Search patient records from criteria in 'Search' box
        /// </summary>
        /// <param name="values">Collection of values from the posted form</param>
        /// <returns>List of patients</returns>
        [HttpPost]
        public ActionResult Index(FormCollection values)
        {
            string searchCriteria = values["PatientSearchTextBox"];    //Get the value entered in the 'Search' field

            IList<Patient> patients = new List<Patient>();

            Regex phoneRegEx = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"); //Check for phone number
            Match m = phoneRegEx.Match(searchCriteria); //Check if the search string matches the phone number
            if (m.Success)
            {
                //Format the phone number to 'XXXXXXXXXX' format to search for it
                string formattedPhoneNumber = phoneRegEx.Replace(m.ToString(), "$1$2$3");

                patients = new PatientRepository().FindByPhoneNumber(formattedPhoneNumber);
            }

            return View(patients);
        }

        public JsonResult AddAllergy()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                string allergyName = Request.Form["allergyName"];

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientId);
                Allergy allergy = new Allergy();
                allergy.Name = allergyName;
                patient.Allergies.Add(allergy);

                return Json(new
                {
                    error = "false",
                    status = "Added allergy: " + allergyName + " successfully",
                    allergy = allergy
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Unable to add allergy successfully",
                    errorMessage = e.Message
                });
            }
        }


        public JsonResult RemoveAllergy()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                int allergyId = int.Parse(Request.Form["allergyID"]);

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientId);
                string name = "";
                bool found = false;
                foreach (var allergy in patient.Allergies)
                {
                    if (allergyId == allergy.Id)
                    {
                        found = true;
                        name = allergy.Name;
                        patient.Allergies.Remove(allergy);
                        break;
                    }
                }

                UnitOfWork.CurrentSession.Flush();
                if (found)
                {
                    return Json(new
                    {
                        error = "false",
                        status = "Removed allergy: " + name + " successfully"
                    });
                }
                else
                {
                    return Json(new
                    {
                        error = "true",
                        status = "Allergy not found, please refresh the page and try again",
                        errorMessage = "Allergy with id: " + allergyId + " not found"
                    });
                }
            }
            catch (Exception e)
            {
                return Json(new
                {
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
                if (Request.Form["height"]!="")
                    vitals.Height = double.Parse(Request.Form["height"]);
                if (Request.Form["weight"] != "")
                    vitals.Weight = double.Parse(Request.Form["weight"]);
                if (Request.Form["BpDiastolic"] != "" && Request.Form["BpSystolic"] != "")
                {
                    BloodPressure bp = new BloodPressure();
                    bp.Diastolic = int.Parse(Request.Form["BpDiastolic"]);
                    bp.Systolic = int.Parse(Request.Form["BpSystolic"]);
                    vitals.BloodPressure = bp;
                }
                if (Request.Form["HeartRate"] != "")
                    vitals.HeartRate = int.Parse(Request.Form["HeartRate"]);
                if (Request.Form["RespiratoryRate"] != "")
                    vitals.RespiratoryRate = int.Parse(Request.Form["RespiratoryRate"]);
                if (Request.Form["Temperature"] != "")
                    vitals.Temperature = float.Parse(Request.Form["Temperature"]);
                vitals.Type = VitalsType.Initial;
                vitals.Time = DateTime.Now;
                vitals.PatientCheckIn = patient.PatientCheckIns[0];
                vitals.IsActive = true;
                patient.PatientCheckIns[0].Vitals.Add(vitals);

                return Json(new {
                    error = "false",
                    status = "Successfully added vital.",
                    date = vitals.Time.ToString("MM/dd/yyyy HH:mm:ss"),
                    height = vitals.Height,
                    weight = vitals.Weight,
                    bpDiastolic = vitals.BloodPressure.Diastolic,
                    bpSystolic = vitals.BloodPressure.Systolic,
                    heartRate = vitals.HeartRate,
                    respiratoryRate = vitals.RespiratoryRate,
                    temperature = vitals.Temperature
                });
            } catch (Exception e) {
                return Json(new {
                    error = "true",
                    status = e.Message
                });
            }
        }

        [HttpPost]
        public ActionResult SearchVisit(FormCollection value1, FormCollection value2)
        {
            //Values from textboxes
            DateTime searchCriteria1 = DateTime.Parse(value1["from"]);
            DateTime searchCriteria2 = DateTime.Parse(value2["to"]);

            IList<PatientCheckIn> pci = new List<PatientCheckIn>();

            var list = from blah in pci
                       where blah.CheckInTime >= searchCriteria1 && blah.CheckInTime <= searchCriteria2
                       select blah;

            return Json(list);
        }
    }
}
