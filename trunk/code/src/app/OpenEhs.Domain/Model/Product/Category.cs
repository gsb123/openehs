/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-17-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;

namespace OpenEhs.Domain
{
    public class Category
    {
        #region Fields

        private string _name;
        private string _description;

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            set 
            {
                _description = value;
            }
        }

        #endregion

        #region Constructor

        public Category()
            : this(String.Empty, String.Empty)
        {}

        public Category(string name, string description)
        {
            Name = name;
            Description = description;
        }

        #endregion
    }
}
