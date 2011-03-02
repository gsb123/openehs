using System.Collections.Generic;
using System.Linq;
using OpenEhs.Data;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class AdminViewModel
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILocationRepository _locationRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IAllergyRepository _allergyRepository;
        private readonly IImmunizationRepository _immunizationRepository;
        private readonly IMedicationRepository _medicationRepository;

        public AdminViewModel()
        {
            _productRepository = new ProductRepository();
            _categoryRepository = new CategoryRepository();
            _locationRepository = new LocationRepository();
            _serviceRepository = new ServiceRepository();
            _allergyRepository = new AllergyRepository();
            _immunizationRepository = new ImmunizationRepository();
            _medicationRepository = new MedicationRepository();
        }

        public IList<Product> Products
        {
            get
            {
                return _productRepository.GetAll();
            }
        }

        public IList<Product> ActiveProducts
        {
            get
            {

                var prod = from activeProd in Products
                           where activeProd.IsActive == true
                           select activeProd;

                return prod.ToList();
            }
        }

        public IList<Category> Categories
        {
            get
            {
                return _categoryRepository.GetAll();
            }
        }

        public IList<Category> ActiveCategories
        {
            get
            {
                var cat = from activeCat in Categories
                          where activeCat.IsActive == true
                          select activeCat;

                return cat.ToList();
            }
        }

        public IList<Allergy> Allergies
        {
            get
            {
                return _allergyRepository.GetAll();
            }
        }

        public IList<Allergy> ActiveAllergies
        {
            get
            {
                var allergy = from activeAll in Allergies
                          where activeAll.IsActive == true
                          select activeAll;

                return allergy.ToList();
            }
        }

        public IList<Immunization> Immunizations
        {
            get
            {
                return _immunizationRepository.GetAll();
            }
        }

        public IList<Immunization> ActiveImmunizations
        {
            get
            {
                var immun = from activeImm in Immunizations
                              where activeImm.IsActive == true
                              select activeImm;

                return immun.ToList();
            }
        }

        public IList<Medication> Medications
        {
            get
            {
                return _medicationRepository.GetAll();
            }
        }

        public IList<Medication> ActiveMedications
        {
            get
            {
                var med = from activeMed in Medications
                            where activeMed.IsActive == true
                            select activeMed;

                return med.ToList();
            }
        }

        public IList<Location> Locations
        {
            get
            {
                return _locationRepository.GetAll();
            }
        }

        public IList<Location> ActiveLocations
        {
            get
            {
                var loc = from activeLoc in Locations
                          where activeLoc.IsActive == true
                          select activeLoc;

                return loc.ToList();
            }
        }

        public IList<Service> Services
        {
            get
            {
                return _serviceRepository.GetAll();
            }
        }

        public IList<Service> ActiveServices
        {
            get
            {
                var ser = from activeSer in Services
                          where activeSer.IsActive == true
                          select activeSer;

                return ser.ToList();
            }
        }
    }
}