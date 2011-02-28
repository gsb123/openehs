using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class CreatePatientViewModel
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Street 1")]
        public string Street1 { get; set; }

        [Display(Name = "Street 2")]
        public string Street2 { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Region { get; set; }

        [Required]
        public string Country { get; set; }

        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [Display(Name = "Tribe/Race")]
        public string TribeRace { get; set; }

        public string Religion { get; set; }

        [Display(Name = "Old Physical Number")]
        public string OldPhysicalRecordNumber { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string EcFirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string EcLastName { get; set; }

        [Display(Name = "Phone Number")]
        public string EcPhoneNumber { get; set; }

        [Required]
        [Display(Name = "Relationship")]
        public Relationship EcRelationship { get; set; }

        public SelectList Relationships
        {
            get
            {
                var types = from Relationship s in Enum.GetValues(typeof(Relationship))
                            select new { Id = s, Name = s.ToString() };

                return new SelectList(types, "Id", "Name");
            }
        }


        [Display(Name = "Street 1")]
        public string EcStreet1 { get; set; }

        [Display(Name = "Street 2")]
        public string EcStreet2 { get; set; }

        [Display(Name = "City")]
        public string EcCity { get; set; }

        [Display(Name = "Region")]
        public string EcRegion { get; set; }

        [Display(Name = "Country")]
        public string EcCountry { get; set; }

        public CreatePatientViewModel()
        {
            DateOfBirth = DateTime.Now;
        }
    }
}