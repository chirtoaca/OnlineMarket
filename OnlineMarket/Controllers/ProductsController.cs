
using OnlineMarket.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }



        // GET: Products
        public ActionResult Index()
        {
            var products = _productService.GetProducts();

            return View(products);
        }
    }
}