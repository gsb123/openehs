using System;
using System.Collections.Generic;
using System.Web.Mvc;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class UserViewModel
    {
        public IList<User> Users { get; set; }
        public Role SelectedRole { get; set; }

        public SelectList Roles
        {
            get
            {
                var roles = new List<Role>(new RoleRepository().GetAll());
                roles.Sort();
                roles.Insert(0, new Role("All", "", DateTime.Now));

                return new SelectList(roles, "Id", "Name");
            }
        }

        public string SearchTerm { get; set; }

        public UserViewModel(IList<User> users)
        {
            Users = users;
        }
    }
}