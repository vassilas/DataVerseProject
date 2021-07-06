using DataVerse.Database;
using DataVerse.Entities;
using DataVerse.Interfaces;
using DataVerse.Options;
using DataVerse.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Tests
{
    public static class scenario_2
    {
        public static bool execute()
        {
            Console.WriteLine("*** SCENARIO 2 - START ***");
            _test_delete_all_customers();
            _test_add_customers();
            Console.WriteLine("*** SCENARIO 2 - FINISH ***");
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
                    Email = "nikpapas12@yahoo.gr",
                    Phones = new Phones
                    {
                        PhoneHome = "2112155567",
                        PhoneMobile = "6959761132",

                    }
                },
                new CustomerOptions
                {
                    FirstName = "George",
                    LastName = "Gerodogiannakhs",
                    Address = "Komninou 23-A, Glyfada 44311",
                    Email = "g.gerodogiannakhs@outlook.com",
                    Phones = new Phones
                    {

                        PhoneWork = "2510334423"
                    }
                },
                new CustomerOptions
                {
                    FirstName = "Manos",
                    LastName = "Nikolopoulos",
                    Address = "Rodophs 4, Nea Ionia 20034",
                    Email = "ManosNikolopoulos@gmail.com",
                    Phones = new Phones
                    {
                        PhoneHome = "2112155567",
                        PhoneMobile = "6959761132",
                        PhoneWork = "2510334423"
                    }
                },
                new CustomerOptions
                {
                    FirstName = "Dimitris",
                    LastName = "Prokopakis",
                    Address = "Athinwn 33, Larisa 99200",
                    Email = "d.prokopakis@outlook.com",
                    Phones = new Phones
                    {
                        PhoneHome = "2112155567",
                        PhoneMobile = "6959761132",
                        PhoneWork = "2510334423"
                    }
                }

            };

            test_customers.ForEach(customer => {
                customerService.CreateCustomer(customer, new PhonesOptions(customer.Phones));
                Console.WriteLine($"    Customer created : [{customer.FirstName} , {customer.LastName}]");
            });
            Console.WriteLine("*** EXECUTED ***");

            return true;
        }
    }
}
