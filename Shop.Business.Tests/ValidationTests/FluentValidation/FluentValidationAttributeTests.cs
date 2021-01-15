using FluentValidation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Entities.Concrete;
using System.Reflection;

namespace Shop.Business.Tests.ValidationTests.FluentValidation
{
    [TestClass]
    public class FluentValidationAttributeTests
    {

        [TestMethod]
        public void Test_instance_method()
        {
            var ex = Assert.ThrowsException<TargetInvocationException>(() => InstanceMethod(new Product { Name = "" }));
            Assert.IsTrue(ex.InnerException is ValidationException);
        }

        [FluentValidation(typeof(ProductValidator))]
        private void InstanceMethod(Product product) { }


    }
}
