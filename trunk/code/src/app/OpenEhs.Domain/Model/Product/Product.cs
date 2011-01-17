/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Product
    {
        #region Fields

        private int _id;
        private string _name;
        private string _description;
        private string _unit;
        private Category _category;
        private decimal _price;
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

        public string Unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        public Category Category
        {
            get { return _category; }
            set { _category = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public int QuantityOnHand
        {
            get { return _quantityOnHand; }
            set { _quantityOnHand = value; }
        }

        #endregion

        #region Constructor(s)

        public Product(int id, string name, string description, string unit, Category category, decimal price, int quantityOnHand)
        {
            Id = id;
            Name = name;
            Description = description;
            Unit = unit;
            Category = category;
            Price = price;
            QuantityOnHand = quantityOnHand;
        }

        #endregion
    }
}
