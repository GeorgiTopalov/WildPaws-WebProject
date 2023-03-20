using System.ComponentModel.DataAnnotations;

namespace WildPaws.Infrastructure.Data
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(75)]
        public string Street { get; set; }

        [Required]
        [StringLength(75)]
        public string City { get; set; }

        [StringLength(75)]
        public string? Province { get; set; }

        [Required]
        [StringLength(10)]
        public string PostalCode { get; set; }
    }
}