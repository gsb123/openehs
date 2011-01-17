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
    public class Product
    {
        #region Fields

        private int _id;
        private string _name;
        private string _unit;
        private string _category;   //TODO split to table (abstract it out)
        private decimal _unitCost;
        private int _quantityOnHand;

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

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public string Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public decimal UnitCost
        {
            get { return _unitCost; }
            set { _unitCost = value; }
        }

        public int QuantityOnHand
        {
            get { return _quantityOnHand; }
            set { _quantityOnHand = value; }
        }

        #endregion

        #region Constructor(s)

        public Product(int id, string name, string unit, string catagory, decimal unitcost, int quantityonhand)
        {
            Id = id;
            Name = name;
            Unit = unit;
            Category = catagory;
            UnitCost = unitcost;
            QuantityOnHand = quantityonhand;
        }

        #endregion
    }
}
