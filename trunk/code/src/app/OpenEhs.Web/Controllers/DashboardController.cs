using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class DashboardController : Controller
    {
        private IPatientRepository _patientRepository;

        public DashboardController()
        {
            _patientRepository = new PatientRepository();
        }

        //
        // GET: /Dashboard/

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel();

            return View(viewModel);
        }

        public JsonResult ActiveCheckIns()
        {
            try
            {
                int loc = int.Parse(Request.Form["loc"]);

                var patients = _patientRepository.GetAll();

                var checkedInPatients = (from patient in patients
                                         from checkin in patient.PatientCheckIns
                                         where checkin.CheckOutTime == DateTime.MinValue && checkin.Location.Id == loc
                                         select patient).ToList();

                return Json(new
                {
                    error = "false",
                    status = "Successfully.",
                    checkedInPatients
                });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = "true"
                });
            }
        }

    }
}
