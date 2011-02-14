/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 14-Feb-2011
 * 
 * Author: Peter Litster (aholibamah@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class ServiceRepository : IServiceRepository
    {
        private ISession Session
        {
            get { return UnitOfWork.CurrentSession; }
        }

        public Service Get(int id)
        {
            return Session.Get<Service>(id);
        }

        public IList<Service> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Service>();
            return criteria.List<Service>();
        }

        public void Add(Service service)
        {
            Session.Save(service);
        }

        public void Remove(Service service)
        {
            Session.Delete(service);
        }

        public IList<Service> GetActiveServices()
        {
            throw new NotImplementedException();
        }

        public IList<Service> GetInactiveServices()
        {
            throw new NotImplementedException();
        }

        public IList<Service> GetByCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
