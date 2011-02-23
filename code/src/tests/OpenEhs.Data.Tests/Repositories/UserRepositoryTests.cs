using NUnit.Framework;

namespace OpenEhs.Data.Tests.Repositories
{
    [TestFixture]
    public class UserRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
            UnitOfWork.Start();
        }

        [Test]
        public void CanAddAUser()
        {
            
        }
    }
}
