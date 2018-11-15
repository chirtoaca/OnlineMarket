using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Entities
{
    public class ShoppingCartService
    {
        private List<CartLineItem> lineItemsList = new List<CartLineItem>();
        
        
        public void AddItem(Product product, int quantity)
        {
            CartLineItem line = lineItemsList.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            if (line == null)
            {
                lineItemsList.Add(new CartLineItem { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            lineItemsList.RemoveAll(l => l.Product.Id == product.Id);
        }

        public decimal ComputeTotalValue()
        {
            return lineItemsList.Sum(e => e.Product.Price * e.Quantity);
        }

        public void Clear()
        {
            lineItemsList.Clear();
        }

        public IEnumerable<CartLineItem> GetCartLineItems
        {

            get { return lineItemsList; }
        }

        
    }
}
