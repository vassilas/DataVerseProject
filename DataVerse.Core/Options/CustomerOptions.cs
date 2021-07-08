using DataVerse.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Options
{
    public class CustomerOptions
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        [RegularExpression("^([a-zA-Z '])+$", ErrorMessage = "First name must be properly formatted.")]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        [RegularExpression("^([a-zA-Z '])+$", ErrorMessage = "Last name must be properly formatted.")]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Address { get; set; }

        [MaxLength(30)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
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
