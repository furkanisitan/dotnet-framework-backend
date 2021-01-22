using Shop.Entities.Concrete;
using System.Data.Entity.ModelConfiguration;

namespace Shop.DataAccess.Concrete.EntityFramework.Mappings
{
    public class MapUser : EntityTypeConfiguration<User>
    {
        public MapUser()
        {
            ToTable("Users");

            // primary key
            HasKey(x => x.Id);
            // unique key
            HasIndex(x => x.Username).IsUnique().HasName("UK_Username_Users");
            // many-to-many
            HasMany(u => u.Roles).WithMany(r => r.Users).Map(ur => ur.ToTable("UserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));

            Property(x => x.Id).HasColumnName("UserId");
            Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            Property(x => x.LastName).IsRequired().HasMaxLength(50);
            Property(x => x.Username).IsRequired().HasColumnType("nvarchar").HasMaxLength(50);
            Property(x => x.Password).IsRequired().HasMaxLength(50);

        }
    }
}
