using OnlineMarket.Core.Services;
using OnlineMarket.DataModels.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
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


        public ActionResult Index()
        {
            var categories = _categoryService.GetCategories();
            return View(categories);
        }
        [HttpGet]
        public ActionResult AddCategory ()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
                 _categoryService.AddCategory(category);
                return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int Id)
        {
            Category cat = _categoryService.GetCategory(Id);
            _categoryService.DeleteCategory(cat);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int Id = 0)
        {
            Category catUpdate = _categoryService.GetCategory(Id);

            if (catUpdate == null)
            {
                return HttpNotFound();
            }
            return View(catUpdate);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryService.UpdateCategory(category);
                return RedirectToAction("Index");

            }
            return View(category);
        }
    }
}