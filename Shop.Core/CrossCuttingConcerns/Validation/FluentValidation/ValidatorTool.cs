using FluentValidation;
using Shop.Core.Entities;
using System.Linq;

namespace Shop.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidatorTool
    {
        /// <summary>
        /// Validates the specified entity
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="validator">The validator</param>
        /// <param name="entity">The entity to validate</param>
        /// <param name="ruleSets">The names of the ruleSets to validate. (optional)</param>
        public static void FluentValidate<T>(IValidator<T> validator, T entity, params string[] ruleSets) where T : class, IEntity, new()
        {
            var result = validator.Validate(entity, options => options.IncludeRuleSets(ruleSets));
            if (result.Errors.Any())
                throw new ValidationException(result.Errors);
        }
    }
}
