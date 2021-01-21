using FluentValidation;
using Shop.Business.ValidationRules.FluentValidation.HelperValidators;
using Shop.Core.Entities;
using System.Collections.Generic;

namespace Shop.Business.ValidationRules.FluentValidation
{
    static class Extensions
    {
        /// <summary>
        /// Checks the uniqueness of the value of the property.
        /// If the item is in the list and the value of property has not changed, it is considered unique.
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="items">The list for uniqueness check.</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<TItem, TProperty> IsUnique<TItem, TProperty>(this IRuleBuilder<TItem, TProperty> ruleBuilder, IEnumerable<TItem> items)
            where TItem : class, IEntity, new()
        {
            return ruleBuilder.SetValidator(new UniqueValidator<TItem>(items));
        }

        /// <summary>
        /// Checks whether the logged-in user has provided one of the <paramref name="roles"/>.
        /// </summary>
        /// <param name="ruleBuilder"></param>
        /// <param name="roles">The authorized roles.</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<TItem, TProperty> IsAuthorized<TItem, TProperty>(this IRuleBuilder<TItem, TProperty> ruleBuilder, params string[] roles)
            where TItem : class, IEntity, new()
        {
            return ruleBuilder.SetValidator(new AuthorizeValidator<TItem>(roles));
        }
    }
}
