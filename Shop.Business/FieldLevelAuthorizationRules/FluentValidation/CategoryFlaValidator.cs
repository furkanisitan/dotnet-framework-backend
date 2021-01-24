using Shop.Business.Abstract;
using Shop.Business.DependencyResolvers.Ninject;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Core.CrossCuttingConcerns.Security.FieldLevelAuthorizationRules.FluentValidation;
using Shop.Entities.Concrete;

namespace Shop.Business.FieldLevelAuthorizationRules.FluentValidation
{
    public class CategoryFlaValidator : AbstractFlaValidator<Category>
    {
        private readonly ICategoryService _categoryService;

        public CategoryFlaValidator() : this(InstanceFactory.GetInstance<ICategoryService>()) { }

        public CategoryFlaValidator(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            SetRules();
        }

        private void SetRules()
        {
            RuleSet("update", () =>
              {
                  When(x => _categoryService.IsPropertiesEdited(x, nameof(x.Name)), () =>
                  {
                      RuleFor(x => x.Name).IsAuthorized("Admin");
                  });
              });
        }
    }
}
