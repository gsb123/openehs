using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;
using NHibernate;
using NHibernate.Criterion;

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
            string q = String.Format("from Invoice where Patient = select * from Patient where Id = {0}", PatientId);
            IQuery query = Session.CreateQuery(q);
            return query.List<Invoice>();
            /*
            ICriteria criteriaBase = Session.CreateCriteria(typeof(Patient));
            SimpleExpression simpleBase = NHibernate.Criterion.Expression.Eq("Id", PatientId);

            ICriteria criteria = Session.CreateCriteria(typeof(Invoice));
            SimpleExpression sim1 = NHibernate.Criterion.Expression.Eq("Patient.Id" ,PatientId);
            criteria.Add(sim1);
            Order order = Order.Desc("Total");
            criteria.AddOrder(order);
            return criteria.List<Invoice>();

            throw new NotImplementedException();
             */
        }
    }
}
