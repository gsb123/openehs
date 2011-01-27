/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;

namespace OpenEhs.Domain
{
    public class User: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
        public virtual string PasswordQuestion { get; set; }
        public virtual string PasswordAnswer { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string ApplicationName { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual DateTime LastLogin { get; set; }
        public virtual bool IsOnline { get; set; }
        public virtual string IPAddress { get; set; }
        public virtual bool IsLockedOut { get; set; }
        public virtual DateTime LastLockout { get; set; }
        public virtual int FailedPasswordAttemptCount { get; set; }
        
        #endregion

    }
}
