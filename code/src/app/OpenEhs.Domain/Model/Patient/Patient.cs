/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;

namespace OpenEhs.Domain
{
    public class Patient
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual Address Address { get; set; }
        public virtual string BloodType { get; set; }
        public virtual string TribeRace { get; set; }
        public virtual string Religion { get; set; }

        #endregion

        #region Constructor(s)

        public Patient(int id, string firstname, string middlename, string lastname, DateTime dateofbirth, Gender gender, string phonenumber, Address address,
            string bloodtype, string triberace, string religion)
        {
            Id = id;
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            DateOfBirth = dateofbirth;
            Gender = gender;
            PhoneNumber = phonenumber;
            Address = address;
            BloodType = bloodtype;
            TribeRace = triberace;
            Religion = religion;
        }

        #endregion
    }
}
