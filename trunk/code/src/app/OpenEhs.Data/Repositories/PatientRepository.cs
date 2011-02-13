/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using OpenEhs.Domain;
using NHibernate;
using NHibernate.Criterion;

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
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Eq("PhoneNumber", phoneNumber));

            return criteria.List<Patient>();
        }

        public IList<Patient> FindByName(string name)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>();
            return null;
        }

        public IList<Patient> FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public IList<Patient> FindByOldPhysicalRecord(int number)
        {
            ICriteria criteria = Session.CreateCriteria<Patient>().Add(Restrictions.Eq("OldPhysicalRecordNumber", number));

            return criteria.List<Patient>();
        }
    }
}
