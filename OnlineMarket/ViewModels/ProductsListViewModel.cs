using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.ViewModels
{
    public class ProductsListViewModel
    {
        public List<Product> Products { get; set; }
        public string CurrentCategory { get; set; }
    }
}
