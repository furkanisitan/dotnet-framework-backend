using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.Aspects.Postsharp.ValidationAspects;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Entities.Concrete;

namespace Shop.Business.Tests.AspectTests.Postsharp
{
    [TestClass]
    public class FluentValidationAspectTests
    {

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void TestInstanceMethod()
        {
            InstanceMethod(new Product { Name = "" });
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        private void InstanceMethod(Product product) { }

    }
}
