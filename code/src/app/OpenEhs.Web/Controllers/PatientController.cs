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
        #region ActionResults

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
                IList<Patient> idPatients = new PatientRepository().FindByPatientId(Convert.ToInt32(m.ToString()));

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

        #endregion

        #region JsonResults

        #region CreatePatient

        public JsonResult CreatePatient()
        {
            try
            {
                Patient patient = new Patient();
                patient.IsActive = true;

                patient.FirstName = Request.Form["p_firstName"];
                patient.MiddleName = Request.Form["p_middleName"];
                patient.LastName = Request.Form["p_lastName"];
                patient.DateOfBirth = DateTime.Parse(Request.Form["p_dob"]);
                patient.Gender = Request.Form["p_gender"];
                patient.PhoneNumber = Request.Form["p_phoneNumber"];
                patient.BloodType = Request.Form["p_bloodType"];
                patient.TribeRace = Request.Form["p_tribeRace"];
                patient.Religion = Request.Form["p_religion"];

                // Address
                patient.Address.IsActive = true;
                patient.Address.Street1 = Request.Form["p_address_street1"];
                patient.Address.Street2 = Request.Form["p_address_street2"];
                patient.Address.City = Request.Form["p_address_City"];
                patient.Address.Region = Request.Form["p_address_Region"];
                patient.Address.Country = Request.Form["p_address_Country"];

                try
                {
                    patient.OldPhysicalRecordNumber = Request.Form["oldPhysicalRecordNumber"];
                }
                catch (ArgumentNullException)
                {
                    // No op
                }

                patient.EmergencyContact.IsActive = true;
                patient.EmergencyContact.FirstName = Request.Form["emergency_firstName"];
                patient.EmergencyContact.LastName = Request.Form["emergency_lastname"];
                try
                {
                    patient.EmergencyContact.Relationship = (Relationship)int.Parse(Request.Form["emergency_relationship"]);
                }
                catch (ArgumentNullException)
                {
                    ArgumentNullException e = new ArgumentNullException("A relationship must be selected for the emergency contact");
                    throw e;
                }
                patient.EmergencyContact.PhoneNumber = Request.Form["emergency_phonenumber"];

                patient.EmergencyContact.Address.IsActive = true;
                patient.EmergencyContact.Address.Street1 = Request.Form["ec_address_street1"];
                patient.EmergencyContact.Address.Street2 = Request.Form["ec_address_street2"];
                patient.EmergencyContact.Address.City = Request.Form["ec_address_City"];
                patient.EmergencyContact.Address.Region = Request.Form["ec_address_Region"];
                patient.EmergencyContact.Address.Country = Request.Form["ec_address_Country"];

                return Json(new
                {
                    error = "false",
                    status = "Created new patient successfully",
                    patient = patient
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Error while creating new patient.",
                    errorMessage = e.Message
                });
            }
        }

        #endregion

        #region FeedChart

        public JsonResult AddFeed()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientId);

                //Get current open patient checkin 
                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;
                PatientCheckIn openCheckIn = query.First<PatientCheckIn>();

                //Create new feed chart object and add appropriate parameters 
                FeedChart feedchart = new FeedChart();

                feedchart.PatientCheckIn = openCheckIn;

                feedchart.FeedTime = DateTime.Now;

                string feedType = Request.Form["feedType"];
                feedchart.FeedType = feedType;

                string amountOffered = Request.Form["amountOffered"];
                feedchart.AmountOffered = amountOffered;

                string amountTaken = Request.Form["amountTaken"];
                feedchart.AmountTaken = amountTaken;

                string vomit = Request.Form["vomit"];
                feedchart.Vomit = vomit;

                string urine = Request.Form["urine"];
                feedchart.Urine = urine;

                string stool = Request.Form["stool"];
                feedchart.Stool = stool;

                string comments = Request.Form["comments"];
                feedchart.Comments = comments;


                //Add new feed chart object to patient
                openCheckIn.FeedChart.Add(feedchart);

                //Return results as JSON
                return Json(new
                {
                    error = "false",
                    status = "Successfully added chart.",
                    Date =feedchart.FeedTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    feedchart.FeedType,
                    feedchart.AmountOffered,
                    feedchart.AmountTaken,
                    feedchart.Vomit,
                    feedchart.Urine,
                    feedchart.Stool,
                    feedchart.Comments
                });

            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Unable to add feed chart successfully",
                    errorMessage = e.Message
                });
            }
        }

        public JsonResult AddIntake()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientId);

                //Get current open patient checkin 
                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;
                PatientCheckIn openCheckIn = query.First<PatientCheckIn>();

                //Create new intake chart object and add appropriate parameters 
                IntakeChart intakechart = new IntakeChart();

                intakechart.PatientCheckIn = openCheckIn;

                intakechart.ChartTime = DateTime.Now;

                string kindoffluid = Request.Form["kindoffluid"];
                intakechart.KindOfFluid = kindoffluid;

                string amount = Request.Form["amount"];
                intakechart.Amount = amount;

                //Add new intake object to patient
                openCheckIn.IntakeChart.Add(intakechart);

                //Return results as JSON
                return Json(new
                {
                    error = "false",
                    status = "Successfully added chart.",
                    Date = intakechart.ChartTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    intakechart.KindOfFluid,
                    intakechart.Amount
                });

            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Unable to add intake chart successfully",
                    errorMessage = e.Message
                });
            }
        }

        public JsonResult AddOutput()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientId);

                //Get current open patient checkin 
                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;
                PatientCheckIn openCheckIn = query.First<PatientCheckIn>();

                //Create new intake chart object and add appropriate parameters 
                OutputChart outputchart = new OutputChart();

                outputchart.PatientCheckIn = openCheckIn;

                outputchart.ChartTime = DateTime.Now;

                string ngAmount = Request.Form["ngAmount"];
                outputchart.NGSuctionAmount = ngAmount;

                string ngColor = Request.Form["ngColor"];
                outputchart.NGSuctionColor = ngColor;

                string urineAmount = Request.Form["urineAmount"];
                outputchart.UrineAmount = urineAmount;

                string stoolAmount = Request.Form["stoolAmount"];
                outputchart.StoolAmount = stoolAmount;

                string stoolColor = Request.Form["stoolColor"];
                outputchart.StoolColor = stoolColor;

                //Add new output object to patient
                openCheckIn.OutputChart.Add(outputchart);

                //Return results as JSON
                return Json(new
                {
                    error = "false",
                    status = "Successfully added chart.",
                    Date = outputchart.ChartTime.ToString("dd/MM/yyyy HH:mm:ss"),
                    outputchart.NGSuctionAmount,
                    outputchart.NGSuctionColor,
                    outputchart.UrineAmount,
                    outputchart.StoolAmount,
                    outputchart.StoolColor
                });

            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Unable to add intake chart successfully",
                    errorMessage = e.Message
                });
            }
        }

        #endregion

        #region Allergy

        public JsonResult AddAllergy()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                string allergyName = Request.Form["allergyName"];

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientId);

                Allergy allergy = new Allergy();
                allergy.IsActive = true;
                allergy.Name = allergyName;
                patient.Allergies.Add(allergy);

                UnitOfWork.CurrentSession.Flush();

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

        #endregion

        #region Vitals

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
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;
                PatientCheckIn openCheckIn = query.First<PatientCheckIn>();

                //Create new vitals object and add appropriate parameters 
                Vitals vitals = new Vitals();
                vitals.PatientCheckIn = openCheckIn;
                if (Request.Form["height"] != "")
                    vitals.Height = double.Parse(Request.Form["height"]);
                if (Request.Form["weight"] != "")
                    vitals.Weight = double.Parse(Request.Form["weight"]);

                BloodPressure bp = new BloodPressure();
                if (Request.Form["BpDiastolic"] != "" && Request.Form["BpSystolic"] != "")
                {
                    bp.Diastolic = int.Parse(Request.Form["BpDiastolic"]);
                    bp.Systolic = int.Parse(Request.Form["BpSystolic"]);
                }
                vitals.BloodPressure = bp;
                if (Request.Form["HeartRate"] != "")
                    vitals.HeartRate = int.Parse(Request.Form["HeartRate"]);
                if (Request.Form["RespiratoryRate"] != "")
                    vitals.RespiratoryRate = int.Parse(Request.Form["RespiratoryRate"]);
                if (Request.Form["Temperature"] != "")
                    vitals.Temperature = float.Parse(Request.Form["Temperature"]);
                vitals.Type = (VitalsType)Enum.Parse(typeof(VitalsType), Request.Form["type"]);
                vitals.Time = DateTime.Now;
                vitals.IsActive = true;

                //Add new vitals object to patient
                openCheckIn.Vitals.Add(vitals);

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

        #endregion

        #region Checkin/Checkout

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
                checkin.PatientType = (PatientCheckinType)Enum.Parse(typeof(PatientCheckinType), Request.Form["patientType"]);
                checkin.AttendingStaff = staff;
                checkin.Location = location;
                checkin.IsActive = true;

                //Build Invoice Object
                Invoice invoice = new Invoice();
                invoice.PatientCheckIn = checkin;
                checkin.Invoice = invoice;

                patient.PatientCheckIns.Add(checkin);
                //new InvoiceRepository().Add(invoice);

                return Json(new
                {
                    error = "false",
                message = checkin
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

        public JsonResult CheckOut()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientId);

                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;

                PatientCheckIn checkIn = query.First<PatientCheckIn>();
                checkIn.CheckOutTime = DateTime.Now;
                checkIn.Diagnosis = Request.Form["diagnosis"];

                if (Request.Form["deceased"] == "on")
                {
                    checkIn.Dead = true;
                    checkIn.TimeOfDeath = DateTime.Parse(Request.Form["timeOfDeath"]);
                    patient.DateOfBirth = DateTime.Parse(Request.Form["timeOfDeath"]);
                }

                var surgeryQuery = from surgery in checkIn.Surgeries
                                   where surgery.EndTime == DateTime.MinValue
                                   select surgery;

                if (surgeryQuery.Count<Surgery>() > 0)
                {
                    Surgery openSurgery = surgeryQuery.First<Surgery>();
                    openSurgery.EndTime = DateTime.Now;
                }

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
            try
            {
                //Get patient object
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
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
                        error = "false",
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

        #endregion

        #region Visit

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
                    date = result.CheckInTime.ToString("dd/MM/yyyy HH:mm:ss")
                });
            }

            jsonResult.Data = resultSet;

            return jsonResult;
        }

        public JsonResult SearchVisitList()
        {
            try
            {

                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                int checkInID = int.Parse(Request.Form["checkInID"]);

                var query = from checkin in patient.PatientCheckIns
                            where checkin.Id == checkInID
                            select checkin;

                var resultSet = new List<object>();
                var jsonResult = new JsonResult();

                foreach (var result in query)
                {
                    IList<object> visitList = new List<object>();

                    foreach (var vitals in result.Vitals)
                    {
                        visitList.Add(new
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
                        date = result.CheckInTime.ToString("dd/MM/yyyy HH:mm:ss"),
                        result.Diagnosis,
                        firstName = result.AttendingStaff.FirstName,
                        lastName =  result.AttendingStaff.LastName,
                        Vitals = visitList
                    });
                }

                jsonResult.Data = resultSet;

                return jsonResult;
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Unable to fetch list successfully",
                    errorMessage = e.Message
                });
            }
        }

        #endregion

        #region Surgery

        public JsonResult AddSurgery()
        {
            try
            {
                //Build surgery objects
                Surgery surgery = new Surgery();

                //Get patient object
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                //Get current open patient checkin 
                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;
                PatientCheckIn openCheckIn = query.First<PatientCheckIn>();

                //Surgery Staff Repository
                StaffRepository staffRepo = new StaffRepository();

                LocationRepository locationRepo = new LocationRepository();
                surgery.Location = locationRepo.Get(int.Parse(Request.Form["theatreNumber"]));

                surgery.StartTime = DateTime.Parse(Request.Form["startTime"]);
                surgery.EndTime = DateTime.Parse(Request.Form["endTime"]);

                //Add to checkin
                openCheckIn.Surgeries.Add(surgery);
                surgery.CheckIn = openCheckIn;
                surgery.CaseType = (CaseType)Enum.Parse(typeof(CaseType), Request.Form["caseType"]);

                UnitOfWork.CurrentSession.Flush();

                //Surgeon
                if (Request.Form["surgeon"] != "")
                {
                    Staff staff = staffRepo.Get(int.Parse(Request.Form["surgeon"]));

                    SurgeryStaff surgeon = new SurgeryStaff();
                    surgeon.Staff = staff;
                    surgeon.Surgery = surgery;
                    surgeon.Role = StaffRole.Surgeon;
                    UnitOfWork.CurrentSession.Flush();
                }
                /*
                //Surgeon Assistant
                if (Request.Form["surgeonAssistant"] != "")
                {
                    SurgeryStaff surgeonAssistant = new SurgeryStaff();
                    surgeonAssistant.Staff = staffRepo.Get(int.Parse(Request.Form["surgeonAssistant"]));
                    //surgeonAssistant.Role = StaffRole.SurgeonAssistant;
                    surgeonAssistant.Surgery = surgery;
                    //surgery.Staff.Add(surgeonAssistant);
                }
                //Anaesthetist
                if (Request.Form["anaesthetist"] != "")
                {
                    SurgeryStaff anaesthetist = new SurgeryStaff();
                    anaesthetist.Staff = staffRepo.Get(int.Parse(Request.Form["anaesthetist"]));
                    //anaesthetist.Role = StaffRole.Anaesthetist;
                    anaesthetist.Surgery = surgery;
                    //surgery.Staff.Add(anaesthetist);
                }
                //Anaesthetist Assistant
                if (Request.Form["anaesthetistAssistant"] != "")
                {
                    SurgeryStaff anaesthetistAssistant = new SurgeryStaff();
                    anaesthetistAssistant.Staff = staffRepo.Get(int.Parse(Request.Form["anaesthetistAssistant"]));
                    //anaesthetistAssistant.Role = StaffRole.AnaesthetistAssistant;
                    anaesthetistAssistant.Surgery = surgery;
                    //surgery.Staff.Add(anaesthetistAssistant);
                }
                //Nurse
                if (Request.Form["nurse"] != "")
                {
                    SurgeryStaff nurse = new SurgeryStaff();
                    nurse.Staff = staffRepo.Get(int.Parse(Request.Form["nurse"]));
                    //nurse.Role = StaffRole.Nurse;
                    nurse.Surgery = surgery;
                    //surgery.Staff.Add(nurse);
                }
                //Consultant
                if (Request.Form["consultant"] != "")
                {
                    SurgeryStaff consultant = new SurgeryStaff();
                    consultant.Staff = staffRepo.Get(int.Parse(Request.Form["consultant"]));
                    //consultant.Role = StaffRole.Consultant;
                    consultant.Surgery = surgery;
                    //surgery.Staff.Add(consultant);
                }

                */

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

        #endregion

        #region Medication

        public JsonResult AddMedication()
        {
            try
            {
                int patientId = int.Parse(Request.Form["patientID"]);
                string medicationName = Request.Form["name"];
                string medicationInstructions = Request.Form["instructions"];
                DateTime startDate = DateTime.Parse(Request.Form["startDate"]);
                DateTime expDate = DateTime.Parse(Request.Form["expDate"]);

                PatientRepository repo = new PatientRepository();
                var patient = repo.Get(patientId);
                Medication medication = new Medication();
                medication.Name = medicationName;
                medication.Instruction = medicationInstructions;
                medication.StartDate = startDate;
                medication.ExpDate = expDate;
                medication.Patient = patient;

                patient.Medications.Add(medication);

                UnitOfWork.CurrentSession.Flush();

                return Json(new
                {
                    error = "false",
                    status = "Added medication: " + medication.Name + " successfully",
                    // Need this fix for circular reference error
                    medication = new
                    {
                        id = medication.Id,
                        instructions = medication.Instruction,
                        name = medication.Name,
                        startDate = medication.StartDate.Date.ToString("dd/MM/yyyy"),
                        expDate = medication.ExpDate.Date.ToString("dd/MM/yyyy")
                    }
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    error = "true",
                    status = "Unable to add medication successfully",
                    errorMessage = e.Message
                });
            }
        }

        #endregion

        #region Billing

        public JsonResult AddInvoiceItem()
        {
            try
            {
                //Build Line Item objects
                InvoiceItem lineItem = new InvoiceItem();

                //Get patient object
                int patientID = int.Parse(Request.Form["patientID"]);
                PatientRepository patientRepo = new PatientRepository();
                var patient = patientRepo.Get(patientID);

                //Get current open patient checkin 
                var query = from checkin in patient.PatientCheckIns
                            where checkin.CheckOutTime == DateTime.MinValue
                            select checkin;
                PatientCheckIn openCheckIn = query.First<PatientCheckIn>();

                //Invoice Repository
                InvoiceRepository invoiceRepo = new InvoiceRepository();

                //Product Repository
                ProductRepository productRepo = new ProductRepository();

                //Service Repository
                ServiceRepository serviceRepo = new ServiceRepository();

                //Quantity
                if (Request.Form["quantity"] != "")
                {
                    lineItem.Quantity = int.Parse(Request.Form["quantity"]);
                    lineItem.Invoice = openCheckIn.Invoice;
                    lineItem.IsActive = true;

                    //Product
                    if (Request.Form["product"] != "")
                    {
                        lineItem.Product = productRepo.Get(int.Parse(Request.Form["product"]));
                        lineItem.Service = null;
                        invoiceRepo.AddLineItem(lineItem);
                        UnitOfWork.CurrentSession.Flush();
                    }
                    else if (Request.Form["service"] != "")
                    {
                        lineItem.Service = serviceRepo.Get(int.Parse(Request.Form["service"]));
                        lineItem.Product = null;
                        invoiceRepo.AddLineItem(lineItem);
                        UnitOfWork.CurrentSession.Flush();
                    }
                }


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


        #endregion

        #endregion
    }
}
