using System;
using System.Collections;
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
                Location loc = new Location();
                PatientRepository patientRepo = new PatientRepository();
                

                string department = Request.Form["loc"];
                loc.Department = department;

                var myLocation = new Location { Department = department };

                var list = patientRepo.FindByLocation(myLocation);

                var resultList = from test in list
                                 select test;

                return Json(new
                {
                    error = "false",
                    status = "Successfully.",
                    //loc.Department
                    //list
                    //resultList
                });

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    error = "true",
                    status = "Didnt work"
                });
            }
        }

    }
}
