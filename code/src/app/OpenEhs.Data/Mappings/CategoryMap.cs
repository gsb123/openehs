using FluentNHibernate.Mapping;
using OpenEhs.Domain;

namespace OpenEhs.Data.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Id(x => x.Id)
                .Column("CategoryID");
            Map(x => x.Name);
            Map(x => x.Description);
            HasMany(x => x.Products)
                .Inverse()
                .Cascade.All();
            Map(x => x.DateCreated);
            Map(x => x.IsActive);
        }
    }
}
