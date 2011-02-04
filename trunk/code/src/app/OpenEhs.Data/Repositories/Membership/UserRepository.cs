using System;
using System.Collections.Generic;
using NHibernate;
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
            throw new NotImplementedException();
        }

        public void Add(User entity)
        {
            Session.Save(entity);
        }

        public void Remove(User entity)
        {
            Session.Delete(entity);
        }
    }
}
