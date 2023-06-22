using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSellWatch.Models;

namespace WebSellWatch.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {

        private readonly dbWatchesContext _context;
        public HomeController(dbWatchesContext context, INotyfService notyfService)
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
        public double Tkdhh()
        {
            double dhd = _context.OrderDetails.Count();
            return dhd;
        }

        public decimal thongkekhachhang()
        {
            decimal skh = _context.Customers.Count();

            return skh;
        }
        public double Thongkedoanhthu()
        {
            double tongdoanhthu = _context.OrderDetails.Sum(n => n.Amount * n.TotalMoney).Value;
            return tongdoanhthu;
        }
        public string Thongkedoanhthutheothang(int nam, int thang)
        {
            decimal ldhd = _context.OrderDetails.Where(n => n.CreateDate.Value.Month == thang && n.CreateDate.Value.Year == nam).Sum(n => n.Amount * n.TotalMoney).Value;

            return ldhd.ToString();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
