/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Location : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Department { get; set; }
        public virtual string RoomNumber { get; set; }
    }
}
