using OnlineMarket.DataModels.Models;

namespace OnlineMarket.Entities
{
    public class CartLineItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
