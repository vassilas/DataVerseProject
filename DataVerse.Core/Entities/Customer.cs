using System.ComponentModel.DataAnnotations;

namespace DataVerse.Entities
{
    public class Customer
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string FirtsName { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(50)]
        [Required]
        public string Address { get; set; }

        [MaxLength(30)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public virtual Phones Phones { get; set; }

    }
}
