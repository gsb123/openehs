using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class UserDetailsViewModel
    {
        private User _user;

        public int UserId
        {
            get { return _user.Id; }
        }

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

        [Display(Name = "Email Address")]
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

        [Display(Name = "First Name")]
        public string FirstName
        {
            get
            {
                return _user.FirstName;
            }
            set
            {
                _user.FirstName = value;
            }
        }

        [Display(Name = "Middle Name")]
        public string MiddleName
        {
            get
            {
                return _user.MiddleName;
            }
            set
            {
                _user.MiddleName = value;
            }
        }

        [Display(Name = "Last Name")]
        public string LastName
        {
            get
            {
                return _user.LastName;
            }
            set
            {
                _user.LastName = value;
            }
        }

        [Display(Name = "Phone Number")]
        public string PhoneNumber
        {
            get
            {
                return _user.PhoneNumber;
            }
            set
            {
                _user.PhoneNumber = value;
            }
        }

        public Address Address
        {
            get
            {
                return _user.Address;
            }
            set
            {
                _user.Address = value; 
            }
        }

        public IList<Role> Roles
        {
            get { return _user.Roles; }
        }

        [Display(Name = "Role")]
        public Role SelectedRole { get; set; }

        [Display(Name = "Roles")]
        public SelectList AvailableRoles
        {
            get
            {
                var roles = new List<Role>(new RoleRepository().GetAll());
                roles.Sort();

                return new SelectList(roles, "Id", "Name");
            }
        }

        public UserDetailsViewModel(User user)
        {
            _user = user;
        }
    }
}