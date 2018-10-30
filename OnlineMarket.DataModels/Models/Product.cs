using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.DataModels.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        public int QuantityInStock { get; set; }

        [Required]
        public int Price { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }
    }
}
