using System.Web.Mvc;
using OpenEhs.Domain;
using OpenEhs.Web.Models;
using OpenEhs.Data;

namespace OpenEhs.Web.Controllers
{
    public class BillingController : Controller
    {
        //
        // GET: /Invoice/

        public ActionResult Index()
        {
            var invoices = new InvoiceRepository().GetAll();

            return View(invoices);
        }

        //
        // GET: /Invoice/Details/5

        public ActionResult Details(int id)
        {
            BillingViewModel billing = new BillingViewModel(id);

            return View(billing);
        }

        //
        // GET: /Invoice/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Invoice/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Invoice/Edit/5

        public ActionResult Edit(int id)
        {
            var invoice = new BillingEditViewModel(id);

            return View(invoice);
        }

        //
        // POST: /Invoice/Edit/5

        [HttpPost]
        public ActionResult Edit(BillingEditViewModel invoice)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View(invoice);
            }
        }

        //
        // GET: /Invoice/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Invoice/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
