using Shop.Entities.Concrete;
using System.Data.Entity;

namespace Shop.Core.Tests.Db.EntityFramework.Configuration
{
    class CoreTestContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public CoreTestContext() : base("ShopContext")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CoreTestContext>());
        }
    }
}
