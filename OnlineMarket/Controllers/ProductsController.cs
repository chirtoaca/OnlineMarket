using OnlineMarket.ViewModels;
using OnlineMarket.Core.Interfaces;
using OnlineMarket.Core.Services;
using OnlineMarket.DataModels.Models;
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
        private readonly ICategoryService _categorySerivice;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categorySerivice = categoryService;

        }
        // GET: Products
        public ActionResult Index()
        {

            var products = _productService.GetProducts();

            var productsShort = new List<ProductsShortViewModel>();
            foreach (var product in products)
            {
                var productVm = new ProductsShortViewModel
                {
                    Id=product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Category = product.Category,
                    Price = product.Price
                };

                productsShort.Add(productVm);
            }
            return View(productsShort);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = _categorySerivice.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {

            _productService.AddProduct(product);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var result = _productService.GetProduct(id);
            if (result != null)
            {
                _productService.DeleteProduct(result);
                return RedirectToAction("Index");
            }
            return HttpNotFound();
        }

        public ActionResult UpdateProduct(int id)
        {
            ViewBag.Categories = _categorySerivice.GetCategories();
            Product prodUpdate = _productService.GetProduct(id);

            if (prodUpdate == null)
            {
                HttpNotFound();
            }
            return View(prodUpdate);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult ProductDetails(int id)
        {
            var productDetails = _productService.GetProduct(id);
            if (productDetails == null)
            {
                return HttpNotFound();
            }
            else
                return View(productDetails);

        }   
    }
}