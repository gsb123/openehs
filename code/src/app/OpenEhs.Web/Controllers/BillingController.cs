using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;

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
            var invoice = new InvoiceRepository().Get(id);

            return View(invoice);
        }

    }
}
