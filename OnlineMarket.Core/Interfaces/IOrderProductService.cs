using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Interfaces
{
    public interface IOrderProductService
    {
        List<OrderProduct> OrdersProducts();

        void AddOrderProducts(OrderProduct orderProducts);
        void RemoveOrderProducts(OrderProduct orderProducts);
        void EditOrderProducts(OrderProduct orderProducts);

        OrderProduct GetOrderProducts(int id);
    }
}
