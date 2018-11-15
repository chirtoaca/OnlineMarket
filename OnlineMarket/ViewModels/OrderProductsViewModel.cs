using OnlineMarket.DataModels.Models;
using System.Collections.Generic;
namespace OnlineMarket.ViewModels
{
    public class OrderProductsViewModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }
        
        public int Quantity { get; set; }
        
        public int PricePerUnit { get; set; }
        
    }
}