using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebSellWatch.Models;

namespace WebSellWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ThongkeHomeController : Controller
    {
      
        private readonly dbWatchesContext _context;
        public ThongkeHomeController(dbWatchesContext context, INotyfService notyfService)
        {
            _context = context;
          
        }
        public IActionResult Index()

        {
            ViewBag.TkDonDatH = Tkdhh(); 
            ViewBag.ThongkedoangThu = Thongkedoanhthu();
            ViewBag.Thongkekhachhang = thongkekhachhang();
            return View();
        }

        public string Tkdhh()
        {
            double dhd = _context.OrderDetails.Count();
            return dhd.ToString();
        }

        public string thongkekhachhang()
        {
            double skh = _context.Customers.Count();

            return skh.ToString();  
        }
        public string Thongkedoanhthu()
        {
            decimal tongdoanhthu = _context.OrderDetails.Sum(n => n.Amount * n.TotalMoney).Value;
            return tongdoanhthu.ToString();
        }
        public string Thongkedoanhthutheothang(int nam, int thang)
        {
            decimal ldhd = _context.OrderDetails.Where(n => n.CreateDate.Value.Month == thang && n.CreateDate.Value.Year == nam).Sum(n => n.Amount*n.TotalMoney).Value;

            return ldhd.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
