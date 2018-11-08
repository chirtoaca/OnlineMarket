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
        public int PageSize = 4;

        public ProductsController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categorySerivice = categoryService;

        }
        // GET: Products
        public ActionResult Index(string category, int page = 1)
        {

            var products = _productService.GetProducts()
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize);
           

            var productsShort = new List<ProductsShortViewModel>();
            foreach (var product in products)
            {
                var productVm = new ProductsShortViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    CategoryId = product.CategoryId,
                    Category = product.Category,
                    Price = product.Price,
                    ImageData = product.ImageData,
                    ImageMimeTime = product.ImageMimeTime

                };
            
            productsShort.Add(productVm);
            }

            
            ProductsListViewModel productLVM = new ProductsListViewModel()
                {
                    PagingInfo = new PagingInfoViewModel
                    {
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = category == null ? 
                        _productService.GetProducts().Count() : 
                        _productService.GetProducts().Where( e => e.Category.Name == category ).Count()
                    },
                    CurrentCategory = category,
                    Products = productsShort

                };
            
            return View(productLVM);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Categories = _categorySerivice.GetCategories();
            return View();
        }

        [HttpPost]
        public ActionResult AddProduct(Product product, HttpPostedFileBase image = null)
        {
            if (image != null)
            {
                product.ImageMimeTime = image.ContentType;
                product.ImageData = new byte[image.ContentLength];
                image.InputStream.Read(product.ImageData, 0, image.ContentLength);
            }

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
        public ActionResult UpdateProduct(Product product, HttpPostedFileBase image = null)
        {
            var existingProduct = _productService.GetProductNoTracking(product.Id);

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    product.ImageMimeTime = image.ContentType;
                    product.ImageData = new byte[image.ContentLength];
                    image.InputStream.Read(product.ImageData, 0, image.ContentLength);
                }
                else if (image == null && existingProduct.ImageData != null)
                {
                    product.ImageData = existingProduct.ImageData;
                    product.ImageMimeTime = existingProduct.ImageMimeTime;
                }
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

        [HttpGet]
        public ActionResult SearchByName(string search)
        {
            var products = _productService.GetProducts().Where(p => p.Name.Contains(search));
            if (search == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var productsShort = new List<ProductsShortViewModel>();
                foreach (var product in products)
                {
                    var productVm = new ProductsShortViewModel
                    {
                        Id = product.Id,
                        Name = product.Name,
                        CategoryId = product.CategoryId,
                        Category = product.Category,
                        Price = product.Price,
                        ImageData = product.ImageData,
                        ImageMimeTime = product.ImageMimeTime
                    };

                    productsShort.Add(productVm);
                }
                return View(productsShort);
            }
        }

        public ActionResult GetImage(int id)
        {
            var product = _productService.GetProduct(id);

            if (product != null)
            {
                return File(product.ImageData, product.ImageMimeTime);
            }
            else
            {
                return null;
            }

        }
    }
}