/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 16-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System.Collections.Generic;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public interface IStaffRepository : IRepository<Staff>
    {
        IList<Staff> FindByName(string firstName, string middleName, string lastName);
        IList<Staff> FindByPhoneNumber(string phoneNumber);
        IList<Staff> FindByType(StaffType type);
        IList<Staff> GetAllInactive();
        IList<Staff> GetAllActive();
        Staff FindByUser(User user);
    }
}