/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 2-Feb-2011
 * 
 * Author: Peter Litster (aholibamah@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public interface IEmergencyContactRepository : IRepository<EmergencyContact>
    {
        EmergencyContact Get(int id);
        IList<EmergencyContact> GetAll();
        void Add(EmergencyContact entity);
        void Remove(EmergencyContact entity);
    }
}
