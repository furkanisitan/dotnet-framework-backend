using Shop.Business.DependencyResolvers.Ninject;
using Shop.Core.Utilities.MVC.Infrastructure;
using System.Web.Mvc;
using System.Web.Routing;

namespace Shop.MVCWebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // dependency injection with ninject
            DependencyResolver.SetResolver(new NinjectDependencyResolver(new BusinessModule()));
        }
    }
}
