using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Medication : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<PatientMedication> Patients { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
