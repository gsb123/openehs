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
    public class Service
    {
        #region Fields

        private int _id;
        private string _name;
        private decimal _servicecost;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public decimal ServiceCost
        {
            get { return _servicecost; }
            set { _servicecost = value; }
        }

        #endregion

        #region Constructor(s)

        public Service(int id, string name, decimal servicecost)
        {
            Id = id;
            Name = name;
            ServiceCost = servicecost;
        }

        #endregion
    }
}
