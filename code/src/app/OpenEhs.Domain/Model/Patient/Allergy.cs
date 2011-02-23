/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Allergy : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual IList<Patient> Patients { get; set; }

        #endregion
    }
}
