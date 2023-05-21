using Microsoft.AspNetCore.Mvc;
using WebSellWatch.ModelViews;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

using WebSellWatch.Extension;


namespace WebSellWatch.Controllers.Components
{
    public class HeaderCartViewComponent: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var cart = HttpContext.Session.Get<List<CartItem>>("GioHang");
            return View(cart);
        }
    }
}
