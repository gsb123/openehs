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
    public class OutPatientEncounter
    {
        #region Fields

        private int _id;
        private PatientCheckIn _patientcheckinid;
        private DateTime _time;
        private string _comments;
        private int _roomnumber;
        private string _diagnosis;
        private Staff _staffid;

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

        public DateTime Time
        {
            get { return _time; }
            set { _time = value; }
        }

        public string Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public int RoomNumber
        {
            get { return _roomnumber; }
            set { _roomnumber = value; }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

        public Staff StaffID
        {
            get { return _staffid; }
            set { _staffid = value; }
        }

        #endregion

        #region Constructor(s)

        public OutPatientEncounter(int id, PatientCheckIn patientcheckinid, DateTime time, string comments, int roomnumber, string diagnosis, Staff staffid)
        {
            Id = id;
            PatientCheckInID = patientcheckinid;
            Time = time;
            Comments = comments;
            RoomNumber = roomnumber;
            Diagnosis = diagnosis;
            StaffID = staffid;
        }

        #endregion
    }
}
