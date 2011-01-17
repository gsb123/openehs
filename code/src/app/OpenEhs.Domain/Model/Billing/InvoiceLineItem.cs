/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

namespace OpenEhs.Domain
{
    public class InvoiceLineItem
    {
        #region Fields

        private int _id;
        private Product _product;
        private Service _service;
        private decimal _quantity; // NOTE: So, is there a reason for this to be a floating point number?

        #endregion


        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public Service Service
        {
            get { return _service; }
            set { _service = value; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public decimal Total
        {
            get
            {
                if (_service != null)
                    return _service.Price;

                return _product.Price * Quantity;
            }
        }

        #endregion


        #region Constructor(s)

        public InvoiceLineItem(int id, Product product, Service service, decimal quantity)
        {
            Id = id;
            Product = product;
            Service = service;
            Quantity = quantity;
        }

        #endregion
    }
}
