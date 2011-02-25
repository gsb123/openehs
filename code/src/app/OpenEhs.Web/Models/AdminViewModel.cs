using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class AdminViewModel
    {
        public IList<Product> ListProducts
        {
            get
            {
                var repo = new ProductRepository();
                return repo.GetActiveProducts();
            }
        }
    }
}