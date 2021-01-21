using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using Shop.Core.CrossCuttingConcerns.Caching;
using System;
using System.Reflection;

namespace Shop.Business.Aspects.Postsharp.CacheAspects
{
    /// <summary>
    /// Removes cache items from the cache.
    /// If declaringType is not passed, method names are searched under the related method's class.
    /// </summary>
    [PSerializable]
    public sealed class CacheRemoveAspect : OnMethodBoundaryAspect
    {
        private Type _cacheManagerType;
        private Type _declaringType;
        private string[] _methodNames;
        private ICacheManager _cacheManager;

        /// <param name="cacheManagerType">Type of cache manager class.</param>
        /// <param name="methodNames">A list of names of methods to invalidate.</param>
        public CacheRemoveAspect(Type cacheManagerType, params string[] methodNames)
        {
            _cacheManagerType = cacheManagerType;
            _methodNames = methodNames;
        }

        /// <param name="cacheManagerType">Type of cache manager class.</param>
        /// <param name="declaringType">The type containing the methods to invalidate.</param>
        /// <param name="methodNames">A list of names of methods to invalidate.</param>
        public CacheRemoveAspect(Type cacheManagerType, Type declaringType, params string[] methodNames)
        {
            _cacheManagerType = cacheManagerType;
            _declaringType = declaringType;
            _methodNames = methodNames;
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (!typeof(ICacheManager).IsAssignableFrom(_cacheManagerType))
                throw new InvalidAnnotationException($"The cacheManagerType is not implement {typeof(ICacheManager).FullName}.");

            return base.CompileTimeValidate(method);
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _cacheManager = (ICacheManager)Activator.CreateInstance(_cacheManagerType);
            base.RuntimeInitialize(method);
        }

        public override void OnSuccess(MethodExecutionArgs args)
        {
            _declaringType = _declaringType ?? args.Method.ReflectedType;
            foreach (var methodName in _methodNames) _cacheManager.RemoveByPattern($"{_declaringType?.FullName}.{methodName}");
        }
    }
}
