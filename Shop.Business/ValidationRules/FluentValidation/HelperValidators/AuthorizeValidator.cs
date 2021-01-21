using FluentValidation.Validators;
using Shop.Core.Entities;
using System.Linq;
using System.Threading;

namespace Shop.Business.ValidationRules.FluentValidation.HelperValidators
{
    class AuthorizeValidator<T> : PropertyValidator where T : class, IEntity, new()
    {
        private readonly string[] _roles;

        public AuthorizeValidator(string[] roles)
        {
            _roles = roles;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            return IsAuthorized(_roles);
        }

        protected override string GetDefaultMessageTemplate() =>
            "You are not authorized to change the '{PropertyName}'.";

        /// <summary>
        /// Checks whether the logged-in user has provided one of the <paramref name="roles"/>.
        /// </summary>
        /// <param name="roles">The authorized roles.</param>
        /// <returns>If the logged in user has one of the <paramref name="roles"/>, true; otherwise, false.</returns>
        private bool IsAuthorized(params string[] roles) =>
            roles.Any(x => Thread.CurrentPrincipal.IsInRole(x));
    }
}
