using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataVerse.Entities
{
    public class Phones
    {
        [ForeignKey("Customer")]
        public int Id { set; get; }
        
        [MaxLength(15)]
        public string PhoneHome { get; set; }

        [MaxLength(15)]
        public string PhoneWork { get; set; }

        [MaxLength(15)]
        public string PhoneMobile { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
