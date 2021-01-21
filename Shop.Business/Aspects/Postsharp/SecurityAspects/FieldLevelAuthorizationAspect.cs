using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using Shop.Business.Aspects.Postsharp.ValidationAspects;
using Shop.Business.FieldLevelAuthorizationRules.FluentValidation;
using Shop.Core.Library.Extensions;
using System;
using System.Reflection;
using System.Security;

namespace Shop.Business.Aspects.Postsharp.SecurityAspects
{
    [PSerializable]
    public class FieldLevelAuthorizationAspect : FluentValidationBaseAspect
    {
        public FieldLevelAuthorizationAspect(Type validatorType, params string[] ruleSets) : base(validatorType, ruleSets) { }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (!_validatorType.IsAssignableToGenericType(typeof(AbstractFlaValidator<>)))
                throw new InvalidAnnotationException($"The validatorType is not declared in a type derived from {typeof(AbstractFlaValidator<>).FullName}.");

            return base.CompileTimeValidate(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            try { base.OnEntry(args); }
            catch (ValidationException e) { throw new SecurityException(e.Message); }
        }
    }
}
