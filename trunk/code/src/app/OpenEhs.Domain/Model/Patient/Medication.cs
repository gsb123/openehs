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
        public virtual string Instruction { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime ExpDate { get; set; }
        public virtual Patient Patient { get; set; }

        #endregion
    }
}
