using FluentValidation;
using Shop.Business.Abstract;
using Shop.Business.DependencyResolvers.Ninject;
using Shop.Entities.Concrete;

namespace Shop.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private readonly ICategoryService _categoryService;

        public CategoryValidator() : this(InstanceFactory.GetInstance<ICategoryService>()) { }

        public CategoryValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            SetRules();
        }

        private void SetRules()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50).IsUnique(_categoryService.GetAll());
        }
    }
}
