using System.ComponentModel.DataAnnotations;

namespace DataVerse.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string FirtsName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string Address { get; set; }

        [MaxLength(30)]
        public string Email { get; set; }

        public virtual Phones Phones { get; set; }

    }
}
