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
        #region Properties

        public virtual int Id { get; private set; }
        public virtual PatientCheckIn PatientCheckInID { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual string Comments { get; set; }
        public virtual int RoomNumber { get; set; }
        public virtual string Diagnosis { get; set; }
        public virtual Staff StaffID { get; set; }

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
