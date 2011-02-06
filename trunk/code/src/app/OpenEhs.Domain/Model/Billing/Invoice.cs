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
    public class Invoice: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual decimal Total { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual IList<InvoiceLineItem> LineItems { get; set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        #region Methods

        public virtual void AddLineItem(InvoiceLineItem item)
        {
            LineItems.Add(item);
        }

        public virtual void RemoveLineItem(InvoiceLineItem item)
        {
            LineItems.Remove(item);
        }

        #endregion
    }
}
