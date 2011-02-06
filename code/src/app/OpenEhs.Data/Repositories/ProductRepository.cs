/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class ProductRepository : IProductRepository
    {
        private ISession Session
        {
            get { return UnitOfWork.CurrentSession; }
        }

        public Product Get(int id)
        {
            return Session.Get<Product>(id);
        }

        public IList<Product> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Product>();
            return criteria.List<Product>();
        }

        public void Add(Product product)
        {
            Session.Save(product);
        }

        public void Remove(Product product)
        {
            Session.Delete(product);
        }

        public IList<Product> GetActiveProducts()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetInactiveProducts()
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetByCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
