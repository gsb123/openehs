using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;
using NHibernate;

namespace OpenEhs.Data
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }

        public Invoice Get(int id)
        {
            return Session.Get<Invoice>(id);
        }

        public IList<Invoice> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Invoice>();

            return criteria.List<Invoice>();
        }

        public void Add(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Invoice entity)
        {
            throw new NotImplementedException();
        }

        public IList<Invoice> FindByPatientId(int PatientId)
        {
            throw new NotImplementedException();
        }
    }
}
