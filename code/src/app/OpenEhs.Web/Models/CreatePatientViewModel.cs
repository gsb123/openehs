using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using OpenEhs.Domain;

namespace OpenEhs.Web.Models
{
    public class CreatePatientViewModel
    {
        [Required(ErrorMessage="Patient's First Name is required")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage="Patient's Last Name is required")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Patient's Date of Birth is required")]
        [DataType(DataType.Date, ErrorMessage = "Patient's Last Name is required")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage="Patient's Gender is required")]
        public Gender Gender { get; set; }

        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage="Patient's Street Address is required")]
        [Display(Name = "Address 1")]
        public string Street1 { get; set; }

        [Display(Name = "Address 2")]
        public string Street2 { get; set; }

        [Required(ErrorMessage = "Patient's City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Patient's Region is required")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Patient's Country is required")]
        public string Country { get; set; }

        [Display(Name = "Blood Type")]
        public string BloodType { get; set; }

        [Display(Name = "Tribe/Race")]
        public string TribeRace { get; set; }

        public string Religion { get; set; }

        [Display(Name = "Old Physical Number")]
        public string OldPhysicalRecordNumber { get; set; }

        [Required(ErrorMessage="Emergency Contact's First Name is required")]
        [Display(Name = "First Name")]
        public string EcFirstName { get; set; }

        [Required(ErrorMessage = "Emergency Contact's Last Name is required")]
        [Display(Name = "Last Name")]
        public string EcLastName { get; set; }

        [Display(Name = "Phone Number")]
        public string EcPhoneNumber { get; set; }

        [Required(ErrorMessage = "Emergency Contact's Relationship with the patient is required")]
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