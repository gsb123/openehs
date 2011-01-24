/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class ChronicDisease
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }

        #endregion

        #region Constructor(s)

        public ChronicDisease(int id, string name)
        {
            Id = id;
            Name = name;
        }

        #endregion
    }
}
