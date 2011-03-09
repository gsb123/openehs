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
                roles.Insert(0, new Role("All", "", DateTime.Now));

                return new SelectList(roles, "Id", "Name");
            }
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