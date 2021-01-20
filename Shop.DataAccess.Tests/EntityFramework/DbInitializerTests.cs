using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.DataAccess.Concrete.EntityFramework.Configuration;

namespace Shop.DataAccess.Tests.EntityFramework
{
    [TestClass]
    public class DbInitializerTests
    {
        [TestMethod]
        public void Test_ShopContextDbInitializer()
        {
            var context = new ShopContext();
            context.Database.Initialize(true);
        }

    }

}
