/*****************************************************************************
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

namespace OpenEhs.Data
{
    public class PatientRepository : IPatientRepository
    {
        public Patient Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Add(Patient entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Patient entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Patient> Find(Expression<Func<Patient, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IList<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        IList<Patient> IPatientRepository.FindByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        IList<Patient> IPatientRepository.FindByName(string name)
        {
            throw new NotImplementedException();
        }

        IList<Patient> IPatientRepository.FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        IList<Patient> IPatientRepository.FindByOldPhysicalRecord(string number)
        {
            throw new NotImplementedException();
        }

        public Patient FindByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public Patient FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public Patient FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        public Patient FindByOldPhysicalRecord(string number)
        {
            throw new NotImplementedException();
        }
    }
}
