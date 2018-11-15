using OnlineMarket.DataModels.Models;
using System.Collections.Generic;

namespace OnlineMarket.ViewModels
{
    public class OrdersViewModel
    {
        public int Id { get; set; }

        public int OrderTotal { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public List<OrderProductsViewModel> OrdersProducts { get; set; }
    }
}