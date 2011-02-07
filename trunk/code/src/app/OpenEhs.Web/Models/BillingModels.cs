using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenEhs.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace OpenEhs.Web.Models
{

    #region Models

    public class BillingList
    {
        private Patient _patient;
        private IList<Invoice> _invoices;
        private IList<Payment> _payment;

        [Required]
        [DisplayName("ID")]
        public int Id
        {
            get
            {
                return _patient.Id;
            }
        }



        //public ActionResult Index()
        //{
        //    return View();
        //}

    }

    #endregion
}
