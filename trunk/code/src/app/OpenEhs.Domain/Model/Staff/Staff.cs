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

        public int Id {get; private set;} 
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string PhoneNumber {get; set;}
        public StaffType Type { get; set; }
        public string LicenseNumber { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }

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
