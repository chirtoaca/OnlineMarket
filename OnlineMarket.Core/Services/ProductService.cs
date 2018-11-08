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
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(Product product)
        {

            _repository.Add(product);
        }

        public void DeleteProduct(Product product)
        {
            _repository.Delete(product);
        }

        public Product GetProduct(int id)
        {
            var result = _repository.GetAll<Product>().FirstOrDefault(p => p.Id == id);
            return result;
        }

        public Product GetProductNoTracking(int id)
        {
            var result = _repository.GetAllAsNoTracking<Product>().FirstOrDefault(p => p.Id == id);
            return result;
        }


        public List<Product> GetProducts()
        {
            var result = _repository.GetAll<Product>().ToList();
            return result;

        }

        public void UpdateProduct(Product product)
        {
            _repository.Update(product);
        }
    }
}

