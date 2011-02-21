using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
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

        public IList<User> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<User>();

            return criteria.List<User>();
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

        public User Get(string username)
        {
            ICriteria criteria = Session.CreateCriteria<User>()
                                        .Add(Restrictions.Eq("Username", username));

            return criteria.UniqueResult<User>();
        }
    }
}
