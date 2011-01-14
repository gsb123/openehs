using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public enum LogInPermissions
    {
        //TODO comne up with permissions
        Admin = 'A',
        Physician = 'P',
        Surgeon = 'S',
        Nurse = 'N',
        Receptionist = 'R'
    }
}
