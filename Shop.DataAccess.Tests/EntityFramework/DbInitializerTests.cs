using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.DataAccess.Concrete.EntityFramework.Configuration;

namespace Shop.DataAccess.Tests.EntityFramework
{
    [TestClass]
    public class DbInitializerTests
    {
        [TestMethod]
        public void ShopContextDbInitializer()
        {
            var context = new ShopContext();
            context.Database.Initialize(true);
        }

    }

}
