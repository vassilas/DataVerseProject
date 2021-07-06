using DataVerse.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataVerse.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerInterface _customerService;

        public CustomersController(ICustomerInterface customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            var allCustomers = _customerService.ReadCustomers_All();
            ViewData["Customers"] = allCustomers;
            return View();
        }

        public IActionResult Edit(int customer_id)
        {
            var customer = _customerService.ReadCustomers_All().Where(c => c.Id == customer_id).FirstOrDefault();
            ViewData["Customer"] = customer;
            return View(customer);
        }
    }
}
