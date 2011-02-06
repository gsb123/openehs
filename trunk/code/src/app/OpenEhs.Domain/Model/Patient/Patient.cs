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
    public class Patient: IEntity
    {
        #region Properties

        public virtual int Id { get; private set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime DateOfBirth { get; set; }
        public virtual string Gender { get; set; }
        public virtual string PhoneNumber { get; set; }
        public virtual IList<Problem> Problems { get; set; }
        public virtual IList<Allergy> Allergies { get; set; }
        public virtual Address Address { get; set; }
        public virtual string BloodType { get; set; }
        public virtual string TribeRace { get; set; }
        public virtual string Religion { get; set; }
        public virtual int OldPhysicalRecordNumber { get; set; }
        public virtual bool IsActive { get; set; }

        #endregion

        #region Methods
        
        public virtual void AddProblem(Problem problem)
        {
            Problems.Add(problem);
        }

        public virtual void RemoveProblem(Problem problem)
        {
            Problems.Remove(problem);
        }
        
        #endregion
    }
}
