using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class PatientMedication : IEntity
    {
        #region Fields

        public virtual int Id { get; set; }
        public virtual string Instruction { get; set; }
        public virtual string Dosage { get; set; }
        public virtual string Frequency { get; set; }
        public virtual MedicationRouteOfAdministrationType ROA { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime ExpDate { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Medication Medication { get; set; }

        #endregion
    }
}
