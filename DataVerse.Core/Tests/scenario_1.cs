using DataVerse.Database;
using DataVerse.Entities;
using DataVerse.Interfaces;
using DataVerse.Options;
using DataVerse.Services;
using System;
using System.Collections.Generic;

namespace DataVerse.Tests
{
    public static class scenario_1
    {
        public static bool execute()
        {
            Console.WriteLine("*** SCENARIO 1 - START ***");
            _test_delete_all_customers();
            _test_add_customers();
            Console.WriteLine("*** SCENARIO 1 - FINISH ***");
            return true;
        }

        public static bool _test_delete_all_customers()
        {
            Console.WriteLine("*** DELETE ALL CUSTOMERS ***");

            using DataVerseDbContext db = new();
            ICustomerInterface customerService = new CustomerService(db);
            List<CustomerOptions> customers = customerService.ReadCustomers_All();
            customers.ForEach(customer => {
                customerService.DeleteCustomer(customer.Id);
                Console.WriteLine($"    Customer Deleted : [{customer.FirstName} , {customer.LastName}]");
            });
            Console.WriteLine("*** EXECUTED ***");
            
            return true;
        }

        public static bool _test_add_customers()
        {
            Console.WriteLine("*** ADD 4 NEW CUSTOMERS ***");
            
            using DataVerseDbContext db = new();
            ICustomerInterface customerService = new CustomerService(db);

            List<CustomerOptions> test_customers = new()
            {
                new CustomerOptions
                {
                    FirstName = "Nikos",
                    LastName = "Papas",
                    Address = "Agias Efterphs 18, Nikea 12311",
                    Email = "nikpapas12@yahoo.gr"
                },
                new CustomerOptions
                {
                    FirstName = "George",
                    LastName = "Gerodogiannakhs",
                    Address = "Komninou 23-A, Glyfada 44311",
                    Email = "g.gerodogiannakhs@outlook.com"
                },
                new CustomerOptions
                {
                    FirstName = "Manos",
                    LastName = "Nikolopoulos",
                    Address = "Rodophs 4, Nea Ionia 20034",
                    Email = "ManosNikolopoulos@gmail.com"
                },
                new CustomerOptions
                {
                    FirstName = "Dimitris",
                    LastName = "Prokopakis",
                    Address = "Athinwn 33, Larisa 99200",
                    Email = "d.prokopakis@outlook.com"
                }

            };

            test_customers.ForEach(customer => {
                customerService.CreateCustomer(customer);
                Console.WriteLine($"    Customer created : [{customer.FirstName} , {customer.LastName}]");
            });
            Console.WriteLine("*** EXECUTED ***");

            return true;
        }
    }
}
