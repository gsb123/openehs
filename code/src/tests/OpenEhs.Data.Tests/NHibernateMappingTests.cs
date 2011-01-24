using System;
using System.Collections;
using FluentNHibernate.Testing;
using NHibernate;
using NUnit.Framework;
using OpenEhs.Domain;

namespace OpenEhs.Data.Tests
{
    [TestFixture]
    public class NHibernateMappingTests
    {
        private ISession _session;

        [SetUp]
        public void SetupTests()
        {}

        [Test]
        public void CanCorrectlyMapProduct()
        {
            new PersistenceSpecification<Product>(_session, new CategoryComparer())
                .CheckProperty(c => c.Id, 1)
                .CheckProperty(c => c.Name, "Test Product")
                .CheckReference(c => c.Category, new Category() { Name = "Test Category", Description = "Test Category Description" })
                .CheckProperty(c => c.Unit, "mL")
                .CheckProperty(c => c.Price, 0.00m)
                .CheckProperty(c => c.QuantityOnHand, 10)
                .CheckProperty(c => c.IsActive, true)
                .VerifyTheMappings();
        }

        [Test]
        public void CanCorrectlyMapCategory()
        {
            new PersistenceSpecification<Category>(_session)
                .CheckProperty(c => c.Id, 1)
                .CheckProperty(c => c.Name, "Test Category")
                .CheckProperty(c => c.Description, "Test Category Description")
                .CheckProperty(c => c.DateCreated, DateTime.Now)
                .CheckProperty(c => c.IsActive, true)
                .VerifyTheMappings();

        }
    }

    #region IComparers Used in Testing

    public class CategoryComparer : IEqualityComparer
    {
        public bool Equals(object x, object y)
        {
            if (x == null || y == null)
                return false;

            if (x is Category && y is Category)
                return ((Category) x).Id == ((Category) y).Id;

            return x.Equals(y);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }
    }

    #endregion

}
