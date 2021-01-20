using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using Shop.Core.CrossCuttingConcerns.Logging;
using Shop.Core.CrossCuttingConcerns.Logging.Log4Net;
using System;
using System.Linq;
using System.Reflection;

namespace Shop.Business.Aspects.Postsharp.LogAspects
{
    [PSerializable]
    [MulticastAttributeUsage(MulticastTargets.Method, TargetMemberAttributes = MulticastAttributes.Instance)]
    public sealed class Log4NetAttribute : OnMethodBoundaryAspect
    {
        private Type _loggerType;
        private SerializableAbstractLogger _logger;

        public Log4NetAttribute(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (!typeof(SerializableAbstractLogger).IsAssignableFrom(_loggerType))
                throw new InvalidAnnotationException($"The loggerType is not declared in a type derived from {typeof(SerializableAbstractLogger).FullName}.");

            return base.CompileTimeValidate(method);
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _logger = (SerializableAbstractLogger)Activator.CreateInstance(_loggerType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            try
            {
                var logMethodParameters = args.Method.GetParameters().Select((x, i) => new LogMethodDetail.LogMethodParameter
                {
                    Name = x.Name,
                    Type = x.ParameterType.Name,
                    Value = args.Arguments.GetArgument(i)
                }).ToList();

                var logMethodDetail = new LogMethodDetail
                {
                    Name = args.Method.Name,
                    DeclaringTypeFullName = args.Method.DeclaringType?.FullName,
                    Parameters = logMethodParameters
                };

                _logger?.Info(logMethodDetail);
            }
            catch { /* ignored */ }
        }
    }
}

