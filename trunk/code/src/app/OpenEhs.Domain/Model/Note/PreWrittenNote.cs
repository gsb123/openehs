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
    public class PreWrittenNote
    {
        #region Fields

        private int _id;
        private string _body;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Body
        {
            get { return _body; }
            set { _body = value; }
        }

        #endregion

        #region Constructor(s)

        public PreWrittenNote(int id, string body)
        {
            Id = id;
            Body = body;
        }

        #endregion
    }
}
