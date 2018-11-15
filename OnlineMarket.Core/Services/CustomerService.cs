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
    public class CustomerService : ICustomerService
    {
        private readonly IRepository _repository;

        public CustomerService(IRepository repository)
        {
            _repository = repository;
        }

        public Customer AddCustomer(Customer customer)
        {
            var addedCustomer = _repository.Add(customer);
            return addedCustomer;
        }

        public void EditCustomer(Customer customer)
        {
            _repository.Update(customer);
        }

        public Customer GetCustomer(int id)
        {
            var result = _repository.GetAll<Customer>().FirstOrDefault(o => o.Id == id);
            return result;
        }

        public List<Customer> GetCustomers()
        {
            var result = _repository.GetAll<Customer>().ToList();
            return result;
        }

        public void RemoveCustomer(Customer customer)
        {
            _repository.Delete(customer);
        }
    }
}
