using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.ViewModels
{
    public class CustomerOrderViewModel
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        
        public string LastName { get; set; }
        
        public string City { get; set; }
        
        public string District { get; set; }
        
        public string Adress { get; set; }
        
        public string Zip { get; set; }
        
        public int PhoneNumber { get; set; }

        public List<OrdersViewModel> Orders { get; set; }
    }
}
