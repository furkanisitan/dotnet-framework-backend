using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Core.Aspects.Postsharp.CacheAspects;
using Shop.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Shop.Core.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class CacheRemoveAspectTests
    {
        private static int _number;

        [TestMethod]
        public void TestInstanceMethods()
        {
            var call1 = InstanceMethod();
            RemoveCacheOfInstanceMethod();
            var call2 = InstanceMethod();

            Assert.AreNotEqual(call1, call2);
        }

        [CacheAspect(typeof(MemoryCacheManager))]
        private int InstanceMethod()
        {
            return ++_number;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager), nameof(InstanceMethod))]
        private void RemoveCacheOfInstanceMethod() { }
    }
}
