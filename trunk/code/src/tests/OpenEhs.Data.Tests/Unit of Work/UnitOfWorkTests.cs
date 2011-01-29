using System;
using NUnit.Framework;

namespace OpenEhs.Data.Tests.Unit_of_Work
{
    [TestFixture]
    public class UnitOfWorkTests
    {
        [Test]
        public void CanStartUnitOfWork()
        {
            IUnitOfWork uow = UnitOfWork.Start();
        }
    }

    public static class UnitOfWork
    {
        public static IUnitOfWork Current { get; private set; }
        
        public static IUnitOfWork Start()
        {
            throw new NotImplementedException();
        }
    }

    public interface IUnitOfWork : IDisposable
    {
    }
}
