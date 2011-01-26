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

namespace OpenEhs.Data
{
    public class ProductRepository : IProductRepository
    {
        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
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
