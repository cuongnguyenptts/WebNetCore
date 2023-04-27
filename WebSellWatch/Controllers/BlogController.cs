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

        // GET: Blog/Ìndex
        [Route("blog.html", Name = "Blog")]
        public IActionResult Index(int? page)
        {
            var collection = _context.TinDangs.AsNoTracking().ToList();
            foreach (var item in collection)
            {
                if (item.CreatedDate == null)
                {
                    item.CreatedDate = DateTime.Now;
                    _context.Update(item);
                    _context.SaveChanges();
                }
            }
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 10;
            var lsTinDangs = _context.TinDangs
                .AsNoTracking()
                .OrderBy(x => x.PostId);
            PagedList<TinDang> models = new PagedList<TinDang>(lsTinDangs, pageNumber, pageSize);

            ViewBag.CurrentPage = pageNumber;
            return View(models);
        }

        [Route("/tintuc/{Alias}-{id}.html", Name = "TinDeltails")]
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
