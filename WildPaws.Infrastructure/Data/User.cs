using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildPaws.Infrastructure.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(AddressId))]
        public Address Address { get; set; }
        public int? AddressId { get; set; }
        public int PetId { get; set; }

        [ForeignKey(nameof(SubscriptionId))]
        public Subscription Subscription { get; set; }
        public int? SubscriptionId { get; set; }
    }
}
