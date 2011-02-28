using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class PatientAllergyRepository : IPatientAllergyRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }
        public PatientAllergy Get(int id)
        {
            return Session.Get<PatientAllergy>(id);
        }
        public IList<PatientAllergy> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<PatientAllergy>();
            return criteria.List<PatientAllergy>();
        }
        public void Add(PatientAllergy entity)
        {
            Session.Save(entity);
        }
        public void Remove(PatientAllergy entity)
        {
            Session.Delete(entity);
        }
    }
}
