/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 16-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System.Collections.Generic;

namespace OpenEhs.Data
{
    public interface IRepository<T>
    {
        T Get(int id);
        IList<T> GetAll();
        void Add(T entity);
        void Remove(T entity);
    }
}
