using NHibernate;

namespace OpenEhs.Data
{
    public class UnitOfWorkImplementor : IUnitOfWork
    {
        private readonly UnitOfWorkFactory _factory;
        private readonly ISession _session;

        public UnitOfWorkImplementor(UnitOfWorkFactory factory, ISession session)
        {
            _factory = factory;
            _session = session;
        }

        public void Dispose()
        {
        }
    }
}