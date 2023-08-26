using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WildPaws.Infrastructure.Data.Identity;

namespace WildPaws.Infrastructure.Data
{
    public class CustomerPet
    {
        [Required]
        public Guid CustomerId { get; set; } = Guid.NewGuid();

        [Required]
        public Guid PetId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual Customer Customerv { get; set; }

        [ForeignKey(nameof(PetId))]
        public virtual Pet Pet { get; set; }
    }
}
