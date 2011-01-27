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
    public class Allergy: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Medication { get; set; }
        public virtual Patient Patient { get; set; }

        #endregion
    }
}
