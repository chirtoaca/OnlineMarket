using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Interfaces
{
    public interface IOrderService
    {
        List<Order> GetOrders();

        Order AddOrder(Order order);
        void RemoveOrder(Order order);
        void EditOrder(Order order);

        Order GetOrder(int id);
    }
}
