using Shop.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace Shop.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MapCategory : EntityTypeConfiguration<Category>
    {
        public MapCategory()
        {
            ToTable("Categories");

            // primary key
            HasKey(x => x.Id);
            // unique key 
            HasIndex(x => x.Name).IsUnique().HasName("UK_Name_Categories");

            Property(x => x.Id).HasColumnName("CategoryId");
            Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
