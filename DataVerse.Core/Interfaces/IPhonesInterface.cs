using DataVerse.Options;
using System.Collections.Generic;

namespace DataVerse.Interfaces
{
    public interface IPhonesInterface
    {
        public PhonesOptions CreatePhones(PhonesOptions phonesOptions);
        public List<PhonesOptions> ReadPhones_All();
        public PhonesOptions ReadPhones_ByCustomerId(int customerId);
        public PhonesOptions UpdatePhones(PhonesOptions phonesOptions, int phonesId);
        public PhonesOptions UpdatePhones_ByCustomerId(PhonesOptions phonesOptions, int customerId);
        public bool DeletePhones(int phonesId);
        public bool DeletePhones_ByCustomerId(int customerId);
    }
}
