using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class FluidChart
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }
        public virtual DateTime CheckTime { get; set; }
        public virtual Output Outputs { get; set; }
        public virtual Intake Intakes { get; set; }

        #endregion
    }
}
