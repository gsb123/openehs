using System.Collections.Generic;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class AdminViewModel
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private ILocationRepository _locationRepository;
        private IServiceRepository _serviceRepository;

        public AdminViewModel()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
            _locationRepository = new LocationRepository();
            _serviceRepository = new ServiceRepository();
        }

        public IList<Product> Products
        {
            get
            {
                return _productRepository.GetAll();
            }
        }

        public IList<Category> Categories
        {
            get
            {
                return _categoryRepository.GetAll();
            }
        }

        public IList<Location> Locations
        {
            get
            {
                return _locationRepository.GetAll();
            }
        }

        public IList<Service> Services
        {
            get
            {
                return _serviceRepository.GetAll();
            }
        }
    }
}