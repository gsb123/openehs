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
            Regex dobRegEx = new Regex(@"(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})|(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))|(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})");
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

                //Find any patients with this Phone Number
                IList<Patient> phonePatients = new PatientRepository().FindByPhoneNumber(formattedPhoneNumber);

                patients = patients.Union<Patient>(phonePatients);  //Add them to the result set
            }

            //Check if the search criteria contains a Patient ID (6 character numeric string)
            Regex idRegEx = new Regex(@"[0-9]{6}"); //Check for Patient ID number
            m = idRegEx.Match(searchCriteria);  //Check if the search string contains the Patient ID
            if (m.Success)
            {
                //Find any patients with a matching ID
                IList<Patient> idPatients = new PatientRepository().FindByPatientID(Convert.ToInt32(m.ToString()));

                patients = patients.Union<Patient>(idPatients); //Add them to the result set
            }

            //Check if the search criteria contains a Patient ID (6 character numeric string)
            Regex physicalIdRegEx = new Regex(@"[0-9]{6,10}"); //Check for Patient ID number
            m = physicalIdRegEx.Match(searchCriteria);  //Check if the search string contains the Patient ID
            if (m.Success)
            {
                //Find any patients with a matching ID
                IList<Patient> physicalIdPatients = new PatientRepository().FindByOldPhysicalRecord(Convert.ToInt32(m.ToString()));

                patients = patients.Union<Patient>(physicalIdPatients); //Add them to the result set
            }

            //Check if the search criteria contains a Patient name
            Regex nameRegEx = new Regex(@"[a-zA-Z]+"); //Check for Patient name
            string[] names = searchCriteria.Split(' ');
            foreach (string name in names)
            {
                m = nameRegEx.Match(name);  //Check if the search string contains a Patient name
                if (m.Success)
                {
                    //Find any patients with a matching name
                    IList<Patient> namePatients = new PatientRepository().FindByFirstName(m.ToString());
                    patients = patients.Union<Patient>(namePatients); //Add them to the result set

                    namePatients = new PatientRepository().FindByMiddleName(m.ToString());
                    patients = patients.Union<Patient>(namePatients); //Add them to the result set

                    namePatients = new PatientRepository().FindByLastName(m.ToString());
                    patients = patients.Union<Patient>(namePatients); //Add them to the result set
                }
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
                        status = "Removed allergy \"" + name + "\" successfully",
                        Id = allergyId
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

        public JsonResult AddVital()
        {
            try
            {
                //Get current patient object
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                //Get current open patient checkin 
                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == new DateTime(1, 1, 1, 0, 0, 0)
                            select checkin;

                //Create new vitals object and add appropriate parameters 
                Vitals vitals = new Vitals();
                vitals.PatientCheckIn = query.First<PatientCheckIn>();
                if (Request.Form["height"] != "")
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
                vitals.Type = (VitalsType)Enum.Parse(typeof(VitalsType), Request.Form["type"]);
                vitals.Time = DateTime.Now;
                //vitals.PatientCheckIn = patient.PatientCheckIns[0];
                vitals.IsActive = true;

                //Add new vitals object to patient
                patient.PatientCheckIns[0].Vitals.Add(vitals);

                //Return results as JSON
                return Json(new
                {
                    error = "false",
                    status = "Successfully added vital.",
                    date = vitals.Time.ToString("MM/dd/yyyy HH:mm:ss"),
                    height = vitals.Height,
                    weight = vitals.Weight,
                    bpDiastolic = vitals.BloodPressure.Diastolic,
                    bpSystolic = vitals.BloodPressure.Systolic,
                    heartRate = vitals.HeartRate,
                    respiratoryRate = vitals.RespiratoryRate,
                    temperature = vitals.Temperature,
                    type = Enum.GetName(typeof(VitalsType), vitals.Type)
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

        public JsonResult AddCheckIn()
        {
            try
            {
                //Get patient object
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                //Get Staff Object
                int staffId = int.Parse(Request.Form["staffID"]);
                StaffRepository staffRepo = new StaffRepository();
                var staff = staffRepo.Get(staffId);

                //Get Location Object
                int locationId = int.Parse(Request.Form["locationID"]);
                LocationRepository locationRepo = new LocationRepository();
                var location = locationRepo.Get(locationId);

                //Build Check In Object
                PatientCheckIn checkin = new PatientCheckIn();
                checkin.Patient = patient;
                checkin.CheckInTime = DateTime.Now;
                checkin.PatientType = (PCIType)Enum.Parse(typeof(PCIType), Request.Form["patientType"]);
                checkin.AttendingStaff = staff;
                checkin.Location = location;

                //Build Invoice Object
                Invoice invoice = new Invoice();
                invoice.PatientCheckIn = checkin;
                checkin.Invoice = invoice;

                patient.PatientCheckIns.Add(checkin);

                return Json(new
                {
                    error = "false"
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

        public JsonResult GetCurrentCheckin()
        {
            try {
                //Get patient object
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == new DateTime(1, 1, 1, 0, 0, 0)
                            select checkin;
                
                
                if (query.Count<PatientCheckIn>() > 0)
                {
                    PatientCheckIn checkIn = query.First<PatientCheckIn>();
                    return Json(new
                    {
                        error = "false",
                        checkin = checkIn.Id
                    });
                }
                else
                {
                    
                    return Json(new
                    {
                        error="false",
                        checkin = "null"
                    });
                }
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
        public JsonResult SearchVisit()
        {
            int patientID = int.Parse(Request.Form["patientID"]);
            PatientRepository patientRepo = new PatientRepository();
            var patient = patientRepo.Get(patientID);

            DateTime fromDate = DateTime.Parse(Request.Form["from"]);
            DateTime toDate = DateTime.Parse(Request.Form["to"]);

            var query = from checkin in patient.PatientCheckIns
                        where checkin.CheckInTime >= fromDate && checkin.CheckInTime <= toDate
                        select checkin;

            var resultSet = new List<object>();
            var jsonResult = new JsonResult();

            foreach (var result in query)
            {
                IList<object> vitalsList = new List<object>();

                resultSet.Add(new
                                  {
                                      //TODO: Need to fix how the time is...
                                      date = result.CheckInTime.ToString("dd/MM/yyyy HH:mm:ss")
                                  });
            }

            jsonResult.Data = resultSet;

            return jsonResult;
        }

        public JsonResult SelectVisit()
        {
            int patientID = int.Parse(Request.Form["patientID"]);
            PatientRepository patientRepo = new PatientRepository();
            var patient = patientRepo.Get(patientID);

            DateTime fromDate = DateTime.Parse(Request.Form["from"]);
            DateTime toDate = DateTime.Parse(Request.Form["to"]);

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
                        Time = vitals.Time.ToString("dd/MM/yyyy HH:mm:ss"),
                        //vitals.Type,
                        type = Enum.GetName(typeof(VitalsType), vitals.Type),
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
                    //TODO: Need to fix how the time is...
                    date = result.CheckInTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    result.Diagnosis,
                    Vitals = vitalsList
                });
            }

            jsonResult.Data = resultSet;

            return jsonResult;
        }
    }
}
