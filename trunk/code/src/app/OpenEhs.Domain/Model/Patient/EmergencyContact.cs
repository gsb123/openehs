/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class EmergencyContact: IEntity // NOTE: Should we just call this class "Contact"?
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual Relationship Relationship { get; set; }
        public virtual Address Address { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
