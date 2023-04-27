using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Drawing.Printing;
using WebSellWatch.Models;
using static System.Reflection.Metadata.BlobBuilder;

namespace WebSellWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SearchController : Controller
    {

        private readonly dbWatchesContext _context;
        public SearchController(dbWatchesContext context, INotyfService notyfService)
        {
            _context = context;
        }
        //Get: Search/FindProduct
        [HttpPost]
        public IActionResult FindProduct(string keyword)
        {
            var pageNumber = 1;
            var pageSize = 20;
            List<Product> IsProduct = new List<Product>();
            List<Product> ls = new List<Product>();
            if (string.IsNullOrEmpty(keyword) || keyword.Length < 1)
            {
                return PartialView("ListProductsSearchPartial", null);
            }
            var s = keyword.ToLower();
            ls = _context.Products.AsNoTracking()
                 .Include(a => a.Cat)
                .Where(x => x.ProductName.ToLower().Contains(s) ||
                 x.Cat.CatName.ToLower().Contains(s))
                .OrderByDescending(x => x.ProductName)
                .Take(10).ToList();

            IsProduct = _context.Products.
                AsNoTracking().
                Include(p => p.Cat)
                .OrderByDescending(x => x.ProductId).ToList();
            PagedList<Product> Models = new PagedList<Product>(IsProduct.AsQueryable(), pageNumber, pageSize);

            if (ls == null )
            {
                return View(Models);
            }
            else
            {
                return PartialView("ListProductsSearchPartial", ls);
            }
        }
    }
}
