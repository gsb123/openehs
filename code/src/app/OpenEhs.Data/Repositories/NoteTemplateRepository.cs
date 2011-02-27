using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class NoteTemplateRepository : INoteTemplateRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }
        public NoteTemplateCategory Get(int id)
        {
            return Session.Get<NoteTemplateCategory>(id);
        }
        public IList<NoteTemplateCategory> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<NoteTemplateCategory>();
            return criteria.List<NoteTemplateCategory>();
        }
        public void Add(NoteTemplateCategory entity)
        {
            Session.Save(entity);
        }
        public void Remove(NoteTemplateCategory entity)
        {
            Session.Delete(entity);
        }
    }
    
}
