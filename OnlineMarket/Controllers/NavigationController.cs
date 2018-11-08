using OnlineMarket.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Controllers
{
    public class NavigationController : Controller
    {
        private readonly IProductService _productService;

        public NavigationController(IProductService productService)
        {
            _productService = productService;
        }

        public PartialViewResult Menu(string category)
        {
            ViewBag.SelectedCategory = category;
            var categories = _productService.GetProducts().Select(x => x.Category.Name).Distinct().OrderBy(x => x);

             return PartialView(categories);
        }
    }
}