using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.DataModels.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }

        public Order Order { get; set; }

        [Required]
        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public int PricePerUnit { get; set; }

        public int TotalPrice { get { return (int)Math.Ceiling((decimal)Quantity * PricePerUnit); } }
    }
}
