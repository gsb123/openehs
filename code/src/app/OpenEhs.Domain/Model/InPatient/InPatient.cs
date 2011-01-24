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
    public class InPatient
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual PatientCheckIn PatientCheckInID { get; set; }
        public virtual string AdmissionReason { get; set; }
        public virtual string Comments { get; set; }
        public virtual DateTime AdmitDate { get; set; }
        public virtual Staff StaffID { get; set; }
        public virtual int WardNumber { get; set; }

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
