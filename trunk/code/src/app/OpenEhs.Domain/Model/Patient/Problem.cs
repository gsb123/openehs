/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-26-2011
 * 
 * Author: Kevin Russon
 *****************************************************************************/

using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Problem : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string ProblemName { get; set; }
        public virtual IList<PatientProblem> Patients { get; set; }

        #endregion

    }
}
