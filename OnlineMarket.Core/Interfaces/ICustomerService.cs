using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Interfaces
{
    public interface ICustomerService
    {
        List<Customer> GetCustomers();

        Customer AddCustomer(Customer customer);
        void RemoveCustomer(Customer customer);
        void EditCustomer(Customer customer);

        Customer GetCustomer(int id);
    }
}
