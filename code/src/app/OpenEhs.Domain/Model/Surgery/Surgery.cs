/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Surgery : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string SurgeryType { get; set; }
        public virtual int RoomNumber { get; set; }
        public virtual DateTime StartTime { get; set; }
        public virtual DateTime EndTime { get; set; }
        public virtual string Comments { get; set; }
        public virtual IList<Staff> Staff { get; set; }
        public virtual Encounter Encounter { get; set; }

        #endregion

    }
}
