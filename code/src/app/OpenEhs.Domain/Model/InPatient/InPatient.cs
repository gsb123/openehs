using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class InPatient
    {
        #region Fields

        private int _id;
        private PatientCheckIn _patientcheckinid;
        private string _admissionreason;
        private string _comments;
        private DateTime _admitdate;
        private Staff _staffid;
        private int _wardnumber;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public PatientCheckIn PatientCheckInID
        {
            get { return _patientcheckinid; }
            set { _patientcheckinid = value; }
        }

        public string AdmissionReason
        {
            get { return _admissionreason; }
            set { _admissionreason = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public DateTime AdmitDate
        {
            get { return _admitdate; }
            set { _admitdate = value; }
        }

        public Staff StaffID
        {
            get { return _staffid; }
            set { _staffid = value; }
        }

        public int WardNumber
        {
            get { return _wardnumber; }
            set { _wardnumber = value; }
        }

        #endregion

        #region Constructor(s)

        public InPatient(int id, PatientCheckIn patientcheckinid, string admissionreason, string comments, DateTime admitdate, Staff staffid, int wardnumber)
        {
            Id = id;
            PatientCheckInID = patientcheckinid;
            AdmissionReason = admissionreason;
            Comments = comments;
            AdmitDate = admitdate;
            StaffID = staffid;
            WardNumber = wardnumber;
        }

        #endregion
    }
}
