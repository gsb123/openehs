/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Vitals: IEntity
    {

        #region Properties

        public virtual int Id {get; private set;}
        public virtual VitalsType Type { get; set; }
        public virtual string Height { get; set; }
        public virtual string Weight { get; set; }
        public virtual int HeartRate { get; set; }
        public virtual float Temperature { get; set; }
        public virtual BloodPressure BloodPressure { get; set; }
        public virtual int RespiratoryRate { get; set; }

        #endregion


    }
}
