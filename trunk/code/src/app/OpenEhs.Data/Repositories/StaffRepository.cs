/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace OpenEhs.Data
{
    public class StaffRepository : IStaffRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }
        public Staff Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Staff> GetAll()
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

        public IList<Staff> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Staff> FindByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IList<Staff> FindByType(StaffType staffType)
        {
            ICriteria criteria = Session.CreateCriteria<Staff>().Add(Restrictions.Eq("StaffType",staffType));
            return criteria.List<Staff>();
        }

        public IList<Staff> GetAllInactive()
        {
            throw new NotImplementedException();
        }

        public IList<Staff> GetAllActive()
        {
            throw new NotImplementedException();
        }

        public Staff FindByUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
