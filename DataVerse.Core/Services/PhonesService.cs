using DataVerse.Entities;
using DataVerse.Interfaces;
using DataVerse.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Services
{
    public class PhonesService : IPhonesInterface
    {
        private readonly IDataVerseDbContext _dbContext;
        private readonly ICustomerInterface _customerService;

        public PhonesService(IDataVerseDbContext dbContext, ICustomerInterface customerService)
        {
            _dbContext = dbContext;
            _customerService = customerService;
        }

        // CREATE
        // -------------------------------------------------------------
        public PhonesOptions CreatePhones(PhonesOptions phonesOptions)
        {
            //var customer = _dbContext.Customers.Where(c => c.Id == customerOptions.Id).FirstOrDefault();
            Phones phones = new()
            {

                PhoneHome = phonesOptions.PhoneHome,
                PhoneWork = phonesOptions.PhoneWork,
                PhoneMobile = phonesOptions.PhoneMobile,
                Customer = phonesOptions.Customer
            };

            _dbContext.Phones.Add(phones);
            _dbContext.SaveChanges();

            return new PhonesOptions(phones);
        }

        // READ/ALL
        // -------------------------------------------------------------
        public List<PhonesOptions> ReadPhones_All()
        {
            List<Phones> phones = _dbContext.Phones.ToList();
            List<PhonesOptions> phonesOptions = new();
            phones.ForEach(phone => phonesOptions.Add(new PhonesOptions(phone)));
            return phonesOptions;
        }
        // READ/BY CUSTOMER ID
        // -------------------------------------------------------------
        public PhonesOptions ReadPhones_ByCustomerId(int customerId)
        {
            Phones phones = _dbContext.Phones.Where(phone => phone.Customer.Id == customerId).FirstOrDefault();
            PhonesOptions phonesOptions = new(phones);
            return phonesOptions;
        }

        // UPDATE
        // -------------------------------------------------------------
        public PhonesOptions UpdatePhones(PhonesOptions phonesOptions,int phonesId)
        {
            Phones phones = _dbContext.Phones.Find(phonesId);
            if (phones == null) return null;

            phones.PhoneHome = phonesOptions.PhoneHome;
            phones.PhoneWork = phonesOptions.PhoneWork;
            phones.PhoneMobile = phonesOptions.PhoneMobile;

            _dbContext.SaveChanges();
            return new PhonesOptions(phones);
        }
        // UPDATE/BY CUSTOMER ID
        // -------------------------------------------------------------
        public PhonesOptions UpdatePhones_ByCustomerId(PhonesOptions phonesOptions, int customerId)
        {
            Phones phones = _dbContext.Phones.Where(phone => phone.Customer.Id== customerId).FirstOrDefault();
            if (phones == null) return null;

            phones.PhoneHome = phonesOptions.PhoneHome;
            phones.PhoneWork = phonesOptions.PhoneWork;
            phones.PhoneMobile = phonesOptions.PhoneMobile;

            _dbContext.SaveChanges();
            return new PhonesOptions(phones);
        }

        // DELETE
        // -------------------------------------------------------------
        public bool DeletePhones(int phonesId)
        {
            Phones phones = _dbContext.Phones.Find(phonesId);
            if (phones == null) return false;
            _dbContext.Phones.Remove(phones);
            _dbContext.SaveChanges();
            return true;
        }
        // DELETE/BY CUSTOMER ID
        // -------------------------------------------------------------
        public bool DeletePhones_ByCustomerId(int customerId)
        {
            Phones phones = _dbContext.Phones.Where(phone => phone.Customer.Id == customerId).FirstOrDefault();
            if (phones == null) return false;
            _dbContext.Phones.Remove(phones);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
