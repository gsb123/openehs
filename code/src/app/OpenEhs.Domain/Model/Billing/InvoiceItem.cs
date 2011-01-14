using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenEhs.Domain
{
    public class InvoiceItem
    {
        #region Fields

        private int _id;
        private Invoice _invoiceid;
        private Products _productsid;
        private Service _serviceid;
        private decimal _quantity;

        #endregion

        #region Properties

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Invoice InvoiceID
        {
            get { return _invoiceid; }
            set { _invoiceid = value; }
        }

        public Products ProductsID
        {
            get { return _productsid; }
            set { _productsid = value; }
        }

        public Service ServiceID
        {
            get { return _serviceid; }
            set { _serviceid = value; }
        }

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        #endregion

        #region Constructor(s)

        public InvoiceItem(int id, Invoice invoiceid, Products productsid, Service serviceid, decimal quantity)
        {
            Id = id;
            InvoiceID = invoiceid;
            ProductsID = productsid;
            ServiceID = serviceid;
            Quantity = quantity;
        }

        #endregion
    }
}
