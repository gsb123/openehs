using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class PatientCheckIn
    {
        #region Fields

        private int _id;
        private DateTime _datetime;
        private PCIType _type;
        private Patient _patientid;
        private PCIStatus _status;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime DateTime
        {
            get { return _datetime; }
            set { _datetime = value; }
        }

        public PCIType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public Patient PatientID
        {
            get { return _patientid; }
            set { _patientid = value; }
        }

        public PCIStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }

        #endregion

        #region Constructor(s)

        public PatientCheckIn(int id, DateTime datetime, PCIType type, Patient patientid, PCIStatus status)
        {
            Id = id;
            DateTime = datetime;
            Type = type;
            PatientID = patientid;
            Status = status;
        }

        #endregion
    }
}
