using System;
using System.Collections.Generic;
using System.Linq;
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


        public RedirectResult AddProductLineItem(int invoiceId)
        {
            InvoiceItem lineItem = new InvoiceItem();
            lineItem.Invoice = new InvoiceRepository().Get(invoiceId);
            lineItem.IsActive = true;
            lineItem.Product = new ProductRepository().Get(1);
            lineItem.Quantity = 1;

            new InvoiceRepository().AddLineItem(lineItem);
            return new RedirectResult("/Billing/Edit/" + invoiceId);
        }

        public ActionResult Service(int invoiceId)
        {
            var lineItem = new InvoiceItem();
            var repo = new InvoiceRepository();
            lineItem.Service = new ServiceRepository().Get(1);
            lineItem.Invoice = repo.Get(invoiceId);
            lineItem.IsActive = true;
            repo.AddLineItem(lineItem);
            

            return View(lineItem);
        }

        [HttpPost]
        public ActionResult Service(InvoiceItem lineItem)
        {
            //add save code here?
            try
            {
                BillingEditViewModel invoice = new BillingEditViewModel(lineItem.Invoice.Id);
                invoice.Save();
                return RedirectToAction("Edit");
            }
            catch
            {
                return RedirectToAction("Index");
            }

        }

        public RedirectResult SaveLineItem(int itemId, int productId, int serviceId, int quantity)
        {
            InvoiceItem lineItem = new InvoiceRepository().GetItem(itemId);
            if (serviceId == 0)
            {
                lineItem.Product = new ProductRepository().Get(productId);
            }
            if (productId == 0)
            {
                lineItem.Service = new ServiceRepository().Get(serviceId);
            }
            lineItem.Quantity = quantity;
            new InvoiceRepository().AddLineItem(lineItem);

            return new RedirectResult("/Billing/Edit/" + lineItem.Invoice.Id);
        }


        public JsonResult AddPayment()
        {
            try
            {
                PaymentRepository paymentRepo = new PaymentRepository();

                Payment payment = new Payment();
                payment.IsActive = true;
                payment.CashAmount = decimal.Parse(Request.Form["Amount"]);
                payment.Invoice = new InvoiceRepository().Get(int.Parse(Request.Form["InvoiceId"]));
                payment.PaymentDate = DateTime.Now;

                paymentRepo.Add(payment);

                return Json(new
                {
                    error = false,
                    Date = payment.PaymentDate.ToString(),
                    Amount = payment.CashAmount.ToString("c")
                });
            }
            catch
            {
                return Json(new
                {
                    error = true
                });
            }
        }

        /*
        //Trying to get search box to work
        public JsonResult InvoiceSearch()
        {
            //var search

            //return Json();
        }
         */
    }
}
