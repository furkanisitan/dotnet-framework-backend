using FluentValidation;
using Shop.Business.Abstract;
using Shop.Business.DependencyResolvers.Ninject;
using Shop.Entities.Concrete;

namespace Shop.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        private readonly IProductService _productService;

        public ProductValidator() : this(InstanceFactory.GetInstance<IProductService>()) { }

        public ProductValidator(IProductService productService)
        {
            _productService = productService;
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).IsUnique(_productService.GetAll());
        }
    }
}
