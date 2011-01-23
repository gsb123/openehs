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
    public class Invoice
    {
        #region Properties

        public virtual int Id { get; set; }
        public virtual decimal Total { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual IList<InvoiceLineItem> LineItems { get; private set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }

        #endregion

        #region Constructor
        
        public Invoice()
        {
            LineItems = new List<InvoiceLineItem>();
        }

        #endregion
    }
}
