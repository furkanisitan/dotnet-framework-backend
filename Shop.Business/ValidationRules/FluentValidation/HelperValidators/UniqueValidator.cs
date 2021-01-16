using FluentValidation.Validators;
using Shop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shop.Business.ValidationRules.FluentValidation.HelperValidators
{
    class UniqueValidator<T> : PropertyValidator where T : class, IEntity, new()
    {
        private readonly IEnumerable<T> _items;

        /// <summary>
        /// Checks the uniqueness of the value of the property.
        /// If the item is in the list and the value of property has not changed, it is considered unique.
        /// </summary>
        /// <param name="items">The list for uniqueness check.</param>
        public UniqueValidator(IEnumerable<T> items)
        {
            _items = items;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var editedItem = context.InstanceToValidate as T;
            var newValue = context.PropertyValue as string;
            var property = typeof(T).GetTypeInfo().GetDeclaredProperty(context.PropertyName);
            return _items.All(item => item.Id == editedItem?.Id || !string.Equals(property.GetValue(item).ToString(), newValue, StringComparison.InvariantCultureIgnoreCase));
        }

        protected override string GetDefaultMessageTemplate() =>
            "{PropertyName} must be unique";
    }
}
