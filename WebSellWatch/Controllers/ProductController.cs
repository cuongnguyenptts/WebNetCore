using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(x => x.Cat).FirstOrDefault(x => x.ProductId == id);
            if (product != null)
            {
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
