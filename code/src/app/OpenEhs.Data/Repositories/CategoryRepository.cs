using System;
using System.Collections.Generic;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }

        public Category Get(int id)
        {
            return Session.Get<Category>(id);
        }

        public IList<Category> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Category>();

            return criteria.List<Category>();
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
