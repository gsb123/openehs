using System;
using System.Linq;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class DashboardController : Controller
    {
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
                PatientRepository patientRepo = new PatientRepository();


                /*
                var result = from checkin in PatientCheckIns
                             where CheckOutTime == DateTime.MinValue
                             select checkin;
                */

              
                return Json(new
                {
                    error = "false",
                    status = "Successfully.",
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
