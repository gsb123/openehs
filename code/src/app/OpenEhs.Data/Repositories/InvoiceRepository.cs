using System;
using System.Collections.Generic;
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

        #region Invoice

        /// <summary>
        /// Get an Invoice with a given id.
        /// </summary>
        /// <param name="id">The Id of the invoice to be retrieved.</param>
        /// <returns></returns>
        public Invoice Get(int id)
        {
            return Session.Get<Invoice>(id);
        }

        /// <summary>
        /// Gets all the Invoices in the Repository.
        /// </summary>
        /// <returns>An IList containing all Invoices in the Repository.</returns>
        public IList<Invoice> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Invoice>();
            return criteria.List<Invoice>();
        }

        /// <summary>
        /// Gets a list of all the InvoiceItems.
        /// </summary>
        /// <returns>Returns an IList of InvoiceItems.</returns>
        public IList<InvoiceItem> GetAllItems()
        {
            ICriteria criteria = Session.CreateCriteria<InvoiceItem>();

            return criteria.List<InvoiceItem>();
        }

        /// <summary>
        /// Gets a list of the InvoiceItems related to a specific Invoice.
        /// </summary>
        /// <param name="invoice">The Invoice to return the InvoiceItems from.</param>
        /// <returns>A List of InvoiceItems for invoice.</returns>
        public IList<InvoiceItem> GetItemsFor(int InvoiceId)
        {
            IList<InvoiceItem> LineItems = GetAllItems();
            for (int i = 0; i < LineItems.Count; i++)
            {
                if (LineItems[i].Invoice.Id != InvoiceId)
                {
                    LineItems.Remove(LineItems[i]);
                }
            }
            return LineItems;
        }

        /// <summary>
        /// Adds an Invoice to the Repository.
        /// </summary>
        /// <param name="entity">The Invoice to add to the Repository.</param>
        public void Add(Invoice entity)
        {
            //is this correct? I copied the ProductRepository.
            Session.Save(entity);
        }

        /// <summary>
        /// Removes an invoice from the Repository.
        /// </summary>
        /// <param name="entity">The Invoice to remove from the Repository.</param>
        public void Remove(Invoice entity)
        {
            //is this correct? I copied the ProductRepository again.
            Session.Delete(entity);
        }

        /// <summary>
        /// Finds a list of Invoices for a given PatientId.
        /// </summary>
        /// <param name="PatientId">The ID of the Patient Object to match Invoices to.</param>
        /// <returns>IList of Invoices for the given PatientId.</returns>
        public IList<Invoice> FindByPatientId(int PatientId)
        {
            string q = String.Format("from Invoice where PatientCheckIn.Patient = select * from Patient where Id = {0}", PatientId);
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

        #endregion
    }
}
