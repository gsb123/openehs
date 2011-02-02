/*****************************************************************************
 * Project: Open Electronic Healthcare System
 * Group: Ghana Team
 * Date: 1-Feb-2011
 * 
 * Author: Matthew Kimber (matthew.kimber@gmail.com)
 *****************************************************************************/

using NHibernate;
using NHibernate.Cfg;

namespace OpenEhs.Data
{
    public interface IUnitOfWorkFactory
    {
        Configuration Configuration { get; }
        ISession CurrentSession { get; set; }
        ISessionFactory SessionFactory { get; }
        IUnitOfWork Create();
        void DisposeUnitOfWork(IUnitOfWorkImplementor adapter);
    }
}