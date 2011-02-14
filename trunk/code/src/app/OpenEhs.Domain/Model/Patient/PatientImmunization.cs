using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class PatientImmunization : IEntity
    {
        #region Fields

        public virtual int Id { get; private set; }
        public virtual int Patient { get; set; }
        public virtual int Immunization { get; set; }

        #endregion
    }
}
