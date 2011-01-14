using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Surgery
    {
        #region Fields

        private int _id;
        private string _surgerytype;
        private int _roomnumber;
        private DateTime _starttime;
        private DateTime _endtime;
        private string _comments;
        private InPatient _inpatientid;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string SurgeryType
        {
            get { return _surgerytype; }
            set { _surgerytype = value; }
        }

        public int RoomNumber
        {
            get { return _roomnumber; }
            set { _roomnumber = value; }
        }

        public DateTime StartTime
        {
            get { return _starttime; }
            set { _starttime = value; }
        }

        public DateTime EndTime
        {
            get { return _endtime; }
            set { _endtime = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public InPatient InPatientID
        {
            get { return _inpatientid; }
            set { _inpatientid = value; }
        }

        #endregion

        #region Constructor(s)

        public Surgery(int id, string surgerytype, int roomnumber, DateTime starttime, DateTime endtime, string comments, InPatient inpatientid)
        {
            Id = id;
            SurgeryType = surgerytype;
            RoomNumber = roomnumber;
            StartTime = starttime;
            EndTime = endtime;
            Comments = comments;
            InPatientID = inpatientid;
        }

        #endregion
    }
}
