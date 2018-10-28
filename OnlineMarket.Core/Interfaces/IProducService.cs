using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Core.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();

    }
}
