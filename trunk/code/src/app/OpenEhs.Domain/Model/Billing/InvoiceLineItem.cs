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
        #region Properties

        public virtual int Id { get; private set; }
        public virtual Product Product { get; set; }
        public virtual Service Service { get; set; }
        public virtual decimal Quantity { get; set; }
        public decimal Total
        {
            get
            {
                if (Service != null)
                    return Service.Price;

                return Product.Price * Quantity;
            }
        }

        #endregion
    }
}
