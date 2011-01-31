using NHibernate;
using NHibernate.Cfg;

namespace OpenEhs.Data
{
    public interface IUnitOfWorkFactory
    {
        Configuration Configuration { get; }
        ISession CurrentSession { get; set; }
        ISessionFactory SessionFactory { get; set; }
        IUnitOfWork Create();
        void DisposeUnitOfWork();
    }
}