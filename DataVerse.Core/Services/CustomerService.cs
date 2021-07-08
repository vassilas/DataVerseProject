using DataVerse.Entities;
using DataVerse.Interfaces;
using DataVerse.Options;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Services
{
    public class CustomerService : ICustomerInterface
    {
        private readonly IDataVerseDbContext _dbContext;
        private readonly IPhonesInterface _phonesService;

        public CustomerService(IDataVerseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public CustomerService(IDataVerseDbContext dbContext, IPhonesInterface phonesService)
        {
            _dbContext = dbContext;
            _phonesService = phonesService;
        }

        // CREATE
        // -------------------------------------------------------------
        public CustomerOptions CreateCustomer(CustomerOptions customerOptions)
        {
            Customer customer = new()
            {
                FirtsName = customerOptions.FirstName,
                LastName = customerOptions.LastName,
                Address = customerOptions.Address,
                Email = customerOptions.Email,
                Phones = customerOptions.Phones
                /* 
                 * TODO: Create phones also here.
                */
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return new CustomerOptions(customer);
        }

        public CustomerOptions CreateCustomer(CustomerOptions customerOptions, PhonesOptions phonesOptions)
        {
            Customer customer = new()
            {
                FirtsName = customerOptions.FirstName,
                LastName = customerOptions.LastName,
                Address = customerOptions.Address,
                Email = customerOptions.Email,
                Phones = new Phones
                {
                    PhoneHome = phonesOptions.PhoneHome,
                    PhoneWork = phonesOptions.PhoneWork,
                    PhoneMobile = phonesOptions.PhoneMobile
                }
            };

            _dbContext.Customers.Add(customer);
            _dbContext.SaveChanges();

            return new CustomerOptions(customer);
        }

        // READ/ALL
        // -------------------------------------------------------------
        public List<CustomerOptions> ReadCustomers_All()
        {
            //List<Customer> customers = _dbContext.Customers.ToList();
            List<Customer> customers = _dbContext.Customers.Include(x => x.Phones).ToList();
            List<CustomerOptions> customerOptions = new();
            customers.ForEach(customer => customerOptions.Add(new CustomerOptions(customer)));
            return customerOptions;
        }

        // READ/BY EMAIL
        // -------------------------------------------------------------
        public CustomerOptions ReadCustomer_ByEmail(string email)
        {
            Customer customer = _dbContext.Customers.Where(customer => customer.Email == email).FirstOrDefault();
            CustomerOptions customerOptions = new(customer);

            return customerOptions;
        }

        // UPDATE
        // -------------------------------------------------------------
        public CustomerOptions UpdateCustomer(CustomerOptions customerOptions, int customerId)
        {
            Customer customer = _dbContext.Customers.Find(customerId);
            if (customer == null) return null;

            customer.FirtsName = customerOptions.FirstName;
            customer.LastName = customerOptions.LastName;
            customer.Address = customerOptions.Address;
            customer.Email = customerOptions.Email;
            customer.Phones.PhoneHome = customerOptions.Phones.PhoneHome;
            customer.Phones.PhoneMobile = customerOptions.Phones.PhoneMobile;
            customer.Phones.PhoneWork = customerOptions.Phones.PhoneWork;

            _dbContext.SaveChanges();
            return new CustomerOptions(customer);
        }

        // DELETE
        // -------------------------------------------------------------
        public bool DeleteCustomer(int customerId)
        {
            Customer customer = _dbContext.Customers.Find(customerId);
            if (customer == null) return false;
            _dbContext.Customers.Remove(customer);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
