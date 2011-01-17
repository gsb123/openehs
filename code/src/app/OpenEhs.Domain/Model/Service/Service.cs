/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class Service
    {
        #region Fields

        private int _id;
        private string _name;
        private decimal _price;

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

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        #endregion

        #region Constructor(s)

        public Service(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        #endregion
    }
}
