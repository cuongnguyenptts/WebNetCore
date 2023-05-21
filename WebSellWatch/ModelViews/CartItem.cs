using WebSellWatch.Models;

namespace WebSellWatch.ModelViews
{
    public class CartItem
    {
        public Product product { get; set; }

        public double amout { get; set; }
        public double TotalMoney => amout * product.Price.Value;

    }
}
