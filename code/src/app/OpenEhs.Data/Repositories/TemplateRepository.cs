using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class TemplateRepository : ITemplateRepository
    {
        public Template Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Template> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Template entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(Template entity)
        {
            throw new NotImplementedException();
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
