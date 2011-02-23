/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class PatientRepository : IPatientRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }
        public Patient Get(int id)
        {
            return Session.Get<Patient>(id);
        }

        public void Add(Patient entity)
        {
            Session.Save(entity);
        }

        public void Remove(Patient entity)
        {
            Session.Delete(entity);
        }

        public IList<Patient> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Patient>();

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByPhoneNumber(string phoneNumber)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Like("PhoneNumber", "%" + phoneNumber + "%"));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByFirstName(string firstName)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Like("FirstName", "%" + firstName + "%"));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByMiddleName(string middleName)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Like("MiddleName", "%" + middleName + "%"));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByLastName(string lastName)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Like("LastName", "%" + lastName + "%"));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByDateOfBirth(DateTime dateOfBirth)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Eq("DateOfBirth", dateOfBirth));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByOldPhysicalRecord(int number)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Like("OldPhysicalRecordNumber", "%" + number.ToString() + "%"));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByPatientId(int number)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Eq("Id", number));

            return criteria.List<Patient>();
        }

    }
}
