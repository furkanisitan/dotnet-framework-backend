using Shop.Business.Abstract;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.Entities.Concrete;

namespace Shop.Business.FieldLevelAuthorizationRules.FluentValidation
{
    public class CategoryFlaValidator : AbstractFlaValidator<Category>
    {
        public CategoryFlaValidator(ICategoryService categoryService)
        {

            RuleSet("update", () =>
            {
                When(x => categoryService.IsPropertiesEdited(x, nameof(x.Name)), () =>
                {
                    RuleFor(x => x.Name).IsAuthorized("Admin");
                });
            });

        }
    }
}
