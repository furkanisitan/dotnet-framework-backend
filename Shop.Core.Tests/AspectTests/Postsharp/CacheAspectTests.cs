using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Aspects.Postsharp.CacheAspects;
using Shop.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Shop.Core.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class CacheAspectTests
    {
        private static int _number;

        [TestMethod]
        public void TestInstanceMethod()
        {
            var call1 = InstanceMethod();
            var call2 = InstanceMethod();

            Assert.AreEqual(call1, call2);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        private int InstanceMethod()
        {
            return ++_number;
        }

    }
}
