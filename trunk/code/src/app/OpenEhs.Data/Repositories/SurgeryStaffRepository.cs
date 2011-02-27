using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenEhs.Domain;
using NHibernate;

namespace OpenEhs.Data
{
    public class SurgeryStaffRepository : ISurgeryStaffRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }
        public SurgeryStaff Get(int id)
        {
            return Session.Get<SurgeryStaff>(id);
        }
        public IList<SurgeryStaff> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<SurgeryStaff>();
            return criteria.List<SurgeryStaff>();
        }
        public void Add(SurgeryStaff entity)
        {
            Session.Save(entity);
        }
        public void Remove(SurgeryStaff entity)
        {
            Session.Delete(entity);
        }
    }
}
