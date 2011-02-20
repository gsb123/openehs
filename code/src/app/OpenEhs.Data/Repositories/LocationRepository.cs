using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class LocationRepository : ILocationRepository
    {
        private ISession Session
        {
            get { return UnitOfWork.CurrentSession; }
        }
        public Location Get(int id)
        {
            return Session.Get<Location>(id);
        }
        public IList<Location> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Location>();
            return criteria.List<Location>();
        }
        public void Add(Location entity)
        {
            Session.Save(entity);
        }
        public void Remove(Location entity)
        {
            Session.Delete(entity);
        }
    }
}
