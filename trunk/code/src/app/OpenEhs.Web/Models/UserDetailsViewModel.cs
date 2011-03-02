using System.Collections.Generic;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class UserDetailsViewModel
    {
        private User _user;

        public string Username
        {
            get
            {
                return _user.Username;
            }
            set
            {
                _user.Username = value;
            }
        }

        public string Password
        {
            get
            {
                return _user.Password;
            }
            set
            {
                _user.Password = value;
            }
        }

        public string EmailAddress
        {
            get
            {
                return _user.EmailAddress;
            }
            set
            {
                _user.EmailAddress = value;
            }
        }

        public IList<Role> Roles
        {
            get { return _user.Roles; }
        }

        public Staff Staff
        {
            get
            {
                return _user.Staff;
            }
            set
            {
                _user.Staff = value;
            }
        }

        public UserDetailsViewModel(User user)
        {
            _user = user;
        }
    }
}