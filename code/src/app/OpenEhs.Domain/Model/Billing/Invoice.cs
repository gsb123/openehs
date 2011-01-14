using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Invoice
    {
        #region Fields

        private int _id;
        private decimal _total;
        private DateTime _date;
        private Patient _patientid;
        private PatientCheckIn _patientcheckinid;

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

        public Patient PatientID
        {
            get { return _patientid; }
            set { _patientid = value; }
        }

        public PatientCheckIn PatientCheckInID
        {
            get { return _patientcheckinid; }
            set { _patientcheckinid = value; }
        }

        #endregion

        #region Constructor(s)

        public Invoice(int id, decimal total, DateTime date, Patient patientid, PatientCheckIn patientcheckinid)
        {
            Id = id;
            Total = total;
            Date = date;
            PatientID = patientid;
            PatientCheckInID = patientcheckinid;
        }

        #endregion
    }
}
