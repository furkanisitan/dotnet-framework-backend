using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.DataAccess.Concrete.EntityFramework.Configuration;
using System.Linq;

namespace Shop.DataAccess.Tests.EntityFramework
{
    [TestClass]
    public class DbInitializerTests
    {
        [TestMethod]
        public void ShopContextDbInitializer()
        {
            var db = new ShopContext();
            var categories = db.Categories.ToList();
        }

    }

}
