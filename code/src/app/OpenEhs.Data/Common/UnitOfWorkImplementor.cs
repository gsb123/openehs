using System.Data;
using NHibernate;

namespace OpenEhs.Data
{
    public class UnitOfWorkImplementor : IUnitOfWork
    {
        private readonly UnitOfWorkFactory _factory;
        private readonly ISession _session;

        public bool IsInActiveTransaction
        {
            get
            {
                return _session.Transaction.IsActive;
            }
        }

        public IUnitOfWorkFactory Factory
        {
            get
            {
                return _factory;
            }
        }

        public ISession Session
        {
            get
            {
                return _session;
            }
        }

        public UnitOfWorkImplementor(UnitOfWorkFactory factory, ISession session)
        {
            _factory = factory;
            _session = session;
        }

        public IGenericTransaction BeginTransaction()
        {
            return new GenericTransaction(_session.BeginTransaction());
        }

        public IGenericTransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return new GenericTransaction(_session.BeginTransaction(isolationLevel));
        }

        public void TransactionalFlush()
        {
            TransactionalFlush(IsolationLevel.ReadCommitted);
        }

        public void TransactionalFlush(IsolationLevel isolationLevel)
        {
            IGenericTransaction tx = BeginTransaction(isolationLevel);

            try
            {
                tx.Commit();
            }
            catch
            {
                tx.Rollback();
                throw;
            }
            finally
            {
                tx.Dispose();
            }
        }

        public void Dispose()
        {
            _factory.DisposeUnitOfWork(this);
            _session.Dispose();
        }

        public void Flush()
        {
            _session.Flush();
        }
    }
}