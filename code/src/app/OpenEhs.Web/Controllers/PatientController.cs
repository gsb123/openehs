using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;
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

            //If the search field is empty then return all results
            if (string.IsNullOrEmpty(searchCriteria))
                return View(new PatientRepository().GetAll());
            
            IEnumerable<Patient> patients = new List<Patient>();

            //Check if the search criteria contains a Date of Birth
            Regex dobRegEx = new Regex(@"(((0[1-9]|[12]\d|3[01])\/(0[13578]|1[02])\/((19|[2-9]\d)\d{2}))|((0[1-9]|[12]\d|30)\/(0[13456789]|1[012])\/((19|[2-9]\d)\d{2}))|((0[1-9]|1\d|2[0-8])\/02\/((19|[2-9]\d)\d{2}))|(29\/02\/((1[6-9]|[2-9]\d)(0[48]|[2468][048]|[13579][26])|((16|[2468][048]|[3579][26])00))))");
            Match m = dobRegEx.Match(searchCriteria);
            if (m.Success)
            {
                //Parse the DOB to English (en) Great Britain (GB) format 'DD/MM/YYYY' for Ghana
                DateTime dob = DateTime.Parse(m.ToString(), new CultureInfo("en-GB"));

                IList<Patient> dobPatients = new PatientRepository().FindByDateOfBirth(dob);    //Find any patients with this DOB

                patients = patients.Union<Patient>(dobPatients); //Add them to the result set
            }

            //Check if the search criteria contains a Phone Number
            Regex phoneRegEx = new Regex(@"\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})"); //Check for phone number
            m = phoneRegEx.Match(searchCriteria); //Check if the search string matches the phone number
            if (m.Success)
            {
                //Format the phone number to 'XXXXXXXXXX' format to search for it
                string formattedPhoneNumber = phoneRegEx.Replace(m.ToString(), "$1$2$3");

                IList<Patient> phonePatients = new PatientRepository().FindByPhoneNumber(formattedPhoneNumber); //Find any patients with this Phone Number

                patients = patients.Union<Patient>(phonePatients);  //Add them to the result set
            }

            return View(patients);  //Return the merged result set with no duplicates
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

        public JsonResult SearchVisit()
        {
            int patientID = int.Parse(Request.Form["patientID"]);
            PatientRepository patientRepo = new PatientRepository();
            var patient = patientRepo.Get(patientID);

            //PatientCheckIn checkIn = new PatientCheckIn();

            DateTime fromDate = DateTime.Parse(Request.Form["from"]);
            DateTime toDate = DateTime.Parse(Request.Form["to"]);


            //IList<PatientCheckIn> pci = new List<PatientCheckIn>();

            var query = from checkin in patient.PatientCheckIns
                       where checkin.CheckInTime >= fromDate && checkin.CheckInTime <= toDate
                       select checkin;

            var resultSet = new List<object>();
            var jsonResult = new JsonResult();

            foreach (var result in query)
            {
                IList<object> vitalsList = new List<object>();

                foreach (var vitals in result.Vitals)
                {
                    vitalsList.Add(new
                    {
                        Time = vitals.Time,
                        Type = vitals.Type,
                        Height = vitals.Height,
                        Weight = vitals.Weight,
                        Temperature = vitals.Temperature,
                        HeartRate = vitals.HeartRate,
                        BpDiastolic = vitals.BloodPressure.Diastolic,
                        BpSystolic = vitals.BloodPressure.Systolic,
                        RespiratoryRate = vitals.RespiratoryRate
                    });
                }

                resultSet.Add(new
                                  {
                                      result.CheckInTime, 
                                      result.Diagnosis,
                                      Vitals = vitalsList
                });
            }

            jsonResult.Data = resultSet;

            return jsonResult;
        }
    }
}
