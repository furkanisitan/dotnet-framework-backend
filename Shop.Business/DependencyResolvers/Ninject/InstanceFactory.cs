using Ninject;
using System;

namespace Shop.Business.DependencyResolvers.Ninject
{
    public static class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            return new StandardKernel(new BusinessModule()).Get<T>();
        }

        public static object GetInstance(Type type)
        {
            return new StandardKernel(new BusinessModule()).Get(type);
        }
    }
}
