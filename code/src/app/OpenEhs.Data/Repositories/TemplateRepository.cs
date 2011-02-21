using System;
using System.Collections.Generic;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class TemplateRepository : ITemplateRepository
    {
        private ISession Session
        {
            get { return UnitOfWork.CurrentSession; }
        }

        public Template Get(int id)
        {
            return Session.Get<Template>(id);
        }

        public IList<Template> GetAll()
        {
            var criteria = Session.CreateCriteria<Template>();
            return criteria.List<Template>();
        }

        public void Add(Template entity)
        {
            Session.Save(entity);
        }

        public void Remove(Template entity)
        {
            Session.Delete(entity);
        }

        public IList<Template> GetAllSurgeryTemplates()
        {
            throw new NotImplementedException();
        }

        public IList<Template> GetAllDiagnosisTemplates()
        {
            throw new NotImplementedException();
        }

        public IList<Template> GetAllNoteTemplates()
        {
            throw new NotImplementedException();
        }

        public IList<Template> GetAllReasonTemplates()
        {
            throw new NotImplementedException();
        }
    }
}
