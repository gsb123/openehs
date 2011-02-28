/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-19-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Configuration.Provider;
using System.Web.Security;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Infrastructure.Security
{
    public class OpenEhsMembershipProvider : MembershipProvider
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion


        #region Properties

        public override string ApplicationName
        {
            get
            {
                return System.Web.Hosting.HostingEnvironment.ApplicationVirtualPath;
            }
            set {}
        }

        public override bool EnablePasswordRetrieval
        {
            get { return false; }
        }

        public override bool EnablePasswordReset
        {
            get { return false; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return false; }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { return 10; }
        }

        public override int PasswordAttemptWindow
        {
            get { return 30; }
        }

        public override bool RequiresUniqueEmail
        {
            get { return false; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return MembershipPasswordFormat.Hashed; }
        }

        public override int MinRequiredPasswordLength
        {
            get { return 6; }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return 0; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return @"(?=.{6,})(?=(.*\d){1,})(?=(.*\W){1,})"; }
        }

        #endregion


        #region Constructor

        public OpenEhsMembershipProvider()
        {
            _userRepository = new UserRepository();
        }

        #endregion


        #region Methods

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            var user = new MembershipUser("OpenEhsMembershipProvider", username, null, email, passwordQuestion, "", false, false, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.MinValue);

            if (_userRepository.CheckForUsernameAvailability(username))
            {
                status = MembershipCreateStatus.Success;
            }
            else
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return user;
            }

            if (password.Length < MinRequiredPasswordLength)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return user;
            }

            return user;
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            var existing = _userRepository.Get(user.UserName);

            if (existing == null)
                throw new ProviderException("That user does not exist.");

            existing.Username = user.UserName;
            existing.EmailAddress = user.Email;
            existing.PasswordQuestion = user.PasswordQuestion;
            existing.IsApproved = user.IsApproved;
            existing.IsLockedOut = user.IsLockedOut;
            existing.LastLockout = user.LastLockoutDate;
            existing.LastLogin = user.LastLoginDate;
            existing.IsOnline = user.IsOnline;
        }

        public override bool ValidateUser(string username, string password)
        {
            var users = _userRepository.Find(username, password);
            return users.Count != 0;
        }

        public override bool UnlockUser(string userName)
        {
            var user = _userRepository.Get(userName);
            user.IsLockedOut = false;

            return true;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = _userRepository.Get(username);

            if (user == null)
                throw new ProviderException("The specified user does not exist.");

            user.IsOnline = userIsOnline;
            return TransformUser(user);
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public bool UsernameExists(string username)
        {
            return _userRepository.CheckForUsernameAvailability(username);
        }


        #region Private Methods

        private static MembershipUser TransformUser(User user)
        {
            return new MembershipUser("OpenEhsMembershipProvider",
                                      user.Username,
                                      null,
                                      user.EmailAddress,
                                      user.PasswordQuestion,
                                      String.Empty,
                                      user.IsApproved,
                                      user.IsLockedOut,
                                      user.DateCreated,
                                      user.LastLogin,
                                      user.LastActivity,
                                      user.LastPasswordChange,
                                      user.LastLockout);
        }

        #endregion

        #endregion
    }
}
