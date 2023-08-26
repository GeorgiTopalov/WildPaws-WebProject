using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildPaws.Infrastructure.Data
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(10)]
        public string? PhoneNumber { get; set; }

        [Required]
        public Guid AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address? Address { get; set; }
        public Guid? SubscriptionId { get; set; }

        [ForeignKey(nameof(SubscriptionId))]
        public Subscription? Subscription { get; set; }

        public ICollection<Pet>? Pets { get; set; }

    }
}