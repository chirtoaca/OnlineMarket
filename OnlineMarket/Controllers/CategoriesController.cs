using OnlineMarket.Core.Services;
using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineMarket.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: Categories
        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }

        public ActionResult AddCategory(Category category)
        {
                 _categoryService.AddCategory(category);
                return RedirectToAction("Index");
        }
    }
}