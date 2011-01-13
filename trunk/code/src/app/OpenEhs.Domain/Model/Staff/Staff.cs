using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Staff
    {
        #region Fields

        private int _id;
        private string _firstname;
        private string _middlename;
        private string _lastname;
        private string _phonenumber;
        private int _stafftype;
        private string _licensenumber;
        private Address _address;
        private LogIn _login;

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

        public string PhoneNumber
        {
            get { return _phonenumber; }
            set { _phonenumber = value; }
        }

        public int StaffType
        {
            get { return _stafftype; }
            set { _stafftype = value; }
        }

        public string LicenseNumber
        {
            get { return _licensenumber; }
            set { _licensenumber = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public LogIn LogIn
        {
            get { return _login; }
            set { _login = value; }
        }

        #endregion

        #region Constructor(s)

        public Staff(int id, string firstname, string middlename, string lastname, string phonenumber, int stafftype, string licensenumber, Address address, LogIn login)
        {
            Id = id;
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            PhoneNumber = phonenumber;
            StaffType = stafftype;
            LicenseNumber = licensenumber;
            Address = address;
            LogIn = login;
        }

        #endregion
    }
}
