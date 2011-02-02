namespace OpenEhs.Data
{
    public interface IUnitOfWorkImplementor : IUnitOfWork
    {
        void IncrementUsages();
    }
}