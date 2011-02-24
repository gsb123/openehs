using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class OutputChart : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual DateTime ChartTime { get; set; }
        public virtual string NGSuctionAmount { get; set; }
        public virtual string NGSuctionColor { get; set; }
        public virtual string UrineAmount { get; set; }
        public virtual string StoolAmount { get; set; }
        public virtual string StoolColor { get; set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }

        #endregion
    }
}
