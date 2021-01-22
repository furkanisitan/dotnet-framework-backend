using System.Web;
using System.Web.Mvc;

namespace Shop.MVCWebUI.Library.Attributes
{
    /// <summary>
    /// Redirects to the login page if not logged in; If logged in but not authorized redirects to 403 page.
    /// </summary>
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                filterContext.Result = new HttpStatusCodeResult(403, "You are not authorized to view this page.");
            else
                filterContext.Result = new RedirectResult(new UrlHelper(filterContext.RequestContext).Action("Login", "Home"));
        }
    }
}