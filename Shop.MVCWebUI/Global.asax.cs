using Shop.Business.DependencyResolvers.Ninject;
using Shop.Core.CrossCuttingConcerns.Security.Principals;
using Shop.Core.Utilities.MVC.Infrastructure;
using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

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

        public override void Init()
        {
            PostAuthenticateRequest += OnPostAuthenticateRequest;
            base.Init();
        }

        private void OnPostAuthenticateRequest(object sender, EventArgs e)
        {
            try
            {
                var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (authCookie == null) return;

                var encTicket = authCookie.Value;
                if (string.IsNullOrEmpty(encTicket)) return;

                var ticket = FormsAuthentication.Decrypt(encTicket);
                var expired = ticket?.Expired;
                if (ticket == null || ticket.Expired) return;

                var serializedModel = new JavaScriptSerializer().Deserialize<CustomPrincipalSerializedModel>(ticket.UserData);
                var principal = new CustomPrincipal(ticket.Name, serializedModel);

                HttpContext.Current.User = principal;   // for web
                Thread.CurrentPrincipal = principal;    // for back-end
            }
            catch { /* ignored */ }
        }
    }
}
