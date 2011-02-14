using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;
using OpenEhs.Web.Models;

namespace OpenEhs.Web.Controllers
{
    public class InvoiceController : Controller
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
            //and we're back to square one where I have to create a viewModel to return both items!
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
            return View();
        }

        //
        // POST: /Invoice/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
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
