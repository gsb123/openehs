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
    public class Note : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Title { get; set; }
        public virtual string Body { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual Staff Author { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<PatientCheckIn> PatientCheckIns { get; set; }

        #endregion

    }
}
