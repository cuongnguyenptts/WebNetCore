using Microsoft.AspNetCore.Mvc;
using WebSellWatch.Areas.Admin.Models;
using WebSellWatch.ModelViews;

namespace WebSellWatch.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        [Area("Admin")]
        [HttpGet]
        [Route("/loginAdmin.html")]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginAdminViewModel request)
        {
            return View(request);
        }
    }
}
