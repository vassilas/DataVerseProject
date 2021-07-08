using DataVerse.Entities;
using System.ComponentModel.DataAnnotations;

namespace DataVerse.Options
{
    public class PhonesOptions
    {
        // PROPERTIES
        public int Id { set; get; }

        [MaxLength(15)]
        [Phone]
        public string PhoneHome { get; set; }

        [MaxLength(15)]
        [Phone]
        public string PhoneWork { get; set; }

        [MaxLength(15)]
        [Phone]
        public string PhoneMobile { get; set; }

        public Customer Customer { get; set; }


        // CONSTRUCTORS
        public PhonesOptions() { }

        public PhonesOptions(Phones phones)
        {
            Id = phones.Id;
            PhoneHome = phones.PhoneHome;
            PhoneWork = phones.PhoneWork;
            PhoneMobile = phones.PhoneMobile;
        }
    }


    
}
