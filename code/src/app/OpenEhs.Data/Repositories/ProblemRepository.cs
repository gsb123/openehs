using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using OpenEhs.Domain;

namespace OpenEhs.Data
{
    public class ProblemRepository : IProblemRepository
    {
        private ISession Session
        {
            get
            {
                return UnitOfWork.CurrentSession;
            }
        }
        public Problem Get(int id)
        {
            return Session.Get<Problem>(id);
        }
        public IList<Problem> GetAll()
        {
            ICriteria criteria = Session.CreateCriteria<Problem>();
            return criteria.List<Problem>();
        }
        public void Add(Problem entity)
        {
            Session.Save(entity);
        }
        public void Remove(Problem entity)
        {
            Session.Delete(entity);
        }
    }
}
