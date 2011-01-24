/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Payment
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual decimal CashAmount { get; set; }
        public virtual DateTime PaymentDate { get; set; }
        public virtual Invoice InvoiceID { get; set; }

        #endregion
    }
}
