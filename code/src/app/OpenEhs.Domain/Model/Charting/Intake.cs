using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Intake
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string IntakeType { get; set; }
        public virtual float IntakeAmount { get; set; }

        #endregion
    }
}
