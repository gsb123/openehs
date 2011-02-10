using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenEhs.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using OpenEhs.Data;

namespace OpenEhs.Web.Models
{

    #region Models

    public class BillingViewModel
    {
        
        private Invoice _invoice;
        private Payment _payment;

        #region Billing
        /*
        [Required]
        [DisplayName("Patient ID")]
        public int PatientId
        {
            get
            {
                return _invoice.Patient.Id;
            }

            set
            {
                _invoice.Patient = new PatientRepository().Get(value);
            }
        }

        [DisplayName("Patient First Name")]
        public string PatientFirstName
        {
            get
            {
                return _invoice.Patient.FirstName;
            }
        }

        [DisplayName("Patient Last Name")]
        public string PatientLastName
        {
            get
            {
                return _invoice.Patient.LastName;
            }
        }

        [DisplayName("Patient Middle Name")]
        public string PatientMiddleName
        {
            get
            {
                return _invoice.Patient.MiddleName;
            }
        }
        */
        [Required]
        [DisplayName("Invoice ID")]
        public int Id
        {
            get
            {
                return _invoice.Id;
            }
        }
        
        [Required]
        [DisplayName("Total")]
        public decimal Total
        {
            get
            {
                return _invoice.Total;
            }
        }

        [Required]
        [DisplayName("Line Items")]
        public IList<InvoiceItem> LineItems
        {
            get
            {
                return _invoice.Items;
            }

            set
            {
                _invoice.Items = value;
            }
        }

        [Required]
        [DisplayName("Date")]
        public DateTime Date
        {
            get
            {
                return _invoice.Date;
            }

            set
            {
                _invoice.Date = value;
            }
        }
                
        /// <summary>
        /// Adds an InvoiceLineItem to this Invoice.
        /// </summary>
        /// <param name="lineItem">The InvoiceLineItem to add to this Invoice.</param>
        public void AddLineItem(InvoiceItem lineItem)
        {
            _invoice.Items.Add(lineItem);
        }

        /// <summary>
        /// Removes one InvoiceLineItem from this Invoice.
        /// </summary>
        /// <param name="lineItem">The InvoiceLineItem to remove from the Invoice.</param>
        public void RemoveLineItem(InvoiceItem lineItem)
        {
            _invoice.Items.Remove(lineItem);
        }

        #endregion

    }

    #endregion
}
