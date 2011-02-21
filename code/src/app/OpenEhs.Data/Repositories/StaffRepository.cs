/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
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
            return Session.Get<Staff>(id);
        }

        public IList<Staff> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Staff>();
            return criteria.List<Staff>();
        }

        public void Add(Staff entity)
        {
            Session.Save(entity);
        }

        public void Remove(Staff entity)
        {
            Session.Delete(entity);
        }

        public IList<Staff> FindByName(string firstName, string middleName, string lastName)
        {
            ICriteria criteria = Session.CreateCriteria<Staff>()
                                        .Add(Restrictions.Like("FirstName", firstName + "%"))
                                        .Add(Restrictions.Like("MiddleName", middleName + "%"))
                                        .Add(Restrictions.Like("LastName", lastName + "%"));

            return criteria.List<Staff>();
        }

        public IList<Staff> FindByPhoneNumber(string phoneNumber)
        {
            ICriteria criteria = Session.CreateCriteria<Staff>()
                                        .Add(Restrictions.Like("PhoneNumber", phoneNumber + "%"));

            return criteria.List<Staff>();
        }

        public IList<Staff> FindByType(StaffType staffType)
        {
            ICriteria criteria = Session.CreateCriteria<Staff>().Add(Restrictions.Eq("StaffType",staffType));

            return criteria.List<Staff>();
        }

        public IList<Staff> GetAllInactive()
        {
            ICriteria criteria = Session.CreateCriteria<Staff>()
                                        .Add(Restrictions.Eq("IsActive", false));

            return criteria.List<Staff>();
        }

        public IList<Staff> GetAllActive()
        {
            ICriteria criteria = Session.CreateCriteria<Staff>()
                                        .Add(Restrictions.Eq("IsActive", true));

            return criteria.List<Staff>();
        }

        public Staff FindByUser(User user)
        {
            ICriteria criteria = Session.CreateCriteria<Staff>()
                .Add(Restrictions.Eq("UserId", user.Id));

            return criteria.UniqueResult<Staff>();
        }
    }
}
