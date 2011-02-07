using System.ComponentModel.DataAnnotations;
using OpenEhs.Domain;
using System.ComponentModel;
using System;
using System.Collections.Generic;

namespace OpenEhs.Web.Models
{
    #region Models

    public class PatientModel 
    {
        private Patient _patient;

        #region Patient

        [Required]
        [DisplayName("ID")]
        public int Id
        {
            get
            {
                return _patient.Id;
            }
        }

        [Required]
        [DisplayName("First Name")]
        public string FirstName
        {
            get
            {
                return _patient.FirstName;
            }
            set
            {
                _patient.FirstName= value;
            }
        }

        [Required]
        [DisplayName("Middle Name")]
        public string MiddleName
        {
            get
            {
                return _patient.MiddleName;
            }
            set
            {
                _patient.MiddleName = value;
            }
        }

        [Required]
        [DisplayName("Last Name")]
        public string LastName
        {
            get
            {
                return _patient.LastName;
            }
            set
            {
                _patient.LastName = value;
            }
        }

        [Required]
        [DisplayName("Date of Birth")]
        public DateTime DateOfBirth
        {
            get
            {
                return _patient.DateOfBirth;
            }
            set
            {
                _patient.DateOfBirth = value;
            }
        }

        [Required]
        [DisplayName("Age")]
        public int Age
        {
            get
            {
                return _patient.Age;
            }
        }

        [Required]
        [DisplayName("Gender")]
        public string Gender
        {
            get
            {
                return _patient.Gender;
            }
            set
            {
                _patient.Gender = value;
            }
        }

        [Required]
        [DisplayName("Phone Number")]
        public string PhoneNumber
        {
            get
            {
                return _patient.PhoneNumber;
            }
            set
            {
                _patient.PhoneNumber = value;
            }
        }

        [Required]
        [DisplayName("Problems")]
        public IList<Problem> Problems
        {
            get
            {
                return _patient.Problems;
            }
            set
            {
                _patient.Problems = value;
            }
        }

        public void AddProblem(Problem problem)
        {
            Problems.Add(problem);
        }

        public void RemoveProblem(Problem problem)
        {
            Problems.Remove(problem);
        }

        [Required]
        [DisplayName("Allergies")]
        public IList<Allergy> Allergies
        {
            get
            {
                return _patient.Allergies;
            }
            set
            {
                _patient.Allergies = value;
            }
        }

        public void AddAllergy(Allergy allergy)
        {
            Allergies.Add(allergy);
        }

        public void RemoveAllergy(Allergy allergy)
        {
            Allergies.Remove(allergy);
        }

        [Required]
        [DisplayName("Emergency Contact")]
        public EmergencyContact EmergencyContact
        { 
            get
            {
                return _patient.EmergencyContact;
            }
            set
            {
                _patient.EmergencyContact = value;
            }
        }

        [Required]
        [DisplayName("Address")]
        public Address Address
        {
            get
            {
                return _patient.Address;
            }
            set
            {
                _patient.Address = value;
            }
        }

        [Required]
        [DisplayName("Blood Type")]
        public string BloodType
        {
            get
            {
                return _patient.BloodType;
            }
            set
            {
                _patient.BloodType = value;
            }
        }

        [Required]
        [DisplayName("Tribe/Race")]
        public string TribeRace
        {
            get
            {
                return _patient.TribeRace;
            }
            set
            {
                _patient.TribeRace = value;
            }
        }

        [Required]
        [DisplayName("Religion")]
        public string Religion
        {
            get
            {
                return _patient.Religion;
            }
            set
            {
                _patient.Religion = value;
            }
        }

        [Required]
        [DisplayName("Old Physical Record Number")]
        public int OldPhysicalRecordNumber
        {
            get
            {
                return _patient.OldPhysicalRecordNumber;
            }
            set
            {
                _patient.OldPhysicalRecordNumber = value;
            }
        }

        [Required]
        [DisplayName("Active")]
        public bool IsActive
        {
            get
            {
                return _patient.IsActive;
            }
            set
            {
                _patient.IsActive = value;
            }
        }

        #endregion


    }

    #endregion
}

    
