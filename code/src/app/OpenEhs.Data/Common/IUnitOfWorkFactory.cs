namespace OpenEhs.Data
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}