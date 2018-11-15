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
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderProductService _orderProductService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, IOrderProductService orderProductService, ICustomerService customerService)
        {
            _orderService = orderService;
            _orderProductService = orderProductService;
            _customerService = customerService;
        }
        // GET: Order
        public ActionResult Index()
        {
            var customerLVM = new List<CustomerOrderViewModel>();
            
            var getCustomers = _customerService.GetCustomers();
            foreach(var customers in getCustomers)
            {
                var getOrders = _orderService.GetOrders().Where(o => o.CustomerId == customers.Id);
                var orderLVM = new List<OrdersViewModel>();
                foreach (var orders in getOrders)
                {
                    var getProducts = _orderProductService.OrdersProducts().Where(p => p.OrderId == orders.Id);
                    var productsLVM = new List<OrderProductsViewModel>();
                    foreach (var products in getProducts)
                    {
                        var resultProducts = new OrderProductsViewModel
                        {
                            ProductId = products.ProductId,
                            PricePerUnit = products.PricePerUnit,
                            Quantity = products.Quantity,
                            OrderId = products.OrderId
                        };
                        productsLVM.Add(resultProducts);
                        
                    }

                    var resultOrders = new OrdersViewModel
                    {
                        Id = orders.Id,
                        OrderTotal = orders.OrderTotal,
                        CustomerId = orders.CustomerId,
                        OrdersProducts = productsLVM
                    };
                    orderLVM.Add(resultOrders);

                    //var orderVM = new OrdersViewModel
                    //{
                    //    Id = orders.Id,
                    //    OrderTotal = orders.OrderTotal,
                    //    CustomerId = orders.CustomerId,
                    //    OrdersProducts = productsLVM
                    //};
                }
                var resultCustomers = new CustomerOrderViewModel
                {
                    FirstName = customers.FirstName,
                    LastName = customers.LastName,
                    District = customers.District,
                    City = customers.City,
                    Adress = customers.Adress,
                    PhoneNumber = customers.PhoneNumber,
                    Zip = customers.Zip,
                    Orders = orderLVM
                };
                customerLVM.Add(resultCustomers);

                //var customerVM = new CustomerOrderViewModel
                //{
                //    Orders = orderLVM
                //};
            }
            var customerTVM = new CustomerListViewModel
            {
                CustomerOrders = customerLVM
            };
            return View(customerTVM);
        }


        [HttpGet]
        public ActionResult AddOrder(ShoppingCartService cart, CustomerOrderViewModel customerVM)
        {
           
            var orderLVM = new List<OrdersViewModel>();
            var productLVM = new List<OrderProductsViewModel>();

            foreach(var products in cart.GetCartLineItems)
            {
                var productVM = new OrderProductsViewModel
                {
                    ProductId = products.Product.Id,
                    PricePerUnit = products.Product.Price,
                    Quantity = products.Quantity
                };
                productLVM.Add(productVM);
            }

            var order = new OrdersViewModel
            {
                OrdersProducts = productLVM
            };
            orderLVM.Add(order);
            var customer = new CustomerOrderViewModel
            {
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,
                District = customerVM.District,
                Adress = customerVM.Adress,
                City = customerVM.City,
                PhoneNumber = customerVM.PhoneNumber,
                Zip = customerVM.Zip,
                Orders = orderLVM
            };
            return View(customer);
        }

        [HttpPost]
        public ActionResult AddOrder( Order order, OrderProduct orderProduct, ShoppingCartService cart, CustomerOrderViewModel customerVM)
        {
            int totalPrice = 0;
            var customerModel = new Customer
            {
                Id = customerVM.Id,
                FirstName = customerVM.FirstName,
                LastName = customerVM.LastName,
                District = customerVM.District,
                City = customerVM.City,
                Adress = customerVM.Adress,
                PhoneNumber = customerVM.PhoneNumber,
                Zip = customerVM.Zip
            };

            var addCustomer = _customerService.AddCustomer(customerModel);

            order.CustomerId = addCustomer.Id;
            var addOrder = _orderService.AddOrder(order);

            foreach (var products in cart.GetCartLineItems)
            {
                var addOrderProduct = new OrderProduct
                {
                    ProductId = products.Product.Id,
                    PricePerUnit = products.Product.Price,
                    Quantity = products.Quantity,
                    OrderId = addOrder.Id
                };
                _orderProductService.AddOrderProducts(addOrderProduct);
                totalPrice = totalPrice + (addOrderProduct.PricePerUnit * addOrderProduct.Quantity);
            }

            addOrder.OrderTotal = totalPrice;

            _orderService.EditOrder(addOrder);

            return View("Index", "Home");
        }

    }
}