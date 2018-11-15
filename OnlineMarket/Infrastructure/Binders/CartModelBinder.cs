using OnlineMarket.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OnlineMarket.Infrastructure.Binders
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //get the Cart from the session
            ShoppingCartService cart = null;
            if (controllerContext.HttpContext.Session != null)
            {
                cart = (ShoppingCartService)controllerContext.HttpContext.Session[sessionKey];
            }

            //create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new ShoppingCartService();
                if (controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[sessionKey] = cart;
                }
            }
            //return the cart
            return cart;
        }
    }
}
