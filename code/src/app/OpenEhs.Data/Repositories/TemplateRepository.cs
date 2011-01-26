using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class TemplateRepository : ITemplateRepository
    {
        public ITemplate Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ITemplate> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(ITemplate entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(ITemplate entity)
        {
            throw new NotImplementedException();
        }

        public IList<ITemplate> GetAllSurgeryTemplates()
        {
            throw new NotImplementedException();
        }

        public IList<ITemplate> GetAllDiagnosisTemplates()
        {
            throw new NotImplementedException();
        }

        public IList<ITemplate> GetAllNoteTemplates()
        {
            throw new NotImplementedException();
        }

        public IList<ITemplate> GetAllReasonTemplates()
        {
            throw new NotImplementedException();
        }
    }
}
