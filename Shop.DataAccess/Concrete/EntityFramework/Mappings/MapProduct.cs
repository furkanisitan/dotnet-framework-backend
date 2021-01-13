using Shop.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace Shop.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MapProduct : EntityTypeConfiguration<Product>
    {
        public MapProduct()
        {
            ToTable("Products");

            // primary key
            HasKey(x => x.Id);
            // unique key 
            HasIndex(x => x.Name).IsUnique().HasName("UK_Name_Products");
            // foreign key
            // Category(1) -> Product(n)
            HasRequired(x => x.Category).WithMany(c => c.Products).HasForeignKey(x => x.CategoryId);

            Property(x => x.Id).HasColumnName("ProductId");
            Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(100);
            Property(x => x.UnitsInStock).HasColumnType("smallint");
            Property(x => x.UnitPrice);
        }
    }
}
