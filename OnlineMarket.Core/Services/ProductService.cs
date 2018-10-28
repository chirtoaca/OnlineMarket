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
        public List<Product> GetProducts()
        {
            var result = _repository.GetAll<Product>().ToList();
            return result;

        }
    }
}

