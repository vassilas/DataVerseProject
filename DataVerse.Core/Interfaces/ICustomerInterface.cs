using DataVerse.Options;
using System.Collections.Generic;

namespace DataVerse.Interfaces
{
    public interface ICustomerInterface
    {
        public CustomerOptions CreateCustomer(CustomerOptions customerOptions);
        public CustomerOptions CreateCustomer(CustomerOptions customerOptions, PhonesOptions phonesOptions);
        public List<CustomerOptions> ReadCustomers_All();
        public CustomerOptions UpdateCustomer(CustomerOptions customerOptions, int customerId);
        public bool DeleteCustomer(int customerId);
    }
}
