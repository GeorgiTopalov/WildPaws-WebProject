using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WildPaws.Infrastructure.Data.Identity;

// Add profile data for application users by adding properties to the WildPawsUser class
public class WildPawsUser : IdentityUser
{
    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [StringLength(10)]
    public string? PhoneNumber { get; set; }

    public Guid? AddressId { get; set; }

    [ForeignKey(nameof(AddressId))]
    public Address? Address { get; set; }
    public Guid? SubscriptionId { get; set; }

    [ForeignKey(nameof(SubscriptionId))]
    public Subscription? Subscription { get; set; }

    public ICollection<Pet>? Pets { get; set; }

}

