using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.ViewModels
{
    public class ProductsShortViewModel
    {
        
        public int Id { get; set; }

      
        public string Name { get; set; }

        public virtual Category Category { get; set; }

       
        public int CategoryId { get; set; }

        public int Price { get; set; }
    }
}
