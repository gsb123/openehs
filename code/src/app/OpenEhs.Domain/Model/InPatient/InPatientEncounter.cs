using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class InPatientEncounter
    {
        #region Fields

        private int _id;
        private DateTime _time;
        private InPatient _inpatientid;
        private string _diagnosis;
        private Staff _staffid;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public InPatient InPatientID
        {
            get { return _inpatientid; }
            set { _inpatientid = value; }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        private Staff StaffID
        {
            get { return _staffid; }
            set { _staffid = value; }
        }

        #endregion

        #region Constructor(s)

        public InPatientEncounter(int id, DateTime time, InPatient inpatientid, string diagnosis, Staff staffid)
        {
            Id = id;
            Time = time;
            InPatientID = inpatientid;
            Diagnosis = diagnosis;
            StaffID = staffid;
        }

        #endregion
    }
}
