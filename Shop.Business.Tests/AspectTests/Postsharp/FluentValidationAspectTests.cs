using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.ValidationAspects;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Entities.Concrete;
using System.Reflection;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class FluentValidationAspectTests
    {

        [TestMethod]
        public void TestInstanceMethod()
        {
            var ex = Assert.ThrowsException<TargetInvocationException>(() => InstanceMethod(new Product { Name = "" }));
            Assert.IsTrue(ex.InnerException is ValidationException);
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        private void InstanceMethod(Product product) { }

    }
}
