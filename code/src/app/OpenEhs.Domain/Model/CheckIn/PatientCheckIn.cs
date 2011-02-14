/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class PatientCheckIn : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual DateTime CheckInTime { get; set; }
        public virtual PCIType PatientType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual PCIStatus PatientStatus { get; set; }
        public virtual DateTime CheckOutTime { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<Encounter> Encounters { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual IList<Vitals> Vitals { get; set; }

        #endregion

    }
}
