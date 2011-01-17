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
        #region Fields

        private int _id;
        private string _diagnosis;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Diagnosis
        {
            get { return _diagnosis; }
            set { _diagnosis = value; }
        }

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
