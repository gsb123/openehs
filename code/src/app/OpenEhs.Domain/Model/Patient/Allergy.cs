/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Allergy: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Medication { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion
    }
}
