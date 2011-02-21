using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Output : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual float NGSuctionAmount { get; set; }
        public virtual string NGSuctionColor { get; set; }
        public virtual float UrineAmount { get; set; }
        public virtual float StoolAmount { get; set; }
        public virtual string StoolColor { get; set; }

        #endregion
    }
}
