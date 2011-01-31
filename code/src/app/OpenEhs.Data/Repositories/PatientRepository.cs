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

        public IList<Patient> GetAll()
        {
            throw new NotImplementedException();
        }

        IList<Patient> FindByPhoneNumber(string phoneNumber)
        {
            throw new NotImplementedException();
        }

        IList<Patient> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        IList<Patient> FindByDateOfBirth(DateTime dateOfBirth)
        {
            throw new NotImplementedException();
        }

        IList<Patient> FindByOldPhysicalRecord(string number)
        {
            throw new NotImplementedException();
        }
    }
}
