using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenEhs.Data;

namespace OpenEhs.Web.Controllers
{
    public class BillingController : Controller
    {
        //
        // GET: /Billing/


        public ActionResult Index()
        {
            var billing = new InvoiceRepository().GetAll();

            return View(billing);
        }

        
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            var invoice = new InvoiceRepository().Get(id);

            return View(invoice);
        }

    }
}
