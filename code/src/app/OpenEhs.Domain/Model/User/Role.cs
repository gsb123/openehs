/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-19-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Role : IEntity
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        //public virtual IList<User> Users { get; private set; }
        public virtual DateTime DateCreated { get; set; }

        public virtual User User { get; set; }
    }
}
