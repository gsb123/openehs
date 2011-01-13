using System;

namespace OpenEhs.Domain
{
    public class Patient
    {
        #region Fields

        private int _id;
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private DateTime _dateofbirth;
        private Gender _gender;
        private string _phonenumber;
        private Address _address;
        private string _bloodtype;
        private string _triberace;
        private string _religion;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string MiddleName
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        public string LastName
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public DateTime DateOfBirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }

        public Gender Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        public string PhoneNumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string BloodType
        {
            get { return _bloodtype; }
            set { _bloodtype = value; }
        }

        public string TribeRace
        {
            get { return _triberace; }
            set { _triberace = value; }
        }

        public string Religion
        {
            get { return _religion; }
            set { _religion = value; }
        }

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
