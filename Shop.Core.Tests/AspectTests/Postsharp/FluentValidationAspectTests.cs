using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Core.Aspects.Postsharp.ValidationAspects;
using Shop.Entities.Concrete;

namespace Shop.Core.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class FluentValidationAspectTests
    {

        [TestMethod]
        [ExpectedException(typeof(FluentValidation.ValidationException))]
        public void TestInstanceMethod()
        {
            InstanceMethod(new Product { Name = "" });
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        private void InstanceMethod(Product product) { }

    }
}
