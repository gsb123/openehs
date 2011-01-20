/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Staff
    {
        #region Fields

        private int _id;
        private string _firstName;
        private string _middleName;
        private string _lastName;
        private string _phoneNumber;
        private StaffType _type;
        private string _licenseNumber;
        private Address _address;
        private User _login;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }
        }

        public StaffType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        public string LicenseNumber
        {
            get { return _licenseNumber; }
            set { _licenseNumber = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public User User
        {
            get { return _login; }
            set { _login = value; }
        }

        #endregion

        #region Constructor(s)

        public Staff(int id, string firstname, string middlename, string lastname, string phonenumber, StaffType stafftype, string licensenumber, Address address, User login)
        {
            Id = id;
            FirstName = firstname;
            MiddleName = middlename;
            LastName = lastname;
            PhoneNumber = phonenumber;
            Type = stafftype;
            LicenseNumber = licensenumber;
            Address = address;
            User = login;
        }

        #endregion
    }
}
