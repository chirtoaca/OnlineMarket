using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.DataModels.Models
{
    public class Order
    {

        public int Id { get; set; }

        public int OrderTotal { get; set; }

        public Customer Customer { get; set; }

        public int CustomerId { get; set; }

        public List<OrderProduct> OrdersProducts { get; set; }
    }
}
