/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-26-2011
 * 
 * Author: Kevin Russon
 *****************************************************************************/

using System;

namespace OpenEhs.Domain
{
    public class PatientEncounter: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }
        public virtual DateTime TimeIn { get; set; }
        public virtual DateTime TimeOut { get; set; }
        public virtual string Comments { get; set; }
        public virtual int Location { get; set; }
        public virtual string Diagnosis { get; set; }
        public virtual Staff Staff { get; set; }
        public virtual string AdmitReason { get; set; }

        #endregion
    }
}
