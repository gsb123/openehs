/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class LogIn
    {
        #region Fields

        private int _id;
        private string _username;
        private string _password;
        private LogInPermissions _loginpermissions;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string UserName
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public LogInPermissions LogInPermissions
        {
            get { return _loginpermissions; }
            set { _loginpermissions = value; }
        }

        #endregion

        #region Constructor(s)

        public LogIn(int id, string username, string password, LogInPermissions loginpermissions)
        {
            Id = id;
            UserName = username;
            Password = password;
            LogInPermissions = loginpermissions;
        }

        #endregion
    }
}
