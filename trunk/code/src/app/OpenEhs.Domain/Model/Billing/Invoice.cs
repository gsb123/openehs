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
        #region Fields

        private int _id;
        private decimal _total;
        private DateTime _date;
        private Patient _patient;
        private readonly IList<InvoiceLineItem> _lineItems;
        private PatientCheckIn _patientcheckinid; // NOTE: So what exactly does a check-in object have to do with an Invoice?

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public DateTime Date
        {
            get { return _date; }
            set { _date = value; }
        }

        public Patient Patient
        {
            get { return _patient; }
            set { _patient = value; }
        }

        public IList<InvoiceLineItem> LineItems
        {
            get
            {
                return _lineItems;
            }
        }

        public PatientCheckIn PatientCheckIn
        {
            get { return _patientcheckinid; }
            set { _patientcheckinid = value; }
        }

        #endregion

        #region Constructor(s)

        public Invoice(int id, decimal total, DateTime date, Patient patient, IList<InvoiceLineItem> lineItems, PatientCheckIn patientCheckin)
        {
            Id = id;
            Total = total;
            Date = date;
            Patient = patient;
            _lineItems = lineItems;
            PatientCheckIn = patientCheckin;
        }

        #endregion
    }
}
