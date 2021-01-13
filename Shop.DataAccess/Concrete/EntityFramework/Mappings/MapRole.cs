using Shop.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace Shop.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MapRole : EntityTypeConfiguration<Role>
    {
        public MapRole()
        {
            ToTable("Roles");

            // primary key
            HasKey(x => x.Id);
            // unique key 
            HasIndex(x => x.Name).IsUnique().HasName("UK_Name_Roles");

            Property(x => x.Id).HasColumnName("RoleId");
            Property(x => x.Name).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
        }
    }
}
