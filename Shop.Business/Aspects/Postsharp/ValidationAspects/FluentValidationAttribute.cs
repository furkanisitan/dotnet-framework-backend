using PostSharp.Aspects;
using PostSharp.Serialization;
using Shop.Business.DependencyResolvers.Ninject;
using Shop.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using System.Linq;

namespace Shop.Business.Aspects.Postsharp.ValidationAspects
{
    /// <summary>
    /// Validates parameters of type 'IEntity'
    /// </summary>
    [PSerializable]
    public sealed class FluentValidationAttribute : OnMethodBoundaryAspect
    {
        private Type _validatorType;
        private string[] _ruleSets;

        /// <param name="validatorType">Type of validation class</param>
        /// <param name="ruleSets">The names of the ruleSets to validate. (optional)</param>
        public FluentValidationAttribute(Type validatorType, params string[] ruleSets)
        {
            _validatorType = validatorType;
            _ruleSets = ruleSets;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = args.Arguments.Where(x => x.GetType() == entityType);
            var genericValidateMethod = typeof(ValidatorTool).GetMethod(nameof(ValidatorTool.FluentValidate))?.MakeGenericMethod(entityType);
            var validator = InstanceFactory.GetInstance(_validatorType);

            foreach (var entity in entities)
                genericValidateMethod?.Invoke(null, new[] { validator, entity, _ruleSets });
        }
    }
}
