using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenEhs.Domain;
using OpenEhs.Data;

namespace OpenEhs.Web.Controllers
{
    public class EmergencyContactController : Controller
    {
        //
        // GET: /EmergencyContact/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /EmergencyContact/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /EmergencyContact/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /EmergencyContact/Create

        [HttpPost]
        public ActionResult Create(EmergencyContact emergencyContact)
        {
            try
            {
                var repository = new EmergencyContactRepository();
                repository.Add(emergencyContact);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /EmergencyContact/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /EmergencyContact/Edit/5

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
        // GET: /EmergencyContact/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /EmergencyContact/Delete/5

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
