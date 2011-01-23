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
        #region Properties

        public int Id { get; private set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }

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
