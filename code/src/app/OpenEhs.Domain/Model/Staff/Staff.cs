/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Staff: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual StaffType StaffType { get; set; }
        public virtual string LicenseNumber { get; set; }
        public virtual Address Address { get; set; }
        public virtual User User { get; set; }
        public virtual IList<Surgery> Surgery { get; set; }
        public virtual bool IsActive { get; set; }
        //public virtual Staff Staff { get; set; }
        public virtual PatientCheckIn PatientCheckIns { get; set; }

        #endregion
    }
}
