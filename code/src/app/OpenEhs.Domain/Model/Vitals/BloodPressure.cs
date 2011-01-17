/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-17-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class BloodPressure
    {
        #region Fields

        private int _systolic;
        private int _diastolic;

        #endregion

        #region Properties

        public int Systolic
        {
            get
            {
                return _systolic;
            }
            set
            {
                _systolic = value;
            }
        }

        public int Diastolic
        {
            get
            {
                return _diastolic;
            }
            set 
            {
                _diastolic = value;
            }
        }

        public BloodPressureCategory Category
        {
            get
            {
                // Normal Blood Pressure
                if ((_systolic > 0 && _systolic < 120) && (_diastolic > 0 && _diastolic < 80))
                    return BloodPressureCategory.Normal;
                
                // Prehypertension
                if ((_systolic >= 120 && _systolic <= 139) || (_diastolic >= 80 && _diastolic <= 89))
                    return BloodPressureCategory.Prehypertension;

                // Stage 1 Hypertension
                if ((_systolic >= 140 && _systolic <= 159) || (_diastolic >= 90 && _diastolic <= 99))
                    return BloodPressureCategory.StageOneHypertension;

                // Stage 2 Hypertension
                if ((_systolic >= 160 && _systolic <= 179) || (_diastolic >= 100 && _diastolic <= 109))
                    return BloodPressureCategory.StageTwoHypertension;

                // Hypertensive Crisis
                if (_systolic >= 180 || _diastolic >= 110)
                    return BloodPressureCategory.Crisis;

                return BloodPressureCategory.None;
            }
        }

        #endregion

        #region Constructor(s)

        public BloodPressure()
            : this(0, 0)
        {}

        public BloodPressure(int systolic, int diastolic)
        {}

        #endregion
    }
}
