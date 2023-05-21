using Microsoft.AspNetCore.Mvc;

namespace WebSellWatch.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }

    }
}
