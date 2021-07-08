using DataVerse.Interfaces;
using DataVerse.Options;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,FirstName,LastName,Address,Email,Phones")] CustomerOptions customerOptions)
        {
            _customerService.UpdateCustomer(customerOptions, customerOptions.Id);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int customer_id)
        {
            var res = _customerService.DeleteCustomer(customer_id);
            return RedirectToAction("Index");

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,Address,Email,Phones")] CustomerOptions customerOptions)
        {
            _customerService.CreateCustomer(customerOptions);

            return RedirectToAction("Index");
        }

    }
}
