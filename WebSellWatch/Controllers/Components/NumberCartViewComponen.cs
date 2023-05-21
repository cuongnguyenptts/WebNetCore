using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebSellWatch.Extension;
using WebSellWatch.ModelViews;

namespace WebSellWatch.Controllers.Components
{
    public class NumberCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}
