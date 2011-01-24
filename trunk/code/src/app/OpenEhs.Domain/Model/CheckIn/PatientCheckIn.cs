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
    public class PatientCheckIn
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual DateTime DateTime { get; set; }
        public virtual PCIType Type { get; set; }
        public virtual Patient PatientID { get; set; }
        public virtual PCIStatus Status { get; set; }

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
