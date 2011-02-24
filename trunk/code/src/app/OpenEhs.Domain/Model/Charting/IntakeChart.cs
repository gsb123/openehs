using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class IntakeChart : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual DateTime ChartTime { get; set; }
        public virtual string KindOfFluid { get; set; }
        public virtual string Amount { get; set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }

        #endregion
    }
}
