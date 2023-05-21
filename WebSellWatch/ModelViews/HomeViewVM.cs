using System;
using System.Collections.Generic;
using WebSellWatch.Models;
namespace WebSellWatch.ModelViews
{
    public class HomeViewVM
    {
        public List<TinDang> TinTucs { get; set; }
        public List<ProductHomeVM> Products { get; set; }
        public List<Customer> customer { get; set; }
        public QuangCao quangcao { get; set; }
    }
}
