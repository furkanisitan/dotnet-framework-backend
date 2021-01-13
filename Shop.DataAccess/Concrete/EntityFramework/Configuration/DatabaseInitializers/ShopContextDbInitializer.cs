using System.Collections.Generic;
using System.Data.Entity;
using Bogus;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Concrete.EntityFramework.Configuration.DatabaseInitializers
{
    internal static class ShopContextDbInitializer
    {

        public class DropCreateAlways : DropCreateDatabaseAlways<ShopContext>
        {
            public override void InitializeDatabase(ShopContext context)
            {
                context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction, $"ALTER DATABASE [{context.Database.Connection.Database}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                base.InitializeDatabase(context);
            }

            protected override void Seed(ShopContext context)
            {
                InitDatabase(context);
            }
        }


        public static void InitDatabase(ShopContext context)
        {

            const int minProductQuantityPerCategory = 2;
            const int maxProductQuantityPerCategory = 5;

            var faker = new Faker("tr");

            // Add roles
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "Manager" },
                new Role { Name = "Staff" }
            };
            context.Roles.AddRange(roles);
            context.SaveChanges();


            // Add users
            var users = new List<User>
            {
                new User { Fullname = faker.Name.FullName(), Password = "1234", Username = "admin", Roles = new List<Role> { roles[0] } },
                new User { Fullname = faker.Name.FullName(), Password = "1234", Username = "manager", Roles = new List<Role> { roles[1], roles[2] } },
                new User { Fullname = faker.Name.FullName(), Password = "1234", Username = "staff", Roles = new List<Role> { roles[2] } }
            };
            context.Users.AddRange(users);
            context.SaveChanges();


            // products
            var productIds = 0;
            var products = new Faker<Product>()
                .RuleFor(x => x.Id, f => productIds++)
                .RuleFor(x => x.UnitPrice, f => decimal.Parse(f.Commerce.Price(10, 500)))
                .RuleFor(x => x.UnitsInStock, f => f.Random.Short(0, 100))
                .RuleFor(x => x.Name, (f, p) => $"{f.Commerce.ProductName()}_{p.Id}");

            // Add categories
            var categoryIds = 0;
            var categories = new Faker<Category>()
                .RuleFor(x => x.Id, f => categoryIds++)
                .RuleFor(x => x.Name, (f, c) => $"{f.Commerce.Department()}_{c.Id}")
                .RuleFor(x => x.Products, f => products.Generate(f.Random.Number(minProductQuantityPerCategory, maxProductQuantityPerCategory)));

            context.Categories.AddRange(categories.Generate(5));
            context.SaveChanges();
        }

    }
}
