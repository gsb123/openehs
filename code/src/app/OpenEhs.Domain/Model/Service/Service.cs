/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Service: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }

        #endregion
    }
}
