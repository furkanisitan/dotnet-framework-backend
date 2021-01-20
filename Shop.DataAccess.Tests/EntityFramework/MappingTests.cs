using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.DataAccess.Tests.EntityFramework.Configuration;

namespace Shop.DataAccess.Tests.EntityFramework
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void Test_CreateDbWithMappings()
        {
            var context = new ShopDataAccessTestContext();
            context.Database.Initialize(true);
        }
    }

}
