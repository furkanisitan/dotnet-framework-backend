using Shop.DataAccess.Concrete.EntityFramework.Mappings;
using Shop.Entities.Concrete;
using System.Data.Entity;

namespace Shop.DataAccess.Tests.EntityFramework.Configuration
{
    class ShopDataAccessTestContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ShopDataAccessTestContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ShopDataAccessTestContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MapProduct());
            modelBuilder.Configurations.Add(new MapCategory());
            modelBuilder.Configurations.Add(new MapRole());
            modelBuilder.Configurations.Add(new MapUser());
        }
    }
}
