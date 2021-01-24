using FluentValidation;

namespace Shop.Core.CrossCuttingConcerns.Security.FieldLevelAuthorizationRules.FluentValidation
{
    public abstract class AbstractFlaValidator<T> : AbstractValidator<T> { }
}
