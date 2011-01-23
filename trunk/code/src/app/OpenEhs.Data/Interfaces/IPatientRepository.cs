using System;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Patient FindByPhoneNumber(string phoneNumber);
        Patient FindByName(string name);
        Patient FindByDateOfBirth(DateTime dateOfBirth);
        Patient FindByOldPhysicalRecord(string number);
    }
}
