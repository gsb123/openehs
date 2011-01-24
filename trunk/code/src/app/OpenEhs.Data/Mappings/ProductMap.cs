using FluentNHibernate.Mapping;
using OpenEhs.Domain;

namespace OpenEhs.Data.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Id(x => x.Id);
            Map(x => x.Name);
            References(x => x.Category)
                .Column("CategoryID");
            Map(x => x.Unit);
            Map(x => x.Price)
                .Column("ProductCost");
            Map(x => x.QuantityOnHand);
            Map(x => x.IsActive);
        }
    }
}
