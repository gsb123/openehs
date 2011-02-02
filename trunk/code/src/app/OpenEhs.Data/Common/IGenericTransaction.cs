using System;

namespace OpenEhs.Data
{
    public interface IGenericTransaction : IDisposable
    {
        void Commit();
        void Rollback();
    }
}