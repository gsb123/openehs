/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Address: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Street1 { get; set; }
        public virtual string Street2 { get; set; }
        public virtual string City { get; set; }
        public virtual string Region { get; set; }
        public virtual string Country { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
