using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class FeedChart : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual PatientCheckIn PatientCheckIn { get; set; }
        public virtual DateTime FeedTime { get; set; }
        public virtual string FeedType { get; set; }
        public virtual float Amountffered { get; set; }
        public virtual float AmountTaken { get; set; }
        public virtual string Vomit { get; set; }
        public virtual string Urine { get; set; }
        public virtual string Stool { get; set; }
        public virtual string Comments { get; set; }

        #endregion
    }
}
