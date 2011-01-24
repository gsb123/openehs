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
    public class InPatientEncounter
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual DateTime Time { get; set; }
        public virtual InPatient InPatientID { get; set; }
        public virtual string Diagnosis { get; set; }
        public virtual Staff Staff { get; set; }

        #endregion

        #region Constructor(s)

        public InPatientEncounter(int id, DateTime time, InPatient inpatientid, string diagnosis, Staff staffid)
        {
            Id = id;
            Time = time;
            InPatientID = inpatientid;
            Diagnosis = diagnosis;
            Staff = staffid;
        }

        #endregion
    }
}
