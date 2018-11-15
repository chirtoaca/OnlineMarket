using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.DataModels.DbContext 
{
    public class OnlineMarketDbContext : System.Data.Entity.DbContext
    {
        public OnlineMarketDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderProduct> OrderProducts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public static OnlineMarketDbContext Create()
        {
            return new OnlineMarketDbContext();
        }

    }
}
