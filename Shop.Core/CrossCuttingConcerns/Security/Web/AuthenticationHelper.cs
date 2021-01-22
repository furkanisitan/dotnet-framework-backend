using Shop.Core.CrossCuttingConcerns.Security.Principals;
using System;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace Shop.Core.CrossCuttingConcerns.Security.Web
{
    public static class AuthenticationHelper
    {
        /// <summary>
        /// Creates an encrypted FormsAuthenticationTicket and adds it to the cookie.
        /// </summary>
        public static void CreateAuthenticationTicket(string username, DateTime expiration, bool rememberMe, CustomPrincipalSerializedModel serializedModel)
        {
            var data = new JavaScriptSerializer().Serialize(serializedModel);
            var authTicket = new FormsAuthenticationTicket(1, username, DateTime.Now, expiration, rememberMe, data);
            var encTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket)
            {
                HttpOnly = true,
                Secure = FormsAuthentication.RequireSSL,
                Path = FormsAuthentication.FormsCookiePath,
                Domain = FormsAuthentication.CookieDomain,
            };
            HttpContext.Current.Response.AppendCookie(cookie);
        }

    }
}
