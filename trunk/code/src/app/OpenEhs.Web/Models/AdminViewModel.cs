using System.Collections.Generic;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class AdminViewModel
    {
        private IProductRepository _productRepository;

        public AdminViewModel()
        {
            _productRepository = new ProductRepository();
        }

        public IList<Product> Products
        {
            get
            {
                return _productRepository.GetAll();
            }
        }
    }
}