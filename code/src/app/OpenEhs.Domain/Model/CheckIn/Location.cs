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
    public class Location : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Department { get; set; }
        public virtual string RoomNumber { get; set; }
        public virtual IList<PatientCheckIn> PatientCheckIns { get; set; }
        public virtual IList<Surgery> Surgeries { get; set; }
    }
}
