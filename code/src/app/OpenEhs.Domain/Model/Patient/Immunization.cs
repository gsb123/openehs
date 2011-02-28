using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Immunization : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual string VaccineType { get; set; }
        public virtual string Comments { get; set; }
        public virtual IList<PatientImmunization> Patients { get; set; }

        #endregion
    }
}
