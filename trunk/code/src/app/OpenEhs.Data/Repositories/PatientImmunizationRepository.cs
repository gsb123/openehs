using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenEhs.Domain;
using NHibernate;

namespace OpenEhs.Data {
    public class PatientImmunizationRepository : IPatientImmunizationRepository {
        private ISession Session {
            get {
                return UnitOfWork.CurrentSession;
            }
        }
        public PatientImmunization Get(int id) {
            return Session.Get<PatientImmunization>(id);
        }
        public IList<PatientImmunization> GetAll() {
            ICriteria criteria = Session.CreateCriteria<PatientImmunization>();
            return criteria.List<PatientImmunization>();
        }
        public void Add(PatientImmunization entity) {
            Session.Save(entity);
        }
        public void Remove(PatientImmunization entity) {
            Session.Delete(entity);
        }
    }
}
