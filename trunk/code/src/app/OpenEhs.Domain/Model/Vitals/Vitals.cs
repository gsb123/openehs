/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;

namespace OpenEhs.Domain
{
    public class Vitals : IEntity
    {

        #region Properties

        public virtual int Id {get; private set;}
        public virtual VitalsType Type { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual int Height { get; set; }
        public virtual int Weight { get; set; }
        public virtual int HeartRate { get; set; }
        public virtual float Temperature { get; set; }
        public virtual BloodPressure BloodPressure { get; set; }
        public virtual int RespiratoryRate { get; set; }
        public virtual Encounter Encounter { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion


    }
}
