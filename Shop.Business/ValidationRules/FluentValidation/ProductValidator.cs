using FluentValidation;
using Shop.Business.Abstract;
using Shop.Entities.Concrete;

namespace Shop.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator(IProductService productService)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).IsUnique(productService.GetAll());
        }
    }
}
