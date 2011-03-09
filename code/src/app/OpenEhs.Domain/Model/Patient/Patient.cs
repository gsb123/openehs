/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: Jan-12-2011
 * 
 * Author: Cameron Harp (charp5257@gmail.com)
 *****************************************************************************/

using System;
using System.Collections.Generic;

namespace OpenEhs.Domain
{
    public class Patient : IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual int Age
        {
            get 
            { 
                var age = DateTime.Now.Subtract(DateOfBirth);
                return age.Days/365;
            }
        }
        public virtual Gender Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual EmergencyContact EmergencyContact { get; set; }
        public virtual Address Address { get; set; }
        public virtual BloodTypes BloodType { get; set; }
        public virtual Tribes Tribe { get; set; }
        public virtual Races Race { get; set; }
        public virtual Religions Religion { get; set; }
        public virtual Education Education { get; set; }
        public virtual string Occupation { get; set; }
        public virtual string InsuranceNumber { get; set; }
        public virtual DateTime InsuranceExpiration { get; set; }
        public virtual string Note { get; set; }
        public virtual string OldPhysicalRecordNumber { get; set; }
        public virtual DateTime DateOfDeath { get; set; }
        public virtual bool IsActive { get; set; }

        public virtual IList<PatientCheckIn> PatientCheckIns { get; set; }
        public virtual IList<PatientProblem> Problems { get; set; }
        public virtual IList<PatientAllergy> Allergies { get; set; }
        public virtual IList<PatientMedication> Medications { get; set; }
        public virtual IList<PatientImmunization> Immunizations { get; set; }

        #endregion
    }
}
