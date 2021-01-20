using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shop.Business.Abstract;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Tests.ValidationTests.FluentValidation
{
    [TestClass]
    public class ProductValidatorTests
    {
        [TestMethod]
        public void Should_UniqueProductName()
        {
            var mock = new Mock<IProductService>();
            mock.Setup(x => x.GetAll()).Returns(
                new List<Product>
                {
                    new Product { Id = 1, Name = "product1" },
                    new Product { Id = 2, Name = "product2" },
                    new Product { Id = 3, Name = "product3" }
                });
            var productService = mock.Object;
            var productValidator = new ProductValidator(productService);
            
            var notUniqueProduct = new Product { Id = 4, Name = "product3" };
            var uniqueProduct = new Product { Id = 5, Name = "product4" };
            var updatedProduct = new Product { Id = 2, Name = "product2" };

            Assert.IsFalse(productValidator.Validate(notUniqueProduct).IsValid);
            Assert.IsTrue(productValidator.Validate(uniqueProduct).IsValid);
            Assert.IsTrue(productValidator.Validate(updatedProduct).IsValid);
        }
    }
}
