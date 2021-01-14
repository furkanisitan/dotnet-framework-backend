using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Shop.Core.Utilities.MVC.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver(INinjectModule module)
        {
            _kernel = new StandardKernel(module);
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}
