using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using WebSellWatch.Models;

namespace WebSellWatch.Controllers
{
    public class BlogController : Controller
    {
        private readonly dbWatchesContext _context;

        public BlogController(dbWatchesContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminTinDangs
        public IActionResult Index(int? page)
        {

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinDangs = _context.TinDangs
                .AsNoTracking()
                .OrderBy(x => x.PostId);
            PagedList<TinDang> models = new PagedList<TinDang>(lsTinDangs, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        public  IActionResult Details(int id)
        {
            var tinDang =  _context.TinDangs.AsNoTracking()
                .SingleOrDefault(m => m.PostId == id);
            if (tinDang == null)
            {
                return RedirectToAction("Index");
            }

            return View(tinDang);
        }

    }
}
