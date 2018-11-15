using OnlineMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.ViewModels
{
    public class CartIndexViewModel
    {
        public ShoppingCartService Cart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
