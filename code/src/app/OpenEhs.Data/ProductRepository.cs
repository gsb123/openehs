using System;
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

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Product entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> Find(Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
