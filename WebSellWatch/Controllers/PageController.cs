using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSellWatch.Models;

namespace WebSellWatch.Controllers
{
    public class PageController : Controller
    {
        private readonly dbWatchesContext _context;

        public PageController(dbWatchesContext context)
        {
            _context = context;
        }
        //Get: page/Alias
        [Route("/page/{Alias}", Name = "PageDetails")]
        public IActionResult Details(string Alias)
        {
            if (string.IsNullOrEmpty(Alias)) 
             return RedirectToAction("Index" , "Home");
            var page = _context.Pages.AsNoTracking()
                .SingleOrDefault(m => m.Alias == Alias);
            if (page == null)
            {
                return RedirectToAction("Index", "Home"); 
            }

            return View(page);
        }

    }
}

