using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using Shop.Business.DependencyResolvers.Ninject;
using Shop.Core.CrossCuttingConcerns.Validation.FluentValidation;
using System;
using System.Linq;
using System.Reflection;

namespace Shop.Business.Aspects.Postsharp.ValidationAspects
{
    /// <summary>
    /// Validates parameters of type 'IEntity'.
    /// </summary>
    [PSerializable]
    public sealed class FluentValidationAspect : OnMethodBoundaryAspect
    {
        private IValidator _validator;
        private Type _validatorType;
        private string[] _ruleSets;

        /// <param name="validatorType">Type of validation class.</param>
        /// <param name="ruleSets">The names of the ruleSets to validate. (optional)</param>
        public FluentValidationAspect(Type validatorType, params string[] ruleSets)
        {
            _validatorType = validatorType;
            _ruleSets = ruleSets;
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (!typeof(IValidator).IsAssignableFrom(_validatorType))
                throw new InvalidAnnotationException($"The validatorType is not declared in a type derived from {typeof(AbstractValidator<>).FullName}.");

            return base.CompileTimeValidate(method);
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _validator = (IValidator)InstanceFactory.GetInstance(_validatorType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var entities = args.Arguments.Where(x => x.GetType() == entityType);
            var genericValidateMethod = typeof(ValidatorTool).GetMethod(nameof(ValidatorTool.FluentValidate))?.MakeGenericMethod(entityType);

            foreach (var entity in entities)
                genericValidateMethod?.Invoke(null, new[] { _validator, entity, _ruleSets });
        }
    }
}
