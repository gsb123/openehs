/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-19-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;

namespace OpenEhs.Domain
{
    public class Role: IEntity
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; private set; }
        public virtual string Description { get; private set; }
        public virtual DateTime DateCreated { get; set; }
    }
}
