/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-17-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Category: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual IList<Product> Products { get; set; }
        public virtual DateTime DateCreated { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        public virtual void AddProduct(Product product)
        {
            product.Category = this;
            Products.Add(product);
        }
    }
}
