using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.CacheAspects;
using Shop.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class CacheAttributeTests
    {
        private static int _number;

        [TestMethod]
        public void TestInstanceMethod()
        {
            var call1 = InstanceMethod();
            var call2 = InstanceMethod();

            Assert.AreEqual(call1, call2);
        }

        [Cache(typeof(MemoryCacheManager))]
        private int InstanceMethod()
        {
            return ++_number;
        }

    }
}
