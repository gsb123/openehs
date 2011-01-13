using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class Products
    {
        #region Fields

        private int _id;
        private string _name;
        private string _unit;
        private string _catagory;   //TODO split to table (abstract it out)
        private decimal _unitcost;
        private int _quantityonhand;

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

        public string Catagory
        {
            get { return _catagory; }
            set { _catagory = value; }
        }

        public decimal UnitCost
        {
            get { return _unitcost; }
            set { _unitcost = value; }
        }

        public int QuantityOnHand
        {
            get { return _quantityonhand; }
            set { _quantityonhand = value; }
        }

        #endregion

        #region Constructor(s)

        public Products(int id, string name, string unit, string catagory, decimal unitcost, int quantityonhand)
        {
            Id = id;
            Name = name;
            Unit = unit;
            Catagory = catagory;
            UnitCost = unitcost;
            QuantityOnHand = quantityonhand;
        }

        #endregion
    }
}
