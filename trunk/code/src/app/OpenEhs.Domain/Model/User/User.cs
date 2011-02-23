/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class User : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual IList<Role> Roles { get; private set; }
        public virtual string PasswordQuestion { get; set; }
        public virtual string PasswordAnswer { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastLogin { get; set; }
        public virtual bool IsOnline { get; set; }
        public virtual string IpAddress { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual DateTime LastLockout { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        public virtual bool IsApproved { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual Staff Staff { get; set; }
        
        #endregion


        #region Constructor

        public User()
            : this(String.Empty, String.Empty, String.Empty, String.Empty, String.Empty, false)
        {}

        public User(string username, string password, string emailAddress, string passwordQuestion, string passwordAnswer, bool isApproved)
        {
            Username = username;
            Password = password;
            EmailAddress = emailAddress;
            PasswordQuestion = passwordQuestion;
            PasswordAnswer = passwordAnswer;
            IsApproved = isApproved;
        }

        #endregion
    }
}
