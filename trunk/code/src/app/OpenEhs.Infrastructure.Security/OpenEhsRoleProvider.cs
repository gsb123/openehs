using System;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Linq;
using System.Web.Security;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Infrastructure.Security
{
    public class OpenEhsRoleProvider : RoleProvider
    {
        #region Fields

        private readonly IRoleRepository _roleRepository;
        private readonly IUserRepository _userRepository;

        #endregion


        #region Properties

        public override string ApplicationName
        {
            get
            {
                return System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            }
            set
            {}
        }

        #endregion


        #region Constructor

        public OpenEhsRoleProvider()
        {
            _roleRepository = new RoleRepository();
            _userRepository = new UserRepository();
        }

        #endregion


        #region Methods

        public override bool IsUserInRole(string username, string roleName)
        {
            var role = _roleRepository.Get(roleName);

            if (role == null)
                throw new ProviderException("Role does not exist.");

            return role.Users.Any(user => user.Username == username);
        }

        public override string[] GetRolesForUser(string username)
        {
            var userRepository = new UserRepository();
            var user = userRepository.Get(username);

            var roles = user.Roles.Select(role => role.Name).ToList();

            return roles.ToArray();
        }

        public override void CreateRole(string roleName)
        {
            var role = new Role {Name = roleName, Description = String.Empty, DateCreated = DateTime.Now};
            _roleRepository.Add(role);
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            var role = _roleRepository.Get(roleName);

            if (!RoleExists(roleName))
                throw new ProviderException("Role does not exist.");

            if (role.Users.Count > 0)
                if (throwOnPopulatedRole)
                    throw new ProviderException("Cannot delete a populated role.");

            _roleRepository.Remove(role);

            return true;
        }

        public override bool RoleExists(string roleName)
        {
            return _roleRepository.Get(roleName) != null;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            var roles = FillRoles(roleNames);
            var users = FillUsers(usernames);

            foreach (var role in roles)
            {
                role.AddUsers(users);
            }
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            var users = FillUsers(usernames);
            var roles = FillRoles(roleNames);

            foreach(var role in roles)
            {
                role.RemoveUsers(users);
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            var role = _roleRepository.Get(roleName);

            return role.Users.Select(user => user.Username).ToList().ToArray();
        }

        public override string[] GetAllRoles()
        {
            var roles = _roleRepository.GetAll();

            return roles.Select(role => role.Name).ToList().ToArray();
        }

        // TODO: Get this one figured out.
        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }


        #region Private Methods

        private IList<Role> FillRoles(string[] roleNames)
        {
            var roles = new List<Role>();

            foreach (var name in roleNames)
            {
                var role = _roleRepository.Get(name);

                if (role != null)
                    roles.Add(role);
            }

            return roles;
        }

        private IList<User> FillUsers(string[] usernames)
        {
            var users = new List<User>();

            foreach (var name in usernames)
            {
                var user = _userRepository.Get(name);

                if (user != null)
                    users.Add(user);
            }

            return users;
        }

        #endregion

        #endregion
    }
}
