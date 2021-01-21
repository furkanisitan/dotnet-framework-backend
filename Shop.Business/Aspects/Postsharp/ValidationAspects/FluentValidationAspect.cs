using PostSharp.Serialization;
using System;

namespace Shop.Business.Aspects.Postsharp.ValidationAspects
{
    /// <summary>
    /// Validates parameters of type 'IEntity'.
    /// </summary>
    [PSerializable]
    public sealed class FluentValidationAspect : FluentValidationBaseAspect
    {
        public FluentValidationAspect(Type validatorType, params string[] ruleSets) : base(validatorType, ruleSets) { }
    }
}
