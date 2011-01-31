using NHibernate;

namespace OpenEhs.Data
{
    public interface IUnitOfWorkFactory
    {
        ISession CurrentSession { get; set; }
        IUnitOfWork Create();
    }
}