using DataVerse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Options
{
    public class CustomerOptions
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public Phones Phones { get; set; }

        public CustomerOptions() { }
        public CustomerOptions(Customer customer) 
        {
            Id = customer.Id;
            FirstName = customer.FirtsName;
            LastName = customer.LastName;
            Address = customer.Address;
            Email = customer.Email;
            Phones = customer.Phones;
        }
    }
}
