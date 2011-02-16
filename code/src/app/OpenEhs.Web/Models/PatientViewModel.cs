﻿using System.ComponentModel.DataAnnotations;
using OpenEhs.Domain;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using OpenEhs.Data;

namespace OpenEhs.Web.Models
{
    #region Models

    public class PatientViewModel
    {
        private Patient _patient;

        public PatientViewModel(int patientId)
        {
            _patient = new PatientRepository().Get(patientId);
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

        [Required]
        [DisplayName("Note")]
        public Note Note
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

        [Required]
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

        [Required]
        [DisplayName("Immunizations")]
        public IList<Immunization> Immunizations
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

        [Required]
        [DisplayName("Medications")]
        public IList<Medication> Medications
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
            foreach(PatientCheckIn checkIn in PatientCheckIns)
            {
                if (checkIn.Id == encounterId)
                {
                    PatientCheckIns.Remove(checkIn);
                    return true;
                }
            }

            return false;
        }

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

        public void AddAllergy(Allergy allergy)
        {
            Allergies.Add(allergy);
        }

        public void RemoveAllergy(Allergy allergy)
        {
            Allergies.Remove(allergy);
        }

        /// <summary>
        /// Remove the allergy by ID
        /// </summary>
        /// <param name="allergyId">ID of the allergy to remove</param>
        /// <returns>If the allergy was successfully removed</returns>
        public bool RemoveAllergy(int allergyId)
        {
            foreach (Allergy allergy in Allergies)
            {
                if (allergy.Id == allergyId)
                {
                    Allergies.Remove(allergy);
                    return true;
                }
            }

            return false;
        }

        public void AddImmunization(Immunization immunization)
        {
            Immunizations.Add(immunization);
        }

        public void RemoveImmunization(Immunization immunization)
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
            foreach (Immunization immunization in Immunizations)
            {
                if (immunization.Id == immunizationId)
                {
                    Immunizations.Remove(immunization);
                    return true;
                }
            }

            return false;
        }

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

        #endregion

    }

    #endregion
}

    