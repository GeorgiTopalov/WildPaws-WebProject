using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildPaws.Infrastructure.Data
{
    public class Subscription
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [Column(TypeName ="decimal(18,4)")]
        public decimal Cost { get; set; }

        public IList<Recipe> Recipes { get; set; } = new List<Recipe>();

        [Required]
        public Guid PetId { get; set; }

        [ForeignKey(nameof(PetId))]
        public Pet Pet { get; set; }

        public Guid CustomerId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }

        public Guid SubscriptionTypeId { get; set; }

        [ForeignKey(nameof(SubscriptionTypeId))]
        public SubscriptionType Type { get; set; }

        [DataType("Date")]
        public DateTime StartDate { get; set; }

        [DataType("Date")]
        public DateTime? ExpiryDate { get; set; }

        [DataType("Date")]
        public DateTime? RenewalDate { get; set; }
        public bool IsActive { get; set; }
    }
}
