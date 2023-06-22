using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Data;
using WebSellWatch.Models;


namespace WebSellWatch.Controllers
{
    public class ProductController : Controller
    {
        private readonly dbWatchesContext _context;
        public ProductController(dbWatchesContext context)
        {
            _context = context;
        }
        [Route("shop.html", Name = ("ShopProduct"))]
        public IActionResult Index(int? page, int CatID = 0, string searchText = "")
        {
            try
            {
                var pageNumber = (page ?? 1);
                var pageSize = 9;

                List<Product> lsProducts = new List<Product>();

                if (searchText != "" && searchText != null)
                {
                    lsProducts = _context.Products.AsNoTracking()
                                      .Include(a => a.Cat)
                                      .Where(x => x.ProductName.Contains(searchText))
                                      .OrderByDescending(x => x.ProductName)
                                      .Take(pageSize)
                                      .ToList();
                }
                else if (CatID != 0)
                {
                    lsProducts = _context.Products.AsNoTracking()
                    .Include(a => a.Cat)
                    .OrderByDescending(x => x.CatId)
                    .Take(pageSize)
                    .ToList();
                }
                else
                {
                    lsProducts = _context.Products
                    .AsNoTracking()
                    .Include(x => x.Cat)
                    .OrderBy(x => x.ProductId).ToList();
                }


                PagedList<Product> models = new PagedList<Product>(lsProducts.AsQueryable(), pageNumber, pageSize);
                ViewBag.Count = models.Count;
                ViewBag.CurrentCateID = CatID;
                ViewBag.SearchText = searchText;
                ViewBag.CurrentPage = pageNumber;

                ViewData["DanhMuc"] = new SelectList(_context.Categories, "CatId", "CatName");

                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [Route("/{Alias}", Name = "ListProductDeltails")]
        public IActionResult List(string Alias, int page = 1)
        {
            try
            {
                var pageSize = 10;
                var danhmuc = _context.Categories.AsNoTracking().SingleOrDefault(x => x.Alias == Alias);
                var lsTinDangs = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == danhmuc.CatId)
                    .OrderByDescending(x => x.DateCreated);
                PagedList<Product> models = new PagedList<Product>(lsTinDangs, page, pageSize);
                ViewBag.CurrentPage = page;
                ViewBag.CurrentCat = danhmuc;
                return View(models);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }

        [Route("/{Alias}-{id}.html", Name = ("ProductDetails"))]
        public IActionResult Details(int id)
        {
            try
            {
                var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
                if (product == null)
                {
                    return RedirectToAction("Index");
                }
                var lsProduct = _context.Products
                    .AsNoTracking()
                    .Where(x => x.CatId == product.CatId && x.ProductId != id && x.Active == true)
                    .Take(4)
                    .OrderByDescending(x => x.DateCreated)
                    .ToList();
                ViewBag.SanPham = lsProduct;
                return View(product);
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }


        }
    }
}
