using System.Web.Mvc;

namespace Shop.MVCWebUI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}