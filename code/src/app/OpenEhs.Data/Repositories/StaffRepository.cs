using System;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class StaffRepository : IStaffRepository
    {
        public Staff Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Staff entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Staff entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Staff> Find(Expression<Func<Staff, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
