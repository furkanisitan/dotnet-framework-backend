using FluentValidation;
using Shop.Business.ValidationRules.FluentValidation.HelperValidators;
using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Business.ValidationRules.FluentValidation
{
    static class Extensions
    {
        public static IRuleBuilderOptions<TItem, TProperty> IsUnique<TItem, TProperty>(this IRuleBuilder<TItem, TProperty> ruleBuilder, IEnumerable<TItem> items)
            where TItem : class, IEntity, new()
        {
            return ruleBuilder.SetValidator(new UniqueValidator<TItem>(items));
        }
    }
}
