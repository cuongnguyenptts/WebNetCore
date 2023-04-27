using System;
using System.Collections.Generic;
using WebSellWatch.Models;

namespace WebSellWatch.ModelViews
{
    public class ProductHomeVM
    {   
        public Category category { get; set; }
        public List<Product> lsProducts { get; set; }
    }
}
