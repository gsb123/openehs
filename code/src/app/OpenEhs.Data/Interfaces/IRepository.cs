using System;
using System.Linq;
using System.Linq.Expressions;

namespace OpenEhs.Data
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);
        IQueryable<T> Find(Expression<Func<T, bool>> predicate);
    }
}
