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
    public class Address
    {
        #region Fields

        private int _id;
        private string _street1;
        private string _street2;
        private string _city;
        private string _region;
        private string _country;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Street1
        {
            get { return _street1; }
            set { _street1 = value; }
        }

        public string Street2
        {
            get { return _street2; }
            set { _street2 = value; }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        #endregion

        #region Constructor(s)

        public Address(int id, string street1, string street2, string city, string region, string country)
        {
            Id = id;
            Street1 = street1;
            Street2 = street2;
            City = city;
            Region = region;
            Country = country;
        }

        #endregion
    }
}
