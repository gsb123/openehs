using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using OpenEhs.Data.Common;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class RoleRepository : IRoleRepository
    {
        private ISession Session
        {
            get { return UnitOfWork.CurrentSession; }
        }

        public Role Get(int id)
        {
            return Session.Get<Role>(id);
        }

        public Role Get(string name)
        {
            ICriteria criteria = Session.CreateCriteria<Role>()
                .Add(Restrictions.Eq("Name", name));

            return criteria.UniqueResult<Role>();
        }

        public IList<Role> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Role>();

            return criteria.List<Role>();
        }

        public PagedList<Role> GetPaged(int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public void Add(Role entity)
        {
            Session.Save(entity);
        }

        public void Remove(Role entity)
        {
            Session.Delete(entity);
        }
    }
}
