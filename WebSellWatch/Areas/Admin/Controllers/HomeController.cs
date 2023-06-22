using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using WebSellWatch.Models;

namespace WebSellWatch.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        private readonly dbWatchesContext _context;
        public INotyfService _notyfService { get; }
        public HomeController(dbWatchesContext context, INotyfService notyfService)
        {
            _context = context;
            _notyfService = notyfService;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            ViewBag.TongDoanhthu = Tongdoanhthu();
            ViewBag.ThongkeDH = ThongkeDH();
            ViewBag.ThongkeTV = ThongkeTV();
            return View();
        }

        public decimal Tongdoanhthu()
        {
            decimal TongDanhthu = _context.OrderDetails.Sum(n => n.TotalMoney*n.Amount).Value;
            return TongDanhthu;
        }
        public decimal ThongkeDH()
        {

            decimal ddH = _context.Orders.Count();
            return ddH;
        }
        public decimal ThongkeTV()
        {

            decimal slkh = _context.Customers.Count();
            return slkh;
        }


        public decimal Thongkedtdate(int thang, int nam)
        {
            decimal TongDanhthu = _context.OrderDetails.Where(x=>x.CreateDate.Value.Month==thang && x.CreateDate.Value.Year==nam).
                Sum(n => n.TotalMoney * n.Amount).Value;
            return TongDanhthu;
        }



    }
}
