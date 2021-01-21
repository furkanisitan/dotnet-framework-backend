using FluentValidation;
using Shop.Business.Abstract;
using Shop.Entities.Concrete;

namespace Shop.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator(ICategoryService categoryService)
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).IsUnique(categoryService.GetAll());

        }
    }
}
