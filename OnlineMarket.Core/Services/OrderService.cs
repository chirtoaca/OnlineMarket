using OnlineMarket.Core.Interfaces;
using OnlineMarket.DataModels.Models;
using OnlineMarket.DataModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository _repository;

        public OrderService(IRepository repository)
        {
            _repository = repository;
        }
        public Order AddOrder(Order order)
        {
            var addedOrder = _repository.Add(order);
            return addedOrder;
        }

        public void EditOrder(Order order)
        {
            _repository.Update(order);
        }

        public Order GetOrder(int id)
        {
            var result = _repository.GetAll<Order>().FirstOrDefault(o => o.Id == id);
            return result;
        }

        public List<Order> GetOrders()
        {
            var result = _repository.GetAll<Order>().ToList();
            return result;
        }

        public void RemoveOrder(Order order)
        {
            _repository.Delete(order);
        }
    }
}
