using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using OpenEhs.Data.Common;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class UserRepository : IUserRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }

        public User Get(int id)
        {
            return Session.Get<User>(id);
        }

        public User Get(string username)
        {
            ICriteria criteria = Session.CreateCriteria<User>()
                                        .Add(Restrictions.Eq("Username", username));

            return criteria.UniqueResult<User>();
        }

        public IList<User> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<User>();

            return criteria.List<User>();
        }

        public PagedList<User> GetPaged(int pageIndex, int pageSize)
        {
            var rowCount = Session.CreateCriteria<User>()
                .SetProjection(Projections.RowCount())
                .FutureValue<Int32>();

            ICriteria criteria = Session.CreateCriteria<User>()
                .SetFirstResult((pageIndex - 1)*pageSize)
                .SetMaxResults(pageSize);

            return new PagedList<User>(criteria.List<User>(), pageSize, pageSize, rowCount.Value);
        }

        public void Add(User entity)
        {
            Session.Save(entity);
        }

        public void Remove(User entity)
        {
            Session.Delete(entity);
        }

        public IList<User> Find(string username, string password)
        {
            ICriteria criteria = Session.CreateCriteria<User>()
                                        .Add(Restrictions.Eq("Username", username))
                                        .Add(Restrictions.Eq("Password", password));

            return criteria.List<User>();
        }

        public bool CheckForUsernameAvailability(string username)
        {
            ICriteria criteria = Session.CreateCriteria<User>()
                .Add(Restrictions.Eq("Username", username));

            if (criteria.UniqueResult<User>() == null)
            {
                return true;
            }

            return false;
        }

        public IList<User> GetByLastNameInitial(string initial)
        {
            if (initial.Length != 1)
            {
                initial = initial.Substring(0, 1);
            }

            ICriteria criteria = Session.CreateCriteria<User>()
                .CreateCriteria("Staff")
                .Add(Restrictions.Like("LastName", initial, MatchMode.Start));

            return criteria.List<User>();
        }

        public IList<User> GetByRole(Role role)
        {
            ICriteria criteria = Session.CreateCriteria<User>()
                .CreateCriteria("Roles")
                .Add(Restrictions.Eq("Id", role.Id))
                .Add(Restrictions.Eq("Name", role.Name));

            return criteria.List<User>();
        }

        public IList<User> FindByType(StaffType staffType)
        {
            ICriteria criteria = Session.CreateCriteria<User>().Add(Restrictions.Eq("StaffType", staffType));

            return criteria.List<User>();
        }
    }
}
