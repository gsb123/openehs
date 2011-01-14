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
        #region Fields

        private int _id;
        private decimal _cashamount;
        private DateTime _paymentdate;
        private Invoice _invoiceid;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal CashAmount
        {
            get { return _cashamount; }
            set { _cashamount = value; }
        }

        public DateTime PaymentDate
        {
            get { return _paymentdate; }
            set { _paymentdate = value; }
        }

        public Invoice InvoiceID
        {
            get { return _invoiceid; }
            set { _invoiceid = value; }
        }

        #endregion

        #region Constructor(s)

        public Payment(int id, decimal cashamount, DateTime paymentdate, Invoice invoiceid)
        {
            Id = id;
            CashAmount = cashamount;
            PaymentDate = paymentdate;
            InvoiceID = invoiceid;
        }

        #endregion
    }
}
