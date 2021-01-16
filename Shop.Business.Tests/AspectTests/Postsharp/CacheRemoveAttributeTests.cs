using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.CacheAspects;
using Shop.Core.CrossCuttingConcerns.Caching.Microsoft;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class CacheRemoveAttributeTests
    {
        private static int _number;

        [TestMethod]
        public void Test_instance_method()
        {
            var call1 = InstanceMethod();
            RemoveCacheOfInstanceMethod();
            var call2 = InstanceMethod();

            Assert.AreNotEqual(call1, call2);
        }

        [Cache(typeof(MemoryCacheManager))]
        private int InstanceMethod()
        {
            return ++_number;
        }

        [CacheRemove(typeof(MemoryCacheManager), nameof(InstanceMethod))]
        private void RemoveCacheOfInstanceMethod() { }
    }
}
