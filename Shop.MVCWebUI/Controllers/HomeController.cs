using Shop.Business.Abstract;
using Shop.Core.CrossCuttingConcerns.Security.Principals;
using Shop.Core.CrossCuttingConcerns.Security.Web;
using Shop.MVCWebUI.Library;
using Shop.MVCWebUI.Library.Attributes;
using Shop.MVCWebUI.Models;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;

namespace Shop.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        [CustomAuthorize(Roles = "Admin,User")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(UserLoginViewModel model)
        {
            var user = _userService.GetByUsernameAndPasswordWithRoles(model.User.Username, model.User.Password);

            if (user == null)
            {
                TempData[Constants.Keys.AlertMessage] = "Login failed!\nUsername or password is incorrect.";
                return RedirectToAction("Login", "Home");
            }

            var serializedModel = new CustomPrincipalSerializedModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Roles = user.Roles.Select(x => x.Name).ToArray()
            };

            AuthenticationHelper.CreateAuthenticationTicket(user.Username, DateTime.Now.AddMinutes(5), model.RememberMe, serializedModel);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}