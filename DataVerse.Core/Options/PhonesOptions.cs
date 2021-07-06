using DataVerse.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataVerse.Options
{
    public class PhonesOptions
    {
        // PROPERTIES
        public int Id { set; get; }
        public string PhoneHome { get; set; }
        public string PhoneWork { get; set; }
        public string PhoneMobile { get; set; }
        public int CustomerRef { get; set; }
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
