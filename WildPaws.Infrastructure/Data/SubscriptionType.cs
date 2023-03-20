using System.ComponentModel.DataAnnotations;

namespace WildPaws.Infrastructure.Data
{
    public class SubscriptionType
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Type { get; set; }

        public int Discount { get; set; } = 0;

        [Required]
        public int DaysActive { get; set; }
    }
}