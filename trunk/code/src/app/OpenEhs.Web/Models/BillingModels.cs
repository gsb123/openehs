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

    public class BillingModel
    {
        private Invoice _invoice;
        private Payment _payment;

        [Required]
        [DisplayName("Patient ID")]
        public int PatientId
        {
            get
            {
                return _invoice.Patient.Id;
            }
        }

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
            //should this iterate through the InvoiceLineItems and add the amounts to get the total?
            get
            {
                return _invoice.Total;

                /*
                 * like this?
                _invoice.Total = 0;
                foreach (InvoiceLineItem ILI in _invoice.LineItems)
                {
                    _invoice.Total += ILI.Total;
                }
                 */
            }

            //probably not needed?
            set
            {
                _invoice.Total = value;
            }
        }

        [Required]
        [DisplayName("Line Items")]
        public IList<InvoiceLineItem> LineItems
        {
            get
            {
                return _invoice.LineItems;
            }

            set
            {
                _invoice.LineItems = value;
            }
        }

        public void AddLineItem(InvoiceLineItem lineItem)
        {
            _invoice.LineItems.Add(lineItem);
        }

        public void RemoveLineItem(InvoiceLineItem lineItem)
        {
            _invoice.LineItems.Remove(lineItem);
        }


    }

    #endregion
}
