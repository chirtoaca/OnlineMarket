using OnlineMarket.Core.Interfaces;
using OnlineMarket.DataModels.Models;
using OnlineMarket.Entities;
using OnlineMarket.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineMarket.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly ICustomerService _customerService;

        public CheckoutController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

       
        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {

            var customerVM = new CustomerOrderViewModel
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                District = customer.District,
                City = customer.City,
                Adress = customer.Adress,
                PhoneNumber = customer.PhoneNumber,
                Zip = customer.Zip
            };
            
            //TempData["customerVM"] = customerVM;
            return RedirectToAction("AddOrder", "Order", new RouteValueDictionary(customerVM));
        }
    }
}