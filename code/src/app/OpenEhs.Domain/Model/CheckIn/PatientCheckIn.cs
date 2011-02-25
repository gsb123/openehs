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
        public virtual PatientCheckinType PatientType { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual DateTime CheckOutTime { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual IList<Vitals> Vitals { get; set; }
        public virtual IList<Surgery> Surgeries { get; set; }
        public virtual string Diagnosis { get; set; }
        public virtual Location Location { get; set; }
        public virtual Staff AttendingStaff { get; set; }
        public virtual bool Dead { get; set; } // NOTE: Isn't this a little redundant? We already have the TimeOfDeath field.
        public virtual DateTime TimeOfDeath { get; set; }
        public virtual IList<FeedChart> FeedChart { get; set; }
        public virtual IList<IntakeChart> IntakeChart { get; set; }
        public virtual IList<OutputChart> OutputChart { get; set; }

        #endregion

    }
}
