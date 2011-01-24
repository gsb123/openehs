/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class PreWrittenDiagnosis
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Diagnosis { get; set; }

        #endregion

        #region Constructor(s)

        public PreWrittenDiagnosis(int id, string diagnosis)
        {
            Id = id;
            Diagnosis = diagnosis;
        }

        #endregion
    }
}
