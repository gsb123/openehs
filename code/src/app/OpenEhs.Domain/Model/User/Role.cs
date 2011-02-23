/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-19-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Role : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<User> Users { get; private set; }
        public virtual DateTime DateCreated { get; set; }

        #endregion


        #region Constructors

        public Role()
            : this(String.Empty, String.Empty, DateTime.Now)
        {}

        public Role(string name, string description, DateTime dateCreated)
        {
            Name = name;
            Description = description;
            Users = new List<User>();
            DateCreated = dateCreated;
        }

        #endregion


        #region Methods

        public virtual void AddUser(User user)
        {
            Users.Add(user);
        }

        public virtual void AddUsers(IList<User> users)
        {
            foreach(var user in users)
            {
                AddUser(user);
            }
        }

        public virtual void RemoveUser(User user)
        {
            Users.Remove(user);
        }

        public virtual void RemoveUsers(IList<User> users)
        {
            foreach(var user in users)
            {
                RemoveUser(user);
            }
        }

        #endregion
    }
}