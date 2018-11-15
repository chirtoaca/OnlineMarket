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
    public class OrderProductsService : IOrderProductService
    {
        private readonly IRepository _repository;

        public OrderProductsService(IRepository repository)
        {
            _repository = repository;
        }
        public void AddOrderProducts(OrderProduct orderProducts)
        {
            _repository.Add(orderProducts);
        }

        public void EditOrderProducts(OrderProduct orderProducts)
        {
            _repository.Update(orderProducts);
        }

        public OrderProduct GetOrderProducts(int id)
        {
            var result = _repository.GetAll<OrderProduct>().FirstOrDefault(o => o.OrderId == id);
            return result;
        }

        public List<OrderProduct> OrdersProducts()
        {
            var result = _repository.GetAll<OrderProduct>().ToList();
            return result;
        }

        public void RemoveOrderProducts(OrderProduct orderProducts)
        {
            _repository.Delete(orderProducts);
        }
    }
}
