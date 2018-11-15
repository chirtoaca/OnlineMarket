using OnlineMarket.Core.Interfaces;
using OnlineMarket.DataModels.Models;
using OnlineMarket.Entities;
using OnlineMarket.ViewModels;
using System.Web.Mvc;

namespace OnlineMarket.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductService _productService;

        public CartController(IProductService productService)
        {
            _productService = productService;
        }

        
        public ViewResult Index(ShoppingCartService cart, string returnUrl)
        {
            return View(new CartIndexViewModel { ReturnUrl = returnUrl, Cart = cart });
        }

        public RedirectToRouteResult AddToCart(ShoppingCartService cart,int id, string returnUrl)
        {
            Product product = _productService.GetProduct(id);

            if (product != null)
            {
                cart.AddItem(product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart (ShoppingCartService cart, int id, string returnUrl)
        {
            Product product = _productService.GetProduct(id);

            if (product != null)
            {
                cart.RemoveLine(product);
            }

            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(ShoppingCartService cart)
        {
            return PartialView(cart);
        }

        private ShoppingCartService GetCart()
        {
            ShoppingCartService cart = (ShoppingCartService)Session["Cart"];
            if (cart == null)
            {
                cart = new ShoppingCartService();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}