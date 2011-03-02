﻿using System.ComponentModel.DataAnnotations;
using System.Linq;
using OpenEhs.Domain;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using OpenEhs.Data;
using System.Web;

namespace OpenEhs.Web.Models
{
    #region Models

    public class PatientViewModel
    {
        private Patient _patient;
        private Staff _staff;
        private ImmunizationRepository _immunization;

        public PatientViewModel(int patientId)
        {
            _patient = new PatientRepository().Get(patientId);
            _immunization = new ImmunizationRepository();
        }

        #region Patient Properties

        [Required]
        [DisplayName("Patient ID")]
        public int PatientId
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
                _patient.FirstName = value;
            }
        }

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
        public Gender Gender
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

        [DisplayName("Phone Number")]
        [RegularExpression(@"^([0-9]{3})[ ]{1}([0-9]{3})[ ]{1}([0-9]{4})$", ErrorMessage = "Please format phone to XXX XXX XXXX")]
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

        [DisplayName("Old Physical Record Number")]
        public string OldPhysicalRecordNumber
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

        [DisplayName("Note")]
        public string Note
        {
            get
            {
                return _patient.Note;
            }
            set
            {
                _patient.Note = value;
            }
        }

        [DisplayName("CheckIns")]
        public IList<PatientCheckIn> PatientCheckIns
        {
            get
            {
                return _patient.PatientCheckIns;
            }
            set
            {
                _patient.PatientCheckIns = value;
            }
        }

        [DisplayName("Problems")]
        public IList<PatientProblem> Problems
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


        [DisplayName("Allergies")]
        public IList<PatientAllergy> PatientAllergies
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

        [DisplayName("Immunizations")]
        public IList<PatientImmunization> Immunizations
        {
            get
            {
                return _patient.Immunizations;
            }
            set
            {
                _patient.Immunizations = value;
            }
        }

        [DisplayName("Medications")]
        public IList<PatientMedication> Medications
        {
            get
            {
                return _patient.Medications;
            }
            set
            {
                _patient.Medications = value;
            }
        }

        public IList<PatientMedication> CurrentMedications
        {
            get
            {
                var currentMeds = from med in Medications
                                  where med.ExpDate >= DateTime.Now
                                  select med;

                return currentMeds.ToList();
            }
        }

        public IList<PatientMedication> PastMedications
        {
            get
            {
                var pastMeds = from med in Medications
                               where med.ExpDate <= DateTime.Now
                               select med;

                return pastMeds.ToList();
            }
        }

        public IList<PatientImmunization> TenImmunization
        {
            get
            {
                var valShots = from immun in Immunizations
                               select immun;

                return valShots.ToList();
            }
        }

        public IList<PatientImmunization> PriorImmunization
        {
            get
            {
                var valShots = from immun in Immunizations
                               where immun.DateAdministered <= DateTime.Now.AddYears(-10)
                               select immun;

                return valShots.ToList();
            }
        }

        public IList<PatientImmunization> TenYearImmunization
        {
            get
            {
                var valShots = from immun in Immunizations
                               where immun.DateAdministered >= DateTime.Now.AddYears(-10)
                               select immun;

                return valShots.ToList();
            }
        }
         
        public PatientCheckIn GetOpenCheckin
        {
            get
            {
                try
                {
                    var query = from checkin in PatientCheckIns
                                where checkin.CheckOutTime == DateTime.MinValue
                                select checkin;

                    return query.First<PatientCheckIn>();
                }
                catch (Exception e)
                {
                    return null;
                }
            }
        }

        public IList<PatientCheckIn> SearchCheckIns
        {
            get
            {
                var searchVisits = from sci in PatientCheckIns
                                   select sci;

                return searchVisits.ToList();
            }
        }

        public IList<PatientCheckIn> SearchCheckInsTop1
        {
            get
            {
                var visitsTopOne = (from sci in PatientCheckIns
                                    orderby sci.Id descending
                                    select sci).Take(1);

                return visitsTopOne.ToList();
            }
        }

        public IList<Location> GetLocations
        {
            get
            {
                LocationRepository locations = new LocationRepository();
                return locations.GetAll();
            }
        }

        public IList<Staff> GetStaff
        {
            get
            {
                StaffRepository staffMembers = new StaffRepository();
                return staffMembers.GetAll();
            }
        }

        public IList<Immunization> AllImmunizations
        {
            get
            {
                ImmunizationRepository immun = new ImmunizationRepository();
                return immun.GetAll();
            }
        }

        public IList<Problem> AllProblems
        {
            get
            {
                ProblemRepository probRepo = new ProblemRepository();
                return probRepo.GetAll();
            }
        }

        public IList<Allergy> AllAllergies
        {
            get
            {
                AllergyRepository allergy = new AllergyRepository();
                return allergy.GetAll();
            }
        }

        public IList<Medication> AllMedications
        {
            get
            {
                MedicationRepository meds = new MedicationRepository();
                return meds.GetAll();
            }
        }

        public IList<Staff> GetActivePhysicians
        {
            get
            {
                StaffRepository staff = new StaffRepository();
                return staff.FindByType(StaffType.Physician);
            }
        }

        public IList<Invoice> Invoices
        {
            get
            {
                InvoiceRepository repo = new InvoiceRepository();
                return repo.FindByPatientId(this._patient.Id);
            }
        }

        [DisplayName("Products")]
        public IList<Product> Products
        {
            get
            {
                return new ProductRepository().GetAll();
            }
        }

        [DisplayName("Services")]
        public IList<Service> Services
        {
            get
            {
                return new ServiceRepository().GetAll();
            }
        }

        #endregion



        #region Patient Methods

        public void AddEncounter(PatientCheckIn checkIn)
        {
            PatientCheckIns.Add(checkIn);
        }

        public void RemoveEncounter(PatientCheckIn checkIn)
        {
            PatientCheckIns.Remove(checkIn);
        }

        /// <summary>
        /// Remove the encounter by ID
        /// </summary>
        /// <param name="encounterId">ID of the encounter to remove</param>
        /// <returns>If the encounter was successfully removed</returns>
        public bool RemoveEncounter(int encounterId)
        {
            foreach (PatientCheckIn checkIn in PatientCheckIns)
            {
                if (checkIn.Id == encounterId)
                {
                    PatientCheckIns.Remove(checkIn);
                    return true;
                }
            }

            return false;
        }

        /*
        public void AddProblem(Problem problem)
        {
            Problems.Add(problem);
        }

        public void RemoveProblem(Problem problem)
        {
            Problems.Remove(problem);
        }

        /// <summary>
        /// Remove the problem by ID
        /// </summary>
        /// <param name="problemId">ID of the problem to remove</param>
        /// <returns>If the problem was successfully removed</returns>
        public bool RemoveProblem(int problemId)
        {
            foreach (Problem problem in Problems)
            {
                if (problem.Id == problemId)
                {
                    Problems.Remove(problem);
                    return true;
                }
            }

            return false;
        }
         */

        public void AddImmunization(PatientImmunization immunization)
        {
            Immunizations.Add(immunization);
        }

        public void RemoveImmunization(PatientImmunization immunization)
        {
            Immunizations.Remove(immunization);
        }

        /// <summary>
        /// Remove the immunization by ID
        /// </summary>
        /// <param name="immunizationId">ID of the immunization to remove</param>
        /// <returns>If the immunization was successfully removed</returns>
        public bool RemoveImmunization(int immunizationId)
        {
            foreach (PatientImmunization immunization in Immunizations)
            {
                if (immunization.Id == immunizationId)
                {
                    Immunizations.Remove(immunization);
                    return true;
                }
            }

            return false;
        }

        /*
        public void AddMedication(Medication medication)
        {
            Medications.Add(medication);
        }

        public void RemoveMedication(Medication medication)
        {
            Medications.Remove(medication);
        }

        /// <summary>
        /// Remove the medication by ID
        /// </summary>
        /// <param name="medicationId">ID of the medication to remove</param>
        /// <returns>If the medication was successfully removed</returns>
        public bool RemoveMedication(int medicationId)
        {
            foreach (Medication medication in Medications)
            {
                if (medication.Id == medicationId)
                {
                    Medications.Remove(medication);
                    return true;
                }
            }

            return false;
        }
         */

        /// <summary>
        /// Get the ID for the invoice on the current PatientCheckIn (not checked out)
        /// </summary>
        /// <returns>The Id of the Invoice.</returns>
        public int GetCheckedInInvoiceId()
        {
            foreach (var checkin in _patient.PatientCheckIns)
            {
                if (checkin.CheckOutTime == null)
                {
                    return checkin.Invoice.Id;
                }
            }
            return 0;
        }

        public Invoice CurrentInvoice
        {
            get
            {
                foreach (var pci in PatientCheckIns)
                {
                    if (pci.CheckOutTime == DateTime.MinValue)
                    {
                        return pci.Invoice;
                    }
                }

                return null;
            }
        }

        public User CurrentUser
        {
            get
            {
                UserRepository userRepo = new UserRepository();
                return userRepo.Get(HttpContext.Current.User.Identity.Name);
            }
        }
        #endregion

    }

    #endregion
}