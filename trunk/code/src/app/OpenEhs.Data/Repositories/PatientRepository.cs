﻿/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 23-Jan-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;
using NHibernate;

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
            throw new NotImplementedException();
        }

        public void Remove(Patient entity)
        {
            throw new NotImplementedException();
        }

        public IList<Patient> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Patient>();
            return criteria.List<Patient>();
            throw new NotImplementedException();
        }

        public IList<Patient> FindByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public IList<Patient> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public IList<Patient> FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public IList<Patient> FindByOldPhysicalRecord(string number)
        {
            throw new NotImplementedException();
        }
    }
}
