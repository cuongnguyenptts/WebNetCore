using Microsoft.AspNetCore.Mvc;
using WebSellWatch.ModelViews;

namespace WebSellWatch.Areas.Admin.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel request)
        {
            return View(request);
        }
    }
}
