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
    public class PreWrittenSurgeryType
    {
        #region Fields

        private int _id;
        private string _surgerytype;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string SurgeryType
        {
            get { return _surgerytype; }
            set { _surgerytype = value; }
        }

        #endregion

        #region Constructor(s)

        public PreWrittenSurgeryType(int id, string surgerytype)
        {
            Id = id;
            SurgeryType = surgerytype;
        }

        #endregion
    }
}
