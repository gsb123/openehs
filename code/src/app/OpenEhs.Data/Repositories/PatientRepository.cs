using System;
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
