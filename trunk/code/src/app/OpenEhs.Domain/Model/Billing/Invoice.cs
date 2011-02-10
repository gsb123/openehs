/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Invoice : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual decimal Total
        {
            get
            {
                var total = 0.0m;

                foreach (var item in InvoiceItems)
                {
                    total += item.Total;
                }

                return total;
            }
        }
        public virtual DateTime Date { get; set; }
        public virtual IList<InvoiceItem> InvoiceItems { get; set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }
        public virtual IList<Payment> Payments { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        #region Methods

        public virtual void AddLineItem(InvoiceItem item)
        {
            InvoiceItems.Add(item);
        }

        public virtual void RemoveLineItem(InvoiceItem item)
        {
            InvoiceItems.Remove(item);
        }

        #endregion
    }
}
