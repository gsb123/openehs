using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    class SurgeryStaff : IEntity
    {
        public virtual int Id { get; private set; }
        public virtual Staff Staff { get; set; }
        public virtual Surgery Surgery { get; set; }
        public virtual StaffRole StaffRoles { get; set; }
    }
}
