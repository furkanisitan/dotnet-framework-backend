using Shop.Entities.Concrete;
using System.Data.Entity;

namespace Shop.Business.Tests.Db.EntityFramework.Configuration
{
    class ShopBusinessTestContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public ShopBusinessTestContext()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ShopBusinessTestContext>());
        }

    }
}
