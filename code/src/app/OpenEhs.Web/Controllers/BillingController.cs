using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class BillingController : Controller
    {
        //
        // GET: /Billing/


        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Invoice invoice)
        {
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            BillingViewModel billing = new BillingViewModel();
            billing.PatientId = id;
            return View(billing);
        }

        public ActionResult Edit(int id)
        {
            BillingViewModel billing = new BillingViewModel();
            billing.PatientId = id;

            return View(billing);
        }
    }
}
